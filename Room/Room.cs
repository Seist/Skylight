// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Room.cs" company="">
//   
// </copyright>
// <summary>
//   Class Room.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Skylight
{
    using System.Collections.Generic;

    using PlayerIOClient;

    using Skylight.Blocks;

    /// <summary>
    ///     Class Room.
    /// </summary>
    public class Room
    {
        #region Fields

        /// <summary>
        ///     Whether the physics are enabled.
        /// </summary>
        internal bool ShouldTick = true;

        /// <summary>
        ///     The connections available.
        /// </summary>
        private List<Connection> _connections = new List<Connection>();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes static members of the <see cref="Room" /> class.
        /// </summary>
        static Room()
        {
            JoinedRooms = new List<Room>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        /// <param name="id">
        /// The room identifier.
        /// </param>
        /// <param name="shouldTick">
        /// If the room should update player coordinates accurately.
        /// </param>
        public Room(string id)
        {
            this.OnlineBots = new List<Bot>();
            this.OnlinePlayers = new List<Player>();
            this.ChatLog = new List<KeyValuePair<string, Player>>();
            this.Receivers = new List<Receiver>();
            this.Id = id;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the joined rooms.
        /// </summary>
        /// <value>The joined rooms.</value>
        public static List<Room> JoinedRooms { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether the blocks are loaded.
        /// </summary>
        /// <value><c>true</c> if the blocks loaded; otherwise, <c>false</c>.</value>
        public bool BlocksLoaded { get; internal set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the blue key is activated.
        /// </summary>
        /// <value><c>true</c> if the blue key is activated; otherwise, <c>false</c>.</value>
        public bool BlueActivated { get; set; }

        /// <summary>
        ///     Gets the chat log.
        /// </summary>
        /// <value>The chat log.</value>
        public List<KeyValuePair<string, Player>> ChatLog { get; internal set; }

        /// <summary>
        ///     Gets the edit key.
        /// </summary>
        /// <value>The edit key.</value>
        public string EditKey { get; internal set; }

        /// <summary>
        ///     Gets the gravity multiplier.
        /// </summary>
        /// <value>The gravity multiplier.</value>
        public double GravityMultiplier { get; internal set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the green key is activated.
        /// </summary>
        /// <value><c>true</c> if the green key is activated; otherwise, <c>false</c>.</value>
        public bool GreenActivated { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this instance has Receiver access.
        /// </summary>
        /// <value><c>true</c> if this instance has Receiver access; otherwise, <c>false</c>.</value>
        public bool HasReceiver { get; internal set; }

        /// <summary>
        ///     Gets the height of the room.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; internal set; }

        /// <summary>
        ///     Gets the identifier of the room.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is initialized.
        /// </summary>
        /// <value><c>true</c> if this instance is initialized; otherwise, <c>false</c>.</value>
        public bool IsInitialized { get; internal set; }

        /// <summary>
        ///     Gets the map.
        /// </summary>
        /// <value>The map.</value>
        public Map Map { get; internal set; }

        /// <summary>
        ///     Gets the name of the room.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; internal set; }

        /// <summary>
        ///     Gets the online bots.
        /// </summary>
        /// <value>The online bots.</value>
        public List<Bot> OnlineBots { get; internal set; }

        /// <summary>
        ///     Gets the online players.
        /// </summary>
        /// <value>The online players.</value>
        public List<Player> OnlinePlayers { get; internal set; }

        /// <summary>
        ///     Gets the owner.
        /// </summary>
        /// <value>The owner.</value>
        public Player Owner { get; internal set; }

        /// <summary>
        ///     Gets the total plays.
        /// </summary>
        /// <value>The plays.</value>
        public int Plays { get; internal set; }

        /// <summary>
        ///     Gets the Receiver.
        /// </summary>
        /// <value>The Receiver.</value>
        public Receiver MainReceiver { get; internal set; }

        /// <summary>
        ///     Gets the Receivers.
        /// </summary>
        /// <value>The Receivers.</value>
        public List<Receiver> Receivers { get; internal set; }

        /// <summary>
        ///     Gets the receiver.
        /// </summary>
        /// <value>The receiver.</value>
        public Bot ReceiverBot { get; internal set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the red key is activated.
        /// </summary>
        /// <value><c>true</c> if the red key is activated; otherwise, <c>false</c>.</value>
        public bool RedActivated { get; set; }

        /// <summary>
        ///     Gets the room key.
        /// </summary>
        /// <value>The room key.</value>
        public string RoomKey { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether time doors are visible.
        /// </summary>
        /// <value><c>true</c> if [time doors visible]; otherwise, <c>false</c>.</value>
        public bool TimeDoorsVisible { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether the room is visible from owner's profile.
        /// </summary>
        public bool IsVisible { get; internal set; }


        /// <summary>
        ///     Gets the width pf the room.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; internal set; }

        public int Favorites { get; internal set; }

        public int Likes { get; internal set; }

        public uint ChatColor { get; internal set; }

        public uint BackgroundColor { get; internal set; }

        public bool IsOpenToLobby { get; internal set; }

        public bool AllowsSpectating { get; internal set; }

        public string RoomDescription { get; internal set; }

        public bool IsCampaignRoom { get; internal set; }

        public int CurseLimit { get; internal set; }

        public int ZombieLimit { get; internal set; }

        public Crew CrewCreators { get; internal set; }

        public int RoomStatus { get; internal set; }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the connections.
        /// </summary>
        /// <value>The connections.</value>
        internal List<Connection> Connections
        {
            get
            {
                return this._connections;
            }

            set
            {
                this._connections = value;
            }
        }

        #endregion
    }
}