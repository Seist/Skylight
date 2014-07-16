namespace Skylight
{
    public class CoinBlock : Block
    {
        private const int
            MINCOINSREQUIRED = 1,
            MAXCOINSREQUIRED = 99;

        private int coinsRequired = -1;
        private bool isGate;

        public CoinBlock(
            int x,
            int y,
            int coinsRequired,
            bool isGate) : base(Tools.CoinIdByGate(isGate), x, y, 0)
        {
            CoinsRequired = coinsRequired;
            IsGate = isGate;
        }

        public bool IsGate
        {
            get { return isGate; }

            internal set { isGate = value; }
        }

        public int CoinsRequired
        {
            get { return coinsRequired; }

            internal set { coinsRequired = value; }
        }
    }
}