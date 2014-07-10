

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
            greenActivated,
            blocksLoaded;

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


        private Block[, ,] map = new Block[700, 400, 2];


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
            get;
            internal set;
        }

        public Block[, ,] Map
        {
            get;
            internal set;
        }

        public bool BlocksLoaded
        {
            get;
            internal set;
        }

        public bool HasPull
        {
            get;
            internal set;
        }

        public bool IsInitialized
        {
            get;
            internal set;
        }

        public bool IsTutorialRoom
        {
            get;
            internal set;
        }

        public bool PotionsAllowed
        {
            get;
            internal set;
        }

        public bool TimeDoorsVisible
        {
            get;
            internal set;
        }

        public Bot Receiver
        {
            get;
            internal set;
        }

        public double GravityMultiplier
        {
            get;
            internal set;
        }

        public In Pull
        {
            get;
            internal set;
        }

        public int Height
        {
            get;
            internal set;
        }

        public int Plays
        {
            get;
            internal set;
        }

        public int TotalWoots
        {
            get;
            internal set;
        }

        public int Width
        {
            get;
            internal set;
        }

        public int Woots
        {
            get;

            internal set;
        }

        public List<In> Pulls
        {
            get;
            internal set;
        }

        public List<KeyValuePair<string, Player>> ChatLog
        {
            get;
            internal set;
        }

        public List<Player> OnlinePlayers
        {
            get;

            internal set;
        }

        public List<Bot> OnlineBots
        {
            get;

            internal set;
        }

        public Player Owner
        {
            get;

            internal set;
        }

        public string EditKey
        {
            get;

            internal set;
        }

        public string Id
        {
            get;

            internal set;
        }

        public string Name
        {
            get;

            internal set;
        }

        public string RoomKey
        {
            get;

            internal set;
        }

        internal bool ShouldTick = true;

        internal List<Connection> Connections
        {
            get;

            set;
        }

        public bool RedActivated
        {
            get;
            set;
        }
        public bool GreenActivated
        {
            get;
            set;
        }
        public bool BlueActivated
        {
            get;
            set;
        }
    }
}