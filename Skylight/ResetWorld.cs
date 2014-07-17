using PlayerIOClient;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class ResetWorld
    {
        private In _in;

        public ResetWorld(In @in)
        {
            _in = @in;
        }

        public void OnReset(Message m)
        {
            foreach (var b in Tools.DeserializeInit(m, 1, _in.Source))
            {
                _in.Source.Map[b.X, b.Y, b.Z] = b;
            }
        }
    }
}