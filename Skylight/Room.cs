using System.Collections.Generic;
using PlayerIOClient;

namespace Skylight
{
    public class Room
    {
        private static List<Room> _joinedRooms = new List<Room>();
        internal bool ShouldTick = true;

        private bool
            _blocksLoaded;

        private bool
            _blueActivated;

        private List<KeyValuePair<string, Player>> _chatLog = new List<KeyValuePair<string, Player>>();
        private List<Connection> _connections = new List<Connection>();

        private string
            _editKey;

        private double
            _gravityMultiplier;

        private bool
            _greenActivated;

        private bool
            _hasPull;

        private int
            _height;

        private string
            _id;

        private bool
            _isInitialized,
            _isTutorialRoom;

        private Block[,,] map = new Block[700, 400, 2];

        private string
            _name;

        private List<Bot> _onlineBots = new List<Bot>();
        private List<Player> _onlinePlayers = new List<Player>();
        private Player _owner;

        private int
            _plays;

        private bool
            _potionsAllowed;

        private In _pull = new In();
        private List<In> _pulls = new List<In>();
        private Bot _receiver;

        private bool
            _redActivated;

        private bool
            _timeDoorsVisible;

        private int
            _totalWoots,
            _width,
            _woots;

        private string
            _worldKey;

        public Room(string id)
        {
            Id = id;
        }

        public static List<Room> JoinedRooms
        {
            get { return _joinedRooms; }

            internal set { _joinedRooms = value; }
        }

        public Block[,,] Map
        {
            get { return map; }

            internal set { map = value; }
        }

        public bool BlocksLoaded
        {
            get { return _blocksLoaded; }
            internal set { _blocksLoaded = value; }
        }

        public bool HasPull
        {
            get { return _hasPull; }

            internal set { _hasPull = value; }
        }

        public bool IsInitialized
        {
            get { return _isInitialized; }

            internal set { _isInitialized = value; }
        }

        public bool IsTutorialRoom
        {
            get { return _isTutorialRoom; }

            internal set { _isTutorialRoom = value; }
        }

        public bool PotionsAllowed
        {
            get { return _potionsAllowed; }

            internal set { _potionsAllowed = value; }
        }

        public bool TimeDoorsVisible
        {
            get { return _timeDoorsVisible; }

            internal set { _timeDoorsVisible = value; }
        }

        public Bot Receiver
        {
            get { return _receiver; }

            internal set { _receiver = value; }
        }

        public double GravityMultiplier
        {
            get { return _gravityMultiplier; }

            internal set { _gravityMultiplier = value; }
        }

        public In Pull
        {
            get { return _pull; }

            internal set { _pull = value; }
        }

        public int Height
        {
            get { return _height; }

            internal set { _height = value; }
        }

        public int Plays
        {
            get { return _plays; }

            internal set { _plays = value; }
        }

        public int TotalWoots
        {
            get { return _totalWoots; }

            internal set { _totalWoots = value; }
        }

        public int Width
        {
            get { return _width; }

            internal set { _width = value; }
        }

        public int Woots
        {
            get { return _woots; }

            internal set { _woots = value; }
        }

        public List<In> Pulls
        {
            get { return _pulls; }

            internal set { _pulls = value; }
        }

        public List<KeyValuePair<string, Player>> ChatLog
        {
            get { return _chatLog; }

            internal set { _chatLog = value; }
        }

        public List<Player> OnlinePlayers
        {
            get { return _onlinePlayers; }

            internal set { _onlinePlayers = value; }
        }

        public List<Bot> OnlineBots
        {
            get { return _onlineBots; }

            internal set { _onlineBots = value; }
        }

        public Player Owner
        {
            get { return _owner; }

            internal set { _owner = value; }
        }

        public string EditKey
        {
            get { return _editKey; }

            internal set { _editKey = value; }
        }

        public string Id
        {
            get { return _id; }

            internal set { _id = value; }
        }

        public string Name
        {
            get { return _name; }

            internal set { _name = value; }
        }

        public string RoomKey
        {
            get { return _worldKey; }

            internal set { _worldKey = value; }
        }

        internal List<Connection> Connections
        {
            get { return _connections; }

            set { _connections = value; }
        }

        public bool RedActivated
        {
            get { return _redActivated; }
            set { _redActivated = value; }
        }

        public bool GreenActivated
        {
            get { return _greenActivated; }
            set { _greenActivated = value; }
        }

        public bool BlueActivated
        {
            get { return _blueActivated; }
            set { _blueActivated = value; }
        }
    }
}