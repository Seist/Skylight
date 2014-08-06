using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    /// Class Sign Block.
    /// </summary>
    public class SignBlock
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignBlock"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public SignBlock(In @in)
        {
            _in = @in;
        }

        /// <summary>
        /// When a sign block is placed in the world.
        /// </summary>
        /// <param name="m">The m.</param>
        public virtual void OnSignBlockEvent(Message m)
        {
            // Extract data
            int x = m.GetInteger(0);
            int y = m.GetInteger(1);
            string theText = m.GetString(3);

            // Fire the event.
            var b = new TextBlock(385, x, y, theText);
            _in.Source.Map[x, y, 0] = b;
            var e = new BlockEventArgs(b, m);

            _in.Source.Pull.SignBlock.SignBlockEvent(e);
        }

        /// <summary>
        /// All of the delegates for BlockEvent. These fire when events occur
        /// (such as when a block was added or updated).
        /// </summary>
        public event In.BlockEvent
            SignBlockEvent = delegate { };
    }
}