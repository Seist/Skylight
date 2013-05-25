namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using PlayerIOClient;

    public class Bot : Player
    {
        internal static readonly string GameID = "everybody-edits-su9rn58o40itdbnw69plyw";

        // TODO: Organize these damned variables
        private int blockDelay = 6, speechDelay = 60;
        private string email, password;
        private bool isConnected;

        private BotClient botClient = new BotClient();
        private Out push = new Out();

        // Each pull is from a different room
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

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
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

        internal BotClient BotClient
        {
            get
            {
                return this.botClient;
            }

            private set
            {
                this.botClient = value;
            }
        }

        // Public methods
        public void LogIn()
        {
            try
            {
                this.BotClient.Client = PlayerIO.QuickConnect.SimpleConnect(GameID, this.Email, this.Password);
                Console.ForegroundColor = Tools.Success;
                Console.WriteLine("Connected/Logged in successfully.");
            }
            catch (PlayerIOError e)
            {
                Console.ForegroundColor = Tools.Error;
                Console.WriteLine("Could not connect/log in: {0}", e.Message);
                this.IsConnected = false;
                return;
            }

            this.IsConnected = true;
        }

        public void Join(Room r)
        {
            // Parse the level ID (because some people like to put full URLs in).
            r.Id = Tools.ParseURL(r.Id);

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

            try
            {
                Connection c;

                // Join room
                c = this.BotClient.Client.Multiplayer.JoinRoom(r.Id, new Dictionary<string, string>());

                // Update room data
                Room.JoinedRooms.Add(r);
                r.ConnectedBots.Add(this);
                r.OnlinePlayers.Add(this);
                r.Pulls.Add(r.Pull);

                // Only one pull per room has a receiver.
                if (!r.HasPull)
                {
                    r.Receiver = this;
                    r.HasPull = true;
                    r.Pulls[0] = r.Pull;
                }

                // Every pull has a source room and a bot and an OnMessage.
                r.Pulls.Last().Source = r;
                r.Pulls.Last().Bot = this;

                c.OnMessage += r.Pulls.Last().OnMessage;

                c.Send("init");
                c.Send("init2");

                r.Connections.Add(c);
                this.BotClient.Connections.Add(c);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = Tools.Error;
                Console.Write("Unable to join room \"{0}\": {1}", r.Id, e.Message);

                return;
            }
        }
    }
}
