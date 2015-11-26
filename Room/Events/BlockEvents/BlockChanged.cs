using System.Collections.Generic;
using PlayerIOClient;
using Skylight.Blocks;

namespace Skylight
{
    using System;

    /// <summary>
    /// Class Block Changed.
    /// </summary>
    public class BlockChanged
    {
        /// <summary>
        /// The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockChanged"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public BlockChanged(Receiver @in)
        {
            _receiver = @in;
        }
        /// <summary>
        /// All of the delegates for BlockEvent. These fire when events occur
        /// (such as when a block was added or updated).
        /// </summary>
        public event Receiver.BlockEvent
            NormalBlockEvent = delegate { };
        /// <summary>
        /// Called when a block is changed.
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnBlock(Message m)
        {
            // Extract data.
            int z = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2),
                blockId = m.GetInteger(3);
            // Update relevant objects.
            var b = new Block(blockId, x, y, z);
            int playerId = -1;
            try
            {
                playerId = m.GetInteger(4);
                Player subject = Tools.GetPlayer(playerId, _receiver.Source);
                b.Placer = subject;
            }
            catch
            {
                b.Placer = this._receiver.Source.Owner;
            }

            _receiver.Source.Map[x][y][z] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, m, _receiver.Source);

            _receiver.Source.MainReceiver.BlockChanged.NormalBlockEvent(e);
        }
    }
}
