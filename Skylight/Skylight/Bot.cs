namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using PlayerIOClient;

    public class Bot : Player
    {
        private bool
            isConnected;

        // In milliseconds.
        private int 
            blockDelay  = 50, 
            speechDelay = 50;

        private string 
            email, 
            password;
      
        private BotClient botClient = new BotClient();

        private Out push = new Out();

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
        
        internal BotClient BotClient
        {
            get
            {
                return this.botClient;
            }

            set
            {
                this.botClient = value;
            }
        }

        // Public methods
        public void LogIn()
        {
            try
            {
                this.BotClient.Client = PlayerIO.QuickConnect.SimpleConnect(Tools.GameID, this.Email, this.Password);
                Console.ForegroundColor = Tools.Success;
                Console.WriteLine("Logged in successfully.");
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
            
                // Everyone gets a connection.
                r.Connections.Add(c);
                this.BotClient.Connections.Add(c);

                // Every bot receives info from the room, because some of it is exclusive to the bot.
                // We call those "personal" pulls.
                // They are exactly the same as the main pull, except In.IsPersonal = true.
                r.Pulls.Add(r.Pull);
                r.Pulls.Last().IsPersonal = true;
                r.Pulls.Last().Source = r;
                r.Pulls.Last().Bot = this;
                c.OnMessage += r.Pulls.Last().OnMessage;

                // However, everything else only needs one bot to handle. Things like chat and movement.
                // We don't need five bots firing an event every time someone chats.
                if (!r.HasPull)
                {
                    r.HasPull = true;

                    r.Receiver = this;

                    r.Pull.IsPersonal = false;
                    r.Pull.Bot = this;
                    r.Pull.Source = r;
                }

                // Once everything is settled, send the init.
                c.Send("init");
                c.Send("init2");
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
