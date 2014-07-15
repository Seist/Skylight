namespace Skylight
{
    using PlayerIOClient;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Rabbit;
    public partial class Bot : Player
    {
        private bool
            isConnected,
            joined;

        private Client client;
        private Client vers_Client;

        // In milliseconds.
        private int
            blockDelay = 10,
            speechDelay = 1000;

        private string chatPrefix = "";

        private readonly string
            emailOrToken,
            passwordOrToken;

        private readonly AccountType accType;

        public static Room currentRoom { get; internal set; }

        private Connection connection = null;

        private Out push = new Out();

        

        /// <param name="password">Make this field null if it isn't needed for your log-in method.</param>
        public Bot(Room r,
                   string emailOrToken = Utilities.GuestEmail,
                   string passwordOrToken = Utilities.GuestPassword,
                   AccountType accType = AccountType.Regular)
            : base(r, 0, "", 0, 0.0, 0.0, false, false, true, 0, false, false, 0)
        {
            this.emailOrToken = emailOrToken;
            this.passwordOrToken = passwordOrToken;
            Bot.currentRoom = r;
            this.accType = accType;
        }

        public bool IsConnected { get; internal set; }

        public bool Joined { get; internal set; }

<<<<<<< HEAD
        public bool ShouldTick { get; set; }

        public Client Client { get; internal set; }

        public string gameVersion { get; internal set; }
=======
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
        
        public Client Client
        {
            get
            {
                return this.client;
            }
>>>>>>> parent of d8a8469... Fixed BID:0 layering bug; fixed ticking defaults

        public int BlockDelay
        {
            get { return this.BlockDelay; }

            set
            {
                if (this.blockDelay > 0)
                {
                    this.blockDelay = value;
                }
            }
        }

        public int SpeechDelay
        {
            get { return this.SpeechDelay; }

            set
            {
                if (this.speechDelay > 0)
                {
                    this.speechDelay = value;
                }
            }
        }

        public string ChatPrefix { get; set; }

        public Out Push { get; internal set; }



        static public In i = new In();

        public Connection Connection { get; internal set; }

        

        private void updateGameVersion()
        {
            // For now because this was throwing a NullReferenceException and I'll have to debug it later.
            string unparsedGameVersion =  new System.Net.WebClient().DownloadString("http://capasha.com/bots/version.txt");
            this.gameVersion = unparsedGameVersion;
        }



        public void Join(bool createRoom = true)
        {

            // Parse the level ID (because some people like to put full URLs in).
            Bot.currentRoom.Id = Utilities.ParseURL(Bot.currentRoom.Id);
            Bot.currentRoom = new Room(Bot.currentRoom.Id);

            try
            {
<<<<<<< HEAD
                // leave passwordOrToken as null (prefered) or empty string if non-applicable.
                this.Connection = new Rabbit.Auth().LogIn(this.emailOrToken, this.passwordOrToken, Bot.currentRoom.Id, createRoom);
                updateGameVersion();
=======
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
                                    Tools.SkylightMessage("Logged in.");
                                }

                                c.Disconnect();
                            };

                        c.Send("auth", this.emailOrToken, this.passwordOrToken);
                        break;
                }

                if (this.accType != AccountType.ArmorGames)
                    Tools.SkylightMessage("Logged in.");
>>>>>>> parent of d8a8469... Fixed BID:0 layering bug; fixed ticking defaults
            }
            catch (PlayerIOError e)
            {
                Logging.SkylightMessage("Cannot log in: " + e.Message);
                this.IsConnected = false;
                return;
            }

            /*
            Room.JoinedRooms.Add(
                Bot.currentRoom
                );*/
            


            // Everyone gets a connection.
            // This throws another NullReferenceException though.
            Bot.currentRoom.Connections.Add(this.Connection);

            // The following section deals with filtering messages from the client.
            // Every bot receives info from the room, because some of it is exclusive to the bot.
            // We call those "personal" pulls.
            // They are exactly the same as the main pull, except In.IsPersonal = true.

            i.IsPersonal = true;
            i.Source = Bot.currentRoom;
            i.Bot = this;
            this.Connection.OnMessage += i.OnMessage;
            Bot.currentRoom.Pulls.Add(i);

            // However, everything else only needs one bot to handle. Things like chat and movement.
            // We don't need five bots firing an event every time someone chats.
            // except when they are located in different rooms, which would be an exception.
            if (!Bot.currentRoom.HasPull)
            {
<<<<<<< HEAD
                if (createRoom)
                {
                    // Join room
                    this.Connection = this.Client.Multiplayer.CreateJoinRoom(
                        this.R.Id,                         // RoomId   (URL)
                        storedVersion,                     // RoomType (Server)
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
=======
                Bot.currentRoom.HasPull = true;
>>>>>>> origin/master

                Bot.currentRoom.Receiver = this;

                this.Connection.OnMessage += Bot.currentRoom.Pull.OnMessage;
                Bot.currentRoom.Pull.IsPersonal = false;
                Bot.currentRoom.Pull.Bot = this;
                Bot.currentRoom.Pull.Source = Bot.currentRoom;
            }

<<<<<<< HEAD
            // Once everything is internal settled, send the inits.
            this.Connection.Send("init");
            this.Connection.Send("init2");
=======
                // Once everything is internal settled, send the init.
                this.Connection.Send("init2");
                this.Connection.Send("init");
>>>>>>> parent of d8a8469... Fixed BID:0 layering bug; fixed ticking defaults

            // this.connection is null so... hmm...?
            Bot.currentRoom.OnlinePlayers.Add(this);

            this.Joined = true;

<<<<<<< HEAD
<<<<<<< HEAD
                while (!this.R.BlocksLoaded) { Thread.Sleep(100); }
=======
                while (!this.R.BlocksLoaded) { }

                Tools.SkylightMessage("Joined room.");
>>>>>>> parent of d8a8469... Fixed BID:0 layering bug; fixed ticking defaults
            }
            catch (Exception e)
=======
            while (!Bot.currentRoom.BlocksLoaded)
>>>>>>> origin/master
            {
                Thread.Sleep(50); //http://stackoverflow.com/questions/11809277/

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




        public enum AccountType : sbyte
        {
            Regular = 0,
            Facebook = 1,
            Kongregate = 2,
            ArmorGames = 3
        }
    }
}
