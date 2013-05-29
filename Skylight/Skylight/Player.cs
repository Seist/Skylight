// <author>TakoMan02</author>
// <summary>Player.cs describes a singular player in an EE world.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;

    public class Player
    {
        // Private instance fields
        private bool
            hasAccess = false,
            hasBoost = false,
            hasClub = false,
            hasCommandAccess = false,
            hasCrown = false,
            hasGravityModifier = false,
            hasSilverCrown = false,
            isFriend = false,
            isGod = false,
            isHoldingDown = false,
            isHoldingLeft = false,
            isHoldingRight = false,
            isHoldingUp = false,
            isHoldingSpace = false,
            isMod = false,
            isOwner = false;

        private int
            coins,
            collectedMagic,
            deathCount = 0,
            id = -1,
            smiley,
            xpLevel;

        private double
            horizontalDirection,
            horizontalModifier,
            horizontalSpeed,
            verticalModifier,
            verticalDirection,
            verticalSpeed,
            x,
            y;
            
        private Room playingIn;

        private string name;

        private List<Potion> potionEffects = new List<Potion>();

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

            set
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
                if (this.IsPlayingIn.Owner == this)
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
        
        public double X
        {
            get
            {
                return this.x;
            }

            internal set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }

            internal set
            {
                this.y = value;
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

        public List<Potion> PotionEffects
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
        
        public Room IsPlayingIn
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
    }
}