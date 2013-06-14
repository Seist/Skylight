namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using PlayerIOClient;

    public class Bot : Player
    {
        private bool
            isConnected;
        
        private Client client;

        // In milliseconds.
        private int 
            blockDelay  = 50, 
            speechDelay = 50;

        private readonly string
            emailOrToken,
            passwordOrToken;

        private readonly AccountType accType;

        private Connection connection;

        private Out push = new Out();

        private Room r = new Room(null);

        /// <param name="password">Make this field null if it isn't needed for your log-in method.</param>
        public Bot(Room r,
                   string emailOrToken = Tools.GuestEmail,
                   string passwordOrToken = Tools.GuestPassword,
                   AccountType accType = AccountType.Regular)
        {
            this.emailOrToken = emailOrToken;
            this.passwordOrToken = passwordOrToken;
            this.R = r;
            this.accType = accType;
        }

        public bool IsConnected
        {
            get
            {
                return this.isConnected;
            }

            internal set
            {
                this.isConnected = value;
            }
        }
        
        public Client Client
        {
            get
            {
                return this.client;
            }

            internal set
            {
                this.client = value;
            }
        }
        
        public int BlockDelay
        {
            get
            {
                return this.blockDelay;
            }

            set
            {
                this.blockDelay = value;
            }
        }
        
        public int SpeechDelay
        {
            get
            {
                return this.speechDelay;
            }

            set
            {
                this.speechDelay = value;
            }
        }

        public Out Push
        {
            get
            {
                return this.push;
            }

            internal set
            {
                this.push = value;
            }
        }

        public Room R
        {
            get;

            internal set;
        }
       
        public Connection Connection
        {
            get
            {
                return this.connection;
            }

            internal set
            {
                this.connection = value;
            }
        }

        // Public methods
        public void LogIn()
        {
            try
            {
                switch (this.accType)
                {
                    case AccountType.Regular:
                        if (this.emailOrToken == Tools.GuestEmail && this.passwordOrToken == Tools.GuestPassword)
                            this.Client = Tools.GuestClient.Value;
                        else
                            this.Client = PlayerIO.QuickConnect.SimpleConnect(Tools.GameID, this.emailOrToken, this.passwordOrToken);
                        break;

                    case AccountType.Facebook:
                        this.Client = PlayerIO.QuickConnect.FacebookOAuthConnect(Tools.GameID, this.emailOrToken, null);
                        break;

                    case AccountType.Kongregate:
                        this.Client = PlayerIO.QuickConnect.KongregateConnect(Tools.GameID, this.emailOrToken, this.passwordOrToken);
                        break;

                    default: //case AccountType.ArmorGames:
                        var c = Tools.GuestClient.Value.Multiplayer.CreateJoinRoom("",
                                                                                   Tools.AuthRoom + Tools.GetGameVersion(),
                                                                                   false, null, null);
                        c.OnMessage += (sender, message) =>
                            {
                                if (message.Type != "auth") return;

                                if (message.Count == 0)
                                    Tools.SkylightMessage("Cannot log in using ArmorGames. The response from the auth server is wrong.");
                                else
                                {
                                    this.Client = PlayerIOClient.PlayerIO.Connect(Tools.GameID, "secure", 
                                                                                  message.GetString(0), message.GetString(1), 
                                                                                  "armorgames");
                                    Tools.SkylightMessage("Logged in.");
                                }

                                c.Disconnect();
                            };

                        c.Send("auth", this.emailOrToken, this.passwordOrToken);
                        break;
                }

                if (this.accType != AccountType.ArmorGames)
                    Tools.SkylightMessage("Logged in.");
            }
            catch (PlayerIOError e)
            {
                Tools.SkylightMessage("Cannot log in: " + e.Message);
                this.IsConnected = false;
                return;
            }

            this.IsConnected = true;
        }

        public void Join()
        {
            if (!this.IsConnected)
            {
                // Log in
                this.LogIn();

                // If you didn't connect, it must have failed.
                if (!this.IsConnected)
                {
                    return;
                }
            }
            
            // Parse the level ID (because some people like to put full URLs in).
            this.R.Id = Tools.ParseURL(this.R.Id);

            try
            {
                // Join room
                this.Connection = this.Client.Multiplayer.JoinRoom(this.R.Id, new Dictionary<string, string>());

                // Update room data
                Room.JoinedRooms.Add(this.R);
            
                // Everyone gets a connection.
                this.R.Connections.Add(this.Connection);

                // Every bot receives info from the room, because some of it is exclusive to the bot.
                // We call those "personal" pulls.
                // They are exactly the same as the main pull, except In.IsPersonal = true.
                In i = new In();
                i.IsPersonal = true;
                i.Source = this.R;
                i.Bot = this;
                this.Connection.OnMessage += i.OnMessage;
                this.R.Pulls.Add(i);

                // However, everything else only needs one bot to handle. Things like chat and movement.
                // We don't need five bots firing an event every time someone chats.
                if (!this.R.HasPull)
                {
                    this.R.HasPull = true;

                    this.R.Receiver = this;

                    this.Connection.OnMessage += this.R.Pull.OnMessage;
                    this.R.Pull.IsPersonal = false;
                    this.R.Pull.Bot = this;
                    this.R.Pull.Source = this.R;
                }

                // Once everything is internal settled, send the init.
                this.Connection.Send("init");
                this.Connection.Send("init2");

                this.R.OnlinePlayers.Add(this);
                
                Tools.SkylightMessage("Joined room.");
            }
            catch (Exception e)
            {
                Tools.SkylightMessage("Unable to join room \"" + this.R.Id + "\": " + e.Message);

                return;
            }
        }

        public void Disconnect()
        {
            // Basically undo everything you already did.
            this.Connection.Disconnect();

            this.Client = null;
            this.Connection = null;
            this.Push = null;
            this.IsConnected = false;
        }

        public enum AccountType : sbyte
        {
            Regular = 0, 
            Facebook = 1, 
            Kongregate = 2, 
            ArmorGames = 3
        }
    }
}
