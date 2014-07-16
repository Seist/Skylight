// <author>TakoMan02</author>
// <summary>Player.cs describes a singular player in an EE world.</summary>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Skylight.Blocks;
using Skylight.Physics;

namespace Skylight
{
    /// <summary>
    /// Class Player.
    /// </summary>
    public class Player
    {
        // Private instance fields
        /// <summary>
        /// The admins
        /// </summary>
        private static readonly List<string> Admins = new List<string>
        {
            "benjaminsen",
            "cyclone",
            "toby",
            "rpgmaster2000",
            "mrshoe",
            "mrvoid"
        };

        /// <summary>
        /// The _mult
        /// </summary>
        private readonly double _mult;
        /// <summary>
        /// The _queue
        /// </summary>
        private readonly Queue<int> _queue = new Queue<int>();
        /// <summary>
        /// The _touchpotions
        /// </summary>
        private readonly Dictionary<string, int> _touchpotions = new Dictionary<string, int>();
        /// <summary>
        /// The _horizontal acceleration
        /// </summary>
        private double _horizontalAcceleration;
        /// <summary>
        /// The _old horizontal acceleration
        /// </summary>
        private double _oldHorizontalAcceleration;
        /// <summary>
        /// The _old vertical acceleration
        /// </summary>
        private double _oldVerticalAcceleration;
        /// <summary>
        /// The switch opened
        /// </summary>
        public bool SwitchOpened = false;
        /// <summary>
        /// The _vertical acceleration
        /// </summary>
        private double _verticalAcceleration;
        /// <summary>
        /// The x
        /// </summary>
        public double X = 0;
        /// <summary>
        /// The y
        /// </summary>
        public double Y = 0;
        /// <summary>
        /// The boost
        /// </summary>
        protected double Boost;
        /// <summary>
        /// The _current thrust
        /// </summary>
        private double _currentThrust;
        /// <summary>
        /// The gravity
        /// </summary>
        protected double Gravity;
        /// <summary>
        /// The _is flaunting
        /// </summary>
        private bool _isFlaunting;
        /// <summary>
        /// The _is invulnerable
        /// </summary>
        private bool _isInvulnerable;
        /// <summary>
        /// The _is thrusting
        /// </summary>
        private bool _isThrusting;
        /// <summary>
        /// The maximum thrust
        /// </summary>
        private const double MaxThrust = 0.2;
        /// <summary>
        /// The modifier x
        /// </summary>
        protected double ModifierX = 0;
        /// <summary>
        /// The modifier y
        /// </summary>
        protected double ModifierY = 0;
        /// <summary>
        /// The mud buoyancy
        /// </summary>
        protected double MudBuoyancy;
        /// <summary>
        /// The mud drag
        /// </summary>
        protected double MudDrag;
        /// <summary>
        /// The no modifier drag x
        /// </summary>
        protected double NoModifierDragX;
        /// <summary>
        /// The no modifier drag y
        /// </summary>
        protected double NoModifierDragY;
        /// <summary>
        /// The speed x
        /// </summary>
        protected double SpeedX = 0;
        /// <summary>
        /// The speed y
        /// </summary>
        protected double SpeedY = 0;
        /// <summary>
        /// The thrust burn off
        /// </summary>
        private const double ThrustBurnOff = 0.01;
        /// <summary>
        /// The water buoyancy
        /// </summary>
        protected double WaterBuoyancy;
        /// <summary>
        /// The water drag
        /// </summary>
        protected double WaterDrag;
        /// <summary>
        /// The _animoffset
        /// </summary>
        private double _animoffset;

        /// <summary>
        /// The _blue coins
        /// </summary>
        private int
            _blueCoins;

        /// <summary>
        /// The checkpoint_x
        /// </summary>
        public int CheckpointX = -1;
        /// <summary>
        /// The checkpoint_y
        /// </summary>
        public int CheckpointY = -1;
        /// <summary>
        /// The _cluboffset
        /// </summary>
        private double _cluboffset;

        /// <summary>
        /// The _coins
        /// </summary>
        private int
            _coins, _collectedMagic;

        /// <summary>
        /// The current block identifier
        /// </summary>
        public int CurrentBlockId = 0;
        /// <summary>
        /// The _current sx
        /// </summary>
        private double _currentSx;
        /// <summary>
        /// The _current sy
        /// </summary>
        private double _currentSy;
        /// <summary>
        /// The _CX
        /// </summary>
        private int _cx;
        /// <summary>
        /// The _cy
        /// </summary>
        private int _cy;
        /// <summary>
        /// The _deadoffset
        /// </summary>
        private double _deadoffset;

        /// <summary>
        /// The _death count
        /// </summary>
        private int
            _deathCount;

        /// <summary>
        /// The _donex
        /// </summary>
        private bool _donex;
        /// <summary>
        /// The _doney
        /// </summary>
        private bool _doney;
        /// <summary>
        /// The gravity multiplier
        /// </summary>
        private const double GravityMultiplier = 1;

        /// <summary>
        /// The _has access
        /// </summary>
        private bool
            _hasAccess, _hasBoost;

        /// <summary>
        /// The _has club
        /// </summary>
        private bool
            _hasClub, _hasCommandAccess, _hasCrown, _hasGravityModifier, _hasSilverCrown;

        /// <summary>
        /// The horizontal
        /// </summary>
        internal int Horizontal = 0;

        /// <summary>
        /// The _id
        /// </summary>
        private int
            _id = -1;

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
        /// The _is dead
        /// </summary>
        private bool _isDead;

        /// <summary>
        /// The _is friend
        /// </summary>
        private bool
            _isFriend, _isGod, _isHoldingDown, _isHoldingLeft, _isHoldingRight;

        /// <summary>
        /// The _is holding space
        /// </summary>
        private bool
            _isHoldingSpace;

        /// <summary>
        /// The _is holding up
        /// </summary>
        private bool
            _isHoldingUp;

        /// <summary>
        /// The _is mod
        /// </summary>
        private bool
            _isMod,
            /// <summary>
            /// The is owner
            /// </summary>
            isOwner; // never used

        /// <summary>
        /// The _is zombie
        /// </summary>
        private bool _isZombie;
        /// <summary>
        /// The isclubmember
        /// </summary>
        public bool isclubmember = false;
        /// <summary>
        /// The _isgodmod
        /// </summary>
        private bool _isgodmod;
        /// <summary>
        /// The jump boost
        /// </summary>
        private const bool JumpBoost = false;
        /// <summary>
        /// The _last portal
        /// </summary>
        private Point _lastPortal;
        /// <summary>
        /// The _last respawn
        /// </summary>
        private double _lastRespawn;
        /// <summary>
        /// The level
        /// </summary>
        private int level = 1; // never used
/*
        private int mod = 0;
*/
        /// <summary>
        /// The _modoffset
        /// </summary>
        private double _modoffset;
        /// <summary>
        /// The _morx
        /// </summary>
        private int _morx;
        /// <summary>
        /// The _mory
        /// </summary>
        private int _mory;
        /// <summary>
        /// The moving
        /// </summary>
        private bool moving; // never used
        /// <summary>
        /// The _name
        /// </summary>
        private string _name;
        /// <summary>
        /// The _old x
        /// </summary>
        private double _oldX = -1;
        /// <summary>
        /// The _old y
        /// </summary>
        private double _oldY = -1;
        /// <summary>
        /// The _osx
        /// </summary>
        private double _osx;
        /// <summary>
        /// The _osy
        /// </summary>
        private double _osy;
        /// <summary>
        /// The _overlapy
        /// </summary>
        private int _overlapy;
        /// <summary>
        /// The _ox
        /// </summary>
        private double _ox;
        /// <summary>
        /// The _oy
        /// </summary>
        private double _oy;
        /// <summary>
        /// The _playing in
        /// </summary>
        private Room _playingIn;
        /// <summary>
        /// The _potion effects
        /// </summary>
        private List<int> _potionEffects = new List<int>();
        /// <summary>
        /// The _reminder x
        /// </summary>
        private double _reminderX;
        /// <summary>
        /// The _reminder y
        /// </summary>
        private double _reminderY;
        /// <summary>
        /// The size
        /// </summary>
        protected int Size;

        /// <summary>
        /// The _smiley
        /// </summary>
        private int
            _smiley;

        /// <summary>
        /// The _spacejustdown
        /// </summary>
        private bool _spacejustdown;
        /// <summary>
        /// The _TX
        /// </summary>
        private double _tx;
        /// <summary>
        /// The _ty
        /// </summary>
        private double _ty;
        /// <summary>
        /// The vertical
        /// </summary>
        internal int Vertical = 0;
        /// <summary>
        /// The worldportalsend
        /// </summary>
        private const bool worldportalsend = false; // never used

        /// <summary>
        /// The _XP level
        /// </summary>
        private int
            _xpLevel;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="room">The room.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="smiley">The smiley.</param>
        /// <param name="xPos">The x position.</param>
        /// <param name="yPos">The y position.</param>
        /// <param name="isGod">if set to <c>true</c> [is god].</param>
        /// <param name="isMod">if set to <c>true</c> [is mod].</param>
        /// <param name="hasChat">if set to <c>true</c> [has chat].</param>
        /// <param name="coins">The coins.</param>
        /// <param name="purple">if set to <c>true</c> [purple].</param>
        /// <param name="isFriend">if set to <c>true</c> [is friend].</param>
        /// <param name="level">The level.</param>
        public Player(Room room, int id, string name, int smiley, double xPos, double yPos, bool isGod, bool isMod,
            bool hasChat, int coins, bool purple, bool isFriend, int level)
        {
            PlayingIn = room;
            Smiley = smiley;
            IsGod = isGod;
            IsMod = isMod;
            Id = id;
            Coins = coins;
            SwitchOpened = purple;
            _isFriend = isFriend;
            this.level = level;
            _queue = new Queue<int>(Config.physics_queue_length);
            _lastPortal = new Point();
            var rectangle = new Rectangle(0, 0, 64, 64);
            _currentThrust = MaxThrust;
            X = xPos;
            Y = yPos;
            Name = name;
            Size = 16;
            NoModifierDragX = Config.physics_no_modifier_drag;
            NoModifierDragY = Config.physics_no_modifier_drag;
            WaterDrag = Config.physics_water_drag;
            WaterBuoyancy = Config.physics_water_buoyancy;
            MudDrag = Config.physics_mud_drag;
            MudBuoyancy = Config.physics_mud_buoyancy;
            Boost = Config.physics_boost;
            Gravity = Config.physics_gravity;
            _mult = Config.physics_variable_multiplyer;
        }

        // Public instance properties.
        /// <summary>
        /// Gets a value indicating whether this instance has access.
        /// </summary>
        /// <value><c>true</c> if this instance has access; otherwise, <c>false</c>.</value>
        public bool HasAccess
        {
            get { return _hasAccess; }

            internal set { _hasAccess = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has boost.
        /// </summary>
        /// <value><c>true</c> if this instance has boost; otherwise, <c>false</c>.</value>
        public bool HasBoost
        {
            get { return _hasBoost; }

            internal set { _hasBoost = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has club.
        /// </summary>
        /// <value><c>true</c> if this instance has club; otherwise, <c>false</c>.</value>
        public bool HasClub
        {
            get { return _hasClub; }

            internal set { _hasClub = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has command access.
        /// </summary>
        /// <value><c>true</c> if this instance has command access; otherwise, <c>false</c>.</value>
        public bool HasCommandAccess
        {
            get { return _hasCommandAccess; }

            internal set { _hasCommandAccess = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has crown.
        /// </summary>
        /// <value><c>true</c> if this instance has crown; otherwise, <c>false</c>.</value>
        public bool HasCrown
        {
            get { return _hasCrown; }

            internal set { _hasCrown = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has gravity modifier.
        /// </summary>
        /// <value><c>true</c> if this instance has gravity modifier; otherwise, <c>false</c>.</value>
        public bool HasGravityModifier
        {
            get { return _hasGravityModifier; }

            internal set { _hasGravityModifier = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has silver crown.
        /// </summary>
        /// <value><c>true</c> if this instance has silver crown; otherwise, <c>false</c>.</value>
        public bool HasSilverCrown
        {
            get { return _hasSilverCrown; }

            internal set { _hasSilverCrown = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is bot.
        /// </summary>
        /// <value><c>true</c> if this instance is bot; otherwise, <c>false</c>.</value>
        public bool IsBot
        {
            get
            {
                if (PlayingIn != null)
                {
                    return PlayingIn.OnlineBots.Any(bt => bt.Id == Id);
                }

                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is friend.
        /// </summary>
        /// <value><c>true</c> if this instance is friend; otherwise, <c>false</c>.</value>
        public bool IsFriend
        {
            get { return _isFriend; }

            internal set { _isFriend = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is god.
        /// </summary>
        /// <value><c>true</c> if this instance is god; otherwise, <c>false</c>.</value>
        public bool IsGod
        {
            get { return _isGod; }

            internal set { _isGod = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is mod.
        /// </summary>
        /// <value><c>true</c> if this instance is mod; otherwise, <c>false</c>.</value>
        public bool IsMod
        {
            get { return _isMod; }

            internal set { _isMod = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is holding left.
        /// </summary>
        /// <value><c>true</c> if this instance is holding left; otherwise, <c>false</c>.</value>
        public bool IsHoldingLeft
        {
            get { return _isHoldingLeft; }

            internal set { _isHoldingLeft = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is holding right.
        /// </summary>
        /// <value><c>true</c> if this instance is holding right; otherwise, <c>false</c>.</value>
        public bool IsHoldingRight
        {
            get { return _isHoldingRight; }

            internal set { _isHoldingRight = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is holding up.
        /// </summary>
        /// <value><c>true</c> if this instance is holding up; otherwise, <c>false</c>.</value>
        public bool IsHoldingUp
        {
            get { return _isHoldingUp; }

            internal set { _isHoldingUp = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is holding down.
        /// </summary>
        /// <value><c>true</c> if this instance is holding down; otherwise, <c>false</c>.</value>
        public bool IsHoldingDown
        {
            get { return _isHoldingDown; }

            internal set { _isHoldingDown = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is holding space.
        /// </summary>
        /// <value><c>true</c> if this instance is holding space; otherwise, <c>false</c>.</value>
        public bool IsHoldingSpace
        {
            get { return _isHoldingSpace; }

            internal set { _isHoldingSpace = value; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is owner.
        /// </summary>
        /// <value><c>true</c> if this instance is owner; otherwise, <c>false</c>.</value>
        public bool IsOwner
        {
            get
            {
                if (PlayingIn.Owner == this)
                {
                    return true;
                }
                return false;
            }

            internal set { isOwner = value; }
        }

        /// <summary>
        /// Gets the coins.
        /// </summary>
        /// <value>The coins.</value>
        public int Coins
        {
            get { return _coins; }

            internal set { _coins = value; }
        }

        /// <summary>
        /// Gets the blue coins.
        /// </summary>
        /// <value>The blue coins.</value>
        public int BlueCoins
        {
            get { return _blueCoins; }
            internal set { _blueCoins = value; }
        }

        /// <summary>
        /// Gets the collected magic.
        /// </summary>
        /// <value>The collected magic.</value>
        public int CollectedMagic
        {
            get { return _collectedMagic; }

            internal set { _collectedMagic = value; }
        }

        /// <summary>
        /// Gets the death count.
        /// </summary>
        /// <value>The death count.</value>
        public int DeathCount
        {
            get { return _deathCount; }

            internal set { _deathCount = value; }
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get { return _id; }

            internal set { _id = value; }
        }

        /// <summary>
        /// Gets the smiley.
        /// </summary>
        /// <value>The smiley.</value>
        public int Smiley
        {
            get { return _smiley; }

            internal set { _smiley = value; }
        }

        /// <summary>
        /// Gets the xp level.
        /// </summary>
        /// <value>The xp level.</value>
        public int XpLevel
        {
            get { return _xpLevel; }

            internal set { _xpLevel = value; }
        }

        /// <summary>
        /// Gets the potion effects.
        /// </summary>
        /// <value>The potion effects.</value>
        public List<int> PotionEffects
        {
            get { return _potionEffects; }

            internal set { _potionEffects = value; }
        }

        /// <summary>
        /// Gets the playing in.
        /// </summary>
        /// <value>The playing in.</value>
        public Room PlayingIn
        {
            get { return _playingIn; }

            internal set { _playingIn = value; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return _name; }
            internal set { _name = value.ToLower(); }
        }

        /// <summary>
        /// Gets the block x.
        /// </summary>
        /// <value>The block x.</value>
        protected int blockX
        {
            get { return (int) Math.Round(((X)/16.0)); }
        }

        /// <summary>
        /// Gets the block y.
        /// </summary>
        /// <value>The block y.</value>
        protected int blockY
        {
            get { return (int) Math.Round((Y)/16.0); }
        }

        /// <summary>
        /// Gets the position x.
        /// </summary>
        /// <value>The position x.</value>
        internal double PosX
        {
            get { return (X + 8); }
        }

        /// <summary>
        /// Gets the position y.
        /// </summary>
        /// <value>The position y.</value>
        internal double PosY
        {
            get { return (Y + 8); }
        }

        /// <summary>
        /// Gets or sets the speed x.
        /// </summary>
        /// <value>The speed x.</value>
        internal double speedX
        {
            get { return SpeedX*_mult; }
            set { SpeedX = value/_mult; }
        }

        /// <summary>
        /// Gets or sets the speed y.
        /// </summary>
        /// <value>The speed y.</value>
        internal double speedY
        {
            get { return SpeedY*_mult; }
            set { SpeedY = value/_mult; }
        }

        /// <summary>
        /// Gets or sets the modifier x.
        /// </summary>
        /// <value>The modifier x.</value>
        internal double modifierX
        {
            get { return ModifierX*_mult; }
            set { ModifierX = value/_mult; }
        }

        /// <summary>
        /// Gets or sets the modifier y.
        /// </summary>
        /// <value>The modifier y.</value>
        internal double modifierY
        {
            get { return ModifierY*_mult; }
            set { ModifierY = value/_mult; }
        }

        /// <summary>
        /// Gets or sets the block x.
        /// </summary>
        /// <value>The block x.</value>
        public int BlockX
        {
            get { return blockX; }
            set { X = value*16; }
        }

        /// <summary>
        /// Gets or sets the block y.
        /// </summary>
        /// <value>The block y.</value>
        public int BlockY
        {
            get { return blockY; }
            set { Y = value*16; }
        }

        /// <summary>
        /// Gets the old block x.
        /// </summary>
        /// <value>The old block x.</value>
        private int OldBlockX
        {
            get { return (int) Math.Round(((_oldX)/16.0)); }
        }

        /// <summary>
        /// Gets the old block y.
        /// </summary>
        /// <value>The old block y.</value>
        private int OldBlockY
        {
            get { return (int) Math.Round(((_oldY)/16.0)); }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Player"/> is moved.
        /// </summary>
        /// <value><c>true</c> if moved; otherwise, <c>false</c>.</value>
        private bool Moved
        {
            get { return BlockX != OldBlockX || BlockY != OldBlockY; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Player"/> is levitation.
        /// </summary>
        /// <value><c>true</c> if levitation; otherwise, <c>false</c>.</value>
        private bool Levitation { get; set; }

        /// <summary>
        /// Resets the coins.
        /// </summary>
        private void ResetCoins()
        {
            Coins = 0;
            BlueCoins = 0;
        }

        /// <summary>
        /// Hits the test.
        /// </summary>
        /// <param name="param1">The param1.</param>
        /// <param name="param2">The param2.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool HitTest(int param1, int param2)
        {
            return param1 >= X && param2 >= Y && param1 <= X + Size && param2 <= Y + Size;
        }

/*
        private double jumpMultiplier() // never used
        {
            double _loc_1 = 1;
            if (JumpBoost)
            {
                _loc_1 = _loc_1*1.2;
            }
            if (zombie())
            {
                _loc_1 = _loc_1*0.75;
            }
            return _loc_1;
        }
*/

        /// <summary>
        /// Speeds the multiplier.
        /// </summary>
        /// <returns>System.Double.</returns>
        private double SpeedMultiplier()
        {
            double loc1 = 1;
            if (Zombie())
            {
                loc1 = loc1*0.6;
            }
            return loc1;
        }

        /// <summary>
        /// Drags the mud.
        /// </summary>
        /// <returns>System.Double.</returns>
        private double DragMud()
        {
            return MudDrag;
        }

        /// <summary>
        /// Overlapses the specified player.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>System.Int32.</returns>
        private int Overlaps(Player player)
        {
            var _loc_8 = new List<int>();

            if (player.X < 0 || player.Y < 0 || player.X >= PlayingIn.Width*16 - 8 ||
                player.Y >= PlayingIn.Height*16 - 8)
            {
                return 1;
            }

            Player loc2 = this;

            if (loc2.IsGod || loc2.IsMod)
            {
                return 0;
            }

            double loc3 = ((loc2.X)/16);
            double loc4 = ((loc2.Y)/16);
            for (int xx = -2; xx < 1; xx++)
            {
                for (int yy = -2; yy < 1; yy++)
                {
                    if (loc3 + xx > 0 && loc3 + xx < PlayingIn.Width && loc4 + yy > 0 &&
                        loc4 + yy <= PlayingIn.Height)
                    {
                        for (int xTest = 0; xTest < 16; xTest++)
                        {
                            for (int yTest = 0; yTest < 16; yTest++)
                            {
                                if (HitTest((int) (xTest + loc2.X + xx*16), (int) (yTest + loc2.Y + yy*16)))
                                {
                                    double loc9 = loc4;
                                    Block currentBlock = PlayingIn.Map[
                                        (int) (((xx*16) + loc2.X + xTest)/16),
                                        (int) (((yy*16) + loc2.Y + yTest)/16),
                                        0];
                                    int loc11 = currentBlock.Id;
                                    if (ItemId.isSolid(loc11))
                                    {
                                        switch (loc11)
                                        {
                                            case 23:
                                            {
                                                if (PlayingIn.RedActivated)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case 24:
                                            {
                                                if (PlayingIn.GreenActivated)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case 25:
                                            {
                                                if (PlayingIn.BlueActivated)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case 26:
                                            {
                                                if (!PlayingIn.RedActivated)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case 27:
                                            {
                                                if (!PlayingIn.GreenActivated)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case 28:
                                            {
                                                if (!PlayingIn.BlueActivated)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case 156:
                                            {
                                                if (PlayingIn.TimeDoorsVisible)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case 157:
                                            {
                                                if (!PlayingIn.TimeDoorsVisible)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Doors.SWITCH:
                                            {
                                                if (SwitchOpened)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Gates.SWITCH:
                                            {
                                                if (!SwitchOpened)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Doors.CLUB:
                                            {
                                                if (isclubmember)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Gates.CLUB:
                                            {
                                                if (!isclubmember)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Doors.COIN:
                                            {
                                                if (currentBlock is CoinBlock &&
                                                    ((CoinBlock) currentBlock).CoinsRequired <= _coins)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Gates.COIN:
                                            {
                                                if (currentBlock is CoinBlock &&
                                                    ((CoinBlock) currentBlock).CoinsRequired > _coins)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Gates.ZOMBIE:
                                            {
                                                if (_isZombie)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Doors.ZOMBIE:
                                            {
                                                if (!_isZombie)
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
                                                    if (loc9 != loc4 || loc2._overlapy == -1)
                                                    {
                                                        loc2._overlapy = (int) loc9;
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
                }
            }

            return 0;
        }

        /// <summary>
        /// Stepxes this instance.
        /// </summary>
        private void Stepx()
        {
            if (_currentSx > 0)
            {
                if (_currentSx + _reminderX >= 1)
                {
                    X = X + (1 - _reminderX);
                    X = Math.Floor(X);
                    _currentSx = _currentSx - (1 - _reminderX);
                    _reminderX = 0;
                }
                else
                {
                    X = X + _currentSx;
                    _currentSx = 0;
                }
            }
            else if (_currentSx < 0)
            {
                if (_reminderX != 0 && _reminderX + _currentSx < 0)
                {
                    _currentSx = _currentSx + _reminderX;
                    X = X - _reminderX;
                    X = Math.Floor(X);
                    _reminderX = 1;
                }
                else
                {
                    X = X + _currentSx;
                    _currentSx = 0;
                }
            }

            if (Overlaps(this) != 0)
            {
                X = _ox;
                SpeedX = 0;
                _currentSx = _osx;
                _donex = true;
            }
        }

        /// <summary>
        /// Stepies this instance.
        /// </summary>
        private void Stepy()
        {
            if (_currentSy > 0)
            {
                if (_currentSy + _reminderY >= 1)
                {
                    Y = Y + (1 - _reminderY);
                    Y = Math.Floor(Y);
                    _currentSy = _currentSy - (1 - _reminderY);
                    _reminderY = 0;
                }
                else
                {
                    Y = Y + _currentSy;
                    _currentSy = 0;
                }
            }
            else if (_currentSy < 0)
            {
                if (_reminderY != 0 && _reminderY + _currentSy < 0)
                {
                    Y = Y - _reminderY;
                    Y = Math.Floor(Y);
                    _currentSy = _currentSy + _reminderY;
                    _reminderY = 1;
                }
                else
                {
                    Y = Y + _currentSy;
                    _currentSy = 0;
                }
            }

            if (Overlaps(this) != 0)
            {
                Y = _oy;
                SpeedY = 0;
                _currentSy = _osy;
                _doney = true;
            }
        }

        /// <summary>
        /// Processes the portals.
        /// </summary>
        private void ProcessPortals()
        {
            var targetPortalList = new List<Point>();
            CurrentBlockId = PlayingIn.Map[_cx, _cy, 0].Id;
            if (!_isgodmod && CurrentBlockId == BlockIds.Action.Portals.WORLD)
            {
                if (_spacejustdown)
                {
                }
            }
            if (!_isgodmod && CurrentBlockId == 242)
            {
                if (_lastPortal.X == 0 && _lastPortal.Y == 0)
                {
                    _lastPortal = new Point(_cx << 4, _cy << 4);

                    Block currentBlock = PlayingIn.Map[_cx, _cy, 0];
                    var currentPortalBlock = (PortalBlock) currentBlock;
                    int currentTarget = currentPortalBlock.PortalDestination;

                    for (int x = 1; x < PlayingIn.Width; x++)
                    {
                        for (int y = 1; y < PlayingIn.Height; y++)
                        {
                            Block block = PlayingIn.Map[x, y, 0];
                            if (block is PortalBlock && ((PortalBlock) block).PortalId == currentTarget)
                            {
                                targetPortalList.Add(new Point(x << 4, y << 4));
                            }
                        }
                    }
                    int loopIterator = 0;
                    while (loopIterator < targetPortalList.Count)
                    {
                        Point currentLoopPortal = targetPortalList[loopIterator];
                        int loc4 = PlayingIn.Map[_lastPortal.X >> 4, _lastPortal.Y >> 4, 0].Direction;
                        int loc5 = PlayingIn.Map[currentLoopPortal.X >> 4, currentLoopPortal.Y >> 4, 0].Direction;
                        if (loc4 < loc5)
                        {
                            loc4 = loc4 + 4;
                        }
                        double loc6 = speedX;
                        double loc7 = speedY;
                        double loc8 = modifierX;
                        double loc9 = modifierY;
                        int loc10 = loc4 - loc5;
                        const double loc11 = 1.42;
                        switch (loc10)
                        {
                            case 1:
                            {
                                speedX = loc7*loc11;
                                speedY = (-loc6)*loc11;
                                modifierX = loc9*loc11;
                                modifierY = (-loc8)*loc11;
                                _reminderY = -_reminderY;
                                _currentSy = -_currentSy;
                                break;
                            }
                            case 3:
                            {
                                speedX = (-loc7)*loc11;
                                speedY = loc6*loc11;
                                modifierX = (-loc9)*loc11;
                                modifierY = loc8*loc11;
                                _reminderX = -_reminderX;
                                _currentSx = -_currentSx;
                                break;
                            }
                            case 2:
                            {
                                speedX = (-loc6)*loc11;
                                speedY = (-loc7)*loc11;
                                modifierX = (-loc8)*loc11;
                                modifierY = (-loc9)*loc11;
                                _reminderY = -_reminderY;
                                _currentSy = -_currentSy;
                                _reminderX = -_reminderX;
                                _currentSx = -_currentSx;
                                break;
                            }
                            default:
                            {
                                break;
                            }
                        }

                        X = currentLoopPortal.X;
                        Y = currentLoopPortal.Y;
                        _lastPortal = currentLoopPortal;
                        break;
                    }
                }
            }
            else
            {
                _lastPortal = new Point(0, 0);
            }
        }

        /// <summary>
        /// Ticks this instance.
        /// </summary>
        public void tick()
        {
            _oldX = X;
            _oldY = Y;

            _animoffset = _animoffset + 0.2;
            if (IsMod && !IsGod)
            {
                _modoffset = _modoffset + 0.2;
                if (_modoffset >= 16)
                {
                    _modoffset = 10;
                }
            }
            else if (isclubmember)
            {
                _cluboffset = _cluboffset + 0.2;
                if (_cluboffset >= 14)
                {
                    _cluboffset = 0;
                }
            }
            else
            {
                _modoffset = 0;
            }
            if (_isDead)
            {
                _deadoffset = _deadoffset + 0.3;
            }
            else
            {
                _deadoffset = 0;
            }
            _cx = (int) ((X + 8)/16);
            _cy = (int) ((Y + 8)/16);
            int delayed = 0;
            if (_queue.Count >= 1)
            {
                delayed = _queue.Dequeue();
            }
            CurrentBlockId = PlayingIn.Map[_cx, _cy, 0].Id;
            _queue.Enqueue(CurrentBlockId);
            if (CurrentBlockId == 4 || ItemId.isClimbable(CurrentBlockId))
            {
                delayed = _queue.Dequeue();
                _queue.Enqueue(CurrentBlockId);
            }
            if (_isDead)
            {
                Horizontal = 0;
                Vertical = 0;
                _spacejustdown = false;
            }
            _isgodmod = IsGod || IsMod;
            if (_isgodmod)
            {
                _morx = 0;
                _mory = 0;
                _oldHorizontalAcceleration = 0;
                _oldVerticalAcceleration = 0;
            }
            else
            {
                switch (CurrentBlockId)
                {
                    case 1:
                    {
                        _morx = -(int) Gravity;
                        _mory = 0;
                        break;
                    }
                    case 2:
                    {
                        _morx = 0;
                        _mory = -(int) Gravity;
                        break;
                    }
                    case 3:
                    {
                        _morx = (int) Gravity;
                        _mory = 0;
                        break;
                    }
                    case BlockIds.Action.Boost.LEFT:
                    case BlockIds.Action.Boost.RIGHT:
                    case BlockIds.Action.Boost.UP:
                    case BlockIds.Action.Boost.DOWN:
                    case BlockIds.Action.Ladders.CHAIN:
                    case BlockIds.Action.Ladders.LADDER:
                    case BlockIds.Action.Ladders.HORIZONTALVINE:
                    case BlockIds.Action.Ladders.VERTICALVINE:
                    case BlockIds.Action.Gravity.ZERO:
                    {
                        _morx = 0;
                        _mory = 0;
                        break;
                    }
                    case BlockIds.Action.Liquids.WATER:
                    {
                        _morx = 0;
                        _mory = (int) WaterBuoyancy;
                        break;
                    }
                    case BlockIds.Action.Liquids.MUD:
                    {
                        _morx = 0;
                        _mory = (int) MudBuoyancy;
                        break;
                    }
                    case BlockIds.Action.Hazards.FIRE:
                    case BlockIds.Action.Hazards.SPIKE:
                    {
                        if (!_isDead && !_isInvulnerable)
                        {
                            KillPlayer();
                        }
                        break;
                    }
                    default:
                    {
                        _morx = 0;
                        _mory = (int) Gravity;
                        break;
                    }
                }
                switch (delayed)
                {
                    case 1:
                    {
                        _oldHorizontalAcceleration = -Gravity;
                        _oldVerticalAcceleration = 0;
                        break;
                    }
                    case 2:
                    {
                        _oldHorizontalAcceleration = 0;
                        _oldVerticalAcceleration = -Gravity;
                        break;
                    }
                    case 3:
                    {
                        _oldHorizontalAcceleration = Gravity;
                        _oldVerticalAcceleration = 0;
                        break;
                    }
                    case BlockIds.Action.Boost.LEFT:
                    case BlockIds.Action.Boost.RIGHT:
                    case BlockIds.Action.Boost.UP:
                    case BlockIds.Action.Boost.DOWN:
                    case BlockIds.Action.Ladders.CHAIN:
                    case BlockIds.Action.Ladders.LADDER:
                    case BlockIds.Action.Ladders.HORIZONTALVINE:
                    case BlockIds.Action.Ladders.VERTICALVINE:
                    case BlockIds.Action.Gravity.ZERO:
                    {
                        _oldHorizontalAcceleration = 0;
                        _oldVerticalAcceleration = 0;
                        break;
                    }
                    case BlockIds.Action.Liquids.WATER:
                    {
                        _oldHorizontalAcceleration = 0;
                        _oldVerticalAcceleration = WaterBuoyancy;
                        break;
                    }
                    case BlockIds.Action.Liquids.MUD:
                    {
                        _oldHorizontalAcceleration = 0;
                        _oldVerticalAcceleration = MudBuoyancy;
                        break;
                    }
                    default:
                    {
                        _oldHorizontalAcceleration = 0;
                        _oldVerticalAcceleration = Gravity;
                        break;
                    }
                }
            }
            if (_oldVerticalAcceleration == WaterBuoyancy || _oldVerticalAcceleration == MudBuoyancy)
            {
                _horizontalAcceleration = Horizontal;
                _verticalAcceleration = Vertical;
            }
            else if (_oldVerticalAcceleration != 0)
            {
                _horizontalAcceleration = Horizontal;
                _verticalAcceleration = 0;
            }
            else if (_oldHorizontalAcceleration != 0)
            {
                _horizontalAcceleration = 0;
                _verticalAcceleration = Vertical;
            }
            else
            {
                _horizontalAcceleration = Horizontal;
                _verticalAcceleration = Vertical;
            }
            _horizontalAcceleration = _horizontalAcceleration*SpeedMultiplier();
            _verticalAcceleration = _verticalAcceleration*SpeedMultiplier();
            _oldHorizontalAcceleration = _oldHorizontalAcceleration*GravityMultiplier;
            _oldVerticalAcceleration = _oldVerticalAcceleration*GravityMultiplier;
            modifierX = _oldHorizontalAcceleration + _horizontalAcceleration;

            modifierY = _oldVerticalAcceleration + _verticalAcceleration;
            if (SpeedX != 0 || ModifierX != 0)
            {
                SpeedX = SpeedX + ModifierX;
                SpeedX = SpeedX*Config.physics_base_drag;
                if (_horizontalAcceleration == 0 && _oldVerticalAcceleration != 0 ||
                    SpeedX < 0 && _horizontalAcceleration > 0 || SpeedX > 0 && _horizontalAcceleration < 0 ||
                    ItemId.isClimbable(CurrentBlockId) && !_isgodmod)
                {
                    SpeedX = SpeedX*NoModifierDragX;
                }
                else if (CurrentBlockId == BlockIds.Action.Liquids.WATER && !_isgodmod)
                {
                    SpeedX = SpeedX*WaterDrag;
                }
                else if (CurrentBlockId == BlockIds.Action.Liquids.MUD && !_isgodmod)
                {
                    SpeedX = SpeedX*DragMud();
                }
                if (SpeedX > 16)
                {
                    SpeedX = 16;
                }
                else if (SpeedX < -16)
                {
                    SpeedX = -16;
                }
                else if (SpeedX < 0.0001 && SpeedX > -0.0001)
                {
                    SpeedX = 0;
                }
            }
            if (SpeedY != 0 || ModifierY != 0)
            {
                SpeedY = SpeedY + ModifierY;
                SpeedY = SpeedY*Config.physics_base_drag;
                if (_verticalAcceleration == 0 && _oldHorizontalAcceleration != 0 ||
                    SpeedY < 0 && _verticalAcceleration > 0 || SpeedY > 0 && _verticalAcceleration < 0 ||
                    ItemId.isClimbable(CurrentBlockId) && !_isgodmod)
                {
                    SpeedY = SpeedY*NoModifierDragY;
                }
                else if (CurrentBlockId == BlockIds.Action.Liquids.WATER && !_isgodmod)
                {
                    SpeedY = SpeedY*WaterDrag;
                }
                else if (CurrentBlockId == BlockIds.Action.Liquids.MUD && !_isgodmod)
                {
                    SpeedY = SpeedY*DragMud();
                }
                if (SpeedY > 16)
                {
                    SpeedY = 16;
                }
                else if (SpeedY < -16)
                {
                    SpeedY = -16;
                }
                else if (SpeedY < 0.0001 && SpeedY > -0.0001)
                {
                    SpeedY = 0;
                }
            }
            if (!_isgodmod)
            {
                switch (CurrentBlockId)
                {
                    case BlockIds.Action.Boost.LEFT:
                    {
                        SpeedX = -Boost;
                        break;
                    }
                    case BlockIds.Action.Boost.RIGHT:
                    {
                        SpeedX = Boost;
                        break;
                    }
                    case BlockIds.Action.Boost.UP:
                    {
                        SpeedY = -Boost;
                        break;
                    }
                    case BlockIds.Action.Boost.DOWN:
                    {
                        SpeedY = Boost;
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            _reminderX = X%1;
            _currentSx = SpeedX;
            _reminderY = Y%1;
            _currentSy = SpeedY;
            _donex = false;
            _doney = false;
            while (_currentSx != 0 && !_donex || _currentSy != 0 && !_doney)
            {
                ProcessPortals();
                _ox = X;
                _oy = Y;
                _osx = _currentSx;
                _osy = _currentSy;
                Stepx();
                Stepy();
            }

            if (Levitation)
            {
                UpdateThrust();
            }
            double imx = SpeedX*256;
            double imy = SpeedY*256;
            moving = false;
            if (imx != 0 || CurrentBlockId == BlockIds.Action.Liquids.WATER ||
                CurrentBlockId == BlockIds.Action.Liquids.MUD)
            {
                moving = true;
            }
            else if (ModifierX < 0.1 && ModifierX > -0.1)
            {
                _tx = X%16;
                if (_tx < 2)
                {
                    if (_tx < 0.2)
                    {
                        X = Math.Floor(X);
                    }
                    else
                    {
                        X = X - _tx/15;
                    }
                }
                else if (_tx > 14)
                {
                    if (_tx > 15.8)
                    {
                        X = Math.Floor(X);
                        double loc3 = X + 1;
                        X = loc3;
                    }
                    else
                    {
                        X = X + (_tx - 14)/15;
                    }
                }
            }
            if (imy != 0 || CurrentBlockId == BlockIds.Action.Liquids.WATER ||
                CurrentBlockId == BlockIds.Action.Liquids.MUD)
            {
                moving = true;
            }
            else if (ModifierY < 0.1 && ModifierY > -0.1)
            {
                _ty = Y%16;
                if (_ty < 2)
                {
                    if (_ty < 0.2)
                    {
                        Y = Math.Floor(Y);
                    }
                    else
                    {
                        Y = Y - _ty/15;
                    }
                }
                else if (_ty > 14)
                {
                    if (_ty > 15.8)
                    {
                        Y = Math.Floor(Y);
                        double loc3 = Y + 1;
                        Y = loc3;
                    }
                    else
                    {
                        Y = Y + (_ty - 14)/15;
                    }
                }
            }
        }

/*
        private void update()
        {
        }
*/

/*
        private void showBadge(bool param1)
        {
        }
*/

/*
        private void drawBadge(Bitmap param1, double param2, double param3, bool param4)
        {
        }
*/

/*
        private void flauntLevelBadge(bool param1)
        {
        }
*/

/*
        private void drawChat(Bitmap param1, double param2, double param3, bool param4)
        {
        }
*/

/*
        private void enterChat()
        {
        }
*/

/*
        private void say(string param1)
        {
        }
*/

        /// <summary>
        /// Kills the player.
        /// </summary>
        private void KillPlayer()
        {
            _isDead = true;
        }

/*
        private void respawn()
        {
            ModifierX = 0;
            ModifierY = 0;
            modifierX = 0;
            modifierY = 0;
            SpeedX = 0;
            SpeedY = 0;
            speedX = 0;
            speedY = 0;
            _isDead = false;

            _lastRespawn = DateTime.Now.Millisecond;
        }
*/

/*
        private void resetCoins()
        {
            _coins = 0;
        }
*/

/*
        private void resetCheckpoint()
        {
            checkpoint_x = -1;
            checkpoint_y = -1;
        }
*/

/*
        private void nameColor(int param1)
        {
        }
*/

/*
        private uint minimapColor()
        {
            return 0;
        }
*/

/*
        private void cursed(bool param1)
        {
            _isCursed = param1;
        }
*/

/*
        private bool cursed()
        {
            return _isCursed;
        }
*/

/*
        private void zombie(bool param1)
        {
            _isZombie = param1;
        }
*/

        /// <summary>
        /// Zombies this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool Zombie()
        {
            if (IsGod || IsMod)
            {
                return false;
            }
            return _isZombie;
        }

/*
        private void addTouchPotion(string param1, double param2 = 1)
        {
            _touchpotions.Add(param1, DateTime.Now.Millisecond + (int) param2*1000);
        }
*/

/*
        private void removeTouchPotion(string param1)
        {
            _touchpotions.Remove(param1);
        }
*/

        /// <summary>
        /// Determines whether [has active potion] [the specified param1].
        /// </summary>
        /// <param name="param1">The param1.</param>
        /// <returns><c>true</c> if [has active potion] [the specified param1]; otherwise, <c>false</c>.</returns>
        private bool HasActivePotion(string param1)
        {
            if (!_touchpotions.ContainsKey(param1))
            {
                return false;
            }
            return (DateTime.Now.Millisecond - _touchpotions[param1]) > 0;
        }

/*
        private bool hasPotion(string param1)
        {
            return _touchpotions.ContainsKey(param1);
        }
*/

        /// <summary>
        /// Gets the active potions.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        private List<string> GetActivePotions()
        {
            return _touchpotions.Keys.Where(HasActivePotion).ToList();
        }

/*
        private bool getCanTag()
        {
            if (IsGod || IsMod || _isDead)
            {
                return false;
            }
            return GetActivePotions().Count > 0;
        }
*/

/*
        private bool getCanBeTagged()
        {
            if (IsGod || IsMod || _isDead)
            {
                return false;
            }
            return (DateTime.Now.Millisecond - _lastRespawn) > 1000;
        }
*/

/*
        private void setPosition(double param1, double param2)
        {
            X = param1;
            Y = param2;
        }
*/

/*
        private void isInvulnerable(bool param1)
        {
            _isInvulnerable = param1;
        }
*/

/*
        private bool isInvulnerable()
        {
            return _isInvulnerable;
        }
*/

/*
        private void hasLevitation(bool param1)
        {
            _hasLevitation = param1;
        }
*/

        /// <summary>
        /// Updates the thrust.
        /// </summary>
        private void UpdateThrust()
        {
            if (_mory != 0)
            {
                speedY = speedY - _currentThrust*(Config.physics_jump_height/2)*(_mory*0.5);
            }
            if (_morx != 0)
            {
                speedX = speedX - _currentThrust*(Config.physics_jump_height/2)*(_morx*0.5);
            }
            if (!_isThrusting)
            {
                if (_currentThrust > 0)
                {
                    _currentThrust = _currentThrust - ThrustBurnOff;
                }
                else
                {
                    _currentThrust = 0;
                }
            }
        }

/*
        private bool isThrusting()
        {
            return _isThrusting;
        }
*/

/*
        private void isThrusting(bool param1)
        {
            _isThrusting = param1;
        }
*/

/*
        private void applyThrust()
        {
            _currentThrust = MaxThrust;
        }
*/

/*
        private bool isFlaunting()
        {
            return _isFlaunting;
        }
*/

/*
        private void isFlaunting(bool param1)
        {
            _isFlaunting = param1;
        }
*/

/*
        private static bool isAdmin(string param1)
        {
            return Admins.Contains(param1);
        }
*/
    }
}