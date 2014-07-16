using System.Collections.Generic;
using PlayerIOClient;
using Skylight.Blocks;

namespace Skylight
{
    public class Room
    {
        internal bool ShouldTick = true;

        private List<Connection> _connections = new List<Connection>();

        public Room(string id)
        {
            OnlineBots = new List<Bot>();
            OnlinePlayers = new List<Player>();
            ChatLog = new List<KeyValuePair<string, Player>>();
            Pulls = new List<In>();
            Pull = new In();
            Map = new Block[700, 400, 2];
            Id = id;
        }

        static Room()
        {
            JoinedRooms = new List<Room>();
        }

        public static List<Room> JoinedRooms { get; internal set; }

        public Block[,,] Map { get; internal set; }

        public bool BlocksLoaded { get; internal set; }

        public bool HasPull { get; internal set; }

        public bool IsInitialized { get; internal set; }

        public bool IsTutorialRoom { get; internal set; }

        public bool PotionsAllowed { get; internal set; }

        public bool TimeDoorsVisible { get; internal set; }

        public Bot Receiver { get; internal set; }

        public double GravityMultiplier { get; internal set; }

        public In Pull { get; internal set; }

        public int Height { get; internal set; }

        public int Plays { get; internal set; }

        public int TotalWoots { get; internal set; }

        public int Width { get; internal set; }

        public int Woots { get; internal set; }

        public List<In> Pulls { get; internal set; }

        public List<KeyValuePair<string, Player>> ChatLog { get; internal set; }

        public List<Player> OnlinePlayers { get; internal set; }

        public List<Bot> OnlineBots { get; internal set; }

        public Player Owner { get; internal set; }

        public string EditKey { get; internal set; }

        public string Id { get; internal set; }

        public string Name { get; internal set; }

        public string RoomKey { get; internal set; }

        internal List<Connection> Connections
        {
            get { return _connections; }

            set { _connections = value; }
        }

        public bool RedActivated { get; set; }

        public bool GreenActivated { get; set; }

        public bool BlueActivated { get; set; }
    }
}