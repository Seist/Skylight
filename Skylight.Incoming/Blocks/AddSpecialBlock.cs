using PlayerIOClient;
using Skylight.Arguments;
using Skylight.Blocks;

namespace Skylight
{
    public class AddSpecialBlock
    {
        private readonly In _in;

        public AddSpecialBlock(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     All of the delegates for BlockEvent. These fire when events occur
        ///     (such as when a block was added or updated).
        /// </summary>
        public event In.BlockEvent
            RotateEvent = delegate { };

        public void OnAddScifiOrSpikes(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                rotation = m.GetInteger(3),
                p_id = m.GetInteger(4); // player id

            // Update relevant objects.
            var b = new Block(id, x, y, 0, rotation);

            _in.Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, _in.Source);

            _in.Source.Pull.AddSpecialBlock.RotateEvent(e);
        }
    }
}