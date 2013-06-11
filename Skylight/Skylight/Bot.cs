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
        
        private Client client;

        // In milliseconds.
        private int 
            blockDelay  = 50, 
            speechDelay = 50;

        private string 
            email, 
            password;

        private Connection connection;

        private Out push = new Out();

        private Room r = new Room();

        public bool IsConnected
        {
            get
            {
                return this.isConnected;
            }

            set
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

            set
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

            set
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
       
        public Connection Connection
        {
            get
            {
                return this.connection;
            }

            set
            {
                this.connection = value;
            }
        }

        // Public methods
        public void LogIn()
        {
            try
            {
                this.Client = PlayerIO.QuickConnect.SimpleConnect(Tools.GameID, this.Email, this.Password);

                Console.ForegroundColor = Tools.Success; 
                Console.WriteLine("Logged in.");
            }
            catch (PlayerIOError e)
            {
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

                // Once everything is settled, send the init.
                this.Connection.Send("init");
                this.Connection.Send("init2");

                this.R.OnlinePlayers.Add(this);

                Console.ForegroundColor = Tools.Success;
                Console.WriteLine("Joined room.");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = Tools.Error;
                Console.WriteLine("Unable to join room \"{0}\": {1}", this.R.Id, e.Message);

                return;
            }
        }

        public void CancelConnection()
        {
            // Basically undo everything you already did.
            this.Client = null;
            this.Connection = null;
            this.Push = null;
        }
    }
}
