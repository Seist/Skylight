namespace Skylight
{
    using System;

    public partial class CoinBlock : Block
    {
        private const int
            MINCOINSREQUIRED = 1,
            MAXCOINSREQUIRED = 99;

        private bool isGate = false; // Gates are nonsolid and move to solid

        private int coinsRequired = -1;

        public CoinBlock(
            int id,
            int x,
            int y,
            int coinsRequired,
            bool isGate,
            Room r,
            Player placer = null) : base(x, y, id, r, placer)
        {
            this.X = x;
            this.Y = y;
            this.CoinsRequired = coinsRequired;
            this.IsGate = isGate;
            this.R = r;
            this.Placer = placer;
        }

        public bool IsGate
        {
            get
            {
                return this.isGate;
            }

            set
            {
                this.isGate = value;
            }
        }

        public int CoinsRequired
        {
            get
            {
                return this.coinsRequired;
            }

            set
            {
                this.coinsRequired = value;
            }
        }
    }
}
