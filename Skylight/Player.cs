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
    public class Player
    {
        // Private instance fields
        private static readonly List<string> Admins = new List<string>
        {
            "benjaminsen",
            "cyclone",
            "toby",
            "rpgmaster2000",
            "mrshoe",
            "mrvoid"
        };

        private readonly double _mult;
        private readonly Queue<int> _queue = new Queue<int>();
        private readonly Dictionary<string, int> _touchpotions = new Dictionary<string, int>();
        private double _horizontalAcceleration;
        private double _oldHorizontalAcceleration;
        private double _oldVerticalAcceleration;
        public bool SwitchOpened = false;
        private double _verticalAcceleration;
        public double X = 0;
        public double Y = 0;
        protected double Boost;
        private double _currentThrust;
        protected double Gravity;
        private bool _hasLevitation;
        private bool _isFlaunting;
        private bool _isInvulnerable;
        private bool _isThrusting;
        private const double MaxThrust = 0.2;
        protected double ModifierX = 0;
        protected double ModifierY = 0;
        protected double MudBuoyancy;
        protected double MudDrag;
        protected double NoModifierDragX;
        protected double NoModifierDragY;
        protected double SpeedX = 0;
        protected double SpeedY = 0;
        private const double ThrustBurnOff = 0.01;
        protected double WaterBuoyancy;
        protected double WaterDrag;
        private double _animoffset;

        private int
            _blueCoins;

        public int checkpoint_x = -1;
        public int checkpoint_y = -1;
        private double _cluboffset;

        private int
            _coins,
            _collectedMagic;

        public int currentBlockId = 0;
        private double _currentSx;
        private double _currentSy;
        private int _cx;
        private int _cy;
        private double _deadoffset;

        private int
            _deathCount;

        private bool _donex;
        private bool _doney;
        private const double GravityMultiplier = 1;

        private bool
            _hasAccess,
            _hasBoost;

        private bool
            _hasClub,
            _hasCommandAccess,
            _hasCrown,
            _hasGravityModifier,
            _hasSilverCrown;

        internal int Horizontal = 0;

        private int
            _id = -1;

        private bool injump = false;
        private bool _isCursed;
        private bool _isDead;

        private bool
            _isFriend,
            _isGod,
            _isHoldingDown,
            _isHoldingLeft,
            _isHoldingRight;

        private bool
            _isHoldingSpace;

        private bool
            _isHoldingUp;

        private bool
            _isMod,
            isOwner;

        private bool _isZombie;
        public bool isclubmember = false;
        private bool _isgodmod;
        private const bool jump_boost = false;
        private Point _lastPortal;
        private double _lastRespawn;
        private int level = 1;
        private int mod = 0;
        private double modoffset;
        private int _morx;
        private int _mory;
        private bool moving;
        private string _name;
        private double _oldX = -1;
        private double _oldY = -1;
        private double _osx;
        private double _osy;
        private int _overlapy;
        private double _ox;
        private double _oy;
        private Room _playingIn;
        private List<int> _potionEffects = new List<int>();
        private double _reminderX;
        private double _reminderY;
        protected int Size;

        private int
            _smiley;

        private bool _spacejustdown;
        private double _tx;
        private double _ty;
        internal int Vertical = 0;
        private const bool worldportalsend = false;

        private int
            _xpLevel;

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
            this._isFriend = isFriend;
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
        public bool HasAccess
        {
            get { return _hasAccess; }

            internal set { _hasAccess = value; }
        }

        public bool HasBoost
        {
            get { return _hasBoost; }

            internal set { _hasBoost = value; }
        }

        public bool HasClub
        {
            get { return _hasClub; }

            internal set { _hasClub = value; }
        }

        public bool HasCommandAccess
        {
            get { return _hasCommandAccess; }

            internal set { _hasCommandAccess = value; }
        }

        public bool HasCrown
        {
            get { return _hasCrown; }

            internal set { _hasCrown = value; }
        }

        public bool HasGravityModifier
        {
            get { return _hasGravityModifier; }

            internal set { _hasGravityModifier = value; }
        }

        public bool HasSilverCrown
        {
            get { return _hasSilverCrown; }

            internal set { _hasSilverCrown = value; }
        }

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

        public bool IsFriend
        {
            get { return _isFriend; }

            internal set { _isFriend = value; }
        }

        public bool IsGod
        {
            get { return _isGod; }

            internal set { _isGod = value; }
        }

        public bool IsMod
        {
            get { return _isMod; }

            internal set { _isMod = value; }
        }

        public bool IsHoldingLeft
        {
            get { return _isHoldingLeft; }

            internal set { _isHoldingLeft = value; }
        }

        public bool IsHoldingRight
        {
            get { return _isHoldingRight; }

            internal set { _isHoldingRight = value; }
        }

        public bool IsHoldingUp
        {
            get { return _isHoldingUp; }

            internal set { _isHoldingUp = value; }
        }

        public bool IsHoldingDown
        {
            get { return _isHoldingDown; }

            internal set { _isHoldingDown = value; }
        }

        public bool IsHoldingSpace
        {
            get { return _isHoldingSpace; }

            internal set { _isHoldingSpace = value; }
        }

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

        public int Coins
        {
            get { return _coins; }

            internal set { _coins = value; }
        }

        public int BlueCoins
        {
            get { return _blueCoins; }
            internal set { _blueCoins = value; }
        }

        public int CollectedMagic
        {
            get { return _collectedMagic; }

            internal set { _collectedMagic = value; }
        }

        public int DeathCount
        {
            get { return _deathCount; }

            internal set { _deathCount = value; }
        }

        public int Id
        {
            get { return _id; }

            internal set { _id = value; }
        }

        public int Smiley
        {
            get { return _smiley; }

            internal set { _smiley = value; }
        }

        public int XpLevel
        {
            get { return _xpLevel; }

            internal set { _xpLevel = value; }
        }

        public List<int> PotionEffects
        {
            get { return _potionEffects; }

            internal set { _potionEffects = value; }
        }

        public Room PlayingIn
        {
            get { return _playingIn; }

            internal set { _playingIn = value; }
        }

        public string Name
        {
            get { return _name; }
            internal set { _name = value.ToLower(); }
        }

        protected int blockX
        {
            get { return (int) Math.Round(((X)/16.0)); }
        }

        protected int blockY
        {
            get { return (int) Math.Round((Y)/16.0); }
        }

        internal double posX
        {
            get { return (X + 8); }
        }

        internal double posY
        {
            get { return (Y + 8); }
        }

        internal double speedX
        {
            get { return SpeedX*_mult; }
            set { SpeedX = value/_mult; }
        }

        internal double speedY
        {
            get { return SpeedY*_mult; }
            set { SpeedY = value/_mult; }
        }

        internal double modifierX
        {
            get { return ModifierX*_mult; }
            set { ModifierX = value/_mult; }
        }

        internal double modifierY
        {
            get { return ModifierY*_mult; }
            set { ModifierY = value/_mult; }
        }

        public int BlockX
        {
            get { return blockX; }
            set { X = value*16; }
        }

        public int BlockY
        {
            get { return blockY; }
            set { Y = value*16; }
        }

        private int OldBlockX
        {
            get { return (int) Math.Round(((_oldX)/16.0)); }
        }

        private int OldBlockY
        {
            get { return (int) Math.Round(((_oldY)/16.0)); }
        }

        private bool Moved
        {
            get { return BlockX != OldBlockX || BlockY != OldBlockY; }
        }

        private bool Levitation
        {
            get { return _hasLevitation; }
            set { _hasLevitation = value; }
        }

        private void ResetCoins()
        {
            Coins = 0;
            BlueCoins = 0;
        }

        private bool hitTest(int param1, int param2)
        {
            return param1 >= X && param2 >= Y && param1 <= X + Size && param2 <= Y + Size;
        }

        private double jumpMultiplier()
        {
            double _loc_1 = 1;
            if (jump_boost)
            {
                _loc_1 = _loc_1*1.2;
            }
            if (zombie())
            {
                _loc_1 = _loc_1*0.75;
            }
            return _loc_1;
        }

        private double speedMultiplier()
        {
            double _loc_1 = 1;
            if (zombie())
            {
                _loc_1 = _loc_1*0.6;
            }
            return _loc_1;
        }

        private double dragMud()
        {
            return MudDrag;
        }

        private int overlaps(Player player)
        {
            var _loc_8 = new List<int>();

            if (player.X < 0 || player.Y < 0 || player.X >= PlayingIn.Width*16 - 8 ||
                player.Y >= PlayingIn.Height*16 - 8)
            {
                return 1;
            }

            Player _loc_2 = this;

            if (_loc_2.IsGod || _loc_2.IsMod)
            {
                return 0;
            }

            double _loc_3 = ((_loc_2.X)/16);
            double _loc_4 = ((_loc_2.Y)/16);
            for (int xx = -2; xx < 1; xx++)
            {
                for (int yy = -2; yy < 1; yy++)
                {
                    if (_loc_3 + xx > 0 && _loc_3 + xx < PlayingIn.Width && _loc_4 + yy > 0 &&
                        _loc_4 + yy <= PlayingIn.Height)
                    {
                        for (int xTest = 0; xTest < 16; xTest++)
                        {
                            for (int yTest = 0; yTest < 16; yTest++)
                            {
                                if (hitTest((int) (xTest + _loc_2.X + xx*16), (int) (yTest + _loc_2.Y + yy*16)))
                                {
                                    double _loc_9 = _loc_4;
                                    Block currentBlock = PlayingIn.Map[
                                        (int) (((xx*16) + _loc_2.X + xTest)/16),
                                        (int) (((yy*16) + _loc_2.Y + yTest)/16),
                                        0];
                                    int _loc_11 = currentBlock.Id;
                                    if (ItemId.isSolid(_loc_11))
                                    {
                                        switch (_loc_11)
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
                                                if (_loc_2.speedY < 0 || _loc_9 <= _loc_2._overlapy)
                                                {
                                                    if (_loc_9 != _loc_4 || _loc_2._overlapy == -1)
                                                    {
                                                        _loc_2._overlapy = (int) _loc_9;
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
                                        return _loc_11;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return 0;
        }

        private void stepx()
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

            if (overlaps(this) != 0)
            {
                X = _ox;
                SpeedX = 0;
                _currentSx = _osx;
                _donex = true;
            }
        }

        private void stepy()
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

            if (overlaps(this) != 0)
            {
                Y = _oy;
                SpeedY = 0;
                _currentSy = _osy;
                _doney = true;
            }
        }

        private void processPortals()
        {
            var targetPortalList = new List<Point>();
            var currentLoopPortal = new Point(0, 0);
            currentBlockId = PlayingIn.Map[_cx, _cy, 0].Id;
            if (!_isgodmod && currentBlockId == BlockIds.Action.Portals.WORLD)
            {
                if (_spacejustdown && !worldportalsend)
                {
                }
            }
            if (!_isgodmod && currentBlockId == 242)
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
                        currentLoopPortal = targetPortalList[loopIterator];
                        int _loc_4 = PlayingIn.Map[_lastPortal.X >> 4, _lastPortal.Y >> 4, 0].Direction;
                        int _loc_5 = PlayingIn.Map[currentLoopPortal.X >> 4, currentLoopPortal.Y >> 4, 0].Direction;
                        if (_loc_4 < _loc_5)
                        {
                            _loc_4 = _loc_4 + 4;
                        }
                        double _loc_6 = speedX;
                        double _loc_7 = speedY;
                        double _loc_8 = modifierX;
                        double _loc_9 = modifierY;
                        int _loc_10 = _loc_4 - _loc_5;
                        double _loc_11 = 1.42;
                        switch (_loc_10)
                        {
                            case 1:
                            {
                                speedX = _loc_7*_loc_11;
                                speedY = (-_loc_6)*_loc_11;
                                modifierX = _loc_9*_loc_11;
                                modifierY = (-_loc_8)*_loc_11;
                                _reminderY = -_reminderY;
                                _currentSy = -_currentSy;
                                break;
                            }
                            case 3:
                            {
                                speedX = (-_loc_7)*_loc_11;
                                speedY = _loc_6*_loc_11;
                                modifierX = (-_loc_9)*_loc_11;
                                modifierY = _loc_8*_loc_11;
                                _reminderX = -_reminderX;
                                _currentSx = -_currentSx;
                                break;
                            }
                            case 2:
                            {
                                speedX = (-_loc_6)*_loc_11;
                                speedY = (-_loc_7)*_loc_11;
                                modifierX = (-_loc_8)*_loc_11;
                                modifierY = (-_loc_9)*_loc_11;
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
                        loopIterator++;
                        break;
                    }
                }
            }
            else
            {
                _lastPortal = new Point(0, 0);
            }
        }

        public void tick()
        {
            _oldX = X;
            _oldY = Y;

            _animoffset = _animoffset + 0.2;
            if (IsMod && !IsGod)
            {
                modoffset = modoffset + 0.2;
                if (modoffset >= 16)
                {
                    modoffset = 10;
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
                modoffset = 0;
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
            currentBlockId = PlayingIn.Map[_cx, _cy, 0].Id;
            _queue.Enqueue(currentBlockId);
            if (currentBlockId == 4 || ItemId.isClimbable(currentBlockId))
            {
                delayed = _queue.Dequeue();
                _queue.Enqueue(currentBlockId);
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
                switch (currentBlockId)
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
                            killPlayer();
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
            _horizontalAcceleration = _horizontalAcceleration*speedMultiplier();
            _verticalAcceleration = _verticalAcceleration*speedMultiplier();
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
                    ItemId.isClimbable(currentBlockId) && !_isgodmod)
                {
                    SpeedX = SpeedX*NoModifierDragX;
                }
                else if (currentBlockId == BlockIds.Action.Liquids.WATER && !_isgodmod)
                {
                    SpeedX = SpeedX*WaterDrag;
                }
                else if (currentBlockId == BlockIds.Action.Liquids.MUD && !_isgodmod)
                {
                    SpeedX = SpeedX*dragMud();
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
                    ItemId.isClimbable(currentBlockId) && !_isgodmod)
                {
                    SpeedY = SpeedY*NoModifierDragY;
                }
                else if (currentBlockId == BlockIds.Action.Liquids.WATER && !_isgodmod)
                {
                    SpeedY = SpeedY*WaterDrag;
                }
                else if (currentBlockId == BlockIds.Action.Liquids.MUD && !_isgodmod)
                {
                    SpeedY = SpeedY*dragMud();
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
                switch (currentBlockId)
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
                processPortals();
                _ox = X;
                _oy = Y;
                _osx = _currentSx;
                _osy = _currentSy;
                stepx();
                stepy();
            }

            if (Levitation)
            {
                updateThrust();
            }
            double imx = SpeedX*256;
            double imy = SpeedY*256;
            moving = false;
            if (imx != 0 || currentBlockId == BlockIds.Action.Liquids.WATER ||
                currentBlockId == BlockIds.Action.Liquids.MUD)
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
                        double _loc_3 = X + 1;
                        X = _loc_3;
                    }
                    else
                    {
                        X = X + (_tx - 14)/15;
                    }
                }
            }
            if (imy != 0 || currentBlockId == BlockIds.Action.Liquids.WATER ||
                currentBlockId == BlockIds.Action.Liquids.MUD)
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
                        double _loc_3 = Y + 1;
                        Y = _loc_3;
                    }
                    else
                    {
                        Y = Y + (_ty - 14)/15;
                    }
                }
            }
        }

        private void update()
        {
        }

        private void showBadge(bool param1)
        {
        }

        private void drawBadge(Bitmap param1, double param2, double param3, bool param4)
        {
        }

        private void flauntLevelBadge(bool param1)
        {
        }

        private void drawChat(Bitmap param1, double param2, double param3, bool param4)
        {
        }

        private void enterChat()
        {
        }

        private void say(string param1)
        {
        }

        private void killPlayer()
        {
            _isDead = true;
        }

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

        private void resetCoins()
        {
            _coins = 0;
        }

        private void resetCheckpoint()
        {
            checkpoint_x = -1;
            checkpoint_y = -1;
        }

        private void nameColor(int param1)
        {
        }

        private uint minimapColor()
        {
            return 0;
        }

        private void cursed(bool param1)
        {
            _isCursed = param1;
        }

        private bool cursed()
        {
            return _isCursed;
        }

        private void zombie(bool param1)
        {
            _isZombie = param1;
        }

        private bool zombie()
        {
            if (IsGod || IsMod)
            {
                return false;
            }
            return _isZombie;
        }

        private void addTouchPotion(string param1, double param2 = 1)
        {
            _touchpotions.Add(param1, DateTime.Now.Millisecond + (int) param2*1000);
        }

        private void removeTouchPotion(string param1)
        {
            _touchpotions.Remove(param1);
        }

        private bool hasActivePotion(string param1)
        {
            if (!_touchpotions.ContainsKey(param1))
            {
                return false;
            }
            return (DateTime.Now.Millisecond - _touchpotions[param1]) > 0;
        }

        private bool hasPotion(string param1)
        {
            return _touchpotions.ContainsKey(param1);
        }

        private List<string> getActivePotions()
        {
            return _touchpotions.Keys.Where(_loc_2 => hasActivePotion(_loc_2)).ToList();
        }

        private bool getCanTag()
        {
            if (IsGod || IsMod || _isDead)
            {
                return false;
            }
            return getActivePotions().Count > 0;
        }

        private bool getCanBeTagged()
        {
            if (IsGod || IsMod || _isDead)
            {
                return false;
            }
            return (DateTime.Now.Millisecond - _lastRespawn) > 1000;
        }

        private void setPosition(double param1, double param2)
        {
            X = param1;
            Y = param2;
        }

        private void isInvulnerable(bool param1)
        {
            _isInvulnerable = param1;
        }

        private bool isInvulnerable()
        {
            return _isInvulnerable;
        }

        private void hasLevitation(bool param1)
        {
            _hasLevitation = param1;
        }

        private void updateThrust()
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

        private bool isThrusting()
        {
            return _isThrusting;
        }

        private void isThrusting(bool param1)
        {
            _isThrusting = param1;
        }

        private void applyThrust()
        {
            _currentThrust = MaxThrust;
        }

        private bool isFlaunting()
        {
            return _isFlaunting;
        }

        private void isFlaunting(bool param1)
        {
            _isFlaunting = param1;
        }

        private static bool isAdmin(string param1)
        {
            return Admins.Contains(param1);
        }
    }
}