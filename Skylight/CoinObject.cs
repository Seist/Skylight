using PlayerIOClient;
using Skylight.Arguments;
using Skylight.Blocks;

namespace Skylight
{
    public class CoinObject
    {
        private readonly In _in;

        public CoinObject(In @in)
        {
            _in = @in;
        }
        public event In.RoomEvent CoinBlockEvent = delegate { };
        public void OnAddCoinDoorOrGate(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                coinsRequired = m.GetInteger(3);

            // Update relevant objects.
            var b = new CoinBlock(x, y, coinsRequired, false);

            if (id == BlockIds.Action.Gates.Coin)
            {
                b.IsGate = true;
            }

            _in.Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, _in.Source);

            _in.Source.Pull.CoinBlockEvent(e);
        }
    }
}