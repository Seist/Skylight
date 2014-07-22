// <copyright file="Room.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using PlayerIOClient;
using Skylight.Blocks;

namespace Skylight
{
    /// <summary>
    ///     Class Room.
    /// </summary>
    public class Room
    {
        /// <summary>
        ///     Whether the physics are enabled.
        /// </summary>
        internal bool ShouldTick = true;

        /// <summary>
        ///     The connections available.
        /// </summary>
        private List<Connection> _connections = new List<Connection>();

        /// <summary>
        ///     Initializes static members of the <see cref="Room" /> class.
        /// </summary>
        static Room()
        {
            JoinedRooms = new List<Room>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Room" /> class.
        /// </summary>
        /// <param name="id">The room identifier.</param>
        public Room(string id, bool shouldTick)
        {
            OnlineBots = new List<Bot>();
            OnlinePlayers = new List<Player>();
            ChatLog = new List<KeyValuePair<string, Player>>();
            Pulls = new List<In>();
            Pull = new In();
            Map = new Block[700, 400, 2];
            Id = id;
            ShouldTick = shouldTick;
        }

        /// <summary>
        ///     Gets the joined rooms.
        /// </summary>
        /// <value>The joined rooms.</value>
        public static List<Room> JoinedRooms { get; private set; }

        /// <summary>
        ///     Gets the map.
        /// </summary>
        /// <value>The map.</value>
        public Block[,,] Map { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether the blocks are loaded.
        /// </summary>
        /// <value><c>true</c> if the blocks loaded; otherwise, <c>false</c>.</value>
        public bool BlocksLoaded { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance has pull access.
        /// </summary>
        /// <value><c>true</c> if this instance has pull access; otherwise, <c>false</c>.</value>
        public bool HasPull { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is initialized.
        /// </summary>
        /// <value><c>true</c> if this instance is initialized; otherwise, <c>false</c>.</value>
        public bool IsInitialized { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is a tutorial room.
        /// </summary>
        /// <value><c>true</c> if this instance is a tutorial room; otherwise, <c>false</c>.</value>
        public bool IsTutorialRoom { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether potions are allowed.
        /// </summary>
        /// <value><c>true</c> if potions are allowed; otherwise, <c>false</c>.</value>
        public bool PotionsAllowed { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether time doors are visible.
        /// </summary>
        /// <value><c>true</c> if [time doors visible]; otherwise, <c>false</c>.</value>
        public bool TimeDoorsVisible { get; internal set; }

        /// <summary>
        ///     Gets the receiver.
        /// </summary>
        /// <value>The receiver.</value>
        public Bot Receiver { get; internal set; }

        /// <summary>
        ///     Gets the gravity multiplier.
        /// </summary>
        /// <value>The gravity multiplier.</value>
        public double GravityMultiplier { get; internal set; }

        /// <summary>
        ///     Gets the pull.
        /// </summary>
        /// <value>The pull.</value>
        public In Pull { get; private set; }

        /// <summary>
        ///     Gets the height of the room.
        /// </summary>
        /// <value>The height.</value>
        public int Height { get; internal set; }

        /// <summary>
        ///     Gets the total plays.
        /// </summary>
        /// <value>The plays.</value>
        public int Plays { get; internal set; }

        /// <summary>
        ///     Gets the total woots.
        /// </summary>
        /// <value>The total woots.</value>
        public int TotalWoots { get; internal set; }

        /// <summary>
        ///     Gets the width pf the room.
        /// </summary>
        /// <value>The width.</value>
        public int Width { get; internal set; }

        /// <summary>
        ///     Gets the woots.
        /// </summary>
        /// <value>The woots.</value>
        public int Woots { get; internal set; }

        /// <summary>
        ///     Gets the pulls.
        /// </summary>
        /// <value>The pulls.</value>
        public List<In> Pulls { get; internal set; }

        /// <summary>
        ///     Gets the chat log.
        /// </summary>
        /// <value>The chat log.</value>
        public List<KeyValuePair<string, Player>> ChatLog { get; internal set; }

        /// <summary>
        ///     Gets the online players.
        /// </summary>
        /// <value>The online players.</value>
        public List<Player> OnlinePlayers { get; internal set; }

        /// <summary>
        ///     Gets the online bots.
        /// </summary>
        /// <value>The online bots.</value>
        public List<Bot> OnlineBots { get; internal set; }

        /// <summary>
        ///     Gets the owner.
        /// </summary>
        /// <value>The owner.</value>
        public Player Owner { get; internal set; }

        /// <summary>
        ///     Gets the edit key.
        /// </summary>
        /// <value>The edit key.</value>
        public string EditKey { get; internal set; }

        /// <summary>
        ///     Gets the identifier of the room.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; internal set; }

        /// <summary>
        ///     Gets the name of the room.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; internal set; }

        /// <summary>
        ///     Gets the room key.
        /// </summary>
        /// <value>The room key.</value>
        public string RoomKey { get; internal set; }

        /// <summary>
        ///     Gets or sets the connections.
        /// </summary>
        /// <value>The connections.</value>
        internal List<Connection> Connections
        {
            get { return _connections; }

            set { _connections = value; }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the red key is activated.
        /// </summary>
        /// <value><c>true</c> if the red key is activated; otherwise, <c>false</c>.</value>
        public bool RedActivated { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the green key is activated.
        /// </summary>
        /// <value><c>true</c> if the green key is activated; otherwise, <c>false</c>.</value>
        public bool GreenActivated { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the blue key is activated.
        /// </summary>
        /// <value><c>true</c> if the blue key is activated; otherwise, <c>false</c>.</value>
        public bool BlueActivated { get; set; }
    }
}