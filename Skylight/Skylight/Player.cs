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
        
        private double
            horizontalDirection,
            horizontalModifier,
            horizontalSpeed,
            verticalModifier,
            verticalDirection,
            verticalSpeed,
            x,
            y;

        private int
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
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

            set
            {
                this.playingIn = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value.ToLower(); }
        }
    }
}