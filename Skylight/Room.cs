using System.Collections.Generic;
using PlayerIOClient;

namespace Skylight
{
    public class Room
    {
        private static List<Room> joinedRooms = new List<Room>();
        internal bool ShouldTick = true;

        private bool
            blocksLoaded;

        private bool
            blueActivated;

        private List<KeyValuePair<string, Player>> chatLog = new List<KeyValuePair<string, Player>>();
        private List<Connection> connections = new List<Connection>();

        private string
            editKey;

        private double
            gravityMultiplier;

        private bool
            greenActivated;

        private bool
            hasPull;

        private int
            height;

        private string
            id;

        private bool
            isInitialized,
            isTutorialRoom;

        private Block[,,] map = new Block[700, 400, 2];

        private string
            name;

        private List<Bot> onlineBots = new List<Bot>();
        private List<Player> onlinePlayers = new List<Player>();
        private Player owner;

        private int
            plays;

        private bool
            potionsAllowed;

        private In pull = new In();
        private List<In> pulls = new List<In>();
        private Bot receiver;

        private bool
            redActivated;

        private bool
            timeDoorsVisible;

        private int
            totalWoots,
            width,
            woots;

        private string
            worldKey;

        public Room(string id)
        {
            Id = id;
        }

        public static List<Room> JoinedRooms
        {
            get { return joinedRooms; }

            internal set { joinedRooms = value; }
        }

        public Block[,,] Map
        {
            get { return map; }

            internal set { map = value; }
        }

        public bool BlocksLoaded
        {
            get { return blocksLoaded; }
            internal set { blocksLoaded = value; }
        }

        public bool HasPull
        {
            get { return hasPull; }

            internal set { hasPull = value; }
        }

        public bool IsInitialized
        {
            get { return isInitialized; }

            internal set { isInitialized = value; }
        }

        public bool IsTutorialRoom
        {
            get { return isTutorialRoom; }

            internal set { isTutorialRoom = value; }
        }

        public bool PotionsAllowed
        {
            get { return potionsAllowed; }

            internal set { potionsAllowed = value; }
        }

        public bool TimeDoorsVisible
        {
            get { return timeDoorsVisible; }

            internal set { timeDoorsVisible = value; }
        }

        public Bot Receiver
        {
            get { return receiver; }

            internal set { receiver = value; }
        }

        public double GravityMultiplier
        {
            get { return gravityMultiplier; }

            internal set { gravityMultiplier = value; }
        }

        public In Pull
        {
            get { return pull; }

            internal set { pull = value; }
        }

        public int Height
        {
            get { return height; }

            internal set { height = value; }
        }

        public int Plays
        {
            get { return plays; }

            internal set { plays = value; }
        }

        public int TotalWoots
        {
            get { return totalWoots; }

            internal set { totalWoots = value; }
        }

        public int Width
        {
            get { return width; }

            internal set { width = value; }
        }

        public int Woots
        {
            get { return woots; }

            internal set { woots = value; }
        }

        public List<In> Pulls
        {
            get { return pulls; }

            internal set { pulls = value; }
        }

        public List<KeyValuePair<string, Player>> ChatLog
        {
            get { return chatLog; }

            internal set { chatLog = value; }
        }

        public List<Player> OnlinePlayers
        {
            get { return onlinePlayers; }

            internal set { onlinePlayers = value; }
        }

        public List<Bot> OnlineBots
        {
            get { return onlineBots; }

            internal set { onlineBots = value; }
        }

        public Player Owner
        {
            get { return owner; }

            internal set { owner = value; }
        }

        public string EditKey
        {
            get { return editKey; }

            internal set { editKey = value; }
        }

        public string Id
        {
            get { return id; }

            internal set { id = value; }
        }

        public string Name
        {
            get { return name; }

            internal set { name = value; }
        }

        public string RoomKey
        {
            get { return worldKey; }

            internal set { worldKey = value; }
        }

        internal List<Connection> Connections
        {
            get { return connections; }

            set { connections = value; }
        }

        public bool RedActivated
        {
            get { return redActivated; }
            set { redActivated = value; }
        }

        public bool GreenActivated
        {
            get { return greenActivated; }
            set { greenActivated = value; }
        }

        public bool BlueActivated
        {
            get { return blueActivated; }
            set { blueActivated = value; }
        }
    }
}