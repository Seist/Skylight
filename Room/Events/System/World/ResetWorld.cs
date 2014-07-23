using PlayerIOClient;
using Skylight.Blocks;

namespace Skylight
{
    /// <summary>
    /// Class Reset World.
    /// </summary>
    public class ResetWorld
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResetWorld"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public ResetWorld(In @in)
        {
            _in = @in;
        }

        /// <summary>
        /// Called when the world is cleared (then the internal map is).
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnReset(Message m)
        {
            foreach (Block b in Tools.DeserializeInit(m, 1, _in.Source))
            {
                _in.Source.Map[b.X, b.Y, b.Z] = b;
            }
        }
    }
}