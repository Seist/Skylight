// <author>TakoMan02</author>
// <summary>Player.cs describes a singular player in an EE world.</summary>
namespace Skylight
{
    using Skylight.Physics;
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class Player
    {
        // Private instance fields
        private bool
            hasAccess,
            hasBoost,
            hasClub,
            hasCommandAccess,
            hasCrown,
            hasGravityModifier,
            hasSilverCrown,
            isFriend,
            isGod,
            isHoldingDown,
            isHoldingLeft,
            isHoldingRight,
            isHoldingUp,
            isHoldingSpace,
            isMod,
            isOwner;

        private int
            blueCoins,
            coins,
            collectedMagic,
            deathCount,
            id = -1,
            smiley,
            xpLevel;

        private List<int> potionEffects = new List<int>();

        private Room playingIn;

        private string name;

        // Public instance properties.
        public bool HasAccess
        {
            get;

            internal set;
        }

        public bool HasBoost
        {
            get;

            internal set;
        }

        public bool HasClub
        {
            get;

            internal set;
        }

        public bool HasCommandAccess
        {
            get;

            internal set;
        }

        public bool HasCrown
        {
            get;

            internal set;
        }

        public bool HasGravityModifier
        {
            get;

            internal set;
        }

        public bool HasSilverCrown
        {
            get;

            internal set;
        }

        public bool IsBot
        {
            get
            {
                if (this.PlayingIn != null)
                {
                    foreach (Bot bt in this.PlayingIn.OnlineBots)
                    {
                        if (bt.Id == this.Id)
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
            get;

            internal set;
        }

        public bool IsGod
        {
            get;

            internal set;
        }

        public bool IsMod
        {
            get;

            internal set;
        }

        public bool IsHoldingLeft
        {
            get;

            internal set;
        }

        public bool IsHoldingRight
        {
            get;

            internal set;
        }

        public bool IsHoldingUp
        {
            get;

            internal set;
        }

        public bool IsHoldingDown
        {
            get;

            internal set;
        }

        public bool IsHoldingSpace
        {
            get;

            internal set;
        }

        public bool IsOwner
        {
            get
            {
                return (this.PlayingIn.Owner == this);

            }

            internal set
            {
                this.isOwner = value;
            }
        }

        public int Coins
        {
            get;

            internal set;
        }

        public int BlueCoins
        {
            get;
            internal set;
        }

        public int CollectedMagic
        {
            get;

            internal set;
        }

        public int DeathCount
        {
            get;

            internal set;
        }

        public int Id
        {
            get;

            internal set;
        }

        public int Smiley
        {
            get;

            internal set;
        }

        public int XpLevel
        {
            get;

            internal set;
        }

        public List<int> PotionEffects
        {
            get;

            internal set;
        }

        public Room PlayingIn
        {
            get;

            internal set;
        }

        public string Name
        {
            get { return this.name; }
            internal set { this.name = value.ToLower(); }
        }

        public bool SwitchOpened = false;
        private double gravityMultiplier = 1;
        internal int horizontal = 0;
        internal int vertical = 0;

        private void ResetCoins()
        {
            this.Coins = 0;
            this.BlueCoins = 0;
            return;
        }

        /* --------------------------- GUSTAVIAN PHYSICS --------------------------- */

        public double X = 0;
        public double Y = 0;
        private bool moving = false;
        protected int size;
        private bool hitTest(int param1, int param2)
        {
            return param1 >= X && param2 >= Y && param1 <= X + this.size && param2 <= Y + this.size;
        }
        protected double _speedX = 0;
        protected double _speedY = 0;
        protected double _modifierX = 0;
        protected double _modifierY = 0;
        protected double _no_modifier_dragX;
        protected double _no_modifier_dragY;
        protected double _water_drag;
        protected double _water_buoyancy;
        protected double _mud_drag;
        protected double _mud_buoyancy;
        protected double _boost;
        protected double _gravity;
        private double OldHorizontalAcceleration = 0;
        private double OldVerticalAcceleration = 0;
        private double HorizontalAcceleration = 0;
        private double VerticalAcceleration = 0;

        private double mult;
        protected int blockX
        {
            get
            {
                return (int)Math.Round(((this.X) / 16.0));
            }
        }
        protected int blockY
        {
            get
            {
                return (int)Math.Round((this.Y) / 16.0);
            }
        }
        internal double posX
        {
            get
            {
                return (this.X + 8);
            }
        }
        internal double posY
        {
            get
            {
                return (this.Y + 8);
            }
        }
        internal double speedX
        {
            get
            {
                return this._speedX * this.mult;
            }
            set
            {
                this._speedX = value / this.mult;
            }
        }
        internal double speedY
        {
            get
            {
                return this._speedY * this.mult;
            }
            set
            {
                this._speedY = value / this.mult;
            }
        }
        internal double modifierX
        {
            get
            {
                return this._modifierX * this.mult;
            }
            set
            {
                this._modifierX = value / this.mult;
            }
        }
        internal double modifierY
        {
            get
            {
                return this._modifierY * this.mult;
            }
            set
            {
                this._modifierY = value / this.mult;
            }
        }

        private bool isDead = false;
        private bool worldportalsend = false;
        private bool _isInvulnerable = false;
        private int morx = 0;
        private int mory = 0;
        private int level = 1;
        private int bcoins = 0;
        public bool isclubmember = false;
        public int currentBlockId = 0;
        public int checkpoint_x = -1;
        public int checkpoint_y = -1;
        private int overlapy = 0;
        private double last_respawn = 0;
        private bool _hasLevitation = false;
        private bool _isFlaunting = false;
        private Queue<int> queue = new Queue<int>();


        private bool spacejustdown = false;

        private Point lastPortal;

        private bool donex = false;
        private bool doney = false;
        private double animoffset = 0;
        private double modoffset = 0;
        private Rectangle modrect;
        private double cluboffset = 0;
        private Rectangle clubrect;
        private double deadoffset = 0;
        private bool jump_boost = false;
        private bool isZombie = false;
        private bool isCursed = false;
        private Dictionary<string, int> touchpotions = new Dictionary<string, int>();
        private bool _isThrusting = false;
        private double _maxThrust = 0.2;
        private double _thrustBurnOff = 0.01;
        private double _currentThrust;
        private static List<string> admins = new List<string> { "benjaminsen", "cyclone", "toby", "rpgmaster2000", "mrshoe", "mrvoid", "atilla", "meredith1999" };
        private bool hasChat;

        private double oldX = -1;
        private double oldY = -1;

        private int cx = 0;
        private int cy = 0;
        private bool isgodmod = false;
        private double reminderX = 0;
        private double currentSX = 0;
        private double reminderY = 0;
        private double currentSY = 0;
        private double osx = 0;
        private double osy = 0;
        private double ox = 0;
        private double oy = 0;
        private int mod = 0;
        private bool injump = false;
        private bool cchanged = false;
        private double tx = 0;
        private double ty = 0;

        public int BlockX { get { return blockX; } set { X = value * 16; } }
        public int BlockY { get { return blockY; } set { Y = value * 16; } }
        private int OldBlockX { get { return (int)Math.Round(((this.oldX) / 16.0)); } }
        private int OldBlockY { get { return (int)Math.Round(((this.oldY) / 16.0)); } }
        private bool Moved { get { return BlockX != OldBlockX || BlockY != OldBlockY; } }

        public Player(Room room, int id, string name, int smiley, double xPos, double yPos, bool isGod, bool isMod, bool hasChat, int coins, bool purple, bool isFriend, int level)
        {
            this.PlayingIn = room;
            this.Smiley = smiley;
            this.IsGod= isGod;
            this.IsMod= isMod;
            this.Id = id;
            this.hasChat = hasChat;
            this.Coins = coins;
            this.SwitchOpened = purple;
            this.isFriend = isFriend;
            this.level = level;
            this.queue = new Queue<int>(Config.physics_queue_length);
            this.lastPortal = new Point();
            this.modrect = new Rectangle(0, 0, 64, 64);
            this.clubrect = new Rectangle(0, 0, 64, 64);
            this._currentThrust = this._maxThrust;
            this.X = xPos;
            this.Y = yPos;
            this.Name = name;
            size = 16;
            this._no_modifier_dragX = Config.physics_no_modifier_drag;
            this._no_modifier_dragY = Config.physics_no_modifier_drag;
            this._water_drag = Config.physics_water_drag;
            this._water_buoyancy = Config.physics_water_buoyancy;
            this._mud_drag = Config.physics_mud_drag;
            this._mud_buoyancy = Config.physics_mud_buoyancy;
            this._boost = Config.physics_boost;
            this._gravity = Config.physics_gravity;
            this.mult = Config.physics_variable_multiplyer;

            return;
        }

        private double jumpMultiplier()
        {
            double _loc_1 = 1;
            if (this.jump_boost)
            {
                _loc_1 = _loc_1 * 1.2;
            }
            if (this.zombie())
            {
                _loc_1 = _loc_1 * 0.75;
            }
            return _loc_1;
        }

        private double speedMultiplier()
        {
            double _loc_1 = 1;
            if (this.zombie())
            {
                _loc_1 = _loc_1 * 0.6;
            }
            return _loc_1;
        }

        private double dragMud()
        {
            return _mud_drag;
        }

        private int overlaps(Player player)
        {
            List<int> _loc_8 = new List<int>();

            int _loc_11 = 0;
            if (player.X < 0 || player.Y < 0 || player.X >= this.PlayingIn.Width * 16 - 8 || 
                player.Y >= this.PlayingIn.Height * 16 - 8)
            {
                return 1;
            }

            Player _loc_2 = this;

            if (_loc_2.IsGod|| _loc_2.IsMod)
            {
                return 0;
            }

            double _loc_3 = ((_loc_2.X) / 16);
            double _loc_4 = ((_loc_2.Y) / 16);
            for (int xx = -2; xx < 1; xx++)
            {
                for (int yy = -2; yy < 1; yy++)
                {
                    if (_loc_3 + xx > 0 && _loc_3 + xx < this.PlayingIn.Width && _loc_4 + yy > 0 && 
                        _loc_4 + yy <= this.PlayingIn.Height)
                    {
                        for (int xTest = 0; xTest < 16; xTest++)
                        {
                            for (int yTest = 0; yTest < 16; yTest++)
                            {
                                if (hitTest((int)(xTest + _loc_2.X + xx * 16), (int)(yTest + _loc_2.Y + yy * 16)))
                                {
                                    double _loc_9 = _loc_4;
                                    Block currentBlock = this.PlayingIn.Map[
                                        (int)(((xx * 16) + _loc_2.X + xTest) / 16),
                                        (int)(((yy * 16) + _loc_2.Y + yTest) / 16),
                                        0];
                                    _loc_11 = currentBlock.Id;
                                    if (ItemId.isSolid(_loc_11))
                                    {
                                        switch (_loc_11)
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
                                            case BlockIds.Action.Doors.SWITCH:
                                                {
                                                    if (this.SwitchOpened)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case BlockIds.Action.Gates.SWITCH:
                                                {
                                                    if (!this.SwitchOpened)
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
                                                    if (currentBlock is CoinBlock && ((CoinBlock)currentBlock).CoinsRequired <= coins)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case BlockIds.Action.Gates.COIN:
                                                {
                                                    if (currentBlock is CoinBlock && ((CoinBlock)currentBlock).CoinsRequired > coins)
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
                                                            _loc_2.overlapy = (int)_loc_9;
                                                        }
                                                        break;
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

            return;
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
            List<Point> targetPortalList = new List<Point>();
            int loopIterator = 0;
            Point currentLoopPortal = new Point(0, 0);
            int _loc_4,
            _loc_5,
            _loc_10;
            double _loc_6,
            _loc_7,
            _loc_8,
            _loc_9,
            _loc_11 = 0;
            currentBlockId = this.PlayingIn.Map[cx, cy, 0].Id;
            
            if (!isgodmod && currentBlockId == 242)
            {
                if (lastPortal.X == 0 && lastPortal.Y == 0)
                {
                    lastPortal = new Point(cx << 4, cy << 4);

                    Block currentBlock = this.PlayingIn.Map[cx, cy, 0];
                    PortalBlock currentPortalBlock = (PortalBlock)currentBlock;
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
                    loopIterator = 0;
                    while (loopIterator < targetPortalList.Count)
                    {
                        currentLoopPortal = targetPortalList[loopIterator];
                        _loc_4 = ((PortalBlock)this.PlayingIn.Map[lastPortal.X >> 4, lastPortal.Y >> 4, 0]).Direction;
                        _loc_5 = ((PortalBlock)this.PlayingIn.Map[currentLoopPortal.X >> 4, currentLoopPortal.Y >> 4, 0]).Direction;
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
                                    speedX = _loc_7 * _loc_11;
                                    speedY = (-_loc_6) * _loc_11;
                                    modifierX = _loc_9 * _loc_11;
                                    modifierY = (-_loc_8) * _loc_11;
                                    reminderY = -reminderY;
                                    currentSY = -currentSY;
                                    break;
                                }
                            case 2:
                                {
                                    speedX = (-_loc_6) * _loc_11;
                                    speedY = (-_loc_7) * _loc_11;
                                    modifierX = (-_loc_8) * _loc_11;
                                    modifierY = (-_loc_9) * _loc_11;
                                    reminderY = -reminderY;
                                    currentSY = -currentSY;
                                    reminderX = -reminderX;
                                    currentSX = -currentSX;
                                    break;
                                }
                            case 3:
                                {
                                    speedX = (-_loc_7) * _loc_11;
                                    speedY = _loc_6 * _loc_11;
                                    modifierX = (-_loc_9) * _loc_11;
                                    modifierY = _loc_8 * _loc_11;
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
            return;
        }

        public void tick()
        {
            oldX = this.X;
            oldY = this.Y;

            this.animoffset = this.animoffset + 0.2;
            if (this.IsMod&& !this.IsGod)
            {
                this.modoffset = this.modoffset + 0.2;
                if (this.modoffset >= 16)
                {
                    this.modoffset = 10;
                }
            }
            else if (this.isclubmember)
            {
                this.cluboffset = this.cluboffset + 0.2;
                if (this.cluboffset >= 14)
                {
                    this.cluboffset = 0;
                }
            }
            else
            {
                this.modoffset = 0;
            }
            if (this.isDead)
            {
                this.deadoffset = this.deadoffset + 0.3;
            }
            else
            {
                this.deadoffset = 0;
            }
            cx = (int)((X + 8) / 16);
            cy = (int)((Y + 8) / 16);
            int delayed = 0;
            if (this.queue.Count >= 1)
            {
                delayed = this.queue.Dequeue();
            }
            this.currentBlockId = this.PlayingIn.Map[cx, cy, 0].Id;
            this.queue.Enqueue(this.currentBlockId);
            if (this.currentBlockId == 4 || ItemId.isClimbable(this.currentBlockId))
            {
                delayed = this.queue.Dequeue();
                this.queue.Enqueue(this.currentBlockId);
            }
            if (this.isDead)
            {
                this.horizontal = 0;
                this.vertical = 0;
                this.spacejustdown = false;
            }
            isgodmod = this.IsGod || this.IsMod;
            if (isgodmod)
            {
                this.morx = 0;
                this.mory = 0;
                this.OldHorizontalAcceleration = 0;
                this.OldVerticalAcceleration = 0;
            }
            else
            {
                switch (this.currentBlockId)
                {
                    case 1:
                        {
                            this.morx = -(int)_gravity;
                            this.mory = 0;
                            break;
                        }
                    case 2:
                        {
                            this.morx = 0;
                            this.mory = -(int)_gravity;
                            break;
                        }
                    case 3:
                        {
                            this.morx = (int)_gravity;
                            this.mory = 0;
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
                            this.morx = 0;
                            this.mory = 0;
                            break;
                        }
                    case BlockIds.Action.Liquids.WATER:
                        {
                            this.morx = 0;
                            this.mory = (int)_water_buoyancy;
                            break;
                        }
                    case BlockIds.Action.Liquids.MUD:
                        {
                            this.morx = 0;
                            this.mory = (int)_mud_buoyancy;
                            break;
                        }
                    case BlockIds.Action.Hazards.FIRE:
                    case BlockIds.Action.Hazards.SPIKE:
                        {
                            if (!this.isDead && !this._isInvulnerable)
                            {
                                this.killPlayer();
                            }
                            break;
                        }
                    default:
                        {
                            this.morx = 0;
                            this.mory = (int)_gravity;
                            break;
                        }
                }
                switch (delayed)
                {
                    case 1:
                        {
                            this.OldHorizontalAcceleration = -_gravity;
                            this.OldVerticalAcceleration = 0;
                            break;
                        }
                    case 2:
                        {
                            this.OldHorizontalAcceleration = 0;
                            this.OldVerticalAcceleration = -_gravity;
                            break;
                        }
                    case 3:
                        {
                            this.OldHorizontalAcceleration = _gravity;
                            this.OldVerticalAcceleration = 0;
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
                            this.OldHorizontalAcceleration = 0;
                            this.OldVerticalAcceleration = 0;
                            break;
                        }
                    case BlockIds.Action.Liquids.WATER:
                        {
                            this.OldHorizontalAcceleration = 0;
                            this.OldVerticalAcceleration = _water_buoyancy;
                            break;
                        }
                    case BlockIds.Action.Liquids.MUD:
                        {
                            this.OldHorizontalAcceleration = 0;
                            this.OldVerticalAcceleration = _mud_buoyancy;
                            break;
                        }
                    default:
                        {
                            this.OldHorizontalAcceleration = 0;
                            this.OldVerticalAcceleration = _gravity;
                            break;
                        }
                }
            }
            if (this.OldVerticalAcceleration == _water_buoyancy || this.OldVerticalAcceleration == _mud_buoyancy)
            {
                HorizontalAcceleration = this.horizontal;
                VerticalAcceleration = this.vertical;
            }
            else if (this.OldVerticalAcceleration != 0)
            {
                HorizontalAcceleration = this.horizontal;
                VerticalAcceleration = 0;
            }
            else if (this.OldHorizontalAcceleration != 0)
            {
                HorizontalAcceleration = 0;
                VerticalAcceleration = this.vertical;
            }
            else
            {
                HorizontalAcceleration = this.horizontal;
                VerticalAcceleration = this.vertical;
            }
            HorizontalAcceleration = HorizontalAcceleration * this.speedMultiplier();
            VerticalAcceleration = VerticalAcceleration * this.speedMultiplier();
            OldHorizontalAcceleration = OldHorizontalAcceleration * this.gravityMultiplier;
            OldVerticalAcceleration = OldVerticalAcceleration * this.gravityMultiplier;
            this.modifierX = this.OldHorizontalAcceleration + HorizontalAcceleration;

            this.modifierY = this.OldVerticalAcceleration + VerticalAcceleration;
            if (_speedX != 0 || _modifierX != 0)
            {
                _speedX = _speedX + _modifierX;
                _speedX = _speedX * Config.physics_base_drag;
                if (HorizontalAcceleration == 0 && OldVerticalAcceleration != 0 || _speedX < 0 && HorizontalAcceleration > 0 || _speedX > 0 && HorizontalAcceleration < 0 || ItemId.isClimbable(this.currentBlockId) && !isgodmod)
                {
                    _speedX = _speedX * _no_modifier_dragX;
                }
                else if (this.currentBlockId == BlockIds.Action.Liquids.WATER && !isgodmod)
                {
                    _speedX = _speedX * _water_drag;
                }
                else if (this.currentBlockId == BlockIds.Action.Liquids.MUD && !isgodmod)
                {
                    _speedX = _speedX * this.dragMud();
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
            if (_speedY != 0 || _modifierY != 0) // this is very similar to the previous block with speedx
            {
                _speedY = _speedY + _modifierY;
                _speedY = _speedY * Config.physics_base_drag;
                if (VerticalAcceleration == 0 && OldHorizontalAcceleration != 0 || _speedY < 0 && VerticalAcceleration > 0 || _speedY > 0 && VerticalAcceleration < 0 || ItemId.isClimbable(this.currentBlockId) && !isgodmod)
                {
                    _speedY = _speedY * _no_modifier_dragY;
                }
                else if (this.currentBlockId == BlockIds.Action.Liquids.WATER && !isgodmod)
                {
                    _speedY = _speedY * _water_drag;
                }
                else if (this.currentBlockId == BlockIds.Action.Liquids.MUD && !isgodmod)
                {
                    _speedY = _speedY * this.dragMud();
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
                switch (this.currentBlockId)
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
            reminderX = X % 1;
            currentSX = _speedX;
            reminderY = Y % 1;
            currentSY = _speedY;
            this.donex = false;
            this.doney = false;
            while (currentSX != 0 && !this.donex || currentSY != 0 && !this.doney)
            {
                this.processPortals();
                ox = X;
                oy = Y;
                osx = currentSX;
                osy = currentSY;
                this.stepx();
                this.stepy();
            }

            if (this.Levitation)
            {
                this.updateThrust();
            }
            var imx = _speedX * 256;
            var imy = _speedY * 256;
            moving = false;
            if (imx != 0 || this.currentBlockId == BlockIds.Action.Liquids.WATER || this.currentBlockId == BlockIds.Action.Liquids.MUD)
            {
                moving = true;
            }
            else if (_modifierX < 0.1 && _modifierX > -0.1)
            {
                tx = X % 16;
                if (tx < 2)
                {
                    if (tx < 0.2)
                    {
                        X = Math.Floor(X);
                    }
                    else
                    {
                        X = X - tx / 15;
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
                        X = X + (tx - 14) / 15;
                    }
                }
            }
            if (imy != 0 || this.currentBlockId == BlockIds.Action.Liquids.WATER || this.currentBlockId == BlockIds.Action.Liquids.MUD)
            {
                moving = true;
            }
            else if (_modifierY < 0.1 && _modifierY > -0.1)
            {
                ty = Y % 16;
                if (ty < 2)
                {
                    if (ty < 0.2)
                    {
                        Y = Math.Floor(Y);
                    }
                    else
                    {
                        Y = Y - ty / 15;
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
                        Y = Y + (ty - 14) / 15;
                    }
                }
            }
            return;
        }

        private void update()
        {
            return;
        }

        private void showBadge(bool param1)
        {
            return;
        }

        private void drawBadge(Bitmap param1, double param2, double param3, bool param4)
        {
            return;
        }

        private void flauntLevelBadge(bool param1)
        {
            return;
        }

        private void drawChat(Bitmap param1, double param2, double param3, bool param4)
        {
            return;
        }

        private void enterChat()
        {
            return;
        }

        private void say(string param1)
        {
            return;
        }

        private void killPlayer()
        {
            this.isDead = true;
            return;
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
            this.isDead = false;

            this.last_respawn = DateTime.Now.Millisecond;
            return;
        }

        private void resetCoins()
        {
            this.coins = 0;
            this.bcoins = 0;
            return;
        }

        private void resetCheckpoint()
        {
            this.checkpoint_x = -1;
            this.checkpoint_y = -1;
            return;
        }

        private void nameColor(int param1)
        {
            return;
        }

        private uint minimapColor()
        {
            return 0;
        }

        private void cursed(bool param1)
        {
            this.isCursed = param1;
            return;
        }

        private bool cursed()
        {
            return this.isCursed;
        }

        private void zombie(bool param1)
        {
            this.isZombie = param1;
            return;
        }

        private bool zombie()
        {
            if (this.IsGod|| this.IsMod)
            {
                return false;
            }
            return this.isZombie;
        }

        private void addTouchPotion(string param1, double param2 = 1)
        {
            this.touchpotions.Add(param1, DateTime.Now.Millisecond + (int)param2 * 1000);
            return;
        }

        private void removeTouchPotion(string param1)
        {
            this.touchpotions.Remove(param1);
            return;
        }

        private bool hasActivePotion(string param1)
        {
            if (!this.touchpotions.ContainsKey(param1))
            {
                return false;
            }
            return (DateTime.Now.Millisecond - this.touchpotions[param1]) > 0;
        }

        private bool hasPotion(string param1)
        {
            return this.touchpotions.ContainsKey(param1);
        }

        private List<string> getActivePotions()
        {
            List<string> _loc_1 = new List<string>();
            foreach (string _loc_2 in this.touchpotions.Keys)
            {
                if (this.hasActivePotion(_loc_2))
                {
                    _loc_1.Add(_loc_2);
                }
            }
            return _loc_1;
        }

        private bool getCanTag()
        {
            if (this.IsGod|| this.IsMod|| this.isDead)
            {
                return false;
            }
            return this.getActivePotions().Count > 0;
        }

        private bool getCanBeTagged()
        {
            if (this.IsGod|| this.IsMod|| this.isDead)
            {
                return false;
            }
            return (DateTime.Now.Millisecond - this.last_respawn) > 1000;
        }

        private void setPosition(double param1, double param2)
        {
            X = param1;
            Y = param2;
            return;
        }

        private void isInvulnerable(bool param1)
        {
            this._isInvulnerable = param1;
            return;
        }

        private bool isInvulnerable()
        {
            return this._isInvulnerable;
        }

        private bool Levitation
        {
            get
            {
                return this._hasLevitation;
            }
            set
            {
                this._hasLevitation = value;
            }
        }

        private void hasLevitation(bool param1)
        {
            this._hasLevitation = param1;
            return;
        }

        private void updateThrust()
        {
            if (this.mory != 0)
            {
                this.speedY = this.speedY - this._currentThrust * (Config.physics_jump_height / 2) * (this.mory * 0.5);
            }
            if (this.morx != 0)
            {
                this.speedX = this.speedX - this._currentThrust * (Config.physics_jump_height / 2) * (this.morx * 0.5);
            }
            if (!this._isThrusting)
            {
                if (this._currentThrust > 0)
                {
                    this._currentThrust = this._currentThrust - this._thrustBurnOff;
                }
                else
                {
                    this._currentThrust = 0;
                }
            }
            return;
        }

        private bool isThrusting()
        {
            return this._isThrusting;
        }

        private void isThrusting(bool param1)
        {
            this._isThrusting = param1;
            return;
        }

        private void applyThrust()
        {
            this._currentThrust = this._maxThrust;
            return;
        }

        private bool isFlaunting()
        {
            return this._isFlaunting;
        }

        private void isFlaunting(bool param1)
        {
            this._isFlaunting = param1;
            return;
        }

        private static bool isAdmin(string param1)
        {
            return admins.Contains(param1);
        }

        
    }
}