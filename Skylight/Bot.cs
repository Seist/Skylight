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
            this.ShouldTick = true;
        }

        public bool IsConnected { get; internal set; }

        public bool Joined { get; internal set; }

        public bool ShouldTick { get; set; }

        public Client Client { get; internal set; }

        public string gameVersion { get; internal set; }

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
                // leave passwordOrToken as null (prefered) or empty string if non-applicable.
                this.Connection = new Rabbit.Auth().LogIn(this.emailOrToken, this.passwordOrToken, Bot.currentRoom.Id, createRoom);
                updateGameVersion();
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
                Bot.currentRoom.HasPull = true;

                Bot.currentRoom.Receiver = this;

                this.Connection.OnMessage += Bot.currentRoom.Pull.OnMessage;
                Bot.currentRoom.Pull.IsPersonal = false;
                Bot.currentRoom.Pull.Bot = this;
                Bot.currentRoom.Pull.Source = Bot.currentRoom;
            }

            // Once everything is internal settled, send the inits.
            this.Connection.Send("init");
            this.Connection.Send("init2");

            // this.connection is null so... hmm...?
            Bot.currentRoom.OnlinePlayers.Add(this);

            this.Joined = true;

            while (!Bot.currentRoom.BlocksLoaded)
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
