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
        private bool
            hasPull,
            isInitialized,
            isTutorialRoom,
            potionsAllowed,
            timeDoorsVisible;
            
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
        
        private Player owner = new Player();

        // The players
        private List<Player> onlinePlayers = new List<Player>();
        private List<Bot> onlineBots    = new List<Bot>();

        // The chat
        private List<KeyValuePair<string, Player>> chatLog = new List<KeyValuePair<string, Player>>();
        
        // The map (a three-dimensional array of blocks)
        private Block[,,] map = new Block[400, 400, 2];

        // Receivers of new information:
        private Bot receiver;
        private In pull                      = new In();
        private List<Connection> connections = new List<Connection>();
        private List<In> pulls               = new List<In>();

        // Public static properties
        public static List<Room> JoinedRooms
        {
            get
            {
                return joinedRooms;
            }

            set
            {
                joinedRooms = value;
            }
        }

        // Public instance properties
        public Block[,,] Map
        {
            get
            {
                return this.map;
            }

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
            { 
                this.worldKey = value;
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