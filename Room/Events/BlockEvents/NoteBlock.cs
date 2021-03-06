// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NoteBlock.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Note Block.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Skylight
{
    using PlayerIOClient;

    using Skylight.Blocks;

    /// <summary>
    /// Class Note Block.
    /// </summary>
    public class NoteBlock
    {
        /// <summary>
        /// The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteBlock"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public NoteBlock(Receiver @in)
        {
            this._receiver = @in;
        }

        /// <summary>
        /// All of the delegates for BlockEvent. These fire when events occur
        /// (such as when a block was added or updated).
        /// </summary>
        public event Receiver.BlockEvent
            SoundBlockEvent = delegate { };

        /// <summary>
        /// Called when a note block is added.
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnAddNoteblock(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                note = m.GetInteger(3);

            // Update relevant objects.
            Block b;

            switch (id)
            {
                case BlockIds.Action.Music.Percussion:
                    b = new PercussionBlock(x, y, note);
                    break;
                case BlockIds.Action.Music.Piano:
                    b = new PianoBlock(x, y, note);
                    break;
                default:
                    Tools.SkylightMessage("Error: noteblock does not exist");
                    return;
            }

            _receiver.Source.Map.AddBlock(b);

            // Fire the event.
            var e = new BlockEventArgs(b, m, this._receiver.Source);

            this._receiver.Source.MainReceiver.NoteBlock.SoundBlockEvent(e);
        }
    }
}