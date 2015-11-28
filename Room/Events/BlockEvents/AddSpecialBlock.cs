// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddSpecialBlock.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Add Special Block.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    using Skylight.Blocks;

    /// <summary>
    /// Class Add Special Block.
    /// </summary>
    public class AddSpecialBlock
    {
        /// <summary>
        /// The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddSpecialBlock"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public AddSpecialBlock(Receiver @in)
        {
            this._receiver = @in;
        }

        /// <summary>
        /// All of the delegates for BlockEvent. These fire when events occur
        /// (such as when a block was added or updated).
        /// </summary>
        public event Receiver.BlockEvent
            RotateEvent = delegate { };

        /// <summary>
        /// Called when a user adds Sci-Fi blocks or spikes.
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

            this._receiver.Source.Map.AddBlock(b);

            // Fire the event.
            var e = new BlockEventArgs(b, m, this._receiver.Source);

            this._receiver.Source.MainReceiver.AddSpecialBlock.RotateEvent(e);
        }
    }
}