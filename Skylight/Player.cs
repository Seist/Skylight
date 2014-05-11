// <author>TakoMan02</author>
// <summary>Playethis.PlayingIn.cs describes a singular player in an EE world.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public partial class Player : SynchronizedSprite
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

        //protected var Ding:Class;
        //protected var Crown:Class;
        //protected var CrownSilver:Class;
        //protected var Aura:Class;
        //protected var ModAura:Class;
        //protected var ding:Sound;
        //private var world:World;
        //public var isme:Boolean;
        //private var crown:BitmapData;
        //private var crown_silver:BitmapData;
        //private var aura:BitmapData;
        //private var modaura:BitmapData;
        //private var connection:Connection;
        //private var state:PlayState;
        //private var chat:Chat;
        //private var badge:LevelBadge;
        //private bool badgeVisible = false;
        //private uint textcolor;
        private int morx = 0,
            mory = 0,
            current = 0;

        public bool purple = false;
        public int overlapy = 0;
        public double gravityMultiplier = 1;
        public double jumpMultiplier = 1;
        //private Rectangle rect2;
        public double aura_color = 4.29497e+009;
        public int aura_offset = 0;
        //private double total = 0;
        private int pastx = 0;
        private int pasty = 0;
        private List<int> queue = new List<int>();
        /*private DateTime lastJump;
        private bool changed = false;
        private int leftDown = 0;
        private int rightDown = 0;
        private int upDown = 0;
        private int downDown = 0;
        private bool spaceDown = false;
        private bool spaceJustDown = false;*/
        public int horizontal = 0;
        public int vertical = 0;
        public int oh = 0;
        public int ov = 0;
        private Point lastPortal;
        //private int lastOverlap = 0;
        public SynchronizedObject that = new SynchronizedObject();
        //private double bBest = 0;
        private bool donex = false;
        private bool doney = false;
        private double animoffset = 0;
        private double modoffset = 0;
        //private Rectangle modRect;
        //private bool slowMotion = true;


        int cx;
        int cy;
        double reminderX;
        double currentSX;
        double reminderY;
        double currentSY;
        double osx;
        double osy;
        double ox;
        double oy;
        //int mod;
        //bool injump;
        //bool cchanged;
        //bool doJump;
        double tx;
        double ty;

        public bool bla;

        public Player()
        {
        }

        public Player(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Player(int id, string name, int frame, float xPos, float yPos, bool isGod, bool isMod, bool bla, int coins, bool purple, bool isFriend, int level)
        {
            this.Id = id;
            this.Name = name;
            this.frame = frame; 
            this.Coins = coins; 
            this.XpLevel = level;
            this.IsGod = isGod; 
            this.IsMod = isMod; 
            this.bla = bla; 
            this.purple = purple; 
            this.isFriend = isFriend;
            that.x = xPos;
            that.y = yPos;
            this.queue = new List<int>(Config.physics_queue_length);
        }

        public int overlaps(SynchronizedObject param1)
        {
            List<int> _loc_8 = new List<int>();
            //int _loc_10 = 0;
            int surroundingBlockId = 0;
            if (param1.x < 0 || param1.y < 0 || param1.x >= this.PlayingIn.Width || param1.y >= this.PlayingIn.Height)
            {
                return 1;
            }

            if (this.isGod || this.isMod)
            {
                return 0;
            }

            double blockY = ((this.y) / 16);
            double blockX = ((this.x) / 16);
            //double _loc_5 = (param1.x + param1.height) / 16;
            //Console.WriteLine(_loc_3 + " - "  +_loc_5);
            //double _loc_6 = (param1.y + param1.width) / 16;
            //bool _loc_7 = false;
            for (int xx = -2; xx < 1; xx++)
            {
                for (int yy = -2; yy < 1; yy++)
                {
                    if (blockY + xx > 0 && blockY + xx < this.PlayingIn.Width && blockX + yy > 0 && blockX + yy <= this.PlayingIn.Height)
                    {
                        for (int xTest = 0; xTest < 16; xTest++)
                        {
                            for (int yTest = 0; yTest < 16; yTest++)
                            {
                                if (hitTest((int)(xTest + this.x + xx * 16), (int)(yTest + this.y + yy * 16)))
                                {
                                    double _blockX = blockX;
                                    surroundingBlockId = this.PlayingIn.Map[
                                        (int)(((xx * 16) + this.x + xTest) / 16),
                                        (int)(((yy * 16) + this.y + yTest) / 16), 0].Id;

                                    if (this.PlayingIn.Map[
                                        (int)(((xx * 16) + this.x + xTest) / 16),
                                        (int)(((yy * 16) + this.y + yTest) / 16), 0].IsSolid)
                                    {
                                        switch (surroundingBlockId)
                                        {
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
                                                    if (this.SpeedY < 0 || _blockX <= this.overlapy)
                                                    {
                                                        if (_blockX != blockX || this.overlapy == -1)
                                                        {
                                                            this.overlapy = (int)_blockX;
                                                        }
                                                        //_loc_7 = true;
                                                        break;
                                                    }
                                                    break;
                                                }
                                            default:
                                                    break;
                                        }
                                        return surroundingBlockId;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //_loc_11 = this.PlayingIn.Map[_loc_3, _loc_4].ID;
            /*while (_loc_9 < _loc_6)
            {

                _loc_8.Clear();
                for (int i = 0; i < this.PlayingIn.Width; i++)
                {
                    _loc_8.Add(this.PlayingIn.Map[i, _loc_9].ID);
                }
                _loc_10 = _loc_3;
                while (_loc_10 < _loc_5)
                {
                    if (_loc_8.Count != 0)
                    {
                        _loc_11 = _loc_8[_loc_10];
                        if (ItemId.isSolid(_loc_11))
                        {
                            switch(_loc_11)
                            {
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
                                    if (this.speedY < 0 || _loc_9 <= this.overlapy)
                                    {
                                        if (_loc_9 != _loc_4 || this.overlapy == -1)
                                        {
                                            this.overlapy = _loc_9;
                                        }
                                        _loc_7 = true;
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
                            if (_loc_11 != 9)
                            Console.WriteLine("returning " + _loc_11 + ", collision");
                            return _loc_11;
                        }
                    }
                    _loc_10++;
                }
                _loc_9++;
            }
            if (!_loc_7)
            {
                this.overlapy = -1;
            }*/
            return 0;
        }// end function

        void StepX()
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
                //Console.WriteLine("xoverlap " + name);
                x = ox;
                speedX = 0;
                currentSX = osx;
                donex = true;
            }
            return;
        }

        void StepY()
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
                //Console.WriteLine("yoverlap " + name);
                y = oy;
                speedY = 0;
                currentSY = osy;
                doney = true;
            }
            return;
        }

        void ProcessPortals()
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
            if (!isGod && current == 242)
            {
                if (lastPortal.X == 0 && lastPortal.Y == 0)
                {
                    lastPortal = new Point(cx << 4, cy << 4);

                    //current = this.PlayingIn.Map[cx, cy].ID;
                    Block currentBlock = this.PlayingIn.Map[cx, cy, 0];
                    int currentTarget = currentBlock.Id;
                    //Console.WriteLine("entered portal with id " + currentBlock.thisID + " and target id " + currentTarget + " and rotation " + currentBlock.rotation);

                    //targetPortalList = world.getPortals(world.getPortal(cx, cy).target);
                    for (int x = 1; x < this.PlayingIn.Width; x++)
                    {
                        for (int y = 1; y < this.PlayingIn.Height; y++)
                        {
                            Block block = this.PlayingIn.Map[x, y, 0];
                            if ((block.Id == BlockIds.Action.Portals.INVISIBLE || 
                                block.Id == BlockIds.Action.Portals.NORMAL ||
                                block.Id == BlockIds.Action.Portals.WORLD) && block.Id == currentTarget)
                            {
                                //Console.WriteLine("found portal target " + block.targetID);
                                targetPortalList.Add(new Point(x << 4, y << 4));
                            }
                        }
                    }
                    loopIterator = 0;
                    while (loopIterator < targetPortalList.Count)
                    {
                        //Console.WriteLine("iter: " + loopIterator);
                        currentLoopPortal = targetPortalList[loopIterator];
                        //_loc_4 = world.getPortal(lastPortal.x >> 4, lastPortal.y >> 4).rotation;
                        _loc_4 = this.PlayingIn.Map[lastPortal.X >> 4, lastPortal.Y >> 4, 0].Direction;
                        //Console.WriteLine("1: " + _loc_4);
                        //_loc_5 = world.getPortal(currentLoopPortal.x >> 4, currentLoopPortal.y >> 4).rotation;
                        _loc_5 = this.PlayingIn.Map[currentLoopPortal.X >> 4, currentLoopPortal.Y >> 4, 0].Direction;
                        //Console.WriteLine("2: " + _loc_5);
                        if (_loc_4 < _loc_5)
                        {
                            _loc_4 = _loc_4 + 4;
                        }
                        _loc_6 = SpeedX;
                        _loc_7 = SpeedY;
                        _loc_8 = ModifierX;
                        _loc_9 = ModifierY;
                        _loc_10 = _loc_4 - _loc_5;
                        _loc_11 = 1.42;
                        //Console.WriteLine("entering switch " + _loc_10);
                        switch (_loc_10)
                        {
                            case 1:
                                {
                                    SpeedX = _loc_7 * _loc_11;
                                    SpeedY = (-_loc_6) * _loc_11;
                                    ModifierX = _loc_9 * _loc_11;
                                    ModifierY = (-_loc_8) * _loc_11;
                                    reminderY = -reminderY;
                                    currentSY = -currentSY;
                                    break;
                                }
                            case 3:
                                {
                                    SpeedX = (-_loc_7) * _loc_11;
                                    SpeedY = _loc_6 * _loc_11;
                                    ModifierX = (-_loc_9) * _loc_11;
                                    ModifierY = _loc_8 * _loc_11;
                                    reminderX = -reminderX;
                                    currentSX = -currentSX;
                                    break;
                                }
                            case 2:
                                {
                                    SpeedX = (-_loc_6) * _loc_11;
                                    SpeedY = (-_loc_7) * _loc_11;
                                    ModifierX = (-_loc_8) * _loc_11;
                                    ModifierY = (-_loc_9) * _loc_11;
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
                        //Console.WriteLine(currentLoopPortal + "  --------  " + x + " " + y);
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

        internal void Tick()
        {
            /*cx = 0;
            cy = 0;
            isGod = false;
            reminderX = 0;
            currentSX = 0;
            reminderY = 0;
            currentSY = 0;
            osx = 0;
            osy = 0;
            ox = 0;
            oy = 0;
            tx = 0;
            ty = 0;*/

            this.animoffset = this.animoffset + 0.2;
            if (this.IsMod && !this.IsGod)
            {
                this.modoffset += 0.2;

                if (this.modoffset >= 16)
                {
                    this.modoffset = 10;
                }
            }
            else
            {
                this.modoffset = 0;
            }

            cx = (int)((this.x + 8) / 16);
            cy = (int)((this.y + 8) / 16);

            int delayed = 0;
            if (this.queue.Count >= 1)
            {
                delayed = this.queue[0];
                queue.Remove(delayed);
            }

            if (cx > 0 && cy > 0 && cx < this.PlayingIn.Width && cy < this.PlayingIn.Height)
            {
                this.current = this.PlayingIn.Map[(int)cx, (int)cy, 0].Id;
            }

            queue.Add(this.current);

            if (this.current == BlockIds.Action.Gravity.ZERO || 
                this.current == BlockIds.Action.Ladders.CHAIN ||
                this.current == BlockIds.Action.Ladders.HORIZONTALVINE ||
                this.current == BlockIds.Action.Ladders.LADDER ||
                this.current == BlockIds.Action.Ladders.VERTICALVINE)
            {
                if (this.queue.Count >= 1)
                {
                    delayed = this.queue[0];
                    queue.Remove(delayed);
                }
                this.queue.Add(this.current);
            }

            isGod = this.IsGod || this.IsMod;
            if (isGod)
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
                            this.morx = -(int)gravity;
                            this.mory = 0;
                            break;
                        }
                    case 2:
                        {
                            this.morx = 0;
                            this.mory = -(int)gravity;
                            break;
                        }
                    case 3:
                        {
                            this.morx = (int)gravity;
                            this.mory = 0;
                            break;
                        }
                    case BlockIds.Action.Boost.DOWN:
                    case BlockIds.Action.Boost.LEFT:
                    case BlockIds.Action.Boost.RIGHT:
                    case BlockIds.Action.Boost.UP:
                    case BlockIds.Action.Ladders.CHAIN:
                    case BlockIds.Action.Ladders.HORIZONTALVINE:
                    case BlockIds.Action.Ladders.LADDER:
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
                            this.mory = (int)water_buoyancy;
                            break;
                        }
                    default:
                        {
                            this.morx = 0;
                            this.mory = (int)gravity;
                            break;
                        }
                }
                switch (delayed)
                {
                    case 1:
                        {
                            this.mox = -gravity;
                            this.moy = 0;
                            break;
                        }
                    case 2:
                        {
                            this.mox = 0;
                            this.moy = -gravity;
                            break;
                        }
                    case 3:
                        {
                            this.mox = gravity;
                            this.moy = 0;
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
                    case 4:
                        {
                            this.mox = 0;
                            this.moy = 0;
                            break;
                        }
                    case BlockIds.Action.Liquids.WATER:
                        {
                            this.mox = 0;
                            this.moy = water_buoyancy;
                            break;
                        }
                    default:
                        {
                            this.mox = 0;
                            this.moy = gravity;
                            break;
                        }
                }
            }
            if (this.moy == water_buoyancy)
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
            mox = mox * this.gravityMultiplier;
            moy = moy * this.gravityMultiplier;
            this.ModifierX = this.mox + mx;
            this.ModifierY = this.moy + my;
            if (speedX != 0 || modifierX != 0)
            {
                speedX = speedX + modifierX;
                speedX = speedX * Config.physics_base_drag;
                if (mx == 0 && moy != 0 || 
                    speedX < 0 && mx > 0 || 
                    speedX > 0 && mx < 0 || 
                    (current == BlockIds.Action.Gravity.ZERO || 
                    current == BlockIds.Action.Ladders.CHAIN ||
                    current == BlockIds.Action.Ladders.HORIZONTALVINE ||
                    current == BlockIds.Action.Ladders.LADDER ||
                    current == BlockIds.Action.Ladders.VERTICALVINE) && !isGod)
                {
                    speedX = speedX * no_modifier_dragX;
                }
                else if (this.current == BlockIds.Action.Liquids.WATER && !isGod)
                {
                    speedX = speedX * water_drag;
                }
                if (speedX > 16)
                {
                    speedX = 16;
                }
                else if (speedX < -16)
                {
                    speedX = -16;
                }
                else if (speedX < 0.0001 && speedX > -0.0001)
                {
                    speedX = 0;
                }
            }
            if (speedY != 0 || modifierY != 0)
            {
                speedY = speedY + modifierY;
                speedY = speedY * Config.physics_base_drag;
                if (my == 0 && mox != 0 || speedY < 0 && my > 0 || speedY > 0 && my < 0 || (current == BlockIds.Action.Gravity.ZERO ||
                    current == BlockIds.Action.Ladders.CHAIN ||
                    current == BlockIds.Action.Ladders.HORIZONTALVINE ||
                    current == BlockIds.Action.Ladders.LADDER ||
                    current == BlockIds.Action.Ladders.VERTICALVINE) && !isGod)
                {
                    speedY = speedY * no_modifier_dragY;
                }
                else if (this.current == BlockIds.Action.Liquids.WATER && !isGod)
                {
                    speedY = speedY * water_drag;
                }
                if (speedY > 16)
                {
                    speedY = 16;
                }
                else if (speedY < -16)
                {
                    speedY = -16;
                }
                else if (speedY < 0.0001 && speedY > -0.0001)
                {
                    speedY = 0;
                }
            }

            if (!isGod)
            {
                switch (this.current)
                {
                    case BlockIds.Action.Boost.DOWN:
                        {
                            speedX = -boost;
                            break;
                        }
                    case BlockIds.Action.Boost.LEFT:
                        {
                            speedX = boost;
                            break;
                        }
                    case BlockIds.Action.Boost.RIGHT:
                        {
                            speedY = -boost;
                            break;
                        }
                    case BlockIds.Action.Boost.UP:
                        {
                            speedY = boost;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                    /*case 100:
                    {
                        if (Global.play_sounds)
                        {
                            this.ding.play();
                        }
                        this.world.setTileComplex(0, cx, cy, 110, null);
                        var _loc_2:String = this;
                        var _loc_3:* = this.coins + 1;
                        _loc_2.coins = _loc_3;
                        cchanged;
                        break;
                    }
                    case 101:
                    {
                        if (Global.play_sounds)
                        {
                            this.ding.play();
                        }
                        this.world.setTileComplex(0, cx, cy, 111, null);
                        var _loc_2:String = this;
                        var _loc_3:* = this.bcoins + 1;
                        _loc_2.bcoins = _loc_3;
                        break;
                    }*/
                }
            }
            reminderX = x % 1;
            currentSX = speedX;
            reminderY = y % 1;
            currentSY = speedY;
            this.donex = false;
            this.doney = false;

            while (currentSX != 0 && !this.donex || currentSY != 0 && !this.doney)
            {
                this.ProcessPortals();
                ox = x;
                oy = y;
                osx = currentSX;
                osy = currentSY;
                this.StepX();
                this.StepY();
            }

            if (this.pastx != cx || this.pasty != cy)
            {
                switch (this.current)
                {
                    case BlockIds.Action.Crowns.GOLD:
                        {
                            if (!this.hasCrown && !isGod)
                            {

                            }
                            break;
                        }
                    case BlockIds.Action.Keys.RED:
                        {
                            break;
                        }
                    case BlockIds.Action.Keys.GREEN:
                        {
                            break;
                        }
                    case BlockIds.Action.Keys.BLUE:
                        {
                            break;
                        }
                    case BlockIds.Action.Switches.SWITCH:
                        {
                            this.purple = !this.purple;
                            if (!this.purple)
                            {
                                this.hasOpenSwitch = false;
                            }
                            else
                            {
                                this.hasOpenSwitch = true;
                            }
                            break;
                        }
                }
                this.pastx = cx;
                this.pasty = cy;
            }

            double imx = speedX * 256;
            double imy = speedY * 256;
            isMoving = false;
            if (imx != 0 || this.current == BlockIds.Action.Liquids.WATER)
            {
                isMoving = true;
            }
            else if (modifierX < 0.1 && modifierX > -0.1)
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
            if (imy != 0 || this.current == BlockIds.Action.Liquids.WATER)
            {
                isMoving = true;
            }
            else if (modifierY < 0.1 && modifierY > -0.1)
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

        internal void Update()
        {
            return;
        }

        public void ResetCoins()
        {
            this.Coins = 0;
            this.BlueCoins = 0;
            return;
        }

    }
}