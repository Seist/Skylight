using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using System;
using MasterBot.Room.Block;
using MasterBot.Room;
namespace MasterBot.Movement
{
    /*import Player.*;
    import SynchronizedObject.*;
    import SynchronizedSprite.*;
    import __AS3__.vec.*;
    import animations.*;
    import blitter.*;
    import com.greensock.*;
    import com.greensock.easing.*;
    import flash.display.*;
    import flash.geom.*;
    import flash.media.*;
    import items.*;
    import playerio.*;
    import states.*;
    import ui.*;*/

    public class PhysicsPlayer : SynchronizedSprite
    {
        /*protected var Ding:Class;
        protected var Crown:Class;
        protected var CrownSilver:Class;
        protected var Aura:Class;
        protected var ModAura:Class;
        protected var FireAura:Class;
        protected var LevitationEffect:Class;*/
        private int _id;
        //protected var ding:Sound;
        //private var world:World;
        public bool isme;
        private Bitmap crown;
        private Bitmap crown_silver;
        private Bitmap aura;
        private Bitmap modaura;
        private Bitmap fireAura;
        private Bitmap invulnerableAura;
        private Bitmap levitationAnimaitonBitmapData;
        private Bitmap clubaura;
        //private var connection:Connection;
        //private var state:PlayState;
        //private var chat:Chat;
        //private var badge:LevelBadge;
        //private var badgevisible:Boolean = false;
        //private var flauntBadge:FlauntLevelBadge;
        private Bitmap deadAnim;
        public bool isDead = false;
        private bool deathsend = false;
        private bool worldportalsend = false;
        private bool _isInvulnerable = false;
        public string name;
        private uint textcolor;
        private int morx = 0;
        private int mory = 0;
        public int woots = 0;
        public int coins = 0;
        public int level = 1;
        public int bcoins = 0;
        public bool hascrown = false;
        public bool hascrownsilver = false;
        public bool isgod = false;
        public bool ismod = false;
        public bool isclubmember = false;
        public int current = 0;
        public int current_bg = 0;
        public bool purple = false;
        public int checkpoint_x = -1;
        public int checkpoint_y = -1;
        public int overlapy = 0;
        public double gravityMultiplier = 1;
        private double last_respawn = 0;
        private bool _tagged = false;
        private bool _canTag = false;
        //private var taggedMarker:TaggedMarker;
        private Rectangle rect2;
        public double aura_color = 4.29497e+009;
        public int aura_offset = 0;
        //private var fireAnimation:BlSprite;
        //private var protectionAnimation:BlSprite;
        //private var levitationAnimation:BlSprite;
        private bool _hasLevitation = false;
        private bool _isFlaunting = false;
        private double total = 0;
        private int pastx = 0;
        private int pasty = 0;
        private Queue<int> queue;
        private DateTime lastJump;
        private bool changed = false;
        private int leftdown = 0;
        private int rightdown = 0;
        private int updown = 0;
        private int downdown = 0;
        private bool spacedown = false;
        private bool spacejustdown = false;
        public int horizontal = 0;
        public int vertical = 0;
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
        private IRoom room;

        public int smiley;
        public bool hasChat;
        public bool isFriend;
        private double oldX = -1;
        private double oldY = -1;

        int cx = 0;
        int cy = 0;
        bool isgodmod = false;
        double reminderX = 0;
        double currentSX = 0;
        double reminderY = 0;
        double currentSY = 0;
        double osx = 0;
        double osy = 0;
        double ox = 0;
        double oy = 0;
        int mod = 0;
        bool injump = false;
        bool cchanged = false;
        double tx = 0;
        double ty = 0;

        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public int BlockX { get { return blockX; } set { x = value * 16; } }
        public int BlockY { get { return blockY; } set { y = value * 16; } }
        public int OldBlockX { get { return (int)Math.Round(((this.oldX) / 16.0)); } }
        public int OldBlockY { get { return (int)Math.Round(((this.oldY) / 16.0)); } }
        public bool Moved { get { return BlockX != OldBlockX || BlockY != OldBlockY; } }

        public PhysicsPlayer(IRoom room, int id, string name, int smiley, double xPos, double yPos, bool isGod, bool isMod, bool hasChat, int coins, bool purple, bool isFriend, int level)
            : base(null, 16)
        {
            this.room = room;
            this.smiley = smiley;
            this.isgod = isGod;
            this.ismod = isMod;
            this._id = id;
            this.hasChat = hasChat;
            this.coins = coins;
            this.purple = purple;
            this.isFriend = isFriend;
            this.level = level;
            //this.Ding = Player_Ding;
            //this.Crown = Player_Crown;
            //this.CrownSilver = Player_CrownSilver;
            //this.Aura = Player_Aura;
            //this.ModAura = Player_ModAura;
            //this.FireAura = Player_FireAura;
            //this.LevitationEffect = Player_LevitationEffect;
            //this.ding = new this.Ding();
            //this.crown = new this.Crown().bitmapData;
            //this.crown_silver = new this.CrownSilver().bitmapData;
            //this.aura = new this.Aura().bitmapData;
            //this.modaura = new this.ModAura().bitmapData;
            ///this.fireAura = new this.FireAura().bitmapData;
            //this.invulnerableAura = AnimationManager.animProtection;
            //this.levitationAnimaitonBitmapData = new this.LevitationEffect().bitmapData;
            //this.clubaura = AnimationManager.animClubAura;
            this.rect2 = new Rectangle(0, 0, 16, 26);
            //this.fireAnimation = new BlSprite(this.fireAura, 0, 0, 26, 26, 6);
            //this.protectionAnimation = new BlSprite(this.invulnerableAura, 0, 0, 26, 26, 24);
            //this.levitationAnimation = new BlSprite(this.levitationAnimaitonBitmapData, 0, 0, 26, 26, 32);
            this.queue = new Queue<int>(Config.physics_queue_length);
            this.lastJump = new DateTime();
            this.lastPortal = new Point();
            this.that = this as SynchronizedObject;
            this.modrect = new Rectangle(0, 0, 64, 64);
            this.clubrect = new Rectangle(0, 0, 64, 64);
            //this.touchpotions = {};
            this._currentThrust = this._maxThrust;
            //super(ItemManager.smiliesBMD);
            //this.state = param5;
            //this.connection = param4;
            //this.world = param1;
            //this.hitmap = param1;
            this.x = xPos;
            this.y = yPos;
            this.isme = false;
            this.name = name;
            //this.chat = new Chat(param2.indexOf(" ") != -1 ? ("") : (param2));
            size = 16;
            width = 16;
            height = 16;
            return;
        }// end function

        public int id()
        {
            return this._id;
        }// end function

        public void id(int param1)
        {
            this._id = param1;
            return;
        }// end function

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
        }// end function

        public double speedMultiplier()
        {
            double _loc_1 = 1;
            if (this.zombie())
            {
                _loc_1 = _loc_1 * 0.6;
            }
            return _loc_1;
        }// end function

        public double dragMud()
        {
            return _mud_drag;
        }// end function

        public int overlaps(SynchronizedObject param1)
        {
            List<int> _loc_8 = new List<int>();
            //int _loc_10 = 0;
            int _loc_11 = 0;
            if (param1.x < 0 || param1.y < 0 || param1.x >= room.Width * 16 - 8 || param1.y >= room.Height * 16 - 8)
            {
                //Console.WriteLine("returning 1, worldborder, " + name + " " + param1.x / 16 + " " + param1.y / 16);
                return 1;
            }
            //else
            //Console.WriteLine("NOT returning 1, worldborder, " + name + " " + param1.x / 16 + " " + param1.y / 16);
            PhysicsPlayer _loc_2 = this;

            if (_loc_2.isgod || _loc_2.ismod)
            {
                //Console.WriteLine("returning 0, isgod");
                return 0;
            }

            double _loc_3 = ((_loc_2.x) / 16);
            double _loc_4 = ((_loc_2.y) / 16);
            //double _loc_5 = (param1.x + param1.height) / 16;
            //Console.WriteLine(_loc_3 + " - "  +_loc_5);
            //double _loc_6 = (param1.y + param1.width) / 16;
            //bool _loc_7 = false;
            for (int xx = -2; xx < 1; xx++)
            {
                for (int yy = -2; yy < 1; yy++)
                {
                    if (_loc_3 + xx > 0 && _loc_3 + xx < room.Width && _loc_4 + yy > 0 && _loc_4 + yy <= room.Height)
                    {
                        for (int xTest = 0; xTest < 16; xTest++)
                        {
                            for (int yTest = 0; yTest < 16; yTest++)
                            {
                                if (hitTest((int)(xTest + _loc_2.x + xx * 16), (int)(yTest + _loc_2.y + yy * 16)))
                                {
                                    double _loc_9 = _loc_4;
                                    IBlock currentBlock = room.getBlock(0, (int)(((xx * 16) + _loc_2.x + xTest) / 16), (int)(((yy * 16) + _loc_2.y + yTest) / 16));
                                    _loc_11 = currentBlock.Id;
                                    if (ItemId.isSolid(_loc_11))
                                    {
                                        switch (_loc_11)
                                        {
                                            case 23:
                                                {
                                                    if (room.HideRed)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case 24:
                                                {
                                                    if (room.HideGreen)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case 25:
                                                {
                                                    if (room.HideBlue)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case 26:
                                                {
                                                    if (!room.HideRed)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case 27:
                                                {
                                                    if (!room.HideGreen)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case 28:
                                                {
                                                    if (!room.HideBlue)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case 156:
                                                {
                                                    if (room.HideTimeDoor)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case 157:
                                                {
                                                    if (!room.HideTimeDoor)
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
                                                    if (currentBlock is BlockCoinDoor && ((BlockCoinDoor)currentBlock).coins <= coins)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                }
                                            case ItemId.COINGATE:
                                                {
                                                    if (currentBlock is BlockCoinGate && ((BlockCoinGate)currentBlock).coins > coins)
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
                                                    /*if (_loc_2.isme)
                                                    {
                                                        knownSecrets[_loc_10 + "x" + _loc_9] = true;
                                                    }*/
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
                                                        //_loc_7 = true;
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

            //_loc_11 = Form1.blockMap[_loc_3, _loc_4].ID;
            /*while (_loc_9 < _loc_6)
            {

                _loc_8.Clear();
                for (int i = 0; i < Form1.worldSize.X; i++)
                {
                    _loc_8.Add(Form1.blockMap[i, _loc_9].ID);
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
                                    if (_loc_2.speedY < 0 || _loc_9 <= _loc_2.overlapy)
                                    {
                                        if (_loc_9 != _loc_4 || _loc_2.overlapy == -1)
                                        {
                                            _loc_2.overlapy = _loc_9;
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
                _loc_2.overlapy = -1;
            }*/
            return 0;
        }// end function

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
            //if (hitmap != null)
            //{
            if (overlaps(that) != 0)
            {
                x = ox;
                _speedX = 0;
                currentSX = osx;
                donex = true;
            }
            //}
            return;
        }// end function

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
            //if (hitmap != null)
            //{
            if (overlaps(that) != 0)
            {
                y = oy;
                _speedY = 0;
                currentSY = osy;
                doney = true;
            }
            //}
            return;
        }// end function

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
            current = room.getBlock(0, cx, cy).Id;
            if (!isgodmod && current == ItemId.WORLD_PORTAL)
            {
                if (spacejustdown && !worldportalsend)
                {
                    //has hit world portal and leaves the world
                    /*
                    _loc_1 = Program.getWorldPortalTarget(cx, cy);
                    if (_loc_1.length > 0)
                    {
                        worldportalsend = true;
                        _loc_2 = new NavigationEvent(NavigationEvent.JOIN_WORLD, true, false);
                        _loc_2.world_id = _loc_1;
                        Global.base.dispatchEvent(_loc_2);
                    }*/
                }
            }
            if (!isgodmod && current == 242)
            {
                if (lastPortal.X == 0 && lastPortal.Y == 0)
                {
                    lastPortal = new Point(cx << 4, cy << 4);

                    //current = Form1.blockMap[cx, cy].ID;
                    IBlock currentBlock = room.getBlock(0, cx, cy);
                    BlockPortal currentBlockPortal = (BlockPortal)currentBlock;
                    int currentTarget = currentBlockPortal.destinationId;
                    //Console.WriteLine("entered portal with id " + currentBlock.thisID + " and target id " + currentTarget + " and rotation " + currentBlock.rotation);

                    //targetPortalList = world.getPortals(world.getPortal(cx, cy).target);
                    for (int x = 1; x < room.Width; x++)
                    {
                        for (int y = 1; y < room.Height; y++)
                        {
                            IBlock block = room.getBlock(0, x, y);
                            if (block is BlockPortal && ((BlockPortal)block).myId == currentTarget)
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
                        _loc_4 = ((BlockPortal)room.getBlock(0, lastPortal.X >> 4, lastPortal.Y >> 4)).rotation;
                        //Console.WriteLine("1: " + _loc_4);
                        //_loc_5 = world.getPortal(currentLoopPortal.x >> 4, currentLoopPortal.y >> 4).rotation;
                        _loc_5 = ((BlockPortal)room.getBlock(0, currentLoopPortal.X >> 4, currentLoopPortal.Y >> 4)).rotation;
                        //Console.WriteLine("2: " + _loc_5);
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
                        //Console.WriteLine("entering switch " + _loc_10);
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
        }// end function

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
            this.current = room.getBlock(0, cx, cy).Id;
            this.queue.Enqueue(this.current);
            if (this.current == 4 || ItemId.isClimbable(this.current))
            {
                delayed = this.queue.Dequeue();
                this.queue.Enqueue(this.current);
            }
            /*if (this.isme)
            {
                this.leftdown = Bl.isKeyDown(37) || Bl.isKeyDown(65) ? (-1) : (0);
                this.rightdown = Bl.isKeyDown(39) || Bl.isKeyDown(68) ? (1) : (0);
                this.updown = Bl.isKeyDown(38) || Bl.isKeyDown(87) ? (-1) : (0);
                this.downdown = Bl.isKeyDown(40) || Bl.isKeyDown(83) ? (1) : (0);
                this.spacejustdown = Bl.isKeyJustPressed(32);
                this.spacedown = Bl.isKeyDown(32);
                this.horizontal = this.leftdown + this.rightdown;
                this.vertical = this.updown + this.downdown;
                Bl.resetJustPressed();
            }*/
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
            /*if (this.isme && !this.isDead)
            {
                mod;
                injump;
                if (this.spacejustdown)
                {
                    this.lastJump = -new Date().time;
                    injump;
                    mod;
                }
                if (this.spacedown)
                {
                    if (this.hasLevitation)
                    {
                        if (!this._isThrusting)
                        {
                            this.changed = true;
                        }
                        this._isThrusting = true;
                        this.applyThrust();
                    }
                    else if (this.lastJump < 0)
                    {
                        if (new Date().time + this.lastJump > 750)
                        {
                            injump;
                        }
                    }
                    else if (new Date().time - this.lastJump > 150)
                    {
                        injump;
                    }
                }
                else if (this.hasLevitation)
                {
                    if (this._isThrusting)
                    {
                        this.changed = true;
                    }
                    this._isThrusting = false;
                }
                if (injump && !this.hasLevitation)
                {
                    if (this.speedX == 0 && this.morx && this.mox && this.x % 16 == 0)
                    {
                        this.speedX = this.speedX - this.morx * Config.physics_jump_height * this.jumpMultiplier;
                        this.changed = true;
                        this.lastJump = new Date().time * mod;
                    }
                    if (this.speedY == 0 && this.mory && this.moy && this.y % 16 == 0)
                    {
                        this.speedY = this.speedY - this.mory * Config.physics_jump_height * this.jumpMultiplier;
                        this.changed = true;
                        this.lastJump = new Date().time * mod;
                    }
                }
                cchanged;
                switch(this.current)
                {
                    case 100:
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
                    }
                    default:
                    {
                        break;
                    }
                }
                if (this.pastx != cx || this.pasty != cy)
                {
                    switch(this.current)
                    {
                        case 5:
                        {
                            if (!this.hascrown && !isgodmod)
                            {
                                this.connection.send(Bl.data.m + "k");
                            }
                            break;
                        }
                        case 6:
                        {
                            this.connection.send(Bl.data.m + "r");
                            this.state.showRed();
                            break;
                        }
                        case 7:
                        {
                            this.connection.send(Bl.data.m + "g");
                            this.state.showGreen();
                            break;
                        }
                        case 8:
                        {
                            this.connection.send(Bl.data.m + "b");
                            this.state.showBlue();
                            break;
                        }
                        case ItemId.SWITCH_PURPLE:
                        {
                            this.purple = !this.purple;
                            if (!this.purple)
                            {
                                this.state.hidePurple();
                            }
                            else
                            {
                                this.state.showPurple();
                            }
                            this.connection.send(Bl.data.m + "sp", this.purple);
                            break;
                        }
                        case 77:
                        {
                            if (this.pastx != cx || this.pasty != cy)
                            {
                                if (Global.play_sounds)
                                {
                                    ItemManager.pianoSounds[this.world.getSound(cx, cy)].play();
                                    this.world.pingSound(cx, cy);
                                }
                            }
                            break;
                        }
                        case 83:
                        {
                            if (this.pastx != cx || this.pasty != cy)
                            {
                                if (Global.play_sounds)
                                {
                                    ItemManager.drumSounds[this.world.getSound(cx, cy)].play();
                                    this.world.pingSound(cx, cy);
                                }
                            }
                            break;
                        }
                        case ItemId.DIAMOND:
                        {
                            this.connection.send("diamondtouch", cx, cy);
                            break;
                        }
                        case ItemId.CAKE:
                        {
                            this.connection.send("caketouch", cx, cy);
                            break;
                        }
                        case ItemId.CHECKPOINT:
                        {
                            if (!isgodmod)
                            {
                                this.checkpoint_x = cx;
                                this.checkpoint_y = cy;
                                this.connection.send("checkpoint", cx, cy);
                            }
                            break;
                        }
                        case ItemId.BRICK_COMPLETE:
                        {
                            if (!isgodmod)
                            {
                                this.connection.send("levelcomplete");
                                if (!this.hascrownsilver)
                                {
                                    Global.base.showLevelComplete(new LevelComplete());
                                }
                            }
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }
                    this.pastx = cx;
                    this.pasty = cy;
                }
                if (this.changed || this.oh != this.horizontal || this.ov != this.vertical)
                {
                    this.oh = this.horizontal;
                    this.ov = this.vertical;
                    if (this.connection.connected)
                    {
                        this.connection.send("m", this.x, this.y, this.speedX, this.speedY, this.modifierX, this.modifierY, this.horizontal, this.vertical, this.gravityMultiplier, this.spacedown);
                    }
                }
                if (cchanged)
                {
                    this.connection.send("c", this.coins, cx, cy);
                    if (Math.random() * 3000 >> 0 == 0)
                    {
                        Global.base.awardSwappits();
                    }
                }
                this.changed = false;
            }*/
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
        }// end function

        override public void update()
        {
            return;
        }// end function

        public void showBadge(bool param1)
        {
            /*bool value = param1;
            if (value)
            {
                //this.badgevisible = true;
                //this.badge = new LevelBadge((this.level - 1));
                //TweenMax.to(this.badge, 0.25, {y:"-15", yoyo:true, repeat:-1, ease:Sine.easeOut});
            }
            else
            {
                //TweenMax.killTweensOf(this.badge);
                //TweenMax.to(this.badge, 0.2, {scale:0, onComplete:function () : void
            {
                //badgevisible = false;
                return;
            }// end function
            });
            }*/
            return;
        }// end function

        public void drawBadge(Bitmap param1, double param2, double param3, bool param4)
        {
            /*if (param4 && this.badgevisible)
            {
                this.badge.draw(param1, param2 + x - 32, param3 + y - 44);
            }*/
            return;
        }// end function

        public void flauntLevelBadge(bool param1)
        {
            /*var value:* = param1;
            this._isFlaunting = value;
            if (this._isFlaunting)
            {
                this.flauntBadge = new FlauntLevelBadge((this.level - 1));
                TweenMax.to(this.flauntBadge, 0.25, {y:"-15", yoyo:true, repeat:-1, ease:Sine.easeOut});
            }
            else
            {
                TweenMax.killTweensOf(this.flauntBadge);
                TweenMax.to(this.flauntBadge, 0.2, {scale:0, onComplete:function () : void
            {
                _isFlaunting = false;
                return;
            }// end function
            });
            }*/
            return;
        }// end function

        public void drawChat(Bitmap param1, double param2, double param3, bool param4)
        {
            //this.chat.drawChat(param1, param2 + x, param3 + y, param4);
            return;
        }// end function

        public void enterChat()
        {
            //this.chat.enterFrame();
            return;
        }// end function

        public void say(string param1)
        {
            //this.chat.say(param1);
            return;
        }// end function

        public void killPlayer()
        {
            this.isDead = true;
            //this.deadAnim = AnimationManager.animRandomDeath();
            return;
        }// end function

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
        }// end function

        public void resetCoins()
        {
            this.coins = 0;
            this.bcoins = 0;
            return;
        }// end function

        public void resetCheckpoint()
        {
            this.checkpoint_x = -1;
            this.checkpoint_y = -1;
            return;
        }// end function

        /*override public function draw(param1:BitmapData, param2:int, param3:int) : void
        {
            var _loc_4:int = 0;
            var _loc_5:Rectangle = null;
            if (this.isgod || this.ismod)
            {
                return;
            }
            if (!Player.HasSolitude || this.isme)
            {
                if (this.isDead)
                {
                    if (this.deadoffset > 16)
                    {
                        if (this.isme && !this.deathsend)
                        {
                            this.deathsend = true;
                            this.connection.send("death");
                        }
                        return;
                    }
                    if (this.deadoffset < 2)
                    {
                        param1.copyPixels(bmd, this.rect2, new Point(x + param2, y + param3 - 5));
                    }
                    _loc_4 = this.deadoffset;
                    param1.copyPixels(this.deadAnim, new Rectangle(_loc_4 * 64, 0, 64, 64), new Point(x + param2 - 24, y + param3 - 24));
                    return;
                }
                if (this._isInvulnerable)
                {
                    if ((this.animoffset >> 0) % 3 == 0)
                    {
                        if (this.protectionAnimation.frame < (this.protectionAnimation.totalFrames - 1))
                        {
                            var _loc_6:* = this.protectionAnimation;
                            var _loc_7:* = this.protectionAnimation.frame + 1;
                            _loc_6.frame = _loc_7;
                        }
                        else
                        {
                            this.protectionAnimation.frame = 0;
                        }
                    }
                    this.protectionAnimation.draw(param1, x + param2 - 5, y + param3 - 5);
                }
                if (this.zombie)
                {
                    _loc_5 = this.rect2.clone();
                    this.rect2.clone().x = _loc_5.width * 87;
                    param1.copyPixels(bmd, _loc_5, new Point(x + param2, y + param3 - 5));
                }
                else
                {
                    param1.copyPixels(bmd, this.rect2, new Point(x + param2, y + param3 - 5));
                }
                if (this.hascrown)
                {
                    param1.copyPixels(this.crown, this.crown.rect, new Point(x + param2, y + param3 - 6));
                }
                else if (this.hascrownsilver)
                {
                    param1.copyPixels(this.crown_silver, this.crown_silver.rect, new Point(x + param2, y + param3 - 6));
                }
                if (this.jump_boost)
                {
                    param1.copyPixels(this.aura, new Rectangle(4 * 26, 0, 26, 26), new Point(x + param2 - 5, y + param3 - 5));
                }
                if (this.fire_aura)
                {
                    if ((this.animoffset >> 0) % 3 == 0)
                    {
                        if (this.fireAnimation.frame < (this.fireAnimation.totalFrames - 1))
                        {
                            var _loc_6:* = this.fireAnimation;
                            var _loc_7:* = this.fireAnimation.frame + 1;
                            _loc_6.frame = _loc_7;
                        }
                        else
                        {
                            this.fireAnimation.frame = 0;
                        }
                    }
                    this.fireAnimation.draw(param1, x + param2 - 4, y + param3 - 5);
                }
                if (this.hasLevitation)
                {
                    if (this._isThrusting)
                    {
                        this.playLevitationAnimation(param1, param2, param3);
                    }
                }
                if (this._isFlaunting && this.flauntBadge)
                {
                    this.flauntBadge.draw(param1, param2 + x - 32, param3 + y - 44);
                }
            }
            return;
        }// end function*/

        /*private function playLevitationAnimation(param1:BitmapData, param2:int, param3:int) : void
        {
            if (this.morx == 0 && this.mory == 0)
            {
                return;
            }
            var _loc_4:int = 0;
            var _loc_5:int = 8;
            var _loc_6:int = -5;
            var _loc_7:int = -5;
            if (this.mory != 0)
            {
                if (this.mory < 0)
                {
                    _loc_6 = -21;
                    _loc_4 = 8;
                }
                else
                {
                    _loc_6 = 12;
                    _loc_4 = 0;
                }
            }
            if (this.morx != 0)
            {
                if (this.morx < 0)
                {
                    _loc_7 = -24;
                    _loc_4 = 16;
                }
                else
                {
                    _loc_7 = 14;
                    _loc_4 = 24;
                }
            }
            if (this.levitationAnimation.frame < _loc_4 + _loc_5 - 1)
            {
                var _loc_8:* = this.levitationAnimation;
                var _loc_9:* = this.levitationAnimation.frame + 1;
                _loc_8.frame = _loc_9;
            }
            else
            {
                this.levitationAnimation.frame = _loc_4;
            }
            this.levitationAnimation.draw(param1, x + param2 + _loc_7, y + param3 + _loc_6);
            return;
        }// end function*/

        /*public function drawGods(param1:BitmapData, param2:int, param3:int) : void
        {
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            if (!this.isgod && !this.ismod)
            {
                return;
            }
            if (this.isgod)
            {
                if (this.isclubmember)
                {
                    _loc_4 = this.cluboffset;
                    this.clubrect.x = _loc_4 * 64;
                    this.clubrect.y = this.aura_offset * 64;
                    param1.copyPixels(this.clubaura, this.clubrect, new Point(x + param2 - 24, y + param3 - 24));
                }
                else
                {
                    param1.copyPixels(this.aura, new Rectangle(this.aura_offset * 26, 0, 26, 26), new Point(x + param2 - 5, y + param3 - 5));
                }
            }
            else if (this.ismod)
            {
                _loc_5 = this.modoffset;
                this.modrect.x = _loc_5 * 64;
                param1.copyPixels(this.modaura, this.modrect, new Point(x + param2 - 24, y + param3 - 24));
            }
            param1.copyPixels(bmd, this.rect2, new Point(x + param2, y + param3 - 5));
            if (this.hascrown)
            {
                param1.copyPixels(this.crown, this.crown.rect, new Point(x + param2, y + param3 - 6));
            }
            else if (this.hascrownsilver)
            {
                param1.copyPixels(this.crown_silver, this.crown_silver.rect, new Point(x + param2, y + param3 - 6));
            }
            return;
        }// end function*/

        override public void frame(int param1)
        {
            this.rect2.X = param1 * 16;
            return;
        }// end function

        override public int frame()
        {
            return this.rect2.X / 16;
        }// end function

        public void nameColor(int param1)
        {
            //this.chat.textColor = param1;
            return;
        }// end function

        public uint minimapColor()
        {
            /*if (this.aura_color != 4294967295)
            {
                return this.aura_color;
            }
            return ItemManager.getSmileyById(this.frame).minimapcolor;*/
            return 0;
        }// end function

        /*private function showCursed(param1:Boolean) : void
        {
            if (param1)
            {
                this.taggedMarker = new TaggedMarker();
                TweenMax.to(this.taggedMarker, 0.25, {y:"-15", yoyo:true, repeat:-1, ease:Sine.easeOut});
            }
            else if (this.taggedMarker)
            {
                TweenMax.killTweensOf(this.taggedMarker);
            }
            return;
        }// end function*/

        /*public function drawTagged(param1:BitmapData, param2:Number, param3:Number) : void
        {
            if (this.cursed)
            {
                this.taggedMarker.draw(param1, x + param2 + 3, y + param3 - 8);
            }
            return;
        }// end function*/

        public void cursed(bool param1)
        {
            this._cursed = param1;
            //this.showCursed(param1);
            return;
        }// end function

        public bool cursed()
        {
            return this._cursed;
        }// end function

        public void zombie(bool param1)
        {
            this._zombie = param1;
            return;
        }// end function

        public bool zombie()
        {
            if (this.isgod || this.ismod)
            {
                return false;
            }
            return this._zombie;
        }// end function

        public void addTouchPotion(string param1, double param2 = 1)
        {
            this.touchpotions.Add(param1, DateTime.Now.Millisecond + (int)param2 * 1000);
            return;
        }// end function

        public void removeTouchPotion(string param1)
        {
            this.touchpotions.Remove(param1);
            return;
        }// end function

        public bool hasActivePotion(string param1)
        {
            if (!this.touchpotions.ContainsKey(param1))
            {
                return false;
            }
            return (DateTime.Now.Millisecond - this.touchpotions[param1]) > 0;
        }// end function

        public bool hasPotion(string param1)
        {
            return this.touchpotions.ContainsKey(param1);
        }// end function

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
        }// end function

        public bool getCanTag()
        {
            if (this.isgod || this.ismod || this.isDead)
            {
                return false;
            }
            return this.getActivePotions().Count > 0;
        }// end function

        public bool getCanBeTagged()
        {
            if (this.isgod || this.ismod || this.isDead)
            {
                return false;
            }
            return (DateTime.Now.Millisecond - this.last_respawn) > 1000;
        }// end function

        public void setCanTag(bool param1)
        {
            if (param1)
            {
                //TweenMax.killDelayedCallsTo(this.setCanTagDelayed);
                //TweenMax.delayedCall(1, this.setCanTagDelayed);
            }
            else
            {
                this._canTag = false;
            }
            return;
        }// end function

        public void setCanTagDelayed()
        {
            this._canTag = true;
            return;
        }// end function

        public void setPosition(double param1, double param2)
        {
            x = param1;
            y = param2;
            return;
        }// end function

        public void isInvulnerable(bool param1)
        {
            this._isInvulnerable = param1;
            return;
        }// end function

        public bool isInvulnerable()
        {
            return this._isInvulnerable;
        }// end function

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
        }// end function

        public void hasLevitation(bool param1)
        {
            this._hasLevitation = param1;
            return;
        }// end function

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
        }// end function

        public bool isThrusting()
        {
            return this._isThrusting;
        }// end function

        public void isThrusting(bool param1)
        {
            this._isThrusting = param1;
            return;
        }// end function

        public void applyThrust()
        {
            this._currentThrust = this._maxThrust;
            return;
        }// end function

        public bool isFlaunting()
        {
            return this._isFlaunting;
        }// end function

        public void isFlaunting(bool param1)
        {
            this._isFlaunting = param1;
            return;
        }// end function

        public static bool isAdmin(string param1)
        {
            return admins.Contains(param1);
        }// end function

    }
}
