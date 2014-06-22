namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using PlayerIOClient;

    public partial class Bot : Player
    {
        private bool
            isConnected,
            joined;

        private Client client;

        // In milliseconds.
        private int 
            blockDelay  = 10, 
            speechDelay = 1000;

        private string chatPrefix = "";

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
                   AccountType accType = AccountType.Regular) : base (r, 0, "", 0, 0.0, 0.0, false, false, true, 0, false, false, 0)
        {
            this.emailOrToken = emailOrToken;
            this.passwordOrToken = passwordOrToken;
            this.R = r;
            this.accType = accType;
            this.ShouldTick = true;
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

        public bool Joined
        {
            get
            {
                return this.joined;
            }
            internal set
            {
                this.joined = value;
            }
        }

        public bool ShouldTick
        {
            get;
            set;
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

        public string ChatPrefix
        {
            get
            {
                return this.chatPrefix;
            }

            set
            {
                this.chatPrefix = value;
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
                        var c = Tools.GuestClient.Value.Multiplayer.JoinRoom("", null);
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
                                }

                                c.Disconnect();
                            };

                        c.Send("auth", this.emailOrToken, this.passwordOrToken);
                        break;
                }
            }
            catch (PlayerIOError e)
            {
                Tools.SkylightMessage("Cannot log in: " + e.Message);
                this.IsConnected = false;
                return;
            }

            this.IsConnected = true;
        }

        public void Join(bool createRoom = true)
        {
            // Update the game version.
            Refresh();

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
                if (createRoom)
                {
                    // Join room
                    this.Connection = this.Client.Multiplayer.CreateJoinRoom(
                        this.R.Id,                         // RoomId   (URL)
                        storedVersion,               // RoomType (Server)
                        true,                              // Visible
                        new Dictionary<string, string>(),  // RoomData
                        new Dictionary<string, string>()); // JoinData
                }
                else
                {
                    this.Connection = this.Client.Multiplayer.JoinRoom(
                        this.R.Id,
                        new Dictionary<string, string>());
                }
                // Update room data
                Room.JoinedRooms.Add(this.R);
            
                // Everyone gets a connection.
                this.R.Connections.Add(this.Connection);

                // The following 25 lines deal with filtering messages from the client.
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

                this.Joined = true;

                while (!this.R.BlocksLoaded) { }
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
            this.Joined = false;
        }

        private static string storedVersion;

        private string Version(bool cached = true, string prefix = Tools.NormalRoom)
        {
            if (!cached || storedVersion == null)
                return prefix + Refresh();

            return prefix + storedVersion;
        }

        private string Refresh()
        {
            storedVersion = Convert.ToString(this.Client.BigDB.Load("config", "config")["version"]);
            return storedVersion;
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
