// <author>TakoMan02</author>
// <summary>Room.cs is a basic layout of a singular world in EE.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using PlayerIOClient;

    public class Room
    {
        // Private static fields
        private static List<Room> joinedRooms = new List<Room>();

        // Private instance fields
        private List<Connection> connections = new List<Connection>();
        private Dictionary<Coords, Block> map = new Dictionary<Coords, Block>();
        private List<Player> alreadyOnlinePlayers = new List<Player>();
        private List<Player> onlinePlayers = new List<Player>();
        private List<KeyValuePair<string, Player>> chatLog = new List<KeyValuePair<string, Player>>();
        private List<Bot> connectedBots = new List<Bot>();
        private string
            id,
            name,
            worldKey,
            editKey;

        private bool
            potionsAllowed,
            isInitialized = false,
            isTutorialRoom = false,
            hasPull = false;

        private int 
            height,
            width,
            plays,
            woots,
            totalWoots;

        private double gravityMultiplier;
        private Player owner = new Player();
        private In pull = new In();
        private List<In> pulls = new List<In>();
        private Bot receiver = new Bot();

        // Public static properties
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

        // Public instance properties
        public In Pull
        {
            get
            {
                return this.pull;
            }

            set
            {
                this.pull = value;
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

        public List<Bot> ConnectedBots
        {
            get
            {
                return this.connectedBots;
            }

            set
            {
                this.connectedBots = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public string EditKey
        {
            get
            {
                return this.editKey;
            }

            set
            {
                this.editKey = value;
            }
        }

        public Dictionary<Coords, Block> Map
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

        public List<Player> AlreadyOnlinePlayers
        {
            get
            {
                return this.alreadyOnlinePlayers;
            }

            internal set
            {
                this.alreadyOnlinePlayers = value;
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

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
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

        public bool PotionsAllowed
        {
            get
            {
                return this.potionsAllowed;
            }

            set
            {
                this.potionsAllowed = value;
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
    }
}