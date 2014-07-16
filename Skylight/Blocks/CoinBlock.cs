namespace Skylight
{
    public class CoinBlock : Block
    {
        private int _coinsRequired = -1;
        private bool _isGate;

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
            get { return _isGate; }

            internal set { _isGate = value; }
        }

        public int CoinsRequired
        {
            get { return _coinsRequired; }

            internal set { _coinsRequired = value; }
        }
    }
}