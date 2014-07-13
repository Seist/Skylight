namespace Skylight
{
    using System;

    public class CoinBlock : Block
    {
        private const int
            MINCOINSREQUIRED = 1,
            MAXCOINSREQUIRED = 99;

        private bool isGate = false; 

        private int coinsRequired = -1;

        public CoinBlock(
            int x,
            int y,
            int coinsRequired,
            bool isGate) : base(Utilities.CoinIdByGate(isGate), x, y, 0)
        {
            this.CoinsRequired = coinsRequired;
            this.IsGate = isGate;
        }

        public bool IsGate
        {
            get;

            internal set;
        }

        public int CoinsRequired
        {
            get;

            internal set;
        }
    }
}
