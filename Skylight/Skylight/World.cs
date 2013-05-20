// <author>TakoMan02</author>
// <summary>World.cs is a basic layout of a singular world in EE.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using PlayerIOClient;

    public class World
    {
        // Private static fields
        private static List<World> joinedWorlds = new List<World>();
        
        // Private instance fields
        private Dictionary<Coords, Block> map = new Dictionary<Coords, Block>();
        private Player bot;
        private Connection c;
        private string id;
        private In pull = new In();
        private Out push = new Out();
        private List<Player> onlinePlayers = new List<Player>();
        private List<string> chatLog = new List<string>();
        private string name;
        private bool potionsAllowed;

        // Public static properties
        public static List<World> JoinedWorlds
        {
            get { return joinedWorlds; }
            internal set { joinedWorlds = value; }
        }

        // Public instance properties
        public Player Bot
        {
            get
            {
                return this.bot;
            }

            internal set
            {
                this.bot = value;
            }
        }

        public Connection C
        {
            get { return this.c; }
            internal set { this.c = value; }
        }

        public In Pull
        {
            get { return this.pull; }
            internal set { this.pull = value; }
        }

        public Out Push
        {
            get { return this.push; }
            internal set { this.push = value; }
        }

        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string EditKey { get; set; }

        public Dictionary<Coords, Block> Map
        {
            get { return this.map; }
            internal set { this.map = value; }
        }

        public List<Player> OnlinePlayers
        {
            get { return this.onlinePlayers; }
            internal set { this.onlinePlayers = value; }
        }

        public List<string> ChatLog
        {
            get { return this.chatLog; }
            internal set { this.chatLog = value; }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            internal set
            {
                if (value != string.Empty)
                {
                    // TODO: Check to see if this works.
                    this.push.ChangeTitle(value);

                    this.name = value;
                }
            }
        }

        public string Owner { get; internal set; }

        public string WorldKey { get; internal set; }

        public int Plays { get; internal set; }

        public int Woots { get; internal set; }

        public int TotalWoots { get; internal set; }

        public int Width { get; internal set; }

        public int Height { get; internal set; }
        
        public bool PotionsAllowed
        {
            get
            {
                return this.potionsAllowed;
            }

            set
            {
                // If the bot has access to change it, change it.
                // TODO: Change potions value in-game.
                if (this.Bot.HasAccess)
                {
                    this.potionsAllowed = value;
                }
            }
        }
        
        // Public methods
        public void Join()
        {
            // Parse the level ID.
            this.Id = Tools.ParseURL(this.Id);

            // Create a connection to the level.
            // The connection can have some errors, so add it seperately in a try-catch.
            try
            {
                this.C = Tools.Client.Multiplayer.JoinRoom(this.Id, new Dictionary<string, string>());

                this.C.OnMessage += this.pull.OnMessage;

                this.C.Send("init");

                this.C.Send("init2");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = Tools.Error;
                Console.Write("Unable to join room \"{0}\": ", this.Id);

                if (e is PlayerIOError)
                {
                    Console.Write(e.Data);

                    Tools.JoinError = true;
                }

                if (e is NullReferenceException)
                {
                    Console.WriteLine("not connected to EE");
                }

                return;
            }

            JoinedWorlds.Add(this);

            Tools.JoinError = false;
        }
    }
}