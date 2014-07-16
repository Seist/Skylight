// <author>TakoMan02</author>
// <summary>Player.cs describes a singular player in an EE world.</summary>

using System;
using System.Collections.Generic;
using System.Drawing;
using Skylight.Physics;

namespace Skylight
{
    public class Player
    {
        // Private instance fields
        private static readonly List<string> admins = new List<string>
        {
            "benjaminsen",
            "cyclone",
            "toby",
            "rpgmaster2000",
            "mrshoe",
            "mrvoid"
        };

        private readonly double mult;
        private readonly Queue<int> queue = new Queue<int>();
        private readonly Dictionary<string, int> touchpotions = new Dictionary<string, int>();
        private double HorizontalAcceleration;
        private double OldHorizontalAcceleration;
        private double OldVerticalAcceleration;
        public bool SwitchOpened = false;
        private double VerticalAcceleration;
        public double X = 0;
        public double Y = 0;
        protected double _boost;
        private double _currentThrust;
        protected double _gravity;
        private bool _hasLevitation;
        private bool _isFlaunting;
        private bool _isInvulnerable;
        private bool _isThrusting;
        private double _maxThrust = 0.2;
        protected double _modifierX = 0;
        protected double _modifierY = 0;
        protected double _mud_buoyancy;
        protected double _mud_drag;
        protected double _no_modifier_dragX;
        protected double _no_modifier_dragY;
        protected double _speedX = 0;
        protected double _speedY = 0;
        private double _thrustBurnOff = 0.01;
        protected double _water_buoyancy;
        protected double _water_drag;
        private double animoffset;
        private int bcoins;

        private int
            blueCoins;

        private bool cchanged = false;
        public int checkpoint_x = -1;
        public int checkpoint_y = -1;
        private double cluboffset;
        private Rectangle clubrect;

        private int
            coins,
            collectedMagic;

        public int currentBlockId = 0;
        private double currentSX;
        private double currentSY;
        private int cx;
        private int cy;
        private double deadoffset;

        private int
            deathCount;

        private bool donex;
        private bool doney;
        private double gravityMultiplier = 1;

        private bool
            hasAccess,
            hasBoost;

        private bool hasChat;

        private bool
            hasClub,
            hasCommandAccess,
            hasCrown,
            hasGravityModifier,
            hasSilverCrown;

        internal int horizontal = 0;

        private int
            id = -1;

        private bool injump = false;
        private bool isCursed;
        private bool isDead;

        private bool
            isFriend,
            isGod,
            isHoldingDown,
            isHoldingLeft,
            isHoldingRight;

        private bool
            isHoldingSpace;

        private bool
            isHoldingUp;

        private bool
            isMod,
            isOwner;

        private bool isZombie;
        public bool isclubmember = false;
        private bool isgodmod;
        private bool jump_boost = false;
        private Point lastPortal;
        private double last_respawn;
        private int level = 1;
        private int mod = 0;
        private double modoffset;
        private Rectangle modrect;
        private int morx;
        private int mory;
        private bool moving;
        private string name;
        private double oldX = -1;
        private double oldY = -1;
        private double osx;
        private double osy;
        private int overlapy;
        private double ox;
        private double oy;
        private Room playingIn;
        private List<int> potionEffects = new List<int>();
        private double reminderX;
        private double reminderY;
        protected int size;

        private int
            smiley;

        private bool spacejustdown;
        private double tx;
        private double ty;
        internal int vertical = 0;
        private bool worldportalsend = false;

        private int
            xpLevel;

        public Player(Room room, int id, string name, int smiley, double xPos, double yPos, bool isGod, bool isMod,
            bool hasChat, int coins, bool purple, bool isFriend, int level)
        {
            PlayingIn = room;
            Smiley = smiley;
            IsGod = isGod;
            IsMod = isMod;
            Id = id;
            this.hasChat = hasChat;
            Coins = coins;
            SwitchOpened = purple;
            this.isFriend = isFriend;
            this.level = level;
            queue = new Queue<int>(Config.physics_queue_length);
            lastPortal = new Point();
            modrect = new Rectangle(0, 0, 64, 64);
            clubrect = new Rectangle(0, 0, 64, 64);
            _currentThrust = _maxThrust;
            X = xPos;
            Y = yPos;
            Name = name;
            size = 16;
            _no_modifier_dragX = Config.physics_no_modifier_drag;
            _no_modifier_dragY = Config.physics_no_modifier_drag;
            _water_drag = Config.physics_water_drag;
            _water_buoyancy = Config.physics_water_buoyancy;
            _mud_drag = Config.physics_mud_drag;
            _mud_buoyancy = Config.physics_mud_buoyancy;
            _boost = Config.physics_boost;
            _gravity = Config.physics_gravity;
            mult = Config.physics_variable_multiplyer;
        }

        // Public instance properties.
        public bool HasAccess
        {
            get { return hasAccess; }

            internal set { hasAccess = value; }
        }

        public bool HasBoost
        {
            get { return hasBoost; }

            internal set { hasBoost = value; }
        }

        public bool HasClub
        {
            get { return hasClub; }

            internal set { hasClub = value; }
        }

        public bool HasCommandAccess
        {
            get { return hasCommandAccess; }

            internal set { hasCommandAccess = value; }
        }

        public bool HasCrown
        {
            get { return hasCrown; }

            internal set { hasCrown = value; }
        }

        public bool HasGravityModifier
        {
            get { return hasGravityModifier; }

            internal set { hasGravityModifier = value; }
        }

        public bool HasSilverCrown
        {
            get { return hasSilverCrown; }

            internal set { hasSilverCrown = value; }
        }

        public bool IsBot
        {
            get
            {
                if (PlayingIn != null)
                {
                    foreach (Bot bt in PlayingIn.OnlineBots)
                    {
                        if (bt.Id == Id)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public bool IsFriend
        {
            get { return isFriend; }

            internal set { isFriend = value; }
        }

        public bool IsGod
        {
            get { return isGod; }

            internal set { isGod = value; }
        }

        public bool IsMod
        {
            get { return isMod; }

            internal set { isMod = value; }
        }

        public bool IsHoldingLeft
        {
            get { return isHoldingLeft; }

            internal set { isHoldingLeft = value; }
        }

        public bool IsHoldingRight
        {
            get { return isHoldingRight; }

            internal set { isHoldingRight = value; }
        }

        public bool IsHoldingUp
        {
            get { return isHoldingUp; }

            internal set { isHoldingUp = value; }
        }

        public bool IsHoldingDown
        {
            get { return isHoldingDown; }

            internal set { isHoldingDown = value; }
        }

        public bool IsHoldingSpace
        {
            get { return isHoldingSpace; }

            internal set { isHoldingSpace = value; }
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
            get { return coins; }

            internal set { coins = value; }
        }

        public int BlueCoins
        {
            get { return blueCoins; }
            internal set { blueCoins = value; }
        }

        public int CollectedMagic
        {
            get { return collectedMagic; }

            internal set { collectedMagic = value; }
        }

        public int DeathCount
        {
            get { return deathCount; }

            internal set { deathCount = value; }
        }

        public int Id
        {
            get { return id; }

            internal set { id = value; }
        }

        public int Smiley
        {
            get { return smiley; }

            internal set { smiley = value; }
        }

        public int XpLevel
        {
            get { return xpLevel; }

            internal set { xpLevel = value; }
        }

        public List<int> PotionEffects
        {
            get { return potionEffects; }

            internal set { potionEffects = value; }
        }

        public Room PlayingIn
        {
            get { return playingIn; }

            internal set { playingIn = value; }
        }

        public string Name
        {
            get { return name; }
            internal set { name = value.ToLower(); }
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
            get { return _speedX*mult; }
            set { _speedX = value/mult; }
        }

        internal double speedY
        {
            get { return _speedY*mult; }
            set { _speedY = value/mult; }
        }

        internal double modifierX
        {
            get { return _modifierX*mult; }
            set { _modifierX = value/mult; }
        }

        internal double modifierY
        {
            get { return _modifierY*mult; }
            set { _modifierY = value/mult; }
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
            get { return (int) Math.Round(((oldX)/16.0)); }
        }

        private int OldBlockY
        {
            get { return (int) Math.Round(((oldY)/16.0)); }
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
            return param1 >= X && param2 >= Y && param1 <= X + size && param2 <= Y + size;
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
            return _mud_drag;
        }

        private int overlaps(Player player)
        {
            var _loc_8 = new List<int>();

            int _loc_11 = 0;
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
                                    _loc_11 = currentBlock.Id;
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
                                                    ((CoinBlock) currentBlock).CoinsRequired <= coins)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Gates.COIN:
                                            {
                                                if (currentBlock is CoinBlock &&
                                                    ((CoinBlock) currentBlock).CoinsRequired > coins)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Gates.ZOMBIE:
                                            {
                                                if (isZombie)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Doors.ZOMBIE:
                                            {
                                                if (!isZombie)
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
                                                if (_loc_2.speedY < 0 || _loc_9 <= _loc_2.overlapy)
                                                {
                                                    if (_loc_9 != _loc_4 || _loc_2.overlapy == -1)
                                                    {
                                                        _loc_2.overlapy = (int) _loc_9;
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
            if (currentSX > 0)
            {
                if (currentSX + reminderX >= 1)
                {
                    X = X + (1 - reminderX);
                    X = Math.Floor(X);
                    currentSX = currentSX - (1 - reminderX);
                    reminderX = 0;
                }
                else
                {
                    X = X + currentSX;
                    currentSX = 0;
                }
            }
            else if (currentSX < 0)
            {
                if (reminderX != 0 && reminderX + currentSX < 0)
                {
                    currentSX = currentSX + reminderX;
                    X = X - reminderX;
                    X = Math.Floor(X);
                    reminderX = 1;
                }
                else
                {
                    X = X + currentSX;
                    currentSX = 0;
                }
            }

            if (overlaps(this) != 0)
            {
                X = ox;
                _speedX = 0;
                currentSX = osx;
                donex = true;
            }
        }

        private void stepy()
        {
            if (currentSY > 0)
            {
                if (currentSY + reminderY >= 1)
                {
                    Y = Y + (1 - reminderY);
                    Y = Math.Floor(Y);
                    currentSY = currentSY - (1 - reminderY);
                    reminderY = 0;
                }
                else
                {
                    Y = Y + currentSY;
                    currentSY = 0;
                }
            }
            else if (currentSY < 0)
            {
                if (reminderY != 0 && reminderY + currentSY < 0)
                {
                    Y = Y - reminderY;
                    Y = Math.Floor(Y);
                    currentSY = currentSY + reminderY;
                    reminderY = 1;
                }
                else
                {
                    Y = Y + currentSY;
                    currentSY = 0;
                }
            }

            if (overlaps(this) != 0)
            {
                Y = oy;
                _speedY = 0;
                currentSY = osy;
                doney = true;
            }
        }

        private void processPortals()
        {
            var targetPortalList = new List<Point>();
            int loopIterator = 0;
            var currentLoopPortal = new Point(0, 0);
            int _loc_4 = 0;
            int _loc_5 = 0;
            double _loc_6 = 0;
            double _loc_7 = 0;
            double _loc_8 = 0;
            double _loc_9 = 0;
            int _loc_10 = 0;
            double _loc_11 = 0;
            currentBlockId = PlayingIn.Map[cx, cy, 0].Id;
            if (!isgodmod && currentBlockId == BlockIds.Action.Portals.WORLD)
            {
                if (spacejustdown && !worldportalsend)
                {
                }
            }
            if (!isgodmod && currentBlockId == 242)
            {
                if (lastPortal.X == 0 && lastPortal.Y == 0)
                {
                    lastPortal = new Point(cx << 4, cy << 4);

                    Block currentBlock = PlayingIn.Map[cx, cy, 0];
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
                    loopIterator = 0;
                    while (loopIterator < targetPortalList.Count)
                    {
                        currentLoopPortal = targetPortalList[loopIterator];
                        _loc_4 = PlayingIn.Map[lastPortal.X >> 4, lastPortal.Y >> 4, 0].Direction;
                        _loc_5 = PlayingIn.Map[currentLoopPortal.X >> 4, currentLoopPortal.Y >> 4, 0].Direction;
                        if (_loc_4 < _loc_5)
                        {
                            _loc_4 = _loc_4 + 4;
                        }
                        _loc_6 = speedX;
                        _loc_7 = speedY;
                        _loc_8 = modifierX;
                        _loc_9 = modifierY;
                        _loc_10 = _loc_4 - _loc_5;
                        _loc_11 = 1.42;
                        switch (_loc_10)
                        {
                            case 1:
                            {
                                speedX = _loc_7*_loc_11;
                                speedY = (-_loc_6)*_loc_11;
                                modifierX = _loc_9*_loc_11;
                                modifierY = (-_loc_8)*_loc_11;
                                reminderY = -reminderY;
                                currentSY = -currentSY;
                                break;
                            }
                            case 3:
                            {
                                speedX = (-_loc_7)*_loc_11;
                                speedY = _loc_6*_loc_11;
                                modifierX = (-_loc_9)*_loc_11;
                                modifierY = _loc_8*_loc_11;
                                reminderX = -reminderX;
                                currentSX = -currentSX;
                                break;
                            }
                            case 2:
                            {
                                speedX = (-_loc_6)*_loc_11;
                                speedY = (-_loc_7)*_loc_11;
                                modifierX = (-_loc_8)*_loc_11;
                                modifierY = (-_loc_9)*_loc_11;
                                reminderY = -reminderY;
                                currentSY = -currentSY;
                                reminderX = -reminderX;
                                currentSX = -currentSX;
                                break;
                            }
                            default:
                            {
                                break;
                            }
                        }

                        X = currentLoopPortal.X;
                        Y = currentLoopPortal.Y;
                        lastPortal = currentLoopPortal;
                        loopIterator++;
                        break;
                    }
                }
            }
            else
            {
                lastPortal = new Point(0, 0);
            }
        }

        public void tick()
        {
            oldX = X;
            oldY = Y;

            animoffset = animoffset + 0.2;
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
                cluboffset = cluboffset + 0.2;
                if (cluboffset >= 14)
                {
                    cluboffset = 0;
                }
            }
            else
            {
                modoffset = 0;
            }
            if (isDead)
            {
                deadoffset = deadoffset + 0.3;
            }
            else
            {
                deadoffset = 0;
            }
            cx = (int) ((X + 8)/16);
            cy = (int) ((Y + 8)/16);
            int delayed = 0;
            if (queue.Count >= 1)
            {
                delayed = queue.Dequeue();
            }
            currentBlockId = PlayingIn.Map[cx, cy, 0].Id;
            queue.Enqueue(currentBlockId);
            if (currentBlockId == 4 || ItemId.isClimbable(currentBlockId))
            {
                delayed = queue.Dequeue();
                queue.Enqueue(currentBlockId);
            }
            if (isDead)
            {
                horizontal = 0;
                vertical = 0;
                spacejustdown = false;
            }
            isgodmod = IsGod || IsMod;
            if (isgodmod)
            {
                morx = 0;
                mory = 0;
                OldHorizontalAcceleration = 0;
                OldVerticalAcceleration = 0;
            }
            else
            {
                switch (currentBlockId)
                {
                    case 1:
                    {
                        morx = -(int) _gravity;
                        mory = 0;
                        break;
                    }
                    case 2:
                    {
                        morx = 0;
                        mory = -(int) _gravity;
                        break;
                    }
                    case 3:
                    {
                        morx = (int) _gravity;
                        mory = 0;
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
                        morx = 0;
                        mory = 0;
                        break;
                    }
                    case BlockIds.Action.Liquids.WATER:
                    {
                        morx = 0;
                        mory = (int) _water_buoyancy;
                        break;
                    }
                    case BlockIds.Action.Liquids.MUD:
                    {
                        morx = 0;
                        mory = (int) _mud_buoyancy;
                        break;
                    }
                    case BlockIds.Action.Hazards.FIRE:
                    case BlockIds.Action.Hazards.SPIKE:
                    {
                        if (!isDead && !_isInvulnerable)
                        {
                            killPlayer();
                        }
                        break;
                    }
                    default:
                    {
                        morx = 0;
                        mory = (int) _gravity;
                        break;
                    }
                }
                switch (delayed)
                {
                    case 1:
                    {
                        OldHorizontalAcceleration = -_gravity;
                        OldVerticalAcceleration = 0;
                        break;
                    }
                    case 2:
                    {
                        OldHorizontalAcceleration = 0;
                        OldVerticalAcceleration = -_gravity;
                        break;
                    }
                    case 3:
                    {
                        OldHorizontalAcceleration = _gravity;
                        OldVerticalAcceleration = 0;
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
                        OldHorizontalAcceleration = 0;
                        OldVerticalAcceleration = 0;
                        break;
                    }
                    case BlockIds.Action.Liquids.WATER:
                    {
                        OldHorizontalAcceleration = 0;
                        OldVerticalAcceleration = _water_buoyancy;
                        break;
                    }
                    case BlockIds.Action.Liquids.MUD:
                    {
                        OldHorizontalAcceleration = 0;
                        OldVerticalAcceleration = _mud_buoyancy;
                        break;
                    }
                    default:
                    {
                        OldHorizontalAcceleration = 0;
                        OldVerticalAcceleration = _gravity;
                        break;
                    }
                }
            }
            if (OldVerticalAcceleration == _water_buoyancy || OldVerticalAcceleration == _mud_buoyancy)
            {
                HorizontalAcceleration = horizontal;
                VerticalAcceleration = vertical;
            }
            else if (OldVerticalAcceleration != 0)
            {
                HorizontalAcceleration = horizontal;
                VerticalAcceleration = 0;
            }
            else if (OldHorizontalAcceleration != 0)
            {
                HorizontalAcceleration = 0;
                VerticalAcceleration = vertical;
            }
            else
            {
                HorizontalAcceleration = horizontal;
                VerticalAcceleration = vertical;
            }
            HorizontalAcceleration = HorizontalAcceleration*speedMultiplier();
            VerticalAcceleration = VerticalAcceleration*speedMultiplier();
            OldHorizontalAcceleration = OldHorizontalAcceleration*gravityMultiplier;
            OldVerticalAcceleration = OldVerticalAcceleration*gravityMultiplier;
            modifierX = OldHorizontalAcceleration + HorizontalAcceleration;

            modifierY = OldVerticalAcceleration + VerticalAcceleration;
            if (_speedX != 0 || _modifierX != 0)
            {
                _speedX = _speedX + _modifierX;
                _speedX = _speedX*Config.physics_base_drag;
                if (HorizontalAcceleration == 0 && OldVerticalAcceleration != 0 ||
                    _speedX < 0 && HorizontalAcceleration > 0 || _speedX > 0 && HorizontalAcceleration < 0 ||
                    ItemId.isClimbable(currentBlockId) && !isgodmod)
                {
                    _speedX = _speedX*_no_modifier_dragX;
                }
                else if (currentBlockId == BlockIds.Action.Liquids.WATER && !isgodmod)
                {
                    _speedX = _speedX*_water_drag;
                }
                else if (currentBlockId == BlockIds.Action.Liquids.MUD && !isgodmod)
                {
                    _speedX = _speedX*dragMud();
                }
                if (_speedX > 16)
                {
                    _speedX = 16;
                }
                else if (_speedX < -16)
                {
                    _speedX = -16;
                }
                else if (_speedX < 0.0001 && _speedX > -0.0001)
                {
                    _speedX = 0;
                }
            }
            if (_speedY != 0 || _modifierY != 0)
            {
                _speedY = _speedY + _modifierY;
                _speedY = _speedY*Config.physics_base_drag;
                if (VerticalAcceleration == 0 && OldHorizontalAcceleration != 0 ||
                    _speedY < 0 && VerticalAcceleration > 0 || _speedY > 0 && VerticalAcceleration < 0 ||
                    ItemId.isClimbable(currentBlockId) && !isgodmod)
                {
                    _speedY = _speedY*_no_modifier_dragY;
                }
                else if (currentBlockId == BlockIds.Action.Liquids.WATER && !isgodmod)
                {
                    _speedY = _speedY*_water_drag;
                }
                else if (currentBlockId == BlockIds.Action.Liquids.MUD && !isgodmod)
                {
                    _speedY = _speedY*dragMud();
                }
                if (_speedY > 16)
                {
                    _speedY = 16;
                }
                else if (_speedY < -16)
                {
                    _speedY = -16;
                }
                else if (_speedY < 0.0001 && _speedY > -0.0001)
                {
                    _speedY = 0;
                }
            }
            if (!isgodmod)
            {
                switch (currentBlockId)
                {
                    case BlockIds.Action.Boost.LEFT:
                    {
                        _speedX = -_boost;
                        break;
                    }
                    case BlockIds.Action.Boost.RIGHT:
                    {
                        _speedX = _boost;
                        break;
                    }
                    case BlockIds.Action.Boost.UP:
                    {
                        _speedY = -_boost;
                        break;
                    }
                    case BlockIds.Action.Boost.DOWN:
                    {
                        _speedY = _boost;
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            reminderX = X%1;
            currentSX = _speedX;
            reminderY = Y%1;
            currentSY = _speedY;
            donex = false;
            doney = false;
            while (currentSX != 0 && !donex || currentSY != 0 && !doney)
            {
                processPortals();
                ox = X;
                oy = Y;
                osx = currentSX;
                osy = currentSY;
                stepx();
                stepy();
            }

            if (Levitation)
            {
                updateThrust();
            }
            double imx = _speedX*256;
            double imy = _speedY*256;
            moving = false;
            if (imx != 0 || currentBlockId == BlockIds.Action.Liquids.WATER ||
                currentBlockId == BlockIds.Action.Liquids.MUD)
            {
                moving = true;
            }
            else if (_modifierX < 0.1 && _modifierX > -0.1)
            {
                tx = X%16;
                if (tx < 2)
                {
                    if (tx < 0.2)
                    {
                        X = Math.Floor(X);
                    }
                    else
                    {
                        X = X - tx/15;
                    }
                }
                else if (tx > 14)
                {
                    if (tx > 15.8)
                    {
                        X = Math.Floor(X);
                        double _loc_3 = X + 1;
                        X = _loc_3;
                    }
                    else
                    {
                        X = X + (tx - 14)/15;
                    }
                }
            }
            if (imy != 0 || currentBlockId == BlockIds.Action.Liquids.WATER ||
                currentBlockId == BlockIds.Action.Liquids.MUD)
            {
                moving = true;
            }
            else if (_modifierY < 0.1 && _modifierY > -0.1)
            {
                ty = Y%16;
                if (ty < 2)
                {
                    if (ty < 0.2)
                    {
                        Y = Math.Floor(Y);
                    }
                    else
                    {
                        Y = Y - ty/15;
                    }
                }
                else if (ty > 14)
                {
                    if (ty > 15.8)
                    {
                        Y = Math.Floor(Y);
                        double _loc_3 = Y + 1;
                        Y = _loc_3;
                    }
                    else
                    {
                        Y = Y + (ty - 14)/15;
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
            isDead = true;
        }

        private void respawn()
        {
            _modifierX = 0;
            _modifierY = 0;
            modifierX = 0;
            modifierY = 0;
            _speedX = 0;
            _speedY = 0;
            speedX = 0;
            speedY = 0;
            isDead = false;

            last_respawn = DateTime.Now.Millisecond;
        }

        private void resetCoins()
        {
            coins = 0;
            bcoins = 0;
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
            isCursed = param1;
        }

        private bool cursed()
        {
            return isCursed;
        }

        private void zombie(bool param1)
        {
            isZombie = param1;
        }

        private bool zombie()
        {
            if (IsGod || IsMod)
            {
                return false;
            }
            return isZombie;
        }

        private void addTouchPotion(string param1, double param2 = 1)
        {
            touchpotions.Add(param1, DateTime.Now.Millisecond + (int) param2*1000);
        }

        private void removeTouchPotion(string param1)
        {
            touchpotions.Remove(param1);
        }

        private bool hasActivePotion(string param1)
        {
            if (!touchpotions.ContainsKey(param1))
            {
                return false;
            }
            return (DateTime.Now.Millisecond - touchpotions[param1]) > 0;
        }

        private bool hasPotion(string param1)
        {
            return touchpotions.ContainsKey(param1);
        }

        private List<string> getActivePotions()
        {
            var _loc_1 = new List<string>();
            foreach (string _loc_2 in touchpotions.Keys)
            {
                if (hasActivePotion(_loc_2))
                {
                    _loc_1.Add(_loc_2);
                }
            }
            return _loc_1;
        }

        private bool getCanTag()
        {
            if (IsGod || IsMod || isDead)
            {
                return false;
            }
            return getActivePotions().Count > 0;
        }

        private bool getCanBeTagged()
        {
            if (IsGod || IsMod || isDead)
            {
                return false;
            }
            return (DateTime.Now.Millisecond - last_respawn) > 1000;
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
            if (mory != 0)
            {
                speedY = speedY - _currentThrust*(Config.physics_jump_height/2)*(mory*0.5);
            }
            if (morx != 0)
            {
                speedX = speedX - _currentThrust*(Config.physics_jump_height/2)*(morx*0.5);
            }
            if (!_isThrusting)
            {
                if (_currentThrust > 0)
                {
                    _currentThrust = _currentThrust - _thrustBurnOff;
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
            _currentThrust = _maxThrust;
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
            return admins.Contains(param1);
        }
    }
}