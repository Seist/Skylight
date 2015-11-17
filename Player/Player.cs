// <author>TakoMan02</author>
// <summary>Player.cs describes a singular player in an EE world.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Skylight.Blocks;

    public class Player
    {
        // Private instance fields
        public bool ShouldTick = true;

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
            xpLevel,
            auraColor;

        private Room playingIn;

        private string name;

        // Public instance properties.
        public int AuraColor { get; internal set; }

        public uint ChatColor { get; internal set; }

        public string Badge { get; internal set; }

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
        public int Horizontal = 0;
        public int Vertical = 0;

        public void ResetCoins()
        {
            this.Coins = 0;
            this.BlueCoins = 0;
            return;
        }

        /* --------------------------- GUSTAVIAN PHYSICS --------------------------- */

        public double X = 0;
        public double Y = 0;
        public int width = 1;
        public int height = 1;
        public bool moving = false;
        protected int size;
        public bool hitTest(int param1, int param2)
        {
            return param1 >= X && param2 >= Y && param1 <= X + this.size && param2 <= Y + this.size;
        }
        protected double _speedX = 0;
        protected double _speedY = 0;
        protected double _modifierX = 0;
        protected double _modifierY = 0;
        protected double _baseDragX;
        protected double _baseDragY;
        protected double _no_modifier_dragX;
        protected double _no_modifier_dragY;
        protected double _water_drag;
        protected double _water_buoyancy;
        protected double _mud_drag;
        protected double _mud_buoyancy;
        protected double _boost;
        protected double _gravity;
        public double mox = 0;
        public double moy = 0;
        public double mx = 0;
        public double my = 0;
        public DateTime last;
        protected double offset = 0;
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
        protected double posX
        {
            get
            {
                return (this.X + 8);
            }
        }
        protected double posY
        {
            get
            {
                return (this.Y + 8);
            }
        }
        public double speedX
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
        public double speedY
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
        public double modifierX
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
        public double modifierY
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

        public bool isme;
        // private Bitmap crown;
        // private Bitmap crown_silver;
        // private Bitmap aura;
        // private Bitmap modaura;
        // private Bitmap fireAura;
        // private Bitmap invulnerableAura;
        // private Bitmap levitationAnimaitonBitmapData;
        // private Bitmap clubaura;
        // private Bitmap deadAnim;
        public bool isDead = false;
        private bool deathsend = false;
        private bool worldportalsend = false;
        private bool _isInvulnerable = false;
        // public string name;
        // private uint textcolor;
        private int morx = 0;
        private int mory = 0;
        // public int coins = 0;
        public int Level = 1;
        public int bcoins = 0;
        // public bool hascrown = false;
        // public bool hascrownsilver = false;
        public bool isclubmember = false;
        public int current = 0;
        // public int current_bg = 0;
        // public bool purple = false;
        public int checkpoint_x = -1;
        public int checkpoint_y = -1;
        public int overlapy = 0;
        // public double gravityMultiplier = 1;
        private double last_respawn = 0;
        // private bool _tagged = false;
        private bool _canTag = false;
        private Rectangle rect2;
        // public double aura_color = 4.29497e+009;
        // public int aura_offset = 0;
        private bool _hasLevitation = false;
        private bool _isFlaunting = false;
        // private double total = 0;
        // private int pastx = 0;
        // private int pasty = 0;
        private Queue<int> queue = new Queue<int>();
        private DateTime lastJump;
        // private bool changed = false;
        // private int leftdown = 0;
        // private int rightdown = 0;
        // private int updown = 0;
        // private int downdown = 0;
        private bool spacedown = false;
        private bool spacejustdown = false;
        // public int horizontal = 0;
        // public int vertical = 0;
        // public int oh = 0;
        // public int ov = 0;
        private Point lastPortal;
        // private int lastOverlap = 0;
        private Player that;
        // private double bbest = 0;
        private bool donex = false;
        private bool doney = false;
        private double animoffset = 0;
        private double modoffset = 0;
        private Rectangle modrect;
        private double cluboffset = 0;
        private Rectangle clubrect;
        private double deadoffset = 0;
        public bool jump_boost = false;
        // public bool fire_aura = false;
        private bool _zombie = false;
        private bool _cursed = false;
        private bool _isThrusting = false;
        private double _maxThrust = 0.2;
        private double _thrustBurnOff = 0.01;
        private double _currentThrust;
        private static List<string> admins = new List<string> { "benjaminsen", "cyclone", "toby", "rpgmaster2000", "mrshoe", "mrvoid" };
        // public static bool HasSolitude = false;

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
        public int BlockX { get { return blockX; } set { X = value * 16; } }
        public int BlockY { get { return blockY; } set { Y = value * 16; } }
        public int OldBlockX { get { return (int)Math.Round(((this.oldX) / 16.0)); } }
        public int OldBlockY { get { return (int)Math.Round(((this.oldY) / 16.0)); } }
        public bool Moved { get { return BlockX != OldBlockX || BlockY != OldBlockY; } }

        public Player(Room room, int id, string name, int smiley, double xPos, double yPos, bool isGod, bool isMod, bool hasChat, int coins, bool purple, bool isFriend, int level)
        {
            this.PlayingIn = room;
            this.Smiley = smiley;
            this.IsGod = isGod;
            this.IsMod = isMod;
            this.Id = id;
            this.hasChat = hasChat;
            this.Coins = coins;
            this.purple = purple;
            this.isFriend = isFriend;
            this.Level = level;
            this.rect2 = new Rectangle(0, 0, 16, 26);
            this.queue = new Queue<int>(Config.physics_queue_length);
            this.lastJump = new DateTime();
            this.lastPortal = new Point();
            this.that = this as Player;
            this.modrect = new Rectangle(0, 0, 64, 64);
            this.clubrect = new Rectangle(0, 0, 64, 64);
            this._currentThrust = this._maxThrust;
            this.X = xPos;
            this.Y = yPos;
            this.isme = false;
            this.Name = name;
            size = 16;
            width = 16;
            height = 16;
            this._baseDragX = Config.physics_base_drag;
            this._baseDragY = Config.physics_base_drag;
            this._no_modifier_dragX = Config.physics_no_modifier_drag;
            this._no_modifier_dragY = Config.physics_no_modifier_drag;
            this._water_drag = Config.physics_water_drag;
            this._water_buoyancy = Config.physics_water_buoyancy;
            this._mud_drag = Config.physics_mud_drag;
            this._mud_buoyancy = Config.physics_mud_buoyancy;
            this._boost = Config.physics_boost;
            this._gravity = Config.physics_gravity;
            this.mult = Config.physics_variable_multiplyer;
            this.last = DateTime.Now;
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

        public void frame(int param1)
        {
            this.rect2.X = param1 * 16;
            return;
        }

        public int frame()
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
            if (this.IsGod || this.IsMod)
            {
                return false;
            }
            return this._zombie;
        }

        public bool getCanBeTagged()
        {
            if (this.IsGod || this.IsMod || this.isDead)
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
            X = param1;
            Y = param2;
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