

namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using PlayerIOClient;

    public class Room
    {
        private static List<Room> joinedRooms = new List<Room>();

        private bool
            hasPull,
            isInitialized,
            isTutorialRoom,
            potionsAllowed,
            timeDoorsVisible,
            blueActivated,
            redActivated,
            greenActivated;

        private double
            gravityMultiplier;

        private int
            height,
            plays,
            totalWoots,
            width,
            woots;

        private string
            editKey,
            id,
            name,
            worldKey;

        private Player owner;


        private List<Player> onlinePlayers = new List<Player>();
        private List<Bot> onlineBots = new List<Bot>();


        private List<KeyValuePair<string, Player>> chatLog = new List<KeyValuePair<string, Player>>();


        private Block[, ,] map = new Block[400, 200, 2];


        private Bot receiver;
        private In pull = new In();
        private List<Connection> connections = new List<Connection>();
        private List<In> pulls = new List<In>();

        public Room(string id)
        {
            this.Id = id;
        }


        public static List<Room> JoinedRooms
        {
            get
            {
                return joinedRooms;
            }

            internal set
            {
                joinedRooms = value;
            }
        }


        public Block[, ,] Map
        {
            get
            {
                return this.map;
            }

            internal set
            {
                this.map = value;
            }
        }

        public bool HasPull
        {
            get
            {
                return this.hasPull;
            }

            internal set
            {
                this.hasPull = value;
            }
        }

        public bool IsInitialized
        {
            get
            {
                return this.isInitialized;
            }

            internal set
            {
                this.isInitialized = value;
            }
        }

        public bool IsTutorialRoom
        {
            get
            {
                return this.isTutorialRoom;
            }

            internal set
            {
                this.isTutorialRoom = value;
            }
        }

        public bool PotionsAllowed
        {
            get
            {
                return this.potionsAllowed;
            }

            internal set
            {
                this.potionsAllowed = value;
            }
        }

        public bool TimeDoorsVisible
        {
            get
            {
                return this.timeDoorsVisible;
            }

            internal set
            {
                this.timeDoorsVisible = value;
            }
        }

        public Bot Receiver
        {
            get
            {
                return this.receiver;
            }

            internal set
            {
                this.receiver = value;
            }
        }

        public double GravityMultiplier
        {
            get
            {
                return this.gravityMultiplier;
            }

            internal set
            {
                this.gravityMultiplier = value;
            }
        }

        public In Pull
        {
            get
            {
                return this.pull;
            }

            internal set
            {
                this.pull = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            internal set
            {
                this.height = value;
            }
        }

        public int Plays
        {
            get
            {
                return this.plays;
            }

            internal set
            {
                this.plays = value;
            }
        }

        public int TotalWoots
        {
            get
            {
                return this.totalWoots;
            }

            internal set
            {
                this.totalWoots = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            internal set
            {
                this.width = value;
            }
        }

        public int Woots
        {
            get
            {
                return this.woots;
            }

            internal set
            {
                this.woots = value;
            }
        }

        public List<In> Pulls
        {
            get
            {
                return this.pulls;
            }

            internal set
            {
                this.pulls = value;
            }
        }

        public List<KeyValuePair<string, Player>> ChatLog
        {
            get
            {
                return this.chatLog;
            }

            internal set
            {
                this.chatLog = value;
            }
        }

        public List<Player> OnlinePlayers
        {
            get
            {
                return this.onlinePlayers;
            }

            internal set
            {
                this.onlinePlayers = value;
            }
        }

        public List<Bot> OnlineBots
        {
            get
            {
                return this.onlineBots;
            }

            internal set
            {
                this.onlineBots = value;
            }
        }

        public Player Owner
        {
            get
            {
                return this.owner;
            }

            internal set
            {
                this.owner = value;
            }
        }

        public string EditKey
        {
            get
            {
                return this.editKey;
            }

            internal set
            {
                this.editKey = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            internal set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            internal set
            {
                this.name = value;
            }
        }

        public string RoomKey
        {
            get
            {
                return this.worldKey;
            }

            internal set
            {
                this.worldKey = value;
            }
        }

        internal bool ShouldTick = true;

        internal List<Connection> Connections
        {
            get
            {
                return this.connections;
            }

            set
            {
                this.connections = value;
            }
        }

        public bool RedActivated
        {
            get
            {
                return this.redActivated;
            }
            set
            {
                this.redActivated = value;
            }
        }
        public bool GreenActivated
        {
            get
            {
                return this.greenActivated;
            }
            set
            {
                this.greenActivated = value;
            }
        }
        public bool BlueActivated
        {
            get
            {
                return this.blueActivated;
            }
            set
            {
                this.blueActivated = value;
            }
        }
    }
}