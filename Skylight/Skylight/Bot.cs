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

        private Room r = new Room();

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

        public Room R
        {
            get
            {
                return this.r;
            }

            set
            {
                this.r = value;
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
                Console.ForegroundColor = Tools.Success; 
                Console.Write("Logging in...");
                this.BotClient.Client = PlayerIO.QuickConnect.SimpleConnect(Tools.GameID, this.Email, this.Password);
                for (int i = 0; i < 13; i++)
                {
                    Console.Write("\b \b");
                }

                Console.WriteLine("Logged in.");
            }
            catch (PlayerIOError e)
            {
                for (int i = 0; i < 13; i++)
                {
                    Console.Write("\b \b");
                }

                Console.ForegroundColor = Tools.Error;
                Console.WriteLine("Cannot log in: {0}", e.Message);
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
            
            Console.Write("Parsing URL...");

            // Parse the level ID (because some people like to put full URLs in).
            this.R.Id = Tools.ParseURL(this.R.Id);
            for (int i = 0; i < 14; i++)
            {
                Console.Write("\b \b");
            }

            try
            {
                Connection c;
                Console.Write("Establishing connection...");

                // Join room
                c = this.BotClient.Client.Multiplayer.JoinRoom(this.R.Id, new Dictionary<string, string>());
                for (int i = 0; i < 26; i++)
                {
                    Console.Write("\b \b");
                }

                // Update room data
                Console.Write("Creating receivers...");
                Room.JoinedRooms.Add(this.R);
                this.R.ConnectedBots.Add(this);
                this.R.OnlinePlayers.Add(this);
            
                // Everyone gets a connection.
                this.R.Connections.Add(c);
                this.BotClient.Connections.Add(c);

                // Every bot receives info from the room, because some of it is exclusive to the bot.
                // We call those "personal" pulls.
                // They are exactly the same as the main pull, except In.IsPersonal = true.
                In p = new In();
                p.IsPersonal = true;
                p.Source = this.R;
                p.Bot = this;
                c.OnMessage += p.OnMessage;
                this.R.Pulls.Add(p);

                // However, everything else only needs one bot to handle. Things like chat and movement.
                // We don't need five bots firing an event every time someone chats.
                if (!this.R.HasPull)
                {
                    this.R.HasPull = true;

                    this.R.Receiver = this;

                    c.OnMessage += this.R.Pull.OnMessage;
                    this.R.Pull.IsPersonal = false;
                    this.R.Pull.Bot = this;
                    this.R.Pull.Source = this.R;
                }

                // Once everything is settled, send the init.
                c.Send("init");
                c.Send("init2");

                for (int i = 0; i < 21; i++)
                {
                    Console.Write("\b \b");
                }

                Console.WriteLine("Joined room.");
            }
            catch (Exception e)
            {
                for (int i = 0; i < 26; i++)
                {
                    Console.Write("\b \b");
                }

                Console.ForegroundColor = Tools.Error;
                Console.WriteLine("Unable to join room \"{0}\": {1}", this.R.Id, e.Message);

                return;
            }
        }
    }
}
