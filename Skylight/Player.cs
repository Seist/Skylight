// <author>TakoMan02</author>
// <summary>Playethis.PlayingIn.cs describes a singular player in an EE world.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Skylight.Physics;

    public class Player : SynchronizedSprite
    {
        // Private instance fields
        private bool
            hasAccess,
            hasBoost,
            hasClub,
            hasCommandAccess,
            hasCrown,
            hasGravityModifier,
            hasOpenSwitch,
            hasSilverCrown,
            isFriend,
            isGod,
            isHoldingDown,
            isHoldingLeft,
            isHoldingRight,
            isHoldingUp,
            isHoldingSpace,
            isMod,
            isMoving,
            isOwner;

        private double
            horizontalDirection,
            horizontalModifier,
            horizontalSpeed,
            verticalModifier,
            verticalDirection,
            verticalSpeed;


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
            get
            {
                return this.hasAccess;
            }

            internal set
            {
                this.hasAccess = value;
            }
        }

        public bool HasBoost
        {
            get
            {
                return this.hasBoost;
            }

            internal set
            {
                this.hasBoost = value;
            }
        }

        public bool HasClub
        {
            get
            {
                return this.hasClub;
            }

            internal set
            {
                this.hasClub = value;
            }
        }

        public bool HasCommandAccess
        {
            get
            {
                return this.hasCommandAccess;
            }

            internal set
            {
                this.hasCommandAccess = value;
            }
        }

        public bool HasCrown
        {
            get
            {
                return this.hasCrown;
            }

            internal set
            {
                this.hasCrown = value;
            }
        }

        public bool HasGravityModifier
        {
            get
            {
                return this.hasGravityModifier;
            }

            internal set
            {
                this.hasGravityModifier = value;
            }
        }

        public bool HasSilverCrown
        {
            get
            {
                return this.hasSilverCrown;
            }

            internal set
            {
                this.hasSilverCrown = value;
            }
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
            get
            {
                return this.isFriend;
            }

            internal set
            {
                this.isFriend = value;
            }
        }

        public bool IsGod
        {
            get
            {
                return this.isGod;
            }

            internal set
            {
                this.isGod = value;
            }
        }

        public bool IsMod
        {
            get
            {
                return this.isMod;
            }

            internal set
            {
                this.isMod = value;
            }
        }

        public bool IsHoldingLeft
        {
            get
            {
                return this.isHoldingLeft;
            }

            internal set
            {
                this.isHoldingLeft = value;
            }
        }

        public bool IsHoldingRight
        {
            get
            {
                return this.isHoldingRight;
            }

            internal set
            {
                this.isHoldingRight = value;
            }
        }

        public bool IsHoldingUp
        {
            get
            {
                return this.isHoldingUp;
            }

            internal set
            {
                this.isHoldingUp = value;
            }
        }

        public bool IsHoldingDown
        {
            get
            {
                return this.isHoldingDown;
            }

            internal set
            {
                this.isHoldingDown = value;
            }
        }

        public bool IsHoldingSpace
        {
            get
            {
                return this.isHoldingSpace;
            }

            internal set
            {
                this.isHoldingSpace = value;
            }
        }

        public bool IsOwner
        {
            get
            {
                if (this.PlayingIn.Owner == this)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            internal set
            {
                this.isOwner = value;
            }
        }

        public double HorizontalDirection
        {
            get
            {
                return this.horizontalDirection;
            }

            internal set
            {
                this.horizontalDirection = value;
            }
        }

        public double HorizontalModifier
        {
            get
            {
                return this.horizontalModifier;
            }

            internal set
            {
                this.horizontalModifier = value;
            }
        }

        public double HorizontalSpeed
        {
            get
            {
                return this.horizontalSpeed;
            }

            internal set
            {
                this.horizontalSpeed = value;
            }
        }

        public double VerticalDirection
        {
            get
            {
                return this.verticalDirection;
            }

            internal set
            {
                this.verticalDirection = value;
            }
        }

        public double VerticalModifier
        {
            get
            {
                return this.verticalModifier;
            }

            internal set
            {
                this.verticalModifier = value;
            }
        }

        public double VerticalSpeed
        {
            get
            {
                return this.verticalSpeed;
            }

            internal set
            {
                this.verticalSpeed = value;
            }
        }

        public int Coins
        {
            get
            {
                return this.coins;
            }

            internal set
            {
                this.coins = value;
            }
        }

        public int BlueCoins
        {
            get
            {
                return this.blueCoins;
            }
            internal set
            {
                this.blueCoins = value;
            }
        }

        public int CollectedMagic
        {
            get
            {
                return this.collectedMagic;
            }

            internal set
            {
                this.collectedMagic = value;
            }
        }

        public int DeathCount
        {
            get
            {
                return this.deathCount;
            }

            internal set
            {
                this.deathCount = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            internal set
            {
                this.id = value;
            }
        }

        public int Smiley
        {
            get
            {
                return this.smiley;
            }

            internal set
            {
                this.smiley = value;
            }
        }

        public int XpLevel
        {
            get
            {
                return this.xpLevel;
            }

            internal set
            {
                this.xpLevel = value;
            }
        }

        public List<int> PotionEffects
        {
            get
            {
                return this.potionEffects;
            }

            internal set
            {
                this.potionEffects = value;
            }
        }

        public Room PlayingIn
        {
            get
            {
                return this.playingIn;
            }

            internal set
            {
                this.playingIn = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            internal set { this.name = value.ToLower(); }
        }

        public bool purple = false;
        public double gravityMultiplier = 1;
        public int horizontal = 0;
        public int vertical = 0;

        public void ResetCoins()
        {
            this.Coins = 0;
            this.BlueCoins = 0;
            return;
        }

        /* --------------------------- GUSTAVIAN PHYSICS --------------------------- */

        public bool isme;
        private Bitmap crown;
        private Bitmap crown_silver;
        private Bitmap aura;
        private Bitmap modaura;
        private Bitmap fireAura;
        private Bitmap invulnerableAura;
        private Bitmap levitationAnimaitonBitmapData;
        private Bitmap clubaura;
        private Bitmap deadAnim;
        public bool isDead = false;
        private bool deathsend = false;
        private bool worldportalsend = false;
        private bool _isInvulnerable = false;
        // public string name;
        private uint textcolor;
        private int morx = 0;
        private int mory = 0;
        public int woots = 0;
        // public int coins = 0;
        public int level = 1;
        public int bcoins = 0;
        public bool hascrown = false;
        public bool hascrownsilver = false;
        public bool isgod = false;
        public bool ismod = false;
        public bool isclubmember = false;
        public int current = 0;
        public int current_bg = 0;
        // public bool purple = false;
        public int checkpoint_x = -1;
        public int checkpoint_y = -1;
        public int overlapy = 0;
        // public double gravityMultiplier = 1;
        private double last_respawn = 0;
        private bool _tagged = false;
        private bool _canTag = false;
        private Rectangle rect2;
        public double aura_color = 4.29497e+009;
        public int aura_offset = 0;
        private bool _hasLevitation = false;
        private bool _isFlaunting = false;
        private double total = 0;
        private int pastx = 0;
        private int pasty = 0;
        private Queue<int> queue = new Queue<int>();
        private DateTime lastJump;
        private bool changed = false;
        private int leftdown = 0;
        private int rightdown = 0;
        private int updown = 0;
        private int downdown = 0;
        private bool spacedown = false;
        private bool spacejustdown = false;
        // public int horizontal = 0;
        // public int vertical = 0;
        public int oh = 0;
        public int ov = 0;
        private Point lastPortal;
        private int lastOverlap = 0;
        private SynchronizedObject that;
        private double bbest = 0;
        private bool donex = false;
        private bool doney = false;
        private double animoffset = 0;
        private double modoffset = 0;
        private Rectangle modrect;
        private double cluboffset = 0;
        private Rectangle clubrect;
        private double deadoffset = 0;
        public bool jump_boost = false;
        public bool fire_aura = false;
        private bool _zombie = false;
        private bool _cursed = false;
        private Dictionary<string, int> touchpotions = new Dictionary<string, int>();
        private bool _isThrusting = false;
        private double _maxThrust = 0.2;
        private double _thrustBurnOff = 0.01;
        private double _currentThrust;
        private static List<string> admins = new List<string> { "benjaminsen", "cyclone", "toby", "rpgmaster2000", "mrshoe", "mrvoid" };
        public static bool HasSolitude = false;

        // public int smiley;
        public bool hasChat;
        // public bool isFriend;
        private double oldX = -1;
        private double oldY = -1;

        public int cx = 0;
        public int cy = 0;
        public bool isgodmod = false;
        public double reminderX = 0;
        public double currentSX = 0;
        public double reminderY = 0;
        public double currentSY = 0;
        public double osx = 0;
        public double osy = 0;
        public double ox = 0;
        public double oy = 0;
        public int mod = 0;
        public bool injump = false;
        public bool cchanged = false;
        public double tx = 0;
        public double ty = 0;

        // public double X { get { return x; } set { x = value; } }
        // public double Y { get { return y; } set { y = value; } }
        public int BlockX { get { return blockX; } set { x = value * 16; } }
        public int BlockY { get { return blockY; } set { y = value * 16; } }
        public int OldBlockX { get { return (int)Math.Round(((this.oldX) / 16.0)); } }
        public int OldBlockY { get { return (int)Math.Round(((this.oldY) / 16.0)); } }
        public bool Moved { get { return BlockX != OldBlockX || BlockY != OldBlockY; } }

        public Player(Room room, int id, string name, int smiley, double xPos, double yPos, bool isGod, bool isMod, bool hasChat, int coins, bool purple, bool isFriend, int level)
            : base(null, 16)
        {
            this.PlayingIn = room;
            this.Smiley = smiley;
            this.isgod = isGod;
            this.ismod = isMod;
            this.Id = id;
            this.hasChat = hasChat;
            this.Coins = coins;
            this.purple = purple;
            this.isFriend = isFriend;
            this.level = level;
            this.rect2 = new Rectangle(0, 0, 16, 26);
            this.queue = new Queue<int>(Config.physics_queue_length);
            this.lastJump = new DateTime();
            this.lastPortal = new Point();
            this.that = this as SynchronizedObject;
            this.modrect = new Rectangle(0, 0, 64, 64);
            this.clubrect = new Rectangle(0, 0, 64, 64);
            this._currentThrust = this._maxThrust;
            this.x = xPos;
            this.y = yPos;
            this.isme = false;
            this.Name = name;
            size = 16;
            width = 16;
            height = 16;
            return;
        }

        // public int id()
        // {
        //     return this._id;
        // }

        // public void id(int param1)
        // {
        //     this._id = param1;
        //     return;
        // }

        public double jumpMultiplier()
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

        public double speedMultiplier()
        {
            double _loc_1 = 1;
            if (this.zombie())
            {
                _loc_1 = _loc_1 * 0.6;
            }
            return _loc_1;
        }

        public double dragMud()
        {
            return _mud_drag;
        }

        public int overlaps(SynchronizedObject param1)
        {
            List<int> _loc_8 = new List<int>();

            int _loc_11 = 0;
            if (param1.x < 0 || param1.y < 0 || param1.x >= this.PlayingIn.Width * 16 - 8 || param1.y >= this.PlayingIn.Height * 16 - 8)
            {
                return 1;
            }
            Player _loc_2 = this;

            if (_loc_2.isgod || _loc_2.ismod)
            {
                return 0;
            }

            double _loc_3 = ((_loc_2.x) / 16);
            double _loc_4 = ((_loc_2.y) / 16);
            for (int xx = -2; xx < 1; xx++)
            {
                for (int yy = -2; yy < 1; yy++)
                {
                    if (_loc_3 + xx > 0 && _loc_3 + xx < this.PlayingIn.Width && _loc_4 + yy > 0 && _loc_4 + yy <= this.PlayingIn.Height)
                    {
                        for (int xTest = 0; xTest < 16; xTest++)
                        {
                            for (int yTest = 0; yTest < 16; yTest++)
                            {
                                if (hitTest((int)(xTest + _loc_2.x + xx * 16), (int)(yTest + _loc_2.y + yy * 16)))
                                {
                                    double _loc_9 = _loc_4;
                                    Block currentBlock = this.PlayingIn.Map[
                                        (int)(((xx * 16) + _loc_2.x + xTest) / 16), 
                                        (int)(((yy * 16) + _loc_2.y + yTest) / 16),
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
                                            case ItemId.DOOR_PURPLE:
                                                {
                                                    if (this.purple)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case ItemId.GATE_PURPLE:
                                                {
                                                    if (!this.purple)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case ItemId.DOOR_CLUB:
                                                {
                                                    if (isclubmember)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case ItemId.GATE_CLUB:
                                                {
                                                    if (!isclubmember)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case ItemId.COINDOOR:
                                                {
                                                    if (currentBlock is CoinBlock && ((CoinBlock)currentBlock).CoinsRequired <= coins)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case ItemId.COINGATE:
                                                {
                                                    if (currentBlock is CoinBlock && ((CoinBlock)currentBlock).CoinsRequired > coins)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case ItemId.ZOMBIE_GATE:
                                                {
                                                    if (_zombie)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case ItemId.ZOMBIE_DOOR:
                                                {
                                                    if (!_zombie)
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
                                                    break;
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

        void stepx()
        {
            if (currentSX > 0)
            {
                if (currentSX + reminderX >= 1)
                {
                    x = x + (1 - reminderX);
                    x = Math.Floor(x);
                    currentSX = currentSX - (1 - reminderX);
                    reminderX = 0;
                }
                else
                {
                    x = x + currentSX;
                    currentSX = 0;
                }
            }
            else if (currentSX < 0)
            {
                if (reminderX != 0 && reminderX + currentSX < 0)
                {
                    currentSX = currentSX + reminderX;
                    x = x - reminderX;
                    x = Math.Floor(x);
                    reminderX = 1;
                }
                else
                {
                    x = x + currentSX;
                    currentSX = 0;
                }
            }

            if (overlaps(that) != 0)
            {
                x = ox;
                _speedX = 0;
                currentSX = osx;
                donex = true;
            }

            return;
        }

        void stepy()
        {
            if (currentSY > 0)
            {
                if (currentSY + reminderY >= 1)
                {
                    y = y + (1 - reminderY);
                    y = Math.Floor(y);
                    currentSY = currentSY - (1 - reminderY);
                    reminderY = 0;
                }
                else
                {
                    y = y + currentSY;
                    currentSY = 0;
                }
            }
            else if (currentSY < 0)
            {
                if (reminderY != 0 && reminderY + currentSY < 0)
                {
                    y = y - reminderY;
                    y = Math.Floor(y);
                    currentSY = currentSY + reminderY;
                    reminderY = 1;
                }
                else
                {
                    y = y + currentSY;
                    currentSY = 0;
                }
            }

            if (overlaps(that) != 0)
            {
                y = oy;
                _speedY = 0;
                currentSY = osy;
                doney = true;
            }
        }

        void processPortals()
        {
            List<Point> targetPortalList = new List<Point>();
            int loopIterator = 0;
            Point currentLoopPortal = new Point(0, 0);
            int _loc_4 = 0;
            int _loc_5 = 0;
            double _loc_6 = 0;
            double _loc_7 = 0;
            double _loc_8 = 0;
            double _loc_9 = 0;
            int _loc_10 = 0;
            double _loc_11 = 0;
            current = this.PlayingIn.Map[cx, cy, 0].Id;
            if (!isgodmod && current == ItemId.WORLD_PORTAL)
            {
                if (spacejustdown && !worldportalsend)
                {
                }
            }
            if (!isgodmod && current == 242)
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
                        //Tools.SkylightMessage("iter: " + loopIterator);
                        currentLoopPortal = targetPortalList[loopIterator];
                        //_loc_4 = world.getPortal(lastPortal.x >> 4, lastPortal.y >> 4).rotation;
                        _loc_4 = ((PortalBlock)this.PlayingIn.Map[lastPortal.X >> 4, lastPortal.Y >> 4, 0]).Direction;
                        //Tools.SkylightMessage("1: " + _loc_4);
                        //_loc_5 = world.getPortal(currentLoopPortal.x >> 4, currentLoopPortal.y >> 4).rotation;
                        _loc_5 = ((PortalBlock)this.PlayingIn.Map[currentLoopPortal.X >> 4, currentLoopPortal.Y >> 4, 0]).Direction;
                        //Tools.SkylightMessage("2: " + _loc_5);
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
                        //Tools.SkylightMessage("entering switch " + _loc_10);
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
                            default:
                                {
                                    break;
                                }
                        }
                        /*if (isme && state)
                        {
                            state.offset(x - currentLoopPortal.x, y - currentLoopPortal.y);
                        }*/
                        //Tools.SkylightMessage(currentLoopPortal + "  --------  " + x + " " + y);
                        x = currentLoopPortal.X;
                        y = currentLoopPortal.Y;
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

        override public void tick()
        {
            oldX = this.x;
            oldY = this.y;

            this.animoffset = this.animoffset + 0.2;
            if (this.ismod && !this.isgod)
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
            cx = (int)((x + 8) / 16);
            cy = (int)((y + 8) / 16);
            int delayed = 0;
            if (this.queue.Count >= 1)
            {
                delayed = this.queue.Dequeue();
            }
            this.current = this.PlayingIn.Map[cx, cy, 0].Id;
            this.queue.Enqueue(this.current);
            if (this.current == 4 || ItemId.isClimbable(this.current))
            {
                delayed = this.queue.Dequeue();
                this.queue.Enqueue(this.current);
            }
            if (this.isDead)
            {
                this.horizontal = 0;
                this.vertical = 0;
                this.spacejustdown = false;
                this.spacedown = false;
            }
            isgodmod = this.isgod || this.ismod;
            if (isgodmod)
            {
                this.morx = 0;
                this.mory = 0;
                this.mox = 0;
                this.moy = 0;
            }
            else
            {
                switch (this.current)
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
                    case ItemId.SPEED_LEFT:
                    case ItemId.SPEED_RIGHT:
                    case ItemId.SPEED_UP:
                    case ItemId.SPEED_DOWN:
                    case ItemId.CHAIN:
                    case ItemId.NINJA_LADDER:
                    case ItemId.WINE_H:
                    case ItemId.WINE_V:
                    case 4:
                        {
                            this.morx = 0;
                            this.mory = 0;
                            break;
                        }
                    case ItemId.WATER:
                        {
                            this.morx = 0;
                            this.mory = (int)_water_buoyancy;
                            break;
                        }
                    case ItemId.MUD:
                        {
                            this.morx = 0;
                            this.mory = (int)_mud_buoyancy;
                            break;
                        }
                    case ItemId.FIRE:
                    case ItemId.SPIKE:
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
                            this.mox = -_gravity;
                            this.moy = 0;
                            break;
                        }
                    case 2:
                        {
                            this.mox = 0;
                            this.moy = -_gravity;
                            break;
                        }
                    case 3:
                        {
                            this.mox = _gravity;
                            this.moy = 0;
                            break;
                        }
                    case ItemId.SPEED_LEFT:
                    case ItemId.SPEED_RIGHT:
                    case ItemId.SPEED_UP:
                    case ItemId.SPEED_DOWN:
                    case ItemId.CHAIN:
                    case ItemId.NINJA_LADDER:
                    case ItemId.WINE_H:
                    case ItemId.WINE_V:
                    case 4:
                        {
                            this.mox = 0;
                            this.moy = 0;
                            break;
                        }
                    case ItemId.WATER:
                        {
                            this.mox = 0;
                            this.moy = _water_buoyancy;
                            break;
                        }
                    case ItemId.MUD:
                        {
                            this.mox = 0;
                            this.moy = _mud_buoyancy;
                            break;
                        }
                    default:
                        {
                            this.mox = 0;
                            this.moy = _gravity;
                            break;
                        }
                }
            }
            if (this.moy == _water_buoyancy || this.moy == _mud_buoyancy)
            {
                mx = this.horizontal;
                my = this.vertical;
            }
            else if (this.moy != 0)
            {
                mx = this.horizontal;
                my = 0;
            }
            else if (this.mox != 0)
            {
                mx = 0;
                my = this.vertical;
            }
            else
            {
                mx = this.horizontal;
                my = this.vertical;
            }
            mx = mx * this.speedMultiplier();
            my = my * this.speedMultiplier();
            mox = mox * this.gravityMultiplier;
            moy = moy * this.gravityMultiplier;
            this.modifierX = this.mox + mx;
            this.modifierY = this.moy + my;
            if (_speedX != 0 || _modifierX != 0)
            {
                _speedX = _speedX + _modifierX;
                _speedX = _speedX * Config.physics_base_drag;
                if (mx == 0 && moy != 0 || _speedX < 0 && mx > 0 || _speedX > 0 && mx < 0 || ItemId.isClimbable(this.current) && !isgodmod)
                {
                    _speedX = _speedX * _no_modifier_dragX;
                }
                else if (this.current == ItemId.WATER && !isgodmod)
                {
                    _speedX = _speedX * _water_drag;
                }
                else if (this.current == ItemId.MUD && !isgodmod)
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
            if (_speedY != 0 || _modifierY != 0)
            {
                _speedY = _speedY + _modifierY;
                _speedY = _speedY * Config.physics_base_drag;
                if (my == 0 && mox != 0 || _speedY < 0 && my > 0 || _speedY > 0 && my < 0 || ItemId.isClimbable(this.current) && !isgodmod)
                {
                    _speedY = _speedY * _no_modifier_dragY;
                }
                else if (this.current == ItemId.WATER && !isgodmod)
                {
                    _speedY = _speedY * _water_drag;
                }
                else if (this.current == ItemId.MUD && !isgodmod)
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
                switch (this.current)
                {
                    case ItemId.SPEED_LEFT:
                        {
                            _speedX = -_boost;
                            break;
                        }
                    case ItemId.SPEED_RIGHT:
                        {
                            _speedX = _boost;
                            break;
                        }
                    case ItemId.SPEED_UP:
                        {
                            _speedY = -_boost;
                            break;
                        }
                    case ItemId.SPEED_DOWN:
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
            reminderX = x % 1;
            currentSX = _speedX;
            reminderY = y % 1;
            currentSY = _speedY;
            this.donex = false;
            this.doney = false;
            while (currentSX != 0 && !this.donex || currentSY != 0 && !this.doney)
            {
                this.processPortals();
                ox = x;
                oy = y;
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
            if (imx != 0 || this.current == ItemId.WATER || this.current == ItemId.MUD)
            {
                moving = true;
            }
            else if (_modifierX < 0.1 && _modifierX > -0.1)
            {
                tx = x % 16;
                if (tx < 2)
                {
                    if (tx < 0.2)
                    {
                        x = Math.Floor(x);
                    }
                    else
                    {
                        x = x - tx / 15;
                    }
                }
                else if (tx > 14)
                {
                    if (tx > 15.8)
                    {
                        x = Math.Floor(x);
                        double _loc_3 = x + 1;
                        x = _loc_3;
                    }
                    else
                    {
                        x = x + (tx - 14) / 15;
                    }
                }
            }
            if (imy != 0 || this.current == ItemId.WATER || this.current == ItemId.MUD)
            {
                moving = true;
            }
            else if (_modifierY < 0.1 && _modifierY > -0.1)
            {
                ty = y % 16;
                if (ty < 2)
                {
                    if (ty < 0.2)
                    {
                        y = Math.Floor(y);
                    }
                    else
                    {
                        y = y - ty / 15;
                    }
                }
                else if (ty > 14)
                {
                    if (ty > 15.8)
                    {
                        y = Math.Floor(y);
                        double _loc_3 = y + 1;
                        y = _loc_3;
                    }
                    else
                    {
                        y = y + (ty - 14) / 15;
                    }
                }
            }
            return;
        }

        override public void update()
        {
            return;
        }

        public void showBadge(bool param1)
        {
            return;
        }

        public void drawBadge(Bitmap param1, double param2, double param3, bool param4)
        {
            return;
        }

        public void flauntLevelBadge(bool param1)
        {
            return;
        }

        public void drawChat(Bitmap param1, double param2, double param3, bool param4)
        {
            return;
        }

        public void enterChat()
        {
            return;
        }

        public void say(string param1)
        {
            return;
        }

        public void killPlayer()
        {
            this.isDead = true;
            return;
        }

        public void respawn()
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
            this.deathsend = false;
            this.last_respawn = DateTime.Now.Millisecond;
            return;
        }

        public void resetCoins()
        {
            this.coins = 0;
            this.bcoins = 0;
            return;
        }

        public void resetCheckpoint()
        {
            this.checkpoint_x = -1;
            this.checkpoint_y = -1;
            return;
        }

        override public void frame(int param1)
        {
            this.rect2.X = param1 * 16;
            return;
        }

        override public int frame()
        {
            return this.rect2.X / 16;
        }

        public void nameColor(int param1)
        {
            return;
        }

        public uint minimapColor()
        {
            return 0;
        }

        public void cursed(bool param1)
        {
            this._cursed = param1;
            return;
        }

        public bool cursed()
        {
            return this._cursed;
        }

        public void zombie(bool param1)
        {
            this._zombie = param1;
            return;
        }

        public bool zombie()
        {
            if (this.isgod || this.ismod)
            {
                return false;
            }
            return this._zombie;
        }

        public void addTouchPotion(string param1, double param2 = 1)
        {
            this.touchpotions.Add(param1, DateTime.Now.Millisecond + (int)param2 * 1000);
            return;
        }

        public void removeTouchPotion(string param1)
        {
            this.touchpotions.Remove(param1);
            return;
        }

        public bool hasActivePotion(string param1)
        {
            if (!this.touchpotions.ContainsKey(param1))
            {
                return false;
            }
            return (DateTime.Now.Millisecond - this.touchpotions[param1]) > 0;
        }

        public bool hasPotion(string param1)
        {
            return this.touchpotions.ContainsKey(param1);
        }

        public List<string> getActivePotions()
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

        public bool getCanTag()
        {
            if (this.isgod || this.ismod || this.isDead)
            {
                return false;
            }
            return this.getActivePotions().Count > 0;
        }

        public bool getCanBeTagged()
        {
            if (this.isgod || this.ismod || this.isDead)
            {
                return false;
            }
            return (DateTime.Now.Millisecond - this.last_respawn) > 1000;
        }

        public void setCanTag(bool param1)
        {
            if (param1)
            {
            }
            else
            {
                this._canTag = false;
            }
            return;
        }

        public void setCanTagDelayed()
        {
            this._canTag = true;
            return;
        }

        public void setPosition(double param1, double param2)
        {
            x = param1;
            y = param2;
            return;
        }

        public void isInvulnerable(bool param1)
        {
            this._isInvulnerable = param1;
            return;
        }

        public bool isInvulnerable()
        {
            return this._isInvulnerable;
        }

        public bool Levitation
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

        public void hasLevitation(bool param1)
        {
            this._hasLevitation = param1;
            return;
        }

        public void updateThrust()
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

        public bool isThrusting()
        {
            return this._isThrusting;
        }

        public void isThrusting(bool param1)
        {
            this._isThrusting = param1;
            return;
        }

        public void applyThrust()
        {
            this._currentThrust = this._maxThrust;
            return;
        }

        public bool isFlaunting()
        {
            return this._isFlaunting;
        }

        public void isFlaunting(bool param1)
        {
            this._isFlaunting = param1;
            return;
        }

        public static bool isAdmin(string param1)
        {
            return admins.Contains(param1);
        }

    }
}