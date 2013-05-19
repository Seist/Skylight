// <author>TakoMan02</author>
// <summary>Player.cs describes a singular player in an EE world.</summary>
namespace Skylight
{
    using System;

    public class Player
    {
        private bool commandAccess = false;

        private string name;

        public bool CommandAccess
        {
            get { return this.commandAccess; }
            set { this.commandAccess = value; }
        }

        public World IsPlayingIn
        {
            get;
            internal set;
        }

        public string Name
        {
            get { return this.name; }
            internal set { this.name = value.ToLower(); }
        }

        public int Smiley
        {
            get;
            internal set;
        }

        public int Id
        {
            get;
            internal set;
        }

        public int Coins
        {
            get;
            internal set;
        }

        public int XpLevel
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

        public bool IsFriend
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

        public bool IsOwner
        {
            get;
            internal set;
        }

        // Location in the world
        public double X
        {
            get;
            internal set;
        }

        public double Y
        {
            get;
            internal set;
        }

        // Movement variables
        public double XSpeed
        {
            get;
            internal set;
        }

        public double YSpeed
        {
            get;
            internal set;
        }

        public double HorizontalModifier
        {
            get;
            internal set;
        }

        public double VerticalModifier
        {
            get;
            internal set;
        }

        public double HorizontalDirection
        {
            get;
            internal set;
        }

        public double VerticalDirection
        {
            get;
            internal set;
        }

        // Things that you can own
        public bool HasClub
        {
            get;
            internal set;
        }

        public bool HasBoost
        {
            get;
            internal set;
        }

        public bool HasAccess
        {
            get;
            internal set;
        }

        public bool HasSilverCrown
        {
            get;
            internal set;
        }

        public bool HasCrown
        {
            get;
            internal set;
        }
    }
}