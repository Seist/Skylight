// <author>TakoMan02</author>
// <summary>Player.cs describes a singular player in an EE world.</summary>

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Skylight
{
    public class Player
    {
        private static readonly List<string> admins = new List<string>
        {
            "benjaminsen",
            "cyclone",
            "toby",
            "rpgmaster2000",
            "mrshoe",
            "mrvoid"
        };

        protected double _baseDragX;
        protected double _baseDragY;
        protected double _boost;
        // private bool _tagged = false;
        private bool _canTag;
        private double _currentThrust;
        private bool _cursed;
        protected double _gravity;
        // public double aura_color = 4.29497e+009;
        // public int aura_offset = 0;
        private bool _isFlaunting;
        private bool _isInvulnerable;
        private bool _isThrusting;
        protected double _modifierX;
        protected double _modifierY;
        protected double _mud_buoyancy;
        protected double _mud_drag;
        protected double _no_modifier_dragX;
        protected double _no_modifier_dragY;
        protected double _speedX;
        protected double _speedY;
        protected double _water_buoyancy;
        protected double _water_drag;
        // public bool fire_aura = false;
        private bool _zombie;
        private double animoffset;
        public int bcoins;
        public bool cchanged = false;
        // public int current_bg = 0;
        // public bool purple = false;
        public int checkpoint_x = -1;
        public int checkpoint_y = -1;
        private double cluboffset;
        private Rectangle clubrect;
        public int current;
        public double currentSX;
        public double currentSY;
        public int cx;
        public int cy;
        private double deadoffset;
        private bool deathsend;
        // private double bbest = 0;
        private bool donex;
        private bool doney;
        public double gravityMultiplier = 1;
        // public static bool HasSolitude = false;

        // public int smiley;
        public bool hasChat;

        private bool hasOpenSwitch,
            isMoving,
            isOwner;

        public int height = 1;
        public int Horizontal;

        private double
            horizontalDirection,
            horizontalModifier,
            horizontalSpeed,
            verticalModifier,
            verticalDirection,
            verticalSpeed;

        private int id = -1;
        public bool injump = false;
        // public bool hascrown = false;
        // public bool hascrownsilver = false;
        public bool isclubmember = false;
        // private Bitmap crown;
        // private Bitmap crown_silver;
        // private Bitmap aura;
        // private Bitmap modaura;
        // private Bitmap fireAura;
        // private Bitmap invulnerableAura;
        // private Bitmap levitationAnimaitonBitmapData;
        // private Bitmap clubaura;
        // private Bitmap deadAnim;
        public bool isDead;
        public bool isgodmod;
        public bool isme;
        public bool jump_boost = false;
        public DateTime last;
        // public double gravityMultiplier = 1;
        private double last_respawn;
        private DateTime lastJump;
        // public int horizontal = 0;
        // public int vertical = 0;
        // public int oh = 0;
        // public int ov = 0;
        private Point lastPortal;
        // public int woots = 0;
        // public int coins = 0;
        public int Level = 1;
        public int mod = 0;
        private double modoffset;
        private Rectangle modrect;
        // public string name;
        // private uint textcolor;
        private int morx;
        private int mory;
        public bool moving;
        public double mox;
        public double moy;
        public double mx;
        public double my;
        private string name;
        protected double offset = 0;
        // public bool isFriend;
        private double oldX = -1;
        private double oldY = -1;
        public double osx;
        public double osy;
        public int overlapy;
        public double ox;
        public double oy;
        private List<int> potionEffects = new List<int>();
        public bool purple;
        private Rectangle rect2;
        public double reminderX;
        public double reminderY;
        // Private instance fields
        public bool ShouldTick = true;
        protected int size;
        // private bool changed = false;
        // private int leftdown = 0;
        // private int rightdown = 0;
        // private int updown = 0;
        // private int downdown = 0;
        private bool spacedown;
        private bool spacejustdown;
        public double tx;
        public double ty;
        public int Vertical;
        public int width = 1;
        /* --------------------------- GUSTAVIAN PHYSICS --------------------------- */

        public double X;
        public double Y;
        private readonly double _maxThrust = 0.2;
        private readonly double _thrustBurnOff = 0.01;
        private readonly double mult;
        // private double total = 0;
        // private int pastx = 0;
        // private int pasty = 0;
        private readonly Queue<int> queue = new Queue<int>();
        // private int lastOverlap = 0;
        private readonly Player that;
        private readonly Dictionary<string, int> touchpotions = new Dictionary<string, int>();
        private readonly bool worldportalsend = false;

        public Player(Room room, int id, string name, int smiley, double xPos, double yPos, bool isGod, bool isMod,
            bool hasChat, int coins, bool purple, bool isFriend, int level)
        {
            Levitation = false;
            PlayingIn = room;
            Smiley = smiley;
            IsGod = isGod;
            IsMod = isMod;
            Id = id;
            this.hasChat = hasChat;
            Coins = coins;
            this.purple = purple;
            IsFriend = isFriend;
            Level = level;
            rect2 = new Rectangle(0, 0, 16, 26);
            queue = new Queue<int>(Config.physics_queue_length);
            lastJump = new DateTime();
            lastPortal = new Point();
            that = this;
            modrect = new Rectangle(0, 0, 64, 64);
            clubrect = new Rectangle(0, 0, 64, 64);
            _currentThrust = _maxThrust;
            X = xPos;
            Y = yPos;
            isme = false;
            Name = name;
            size = 16;
            width = 16;
            height = 16;
            _baseDragX = Config.physics_base_drag;
            _baseDragY = Config.physics_base_drag;
            _no_modifier_dragX = Config.physics_no_modifier_drag;
            _no_modifier_dragY = Config.physics_no_modifier_drag;
            _water_drag = Config.physics_water_drag;
            _water_buoyancy = Config.physics_water_buoyancy;
            _mud_drag = Config.physics_mud_drag;
            _mud_buoyancy = Config.physics_mud_buoyancy;
            _boost = Config.physics_boost;
            _gravity = Config.physics_gravity;
            mult = Config.physics_variable_multiplyer;
            last = DateTime.Now;
        }

        // Public instance properties.
        public bool HasAccess { get; internal set; }
        public bool HasBoost { get; internal set; }
        public bool HasClub { get; internal set; }
        public bool HasCommandAccess { get; internal set; }
        public bool HasCrown { get; internal set; }
        public bool HasGravityModifier { get; internal set; }
        public bool HasSilverCrown { get; internal set; }

        public bool IsBot
        {
            get
            {
                if (PlayingIn != null)
                {
                    foreach (var bt in PlayingIn.OnlineBots)
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

        public bool IsFriend { get; internal set; }
        public bool IsGod { get; internal set; }
        public bool IsMod { get; internal set; }
        public bool IsHoldingLeft { get; internal set; }
        public bool IsHoldingRight { get; internal set; }
        public bool IsHoldingUp { get; internal set; }
        public bool IsHoldingDown { get; internal set; }
        public bool IsHoldingSpace { get; internal set; }

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

        public int Coins { get; internal set; }
        public int BlueCoins { get; internal set; }
        public int CollectedMagic { get; internal set; }
        public int DeathCount { get; internal set; }

        public int Id
        {
            get { return id; }

            internal set { id = value; }
        }

        public int Smiley { get; internal set; }
        public int XpLevel { get; internal set; }

        public List<int> PotionEffects
        {
            get { return potionEffects; }

            internal set { potionEffects = value; }
        }

        public Room PlayingIn { get; internal set; }

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

        protected double posX
        {
            get { return (X + 8); }
        }

        protected double posY
        {
            get { return (Y + 8); }
        }

        public double speedX
        {
            get { return _speedX*mult; }
            set { _speedX = value/mult; }
        }

        public double speedY
        {
            get { return _speedY*mult; }
            set { _speedY = value/mult; }
        }

        public double modifierX
        {
            get { return _modifierX*mult; }
            set { _modifierX = value/mult; }
        }

        public double modifierY
        {
            get { return _modifierY*mult; }
            set { _modifierY = value/mult; }
        }

        // public double X { get { return x; } set { x = value; } }
        // public double Y { get { return y; } set { y = value; } }
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

        public int OldBlockX
        {
            get { return (int) Math.Round(((oldX)/16.0)); }
        }

        public int OldBlockY
        {
            get { return (int) Math.Round(((oldY)/16.0)); }
        }

        public bool Moved
        {
            get { return BlockX != OldBlockX || BlockY != OldBlockY; }
        }

        public bool Levitation { get; set; }

        public void ResetCoins()
        {
            Coins = 0;
            BlueCoins = 0;
        }

        public bool hitTest(int param1, int param2)
        {
            return param1 >= X && param2 >= Y && param1 <= X + size && param2 <= Y + size;
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

        public double speedMultiplier()
        {
            double _loc_1 = 1;
            if (zombie())
            {
                _loc_1 = _loc_1*0.6;
            }
            return _loc_1;
        }

        public double dragMud()
        {
            return _mud_drag;
        }

        public int overlaps(Player param1)
        {
            var _loc_8 = new List<int>();

            var _loc_11 = 0;
            if (param1.X < 0 || param1.Y < 0 || param1.X >= PlayingIn.Width*16 - 8 ||
                param1.Y >= PlayingIn.Height*16 - 8)
            {
                return 1;
            }
            var _loc_2 = this;

            if (_loc_2.IsGod || _loc_2.IsMod)
            {
                return 0;
            }

            var _loc_3 = ((_loc_2.X)/16);
            var _loc_4 = ((_loc_2.Y)/16);
            for (var xx = -2; xx < 1; xx++)
            {
                for (var yy = -2; yy < 1; yy++)
                {
                    if (_loc_3 + xx > 0 && _loc_3 + xx < PlayingIn.Width && _loc_4 + yy > 0 &&
                        _loc_4 + yy <= PlayingIn.Height)
                    {
                        for (var xTest = 0; xTest < 16; xTest++)
                        {
                            for (var yTest = 0; yTest < 16; yTest++)
                            {
                                if (hitTest((int) (xTest + _loc_2.X + xx*16), (int) (yTest + _loc_2.Y + yy*16)))
                                {
                                    var _loc_9 = _loc_4;
                                    var currentBlock = PlayingIn.Map[
                                        (int) (((xx*16) + _loc_2.X + xTest)/16),
                                        (int) (((yy*16) + _loc_2.Y + yTest)/16),
                                        0];
                                    _loc_11 = currentBlock.Id;
                                    if (ItemId.IsSolid(_loc_11))
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
                                            case BlockIds.Action.Doors.Switch:
                                            {
                                                if (purple)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Gates.Switch:
                                            {
                                                if (!purple)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Doors.Club:
                                            {
                                                if (isclubmember)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Gates.Club:
                                            {
                                                if (!isclubmember)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Doors.Coin:
                                            {
                                                if (currentBlock is CoinBlock &&
                                                    ((CoinBlock) currentBlock).CoinsRequired <= Coins)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Gates.Coin:
                                            {
                                                if (currentBlock is CoinBlock &&
                                                    ((CoinBlock) currentBlock).CoinsRequired > Coins)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Gates.Zombie:
                                            {
                                                if (_zombie)
                                                {
                                                    continue;
                                                }
                                                break;
                                            }
                                            case BlockIds.Action.Doors.Zombie:
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
                                                        _loc_2.overlapy = (int) _loc_9;
                                                    }
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

            if (overlaps(that) != 0)
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

            if (overlaps(that) != 0)
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
            var loopIterator = 0;
            var currentLoopPortal = new Point(0, 0);
            var _loc_4 = 0;
            var _loc_5 = 0;
            double _loc_6 = 0;
            double _loc_7 = 0;
            double _loc_8 = 0;
            double _loc_9 = 0;
            var _loc_10 = 0;
            double _loc_11 = 0;
            current = PlayingIn.Map[cx, cy, 0].Id;
            if (!isgodmod && current == BlockIds.Action.Portals.World)
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

                    var currentBlock = PlayingIn.Map[cx, cy, 0];
                    var currentPortalBlock = (PortalBlock) currentBlock;
                    var currentTarget = currentPortalBlock.PortalDestination;

                    for (var x = 1; x < PlayingIn.Width; x++)
                    {
                        for (var y = 1; y < PlayingIn.Height; y++)
                        {
                            var block = PlayingIn.Map[x, y, 0];
                            if (block is PortalBlock && ((PortalBlock) block).PortalId == currentTarget)
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
                        _loc_4 = ((PortalBlock) PlayingIn.Map[lastPortal.X >> 4, lastPortal.Y >> 4, 0]).Direction;
                        //Tools.SkylightMessage("1: " + _loc_4);
                        //_loc_5 = world.getPortal(currentLoopPortal.x >> 4, currentLoopPortal.y >> 4).rotation;
                        _loc_5 =
                            ((PortalBlock) PlayingIn.Map[currentLoopPortal.X >> 4, currentLoopPortal.Y >> 4, 0])
                                .Direction;
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
                        /*if (isme && state)
                        {
                            state.offset(x - currentLoopPortal.x, y - currentLoopPortal.y);
                        }*/
                        //Tools.SkylightMessage(currentLoopPortal + "  --------  " + x + " " + y);
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

        public void Tick()
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
            var delayed = 0;
            if (queue.Count >= 1)
            {
                delayed = queue.Dequeue();
            }
            current = PlayingIn.Map[cx, cy, 0].Id;
            queue.Enqueue(current);
            if (current == 4 || ItemId.IsClimbable(current))
            {
                delayed = queue.Dequeue();
                queue.Enqueue(current);
            }
            if (isDead)
            {
                Horizontal = 0;
                Vertical = 0;
                spacejustdown = false;
                spacedown = false;
            }
            isgodmod = IsGod || IsMod;
            if (isgodmod)
            {
                morx = 0;
                mory = 0;
                mox = 0;
                moy = 0;
            }
            else
            {
                switch (current)
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
                    case BlockIds.Action.Boost.Left:
                    case BlockIds.Action.Boost.Right:
                    case BlockIds.Action.Boost.Up:
                    case BlockIds.Action.Boost.Down:
                    case BlockIds.Action.Ladders.Chain:
                    case BlockIds.Action.Ladders.Ladder:
                    case BlockIds.Action.Ladders.Horizontalvine:
                    case BlockIds.Action.Ladders.Verticalvine:
                    case 4:
                    {
                        morx = 0;
                        mory = 0;
                        break;
                    }
                    case BlockIds.Action.Liquids.Water:
                    {
                        morx = 0;
                        mory = (int) _water_buoyancy;
                        break;
                    }
                    case BlockIds.Action.Liquids.Mud:
                    {
                        morx = 0;
                        mory = (int) _mud_buoyancy;
                        break;
                    }
                    case BlockIds.Action.Hazards.Fire:
                    case BlockIds.Action.Hazards.Spike:
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
                        mox = -_gravity;
                        moy = 0;
                        break;
                    }
                    case 2:
                    {
                        mox = 0;
                        moy = -_gravity;
                        break;
                    }
                    case 3:
                    {
                        mox = _gravity;
                        moy = 0;
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
                    case 4:
                    {
                        mox = 0;
                        moy = 0;
                        break;
                    }
                    case BlockIds.Action.Liquids.Water:
                    {
                        mox = 0;
                        moy = _water_buoyancy;
                        break;
                    }
                    case BlockIds.Action.Liquids.Mud:
                    {
                        mox = 0;
                        moy = _mud_buoyancy;
                        break;
                    }
                    default:
                    {
                        mox = 0;
                        moy = _gravity;
                        break;
                    }
                }
            }
            if (moy == _water_buoyancy || moy == _mud_buoyancy)
            {
                mx = Horizontal;
                my = Vertical;
            }
            else if (moy != 0)
            {
                mx = Horizontal;
                my = 0;
            }
            else if (mox != 0)
            {
                mx = 0;
                my = Vertical;
            }
            else
            {
                mx = Horizontal;
                my = Vertical;
            }
            mx = mx*speedMultiplier();
            my = my*speedMultiplier();
            mox = mox*gravityMultiplier;
            moy = moy*gravityMultiplier;
            modifierX = mox + mx;
            modifierY = moy + my;
            if (_speedX != 0 || _modifierX != 0)
            {
                _speedX = _speedX + _modifierX;
                _speedX = _speedX*Config.physics_base_drag;
                if (mx == 0 && moy != 0 || _speedX < 0 && mx > 0 || _speedX > 0 && mx < 0 ||
                    ItemId.IsClimbable(current) && !isgodmod)
                {
                    _speedX = _speedX*_no_modifier_dragX;
                }
                else if (current == BlockIds.Action.Liquids.Water && !isgodmod)
                {
                    _speedX = _speedX*_water_drag;
                }
                else if (current == BlockIds.Action.Liquids.Mud && !isgodmod)
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
                if (my == 0 && mox != 0 || _speedY < 0 && my > 0 || _speedY > 0 && my < 0 ||
                    ItemId.IsClimbable(current) && !isgodmod)
                {
                    _speedY = _speedY*_no_modifier_dragY;
                }
                else if (current == BlockIds.Action.Liquids.Water && !isgodmod)
                {
                    _speedY = _speedY*_water_drag;
                }
                else if (current == BlockIds.Action.Liquids.Mud && !isgodmod)
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
                switch (current)
                {
                    case BlockIds.Action.Boost.Left:
                    {
                        _speedX = -_boost;
                        break;
                    }
                    case BlockIds.Action.Boost.Right:
                    {
                        _speedX = _boost;
                        break;
                    }
                    case BlockIds.Action.Boost.Up:
                    {
                        _speedY = -_boost;
                        break;
                    }
                    case BlockIds.Action.Boost.Down:
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
            var imx = _speedX*256;
            var imy = _speedY*256;
            moving = false;
            if (imx != 0 || current == BlockIds.Action.Liquids.Water || current == BlockIds.Action.Liquids.Mud)
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
                        var _loc_3 = X + 1;
                        X = _loc_3;
                    }
                    else
                    {
                        X = X + (tx - 14)/15;
                    }
                }
            }
            if (imy != 0 || current == BlockIds.Action.Liquids.Water || current == BlockIds.Action.Liquids.Mud)
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
                        var _loc_3 = Y + 1;
                        Y = _loc_3;
                    }
                    else
                    {
                        Y = Y + (ty - 14)/15;
                    }
                }
            }
        }

        public void update()
        {
        }

        public void showBadge(bool param1)
        {
        }

        public void drawBadge(Bitmap param1, double param2, double param3, bool param4)
        {
        }

        public void flauntLevelBadge(bool param1)
        {
        }

        public void drawChat(Bitmap param1, double param2, double param3, bool param4)
        {
        }

        public void enterChat()
        {
        }

        public void say(string param1)
        {
        }

        public void killPlayer()
        {
            isDead = true;
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
            isDead = false;
            deathsend = false;
            last_respawn = DateTime.Now.Millisecond;
        }

        public void resetCoins()
        {
            Coins = 0;
            bcoins = 0;
        }

        public void resetCheckpoint()
        {
            checkpoint_x = -1;
            checkpoint_y = -1;
        }

        public void frame(int param1)
        {
            rect2.X = param1*16;
        }

        public int frame()
        {
            return rect2.X/16;
        }

        public void nameColor(int param1)
        {
        }

        public uint minimapColor()
        {
            return 0;
        }

        public void cursed(bool param1)
        {
            _cursed = param1;
        }

        public bool cursed()
        {
            return _cursed;
        }

        public void zombie(bool param1)
        {
            _zombie = param1;
        }

        public bool zombie()
        {
            if (IsGod || IsMod)
            {
                return false;
            }
            return _zombie;
        }

        public void addTouchPotion(string param1, double param2 = 1)
        {
            touchpotions.Add(param1, DateTime.Now.Millisecond + (int) param2*1000);
        }

        public void removeTouchPotion(string param1)
        {
            touchpotions.Remove(param1);
        }

        public bool hasActivePotion(string param1)
        {
            if (!touchpotions.ContainsKey(param1))
            {
                return false;
            }
            return (DateTime.Now.Millisecond - touchpotions[param1]) > 0;
        }

        public bool hasPotion(string param1)
        {
            return touchpotions.ContainsKey(param1);
        }

        public List<string> getActivePotions()
        {
            var _loc_1 = new List<string>();
            foreach (var _loc_2 in touchpotions.Keys)
            {
                if (hasActivePotion(_loc_2))
                {
                    _loc_1.Add(_loc_2);
                }
            }
            return _loc_1;
        }

        public bool getCanTag()
        {
            if (IsGod || IsMod || isDead)
            {
                return false;
            }
            return getActivePotions().Count > 0;
        }

        public bool getCanBeTagged()
        {
            if (IsGod || IsMod || isDead)
            {
                return false;
            }
            return (DateTime.Now.Millisecond - last_respawn) > 1000;
        }

        public void setCanTag(bool param1)
        {
            if (param1)
            {
            }
            else
            {
                _canTag = false;
            }
        }

        public void setCanTagDelayed()
        {
            _canTag = true;
        }

        public void setPosition(double param1, double param2)
        {
            X = param1;
            Y = param2;
        }

        public void isInvulnerable(bool param1)
        {
            _isInvulnerable = param1;
        }

        public bool isInvulnerable()
        {
            return _isInvulnerable;
        }

        public void hasLevitation(bool param1)
        {
            Levitation = param1;
        }

        public void updateThrust()
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

        public bool isThrusting()
        {
            return _isThrusting;
        }

        public void isThrusting(bool param1)
        {
            _isThrusting = param1;
        }

        public void applyThrust()
        {
            _currentThrust = _maxThrust;
        }

        public bool isFlaunting()
        {
            return _isFlaunting;
        }

        public void isFlaunting(bool param1)
        {
            _isFlaunting = param1;
        }

        public static bool isAdmin(string param1)
        {
            return admins.Contains(param1);
        }
    }
}