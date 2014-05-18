namespace Skylight
{
    using System;

    public class CoinBlock : Block
    {
        private const int
            MINCOINSREQUIRED = 1,
            MAXCOINSREQUIRED = 99;

        private bool isGate = false; // Gates are nonsolid and move to solid

        private int coinsRequired = -1;

        public CoinBlock(
            int x,
            int y,
            int coinsRequired,
            bool isGate) : base(Tools.CoinIdByGate(isGate), x, y, 0)
        {
            this.CoinsRequired = coinsRequired;
            this.IsGate = isGate;
        }

        public bool IsGate
        {
            get
            {
                return this.isGate;
            }

            internal set
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

            internal set
            {
                this.coinsRequired = value;
            }
        }
    }
}
