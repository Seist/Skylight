// --------------------------------------------------------------------------------------------------------------------
// <copyright company="" file="Player.cs">
//   
// </copyright>
// <author>TakoMan02</author>
// <summary>
//   Player.cs describes a singular player in an EE world.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    using Skylight.Blocks;

    /// <summary>
    ///     Class Player.
    /// </summary>
    public class Player
    {
        // Private instance fields
        #region Constants

        /// <summary>
        ///     The gravity multiplier
        /// </summary>
        private const double GravityMultiplier = 1;

        /// <summary>
        ///     The maximum thrust
        /// </summary>
        private const double MaxThrust = 0.2;

        /// <summary>
        ///     The thrust burn off duration
        /// </summary>
        private const double ThrustBurnOff = 0.01;

        #endregion

        /*
        /// <summary>
        ///     The jump boost
        /// </summary>
 *      Before this is re-initialized the potion id that concerns this has
 *      to be looked up. Only then can JumpBoost be true.
        private const bool JumpBoost = false;
*/
        #region Static Fields

        /// <summary>
        ///     The admins. This is never used.
        /// </summary>
        public static readonly List<string> Admins = new List<string>
                                                         {
                                                             "benjaminsen", 
                                                             "cyclone", 
                                                             "toby", 
                                                             "rpgmaster2000", 
                                                             "mrshoe", 
                                                             "mrvoid"
                                                         };

        #endregion

        #region Fields

        /// <summary>
        ///     The checkpoint at the x coordinate
        /// </summary>
        public int CheckpointX = -1;

        /// <summary>
        ///     The checkpoint at the y coordinate
        /// </summary>
        public int CheckpointY = -1;

        /// <summary>
        ///     The horizontal position
        /// </summary>
        internal int Horizontal = 0;

        /// <summary>
        ///     The vertical
        /// </summary>
        internal int Vertical = 0;

        /// <summary>
        ///     The multiplyer.
        /// </summary>
        protected double ModifierY = 0;

        /// <summary>
        ///     Whether the player is a club member or not
        /// </summary>
        protected double SpeedX = 0;

        /// <summary>
        ///     The modifier x
        /// </summary>
        protected double SpeedY = 0;

        /// <summary>
        ///     The boost
        /// </summary>
        private readonly double Boost;

        /// <summary>
        ///     The gravity
        /// </summary>
        private readonly double Gravity;

        /// <summary>
        ///     The mud buoyancy
        /// </summary>
        private readonly double MudBuoyancy;

        /// <summary>
        ///     The mud drag
        /// </summary>
        private readonly double MudDrag;

        /// <summary>
        ///     The no modifier drag x
        /// </summary>
        private readonly double NoModifierDragX;

        /// <summary>
        ///     The no modifier drag y
        /// </summary>
        private readonly double NoModifierDragY;

        /// <summary>
        ///     The size of the block
        /// </summary>
        private readonly int Size;

        /// <summary>
        ///     The switch opened
        /// </summary>
        private readonly bool SwitchOpened;

        /// <summary>
        ///     The water buoyancy
        /// </summary>
        private readonly double WaterBuoyancy;

        /// <summary>
        ///     The water drag
        /// </summary>
        private readonly double WaterDrag;

        /// <summary>
        ///     Whether or not the player has died
        /// </summary>
        private readonly bool _isDead;

        /// <summary>
        ///     Whether or not the player is invulnerable
        /// </summary>
        private readonly bool _isInvulnerable;

        /// <summary>
        /// The _is thrusting.
        /// </summary>
        private readonly bool _isThrusting;

        /// <summary>
        ///     The player is a zombie
        /// </summary>
        private readonly bool _isZombie;

        /// <summary>
        /// The _mult.
        /// </summary>
        private readonly double _mult;

        /// <summary>
        ///     The main event queue.
        /// </summary>
        private readonly Queue<int> _queue = new Queue<int>();

        /// <summary>
        ///     The current block identifier
        /// </summary>
        private int CurrentBlockId;

        /// <summary>
        /// The modifier x.
        /// </summary>
        private double ModifierX;

        /// <summary>
        ///     The _animoffset
        /// </summary>
        private double _animoffset;

        /// <summary>
        ///     The _cluboffset
        /// </summary>
        private double _cluboffset;

        /// <summary>
        ///     The _current sx
        /// </summary>
        private double _currentSx;

        /// <summary>
        ///     The _current sy
        /// </summary>
        private double _currentSy;

        /// <summary>
        ///     The _current thrust
        /// </summary>
        private double _currentThrust;

        /// <summary>
        ///     The _CX
        /// </summary>
        private int _cx;

        /// <summary>
        ///     The _cy
        /// </summary>
        private int _cy;

        /// <summary>
        ///     The _deadoffset
        /// </summary>
        private double _deadoffset;

        /// <summary>
        ///     The _donex
        /// </summary>
        private bool _donex;

        /// <summary>
        ///     The _doney
        /// </summary>
        private bool _doney;

        /// <summary>
        ///     The horizontal acceleration
        /// </summary>
        private double _horizontalAcceleration;

        /*
        private bool injump = false;
*/
        /*
        /// <summary>
        /// The _is cursed
        /// </summary>
        private bool _isCursed;
*/

        /// <summary>
        ///     The player has god mode
        /// </summary>
        private bool _isgodmod;

        /// <summary>
        ///     The coordinate of the player's last occurance with a portal
        /// </summary>
        private Point _lastPortal;

        /*
        /// <summary>
        /// The _last respawn
        /// </summary>
        private double _lastRespawn;
*/
        /*
        private int mod = 0;
*/

        /// <summary>
        ///     The _modoffset
        /// </summary>
        private double _modoffset;

        /// <summary>
        ///     The _morx
        /// </summary>
        private int _morx;

        /// <summary>
        ///     The _mory
        /// </summary>
        private int _mory;

        /// <summary>
        ///     The _name
        /// </summary>
        private string _name;

        /// <summary>
        ///     The old horizontal acceleration
        /// </summary>
        private double _oldHorizontalAcceleration;

        /// <summary>
        ///     The old vertical acceleration
        /// </summary>
        private double _oldVerticalAcceleration;

        /// <summary>
        ///     The _osx
        /// </summary>
        private double _osx;

        /// <summary>
        ///     The _osy
        /// </summary>
        private double _osy;

        /// <summary>
        ///     The _overlapy
        /// </summary>
        private int _overlapy;

        /// <summary>
        ///     The _ox
        /// </summary>
        private double _ox;

        /// <summary>
        ///     The _oy
        /// </summary>
        private double _oy;

        /// <summary>
        ///     The _reminder x
        /// </summary>
        private double _reminderX;

        /// <summary>
        ///     The _reminder y
        /// </summary>
        private double _reminderY;

        /// <summary>
        ///     The_spacejustdown
        /// </summary>
        private bool _spacejustdown;

        /// <summary>
        ///     The _TX
        /// </summary>
        private double _tx;

        /// <summary>
        ///     The _ty
        /// </summary>
        private double _ty;

        /// <summary>
        ///     The _vertical acceleration
        /// </summary>
        private double _verticalAcceleration;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="room">
        /// The room.
        /// </param>
        /// <param name="id">
        /// The identifier.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="smiley">
        /// The smiley.
        /// </param>
        /// <param name="xPos">
        /// The x position.
        /// </param>
        /// <param name="yPos">
        /// The y position.
        /// </param>
        /// <param name="isGod">
        /// if set to <c>true</c> [is god].
        /// </param>
        /// <param name="isMod">
        /// if set to <c>true</c> [is mod].
        /// </param>
        /// <param name="hasChat">
        /// if set to <c>true</c> [has chat].
        /// </param>
        /// <param name="coins">
        /// The coins.
        /// </param>
        /// <param name="switchOpened">
        /// if set to <c>true</c> [purple].
        /// </param>
        /// <param name="isFriend">
        /// if set to <c>true</c> [is friend].
        /// </param>
        /// <param name="level">
        /// The level.
        /// </param>
        /// <param name="hasClub">
        /// If the player has builder's club or not.
        /// </param>
        /// <param name="isInvulnerable">
        /// The player can die.
        /// </param>
        /// <param name="isThrusting">
        /// Player is using boost potion
        /// </param>
        /// <param name="isZombie">
        /// Player is a zombie
        /// </param>
        /// <param name="isDead">
        /// Player is dead
        /// </param>
        /// <param name="levitation">
        /// Player has levitation potion
        /// </param>
        public Player(
            Room room, 
            int id, 
            string name, 
            int smiley, 
            double xPos, 
            double yPos, 
            bool isGod, 
            bool isMod, 
            bool hasChat, 
            int coins, 
            bool switchOpened, 
            bool isFriend, 
            int level, 
            bool hasClub, 
            bool isInvulnerable, 
            bool isThrusting, 
            bool isZombie, 
            bool isDead, 
            bool levitation)
        {
            this.PotionEffects = new List<int>();
            this.PlayingIn = room;
            this.Smiley = smiley;
            this.IsGod = isGod;
            this.IsMod = isMod;
            this.HasChat = hasChat;
            this.Id = id;
            this.Coins = coins;
            this.SwitchOpened = switchOpened;
            this.IsFriend = isFriend;
            this.Level = level;
            this.HasClub = hasClub;
            this._isInvulnerable = isInvulnerable;
            this._isThrusting = isThrusting;
            this._isZombie = isZombie;
            this._isDead = isDead;
            this.Levitation = levitation;
            this._queue = new Queue<int>(Config.PhysicsQueueLength);
            this._lastPortal = new Point();

            this._currentThrust = MaxThrust;
            this.X = xPos;
            this.Y = yPos;
            this.Name = name;
            this.Size = 16;
            this.NoModifierDragX = Config.PhysicsNoModifierDrag;
            this.NoModifierDragY = Config.PhysicsNoModifierDrag;
            this.WaterDrag = Config.PhysicsWaterDrag;
            this.WaterBuoyancy = Config.PhysicsWaterBuoyancy;
            this.MudDrag = Config.PhysicsMudDrag;
            this.MudBuoyancy = Config.PhysicsMudBuoyancy;
            this.Boost = Config.PhysicsBoost;
            this.Gravity = Config.PhysicsGravity;
            this._mult = Config.PhysicsVariableMultiplyer;

            this.ShouldTick = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class. 
        /// Creates a copy of a player object.
        /// </summary>
        /// <param name="p">
        /// The player object to be copied.
        /// </param>
        public Player(Player p)
        {
            this.PotionEffects = new List<int>();
            this.PlayingIn = p.PlayingIn;
            this.Smiley = p.Smiley;
            this.IsGod = p.IsGod;
            this.IsMod = p.IsMod;
            this.HasChat = p.HasChat;
            this.Id = p.Id;
            this.Coins = p.Coins;
            this.SwitchOpened = p.SwitchOpened;
            this.IsFriend = p.IsFriend;
            this.Level = p.Level;
            this.HasClub = p.HasClub;
            this._isInvulnerable = p._isInvulnerable;
            this._isThrusting = p._isThrusting;
            this._isZombie = p._isZombie;
            this._isDead = p._isDead;
            this.Levitation = p.Levitation;
            this._queue = new Queue<int>(Config.PhysicsQueueLength);
            this._lastPortal = new Point();

            this._currentThrust = MaxThrust;
            this.X = p.X;
            this.Y = p.Y;
            this.Name = p.Name;
            this.Size = 16;
            this.NoModifierDragX = Config.PhysicsNoModifierDrag;
            this.NoModifierDragY = Config.PhysicsNoModifierDrag;
            this.WaterDrag = Config.PhysicsWaterDrag;
            this.WaterBuoyancy = Config.PhysicsWaterBuoyancy;
            this.MudDrag = Config.PhysicsMudDrag;
            this.MudBuoyancy = Config.PhysicsMudBuoyancy;
            this.Boost = Config.PhysicsBoost;
            this.Gravity = Config.PhysicsGravity;
            this._mult = Config.PhysicsVariableMultiplyer;

            this.ShouldTick = true;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the block x.
        /// </summary>
        /// <value>The block x.</value>
        public int BlockX
        {
            get
            {
                return this.blockX;
            }

            set
            {
                this.X = value * 16;
            }
        }

        /// <summary>
        ///     Gets or sets the block y.
        /// </summary>
        /// <value>The block y.</value>
        public int BlockY
        {
            get
            {
                return this.blockY;
            }

            set
            {
                this.Y = value * 16;
            }
        }

        /// <summary>
        ///     Gets the blue coins.
        /// </summary>
        /// <value>The blue coins.</value>
        public int BlueCoins { get; internal set; }

        /// <summary>
        ///     Gets the coins.
        /// </summary>
        /// <value>The coins.</value>
        public int Coins { get; internal set; }

        /// <summary>
        ///     Gets the collected magic.
        /// </summary>
        /// <value>The collected magic.</value>
        public int CollectedMagic { get; internal set; }

        /// <summary>
        ///     Gets the death count.
        /// </summary>
        /// <value>The death count.</value>
        public int DeathCount { get; internal set; }

        // Public instance properties.

        /// <summary>
        ///     Gets a value indicating whether this instance has access.
        /// </summary>
        /// <value><c>true</c> if this instance has access; otherwise, <c>false</c>.</value>
        public bool HasAccess { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance has boost.
        /// </summary>
        /// <value><c>true</c> if this instance has boost; otherwise, <c>false</c>.</value>
        public bool HasBoost { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance has command access.
        /// </summary>
        /// <value><c>true</c> if this instance has command access; otherwise, <c>false</c>.</value>
        public bool HasCommandAccess { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance has crown.
        /// </summary>
        /// <value><c>true</c> if this instance has crown; otherwise, <c>false</c>.</value>
        public bool HasCrown { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance has gravity modifier.
        /// </summary>
        /// <value><c>true</c> if this instance has gravity modifier; otherwise, <c>false</c>.</value>
        public bool HasGravityModifier { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance has silver crown.
        /// </summary>
        /// <value><c>true</c> if this instance has silver crown; otherwise, <c>false</c>.</value>
        public bool HasSilverCrown { get; internal set; }

        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is bot.
        /// </summary>
        /// <value><c>true</c> if this instance is bot; otherwise, <c>false</c>.</value>
        public bool IsBot
        {
            get
            {
                return this.PlayingIn != null && this.PlayingIn.OnlineBots.Any(bt => bt.Id == this.Id);
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is god.
        /// </summary>
        /// <value><c>true</c> if this instance is god; otherwise, <c>false</c>.</value>
        public bool IsGod { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is holding down.
        /// </summary>
        /// <value><c>true</c> if this instance is holding down; otherwise, <c>false</c>.</value>
        public bool IsHoldingDown { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is holding left.
        /// </summary>
        /// <value><c>true</c> if this instance is holding left; otherwise, <c>false</c>.</value>
        public bool IsHoldingLeft { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is holding right.
        /// </summary>
        /// <value><c>true</c> if this instance is holding right; otherwise, <c>false</c>.</value>
        public bool IsHoldingRight { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is holding space.
        /// </summary>
        /// <value><c>true</c> if this instance is holding space; otherwise, <c>false</c>.</value>
        public bool IsHoldingSpace { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is holding up.
        /// </summary>
        /// <value><c>true</c> if this instance is holding up; otherwise, <c>false</c>.</value>
        public bool IsHoldingUp { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is mod.
        /// </summary>
        /// <value><c>true</c> if this instance is mod; otherwise, <c>false</c>.</value>
        public bool IsMod { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is owner.
        /// </summary>
        /// <value><c>true</c> if this instance is owner; otherwise, <c>false</c>.</value>
        public bool IsOwner
        {
            get
            {
                return this.PlayingIn.Owner.Name == this.Name;
            }
        }

        /// <summary>
        ///     The level of the player (in terms of xp).
        /// </summary>
        /// <value>The level.</value>
        public int Level { get; set; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return this._name;
            }

            internal set
            {
                this._name = value.ToLower();
            }
        }

        /// <summary>
        ///     Gets the playing in.
        /// </summary>
        /// <value>The playing in.</value>
        public Room PlayingIn { get; internal set; }

        /// <summary>
        ///     Gets the potion effects.
        /// </summary>
        /// <value>The potion effects.</value>
        public List<int> PotionEffects { get; internal set; }

        /// <summary>
        ///     Gets or sets value indicating whether this player should have accurate player coordinates.
        /// </summary>
        public bool ShouldTick { get; set; }

        /// <summary>
        ///     Gets the smiley.
        /// </summary>
        /// <value>The smiley.</value>
        public int Smiley { get; internal set; }

        /// <summary>
        ///     The x position
        /// </summary>
        public double X { get; internal set; }

        /// <summary>
        ///     The y position
        /// </summary>
        public double Y { get; internal set; }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the position x.
        /// </summary>
        /// <value>The position x.</value>
        internal double PosX
        {
            get
            {
                return this.X + 8;
            }
        }

        /// <summary>
        ///     Gets the position y.
        /// </summary>
        /// <value>The position y.</value>
        internal double PosY
        {
            get
            {
                return this.Y + 8;
            }
        }

        /// <summary>
        ///     Gets or sets the modifier x.
        /// </summary>
        /// <value>The modifier x.</value>
        internal double modifierX
        {
            get
            {
                return this.ModifierX * this._mult;
            }

            set
            {
                this.ModifierX = value / this._mult;
            }
        }

        /// <summary>
        ///     Gets or sets the modifier y.
        /// </summary>
        /// <value>The modifier y.</value>
        internal double modifierY
        {
            get
            {
                return this.ModifierY * this._mult;
            }

            set
            {
                this.ModifierY = value / this._mult;
            }
        }

        /// <summary>
        ///     Gets or sets the speed x.
        /// </summary>
        /// <value>The speed x.</value>
        internal double speedX
        {
            get
            {
                return this.SpeedX * this._mult;
            }

            set
            {
                this.SpeedX = value / this._mult;
            }
        }

        /// <summary>
        ///     Gets or sets the speed y.
        /// </summary>
        /// <value>The speed y.</value>
        internal double speedY
        {
            get
            {
                return this.SpeedY * this._mult;
            }

            set
            {
                this.SpeedY = value / this._mult;
            }
        }

        /// <summary>
        ///     Whether or not the player is able to use the chat box for
        ///     free form chat messages.
        /// </summary>
        /// <value><c>true</c> if this instance has chat; otherwise, <c>false</c>.</value>
        private bool HasChat { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this instance has club.
        /// </summary>
        /// <value><c>true</c> if this instance has club; otherwise, <c>false</c>.</value>
        private bool HasClub { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is friend.
        /// </summary>
        /// <value><c>true</c> if this instance is friend; otherwise, <c>false</c>.</value>
        private bool IsFriend { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="Player" /> is levitation.
        /// </summary>
        /// <value><c>true</c> if levitation; otherwise, <c>false</c>.</value>
        private bool Levitation { get; set; }

        /// <summary>
        ///     Gets the block x.
        /// </summary>
        /// <value>The block x.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        private int blockX
        {
            get
            {
                return (int)Math.Round(this.X / 16.0);
            }
        }

        /// <summary>
        ///     Gets the block y.
        /// </summary>
        /// <value>The block y.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        private int blockY
        {
            get
            {
                return (int)Math.Round(this.Y / 16.0);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Ticks this instance.
        /// </summary>
        public void Tick()
        {
            this._animoffset = this._animoffset + 0.2;
            if (this.IsMod && !this.IsGod)
            {
                this._modoffset = this._modoffset + 0.2;
                if (this._modoffset >= 16)
                {
                    this._modoffset = 10;
                }
            }
            else if (this.HasClub)
            {
                this._cluboffset = this._cluboffset + 0.2;
                if (this._cluboffset >= 14)
                {
                    this._cluboffset = 0;
                }
            }
            else
            {
                this._modoffset = 0;
            }

            if (this._isDead)
            {
                this._deadoffset = this._deadoffset + 0.3;
            }
            else
            {
                this._deadoffset = 0;
            }

            this._cx = (int)((this.X + 8) / 16);
            this._cy = (int)((this.Y + 8) / 16);
            int delayed = 0;
            if (this._queue.Count >= 1)
            {
                delayed = this._queue.Dequeue();
            }

            this.CurrentBlockId = this.PlayingIn.Map[this._cx, this._cy, 0].Id;
            this._queue.Enqueue(this.CurrentBlockId);
            if (this.CurrentBlockId == 4 || ItemId.IsClimbable(this.CurrentBlockId))
            {
                delayed = this._queue.Dequeue();
                this._queue.Enqueue(this.CurrentBlockId);
            }

            if (this._isDead)
            {
                this.Horizontal = 0;
                this.Vertical = 0;
                this._spacejustdown = false;
            }

            this._isgodmod = this.IsGod || this.IsMod;
            if (this._isgodmod)
            {
                this._morx = 0;
                this._mory = 0;
                this._oldHorizontalAcceleration = 0;
                this._oldVerticalAcceleration = 0;
            }
            else
            {
                switch (this.CurrentBlockId)
                {
                    case 1:
                        {
                            this._morx = -(int)this.Gravity;
                            this._mory = 0;
                            break;
                        }

                    case 2:
                        {
                            this._morx = 0;
                            this._mory = -(int)this.Gravity;
                            break;
                        }

                    case 3:
                        {
                            this._morx = (int)this.Gravity;
                            this._mory = 0;
                            break;
                        }

                    case BlockIds.Action.Boost.Left:
                    case BlockIds.Action.Boost.Right:
                    case BlockIds.Action.Boost.Up:
                    case BlockIds.Action.Boost.Down:
                    case BlockIds.Action.Ladders.Chain:
                    case BlockIds.Action.Ladders.Ladder:
                    case BlockIds.Action.Ladders.Horizontalvine:
                    case BlockIds.Action.Ladders.Verticalvine:
                    case BlockIds.Action.Gravity.Zero:
                        {
                            this._morx = 0;
                            this._mory = 0;
                            break;
                        }

                    case BlockIds.Action.Liquids.Water:
                        {
                            this._morx = 0;
                            this._mory = (int)this.WaterBuoyancy;
                            break;
                        }

                    case BlockIds.Action.Liquids.Mud:
                        {
                            this._morx = 0;
                            this._mory = (int)this.MudBuoyancy;
                            break;
                        }

                    case BlockIds.Action.Hazards.Fire:
                    case BlockIds.Action.Hazards.Spike:
                        {
                            if (!this._isDead && !this._isInvulnerable)
                            {
                                // KillPlayer(); // this line has problems.
                            }

                            break;
                        }

                    default:
                        {
                            this._morx = 0;
                            this._mory = (int)this.Gravity;
                            break;
                        }
                }

                switch (delayed)
                {
                    case 1:
                        {
                            this._oldHorizontalAcceleration = -this.Gravity;
                            this._oldVerticalAcceleration = 0;
                            break;
                        }

                    case 2:
                        {
                            this._oldHorizontalAcceleration = 0;
                            this._oldVerticalAcceleration = -this.Gravity;
                            break;
                        }

                    case 3:
                        {
                            this._oldHorizontalAcceleration = this.Gravity;
                            this._oldVerticalAcceleration = 0;
                            break;
                        }

                    case BlockIds.Action.Boost.Left:
                    case BlockIds.Action.Boost.Right:
                    case BlockIds.Action.Boost.Up:
                    case BlockIds.Action.Boost.Down:
                    case BlockIds.Action.Ladders.Chain:
                    case BlockIds.Action.Ladders.Ladder:
                    case BlockIds.Action.Ladders.Horizontalvine:
                    case BlockIds.Action.Ladders.Verticalvine:
                    case BlockIds.Action.Gravity.Zero:
                        {
                            this._oldHorizontalAcceleration = 0;
                            this._oldVerticalAcceleration = 0;
                            break;
                        }

                    case BlockIds.Action.Liquids.Water:
                        {
                            this._oldHorizontalAcceleration = 0;
                            this._oldVerticalAcceleration = this.WaterBuoyancy;
                            break;
                        }

                    case BlockIds.Action.Liquids.Mud:
                        {
                            this._oldHorizontalAcceleration = 0;
                            this._oldVerticalAcceleration = this.MudBuoyancy;
                            break;
                        }

                    default:
                        {
                            this._oldHorizontalAcceleration = 0;
                            this._oldVerticalAcceleration = this.Gravity;
                            break;
                        }
                }
            }

            if (Math.Abs(this._oldVerticalAcceleration - this.WaterBuoyancy) < 0.00000001
                || Math.Abs(this._oldVerticalAcceleration - this.MudBuoyancy) < 0.00000001)
            {
                this._horizontalAcceleration = this.Horizontal;
                this._verticalAcceleration = this.Vertical;
            }
            else if (Math.Abs(this._oldVerticalAcceleration) > 0.00000001)
            {
                this._horizontalAcceleration = this.Horizontal;
                this._verticalAcceleration = 0;
            }
            else if (Math.Abs(this._oldHorizontalAcceleration) > 0.00000001)
            {
                this._horizontalAcceleration = 0;
                this._verticalAcceleration = this.Vertical;
            }
            else
            {
                this._horizontalAcceleration = this.Horizontal;
                this._verticalAcceleration = this.Vertical;
            }

            this._horizontalAcceleration = this._horizontalAcceleration * this.SpeedMultiplier();
            this._verticalAcceleration = this._verticalAcceleration * this.SpeedMultiplier();
            this._oldHorizontalAcceleration = this._oldHorizontalAcceleration * GravityMultiplier;
            this._oldVerticalAcceleration = this._oldVerticalAcceleration * GravityMultiplier;
            this.modifierX = this._oldHorizontalAcceleration + this._horizontalAcceleration;

            this.modifierY = this._oldVerticalAcceleration + this._verticalAcceleration;
            if (Math.Abs(this.SpeedX) > 0.00000001 || Math.Abs(this.ModifierX) > 0.00000001)
            {
                this.SpeedX = this.SpeedX + this.ModifierX;
                this.SpeedX = this.SpeedX * Config.PhysicsBaseDrag;
                if (Math.Abs(this._horizontalAcceleration) < 0.00000001
                    && Math.Abs(this._oldVerticalAcceleration) > 0.00000001
                    || this.SpeedX < 0 && this._horizontalAcceleration > 0
                    || this.SpeedX > 0 && this._horizontalAcceleration < 0
                    || ItemId.IsClimbable(this.CurrentBlockId) && !this._isgodmod)
                {
                    this.SpeedX = this.SpeedX * this.NoModifierDragX;
                }
                else if (this.CurrentBlockId == BlockIds.Action.Liquids.Water && !this._isgodmod)
                {
                    this.SpeedX = this.SpeedX * this.WaterDrag;
                }
                else if (this.CurrentBlockId == BlockIds.Action.Liquids.Mud && !this._isgodmod)
                {
                    this.SpeedX = this.SpeedX * this.DragMud();
                }

                if (this.SpeedX > 16)
                {
                    this.SpeedX = 16;
                }
                else if (this.SpeedX < -16)
                {
                    this.SpeedX = -16;
                }
                else if (this.SpeedX < 0.0001 && this.SpeedX > -0.0001)
                {
                    this.SpeedX = 0;
                }
            }

            if (Math.Abs(this.SpeedY) > 0.00000001 || Math.Abs(this.ModifierY) > 0.00000001)
            {
                this.SpeedY = this.SpeedY + this.ModifierY;
                this.SpeedY = this.SpeedY * Config.PhysicsBaseDrag;
                if (Math.Abs(this._verticalAcceleration) < 0.00000001
                    && Math.Abs(this._oldHorizontalAcceleration) > 0.00000001
                    || this.SpeedY < 0 && this._verticalAcceleration > 0
                    || this.SpeedY > 0 && this._verticalAcceleration < 0
                    || ItemId.IsClimbable(this.CurrentBlockId) && !this._isgodmod)
                {
                    this.SpeedY = this.SpeedY * this.NoModifierDragY;
                }
                else if (this.CurrentBlockId == BlockIds.Action.Liquids.Water && !this._isgodmod)
                {
                    this.SpeedY = this.SpeedY * this.WaterDrag;
                }
                else if (this.CurrentBlockId == BlockIds.Action.Liquids.Mud && !this._isgodmod)
                {
                    this.SpeedY = this.SpeedY * this.DragMud();
                }

                if (this.SpeedY > 16)
                {
                    this.SpeedY = 16;
                }
                else if (this.SpeedY < -16)
                {
                    this.SpeedY = -16;
                }
                else if (this.SpeedY < 0.0001 && this.SpeedY > -0.0001)
                {
                    this.SpeedY = 0;
                }
            }

            if (!this._isgodmod)
            {
                switch (this.CurrentBlockId)
                {
                    case BlockIds.Action.Boost.Left:
                        {
                            this.SpeedX = -this.Boost;
                            break;
                        }

                    case BlockIds.Action.Boost.Right:
                        {
                            this.SpeedX = this.Boost;
                            break;
                        }

                    case BlockIds.Action.Boost.Up:
                        {
                            this.SpeedY = -this.Boost;
                            break;
                        }

                    case BlockIds.Action.Boost.Down:
                        {
                            this.SpeedY = this.Boost;
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
            }

            this._reminderX = this.X % 1;
            this._currentSx = this.SpeedX;
            this._reminderY = this.Y % 1;
            this._currentSy = this.SpeedY;
            this._donex = false;
            this._doney = false;
            while (Math.Abs(this._currentSx) > 0.00000001 && !this._donex
                   || Math.Abs(this._currentSy) > 0.00000001 && !this._doney)
            {
                this.ProcessPortals();
                this._ox = this.X;
                this._oy = this.Y;
                this._osx = this._currentSx;
                this._osy = this._currentSy;
                this.Stepx();
                this.Stepy();
            }

            if (this.Levitation)
            {
                this.UpdateThrust();
            }

            double imx = this.SpeedX * 256;
            double imy = this.SpeedY * 256;
            if (Math.Abs(imx) > 0.00000001 || this.CurrentBlockId == BlockIds.Action.Liquids.Water
                || this.CurrentBlockId == BlockIds.Action.Liquids.Mud)
            {
            }
            else if (this.ModifierX < 0.1 && this.ModifierX > -0.1)
            {
                this._tx = this.X % 16;
                if (this._tx < 2)
                {
                    if (this._tx < 0.2)
                    {
                        this.X = Math.Floor(this.X);
                    }
                    else
                    {
                        this.X = this.X - this._tx / 15;
                    }
                }
                else if (this._tx > 14)
                {
                    if (this._tx > 15.8)
                    {
                        this.X = Math.Floor(this.X);
                        double loc3 = this.X + 1;
                        this.X = loc3;
                    }
                    else
                    {
                        this.X = this.X + (this._tx - 14) / 15;
                    }
                }
            }

            if (Math.Abs(imy) > 0.0000001 || this.CurrentBlockId == BlockIds.Action.Liquids.Water
                || this.CurrentBlockId == BlockIds.Action.Liquids.Mud)
            {
            }
            else if (this.ModifierY < 0.1 && this.ModifierY > -0.1)
            {
                this._ty = this.Y % 16;
                if (this._ty < 2)
                {
                    if (this._ty < 0.2)
                    {
                        this.Y = Math.Floor(this.Y);
                    }
                    else
                    {
                        this.Y = this.Y - this._ty / 15;
                    }
                }
                else if (this._ty > 14)
                {
                    if (this._ty > 15.8)
                    {
                        this.Y = Math.Floor(this.Y);
                        double loc3 = this.Y + 1;
                        this.Y = loc3;
                    }
                    else
                    {
                        this.Y = this.Y + (this._ty - 14) / 15;
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Drags the mud.
        /// </summary>
        /// <returns>System.Double.</returns>
        private double DragMud()
        {
            return this.MudDrag;
        }

        /// <summary>
        /// Hits the test.
        /// </summary>
        /// <param name="param1">
        /// The param1.
        /// </param>
        /// <param name="param2">
        /// The param2.
        /// </param>
        /// <returns>
        /// <c>true</c> if XXXX, <c>false</c> otherwise.
        /// </returns>
        private bool HitTest(int param1, int param2)
        {
            return param1 >= this.X && param2 >= this.Y && param1 <= this.X + this.Size && param2 <= this.Y + this.Size;
        }

        /// <summary>
        /// Overlapses the specified player.
        /// </summary>
        /// <param name="player">
        /// The player.
        /// </param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        private int Overlaps(Player player)
        {
            if (player.X < 0 || player.Y < 0 || player.X >= this.PlayingIn.Width * 16 - 8
                || player.Y >= this.PlayingIn.Height * 16 - 8)
            {
                return 1;
            }

            Player loc2 = this;

            if (loc2.IsGod || loc2.IsMod)
            {
                return 0;
            }

            double loc3 = (loc2.X) / 16;
            double loc4 = (loc2.Y) / 16;
            for (int xx = -2; xx < 1; xx++)
            {
                for (int yy = -2; yy < 1; yy++)
                {
                    if (loc3 + xx > 0 && loc3 + xx < this.PlayingIn.Width && loc4 + yy > 0
                        && loc4 + yy <= this.PlayingIn.Height)
                    {
                        for (int xTest = 0; xTest < 16; xTest++)
                        {
                            for (int yTest = 0; yTest < 16; yTest++)
                            {
                                if (!this.HitTest((int)(xTest + loc2.X + xx * 16), (int)(yTest + loc2.Y + yy * 16)))
                                {
                                    continue;
                                }

                                double loc9 = loc4;
                                Block currentBlock =
                                    this.PlayingIn.Map[
                                        (int)(((xx * 16) + loc2.X + xTest) / 16), 
                                        (int)(((yy * 16) + loc2.Y + yTest) / 16), 
                                        0];
                                int loc11 = currentBlock.Id;
                                if (!ItemId.IsSolid(loc11))
                                {
                                    continue;
                                }

                                switch (loc11)
                                {
                                    case 23:
                                        {
                                            if (this.PlayingIn.RedActivated)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case 24:
                                        {
                                            if (this.PlayingIn.GreenActivated)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case 25:
                                        {
                                            if (this.PlayingIn.BlueActivated)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case 26:
                                        {
                                            if (!this.PlayingIn.RedActivated)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case 27:
                                        {
                                            if (!this.PlayingIn.GreenActivated)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case 28:
                                        {
                                            if (!this.PlayingIn.BlueActivated)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case 156:
                                        {
                                            if (this.PlayingIn.TimeDoorsVisible)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case 157:
                                        {
                                            if (!this.PlayingIn.TimeDoorsVisible)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case BlockIds.Action.Doors.Switch:
                                        {
                                            if (this.SwitchOpened)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case BlockIds.Action.Gates.Switch:
                                        {
                                            if (!this.SwitchOpened)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case BlockIds.Action.Doors.Club:
                                        {
                                            if (this.HasClub)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case BlockIds.Action.Gates.Club:
                                        {
                                            if (!this.HasClub)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case BlockIds.Action.Doors.Coin:
                                        {
                                            if (currentBlock is CoinBlock
                                                && ((CoinBlock)currentBlock).CoinsRequired <= this.Coins)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case BlockIds.Action.Gates.Coin:
                                        {
                                            if (currentBlock is CoinBlock
                                                && ((CoinBlock)currentBlock).CoinsRequired > this.Coins)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case BlockIds.Action.Gates.Zombie:
                                        {
                                            if (this._isZombie)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case BlockIds.Action.Doors.Zombie:
                                        {
                                            if (!this._isZombie)
                                            {
                                                continue;
                                            }

                                            break;
                                        }

                                    case 50:
                                        {
                                            break;
                                        }

                                    case 61:
                                    case 62:
                                    case 63:
                                    case 64:
                                    case 89:
                                    case 90:
                                    case 91:
                                    case 96:
                                    case 97:
                                    case 122:
                                    case 123:
                                    case 124:
                                    case 125:
                                    case 126:
                                    case 127:
                                    case 146:
                                    case 154:
                                    case 158:
                                    case 194:
                                        {
                                            if (loc2.speedY < 0 || loc9 <= loc2._overlapy)
                                            {
                                                if (Math.Abs(loc9 - loc4) > 0.00000001 || loc2._overlapy == -1)
                                                {
                                                    loc2._overlapy = (int)loc9;
                                                }
                                            }

                                            break;
                                        }

                                    case 83:
                                    case 77:
                                        {
                                            continue;
                                        }

                                    default:
                                        {
                                            break;
                                        }
                                }

                                return loc11;
                            }
                        }
                    }
                }
            }

            return 0;
        }

        /// <summary>
        ///     Processes the portals.
        /// </summary>
        private void ProcessPortals()
        {
            var targetPortalList = new List<Point>();
            this.CurrentBlockId = this.PlayingIn.Map[this._cx, this._cy, 0].Id;
            if (!this._isgodmod && this.CurrentBlockId == BlockIds.Action.Portals.World)
            {
                if (this._spacejustdown)
                {
                }
            }

            if (!this._isgodmod && this.CurrentBlockId == 242)
            {
                if (this._lastPortal.X == 0 && this._lastPortal.Y == 0)
                {
                    this._lastPortal = new Point(this._cx << 4, this._cy << 4);

                    Block currentBlock = this.PlayingIn.Map[this._cx, this._cy, 0];
                    var currentPortalBlock = (PortalBlock)currentBlock;
                    int currentTarget = currentPortalBlock.PortalDestination;

                    for (int x = 1; x < this.PlayingIn.Width; x++)
                    {
                        for (int y = 1; y < this.PlayingIn.Height; y++)
                        {
                            Block block = this.PlayingIn.Map[x, y, 0];
                            if (block is PortalBlock && ((PortalBlock)block).PortalId == currentTarget)
                            {
                                targetPortalList.Add(new Point(x << 4, y << 4));
                            }
                        }
                    }

                    const int loopIterator = 0;
                    while (loopIterator < targetPortalList.Count)
                    {
                        Point currentLoopPortal = targetPortalList[loopIterator];
                        int loc4 = this.PlayingIn.Map[this._lastPortal.X >> 4, this._lastPortal.Y >> 4, 0].Direction;
                        int loc5 = this.PlayingIn.Map[currentLoopPortal.X >> 4, currentLoopPortal.Y >> 4, 0].Direction;
                        if (loc4 < loc5)
                        {
                            loc4 = loc4 + 4;
                        }

                        double loc6 = this.speedX;
                        double loc7 = this.speedY;
                        double loc8 = this.modifierX;
                        double loc9 = this.modifierY;
                        int loc10 = loc4 - loc5;
                        const double loc11 = 1.42;
                        switch (loc10)
                        {
                            case 1:
                                {
                                    this.speedX = loc7 * loc11;
                                    this.speedY = (-loc6) * loc11;
                                    this.modifierX = loc9 * loc11;
                                    this.modifierY = (-loc8) * loc11;
                                    this._reminderY = -this._reminderY;
                                    this._currentSy = -this._currentSy;
                                    break;
                                }

                            case 3:
                                {
                                    this.speedX = (-loc7) * loc11;
                                    this.speedY = loc6 * loc11;
                                    this.modifierX = (-loc9) * loc11;
                                    this.modifierY = loc8 * loc11;
                                    this._reminderX = -this._reminderX;
                                    this._currentSx = -this._currentSx;
                                    break;
                                }

                            case 2:
                                {
                                    this.speedX = (-loc6) * loc11;
                                    this.speedY = (-loc7) * loc11;
                                    this.modifierX = (-loc8) * loc11;
                                    this.modifierY = (-loc9) * loc11;
                                    this._reminderY = -this._reminderY;
                                    this._currentSy = -this._currentSy;
                                    this._reminderX = -this._reminderX;
                                    this._currentSx = -this._currentSx;
                                    break;
                                }

                            default:
                                {
                                    break;
                                }
                        }

                        this.X = currentLoopPortal.X;
                        this.Y = currentLoopPortal.Y;
                        this._lastPortal = currentLoopPortal;
                        break;
                    }
                }
            }
            else
            {
                this._lastPortal = new Point(0, 0);
            }
        }

        /// <summary>
        ///     Resets the coins.
        /// </summary>
        private void ResetCoins()
        {
            this.Coins = 0;
            this.BlueCoins = 0;
        }

        /// <summary>
        ///     Speeds the multiplier.
        /// </summary>
        /// <returns>System.Double.</returns>
        private double SpeedMultiplier()
        {
            double loc1 = 1;
            if (this.Zombie())
            {
                loc1 = loc1 * 0.6;
            }

            return loc1;
        }

        /// <summary>
        ///     Stepxes this instance.
        /// </summary>
        private void Stepx()
        {
            if (this._currentSx > 0)
            {
                if (this._currentSx + this._reminderX >= 1)
                {
                    this.X = this.X + (1 - this._reminderX);
                    this.X = Math.Floor(this.X);
                    this._currentSx = this._currentSx - (1 - this._reminderX);
                    this._reminderX = 0;
                }
                else
                {
                    this.X = this.X + this._currentSx;
                    this._currentSx = 0;
                }
            }
            else if (this._currentSx < 0)
            {
                if (Math.Abs(this._reminderX) > 0.00000001 && this._reminderX + this._currentSx < 0)
                {
                    this._currentSx = this._currentSx + this._reminderX;
                    this.X = this.X - this._reminderX;
                    this.X = Math.Floor(this.X);
                    this._reminderX = 1;
                }
                else
                {
                    this.X = this.X + this._currentSx;
                    this._currentSx = 0;
                }
            }

            if (this.Overlaps(this) != 0)
            {
                this.X = this._ox;
                this.SpeedX = 0;
                this._currentSx = this._osx;
                this._donex = true;
            }
        }

        /// <summary>
        ///     Stepies this instance.
        /// </summary>
        private void Stepy()
        {
            if (this._currentSy > 0)
            {
                if (this._currentSy + this._reminderY >= 1)
                {
                    this.Y = this.Y + (1 - this._reminderY);
                    this.Y = Math.Floor(this.Y);
                    this._currentSy = this._currentSy - (1 - this._reminderY);
                    this._reminderY = 0;
                }
                else
                {
                    this.Y = this.Y + this._currentSy;
                    this._currentSy = 0;
                }
            }
            else if (this._currentSy < 0)
            {
                if (Math.Abs(this._reminderY) > 0.00000001 && this._reminderY + this._currentSy < 0)
                {
                    this.Y = this.Y - this._reminderY;
                    this.Y = Math.Floor(this.Y);
                    this._currentSy = this._currentSy + this._reminderY;
                    this._reminderY = 1;
                }
                else
                {
                    this.Y = this.Y + this._currentSy;
                    this._currentSy = 0;
                }
            }

            if (this.Overlaps(this) != 0)
            {
                this.Y = this._oy;
                this.SpeedY = 0;
                this._currentSy = this._osy;
                this._doney = true;
            }
        }

        /// <summary>
        ///     Updates the thrust.
        /// </summary>
        private void UpdateThrust()
        {
            if (this._mory != 0)
            {
                this.speedY = this.speedY - this._currentThrust * (Config.PhysicsJumpHeight / 2) * (this._mory * 0.5);
            }

            if (this._morx != 0)
            {
                this.speedX = this.speedX - this._currentThrust * (Config.PhysicsJumpHeight / 2) * (this._morx * 0.5);
            }

            if (this._isThrusting)
            {
                return;
            }

            this._currentThrust = this._currentThrust > 0 ? this._currentThrust - ThrustBurnOff : 0;
        }

        /// <summary>
        ///     Zombies this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool Zombie()
        {
            return !this.IsGod && !this.IsMod && this._isZombie;
        }

        #endregion
    }
}