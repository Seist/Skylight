using PlayerIOClient;
using Skylight.Blocks;

namespace Skylight
{
    /// <summary>
    /// Class Add Special Block.
    /// </summary>
    public class AddSpecialBlock
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddSpecialBlock"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public AddSpecialBlock(In @in)
        {
            _in = @in;
        }

        /// <summary>
        /// All of the delegates for BlockEvent. These fire when events occur
        /// (such as when a block was added or updated).
        /// </summary>
        public event In.BlockEvent
            RotateEvent = delegate { };

        /// <summary>
        /// Called when a user adds scifi blocks or spikes.
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnAddScifiOrSpikes(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                rotation = m.GetInteger(3);

            // Update relevant objects.
            var b = new Block(id, x, y, 0, rotation);

            _in.Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, _in.Source);

            _in.Source.Pull.AddSpecialBlock.RotateEvent(e);
        }
    }
}