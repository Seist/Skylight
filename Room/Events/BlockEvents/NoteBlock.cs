using PlayerIOClient;
using Skylight.Blocks;

namespace Skylight
{
    /// <summary>
    /// Class Note Block.
    /// </summary>
    public class NoteBlock
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteBlock"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public NoteBlock(In @in)
        {
            _in = @in;
        }

        /// <summary>
        /// All of the delegates for BlockEvent. These fire when events occur
        /// (such as when a block was added or updated).
        /// </summary>
        public event In.BlockEvent
            SoundBlockEvent = delegate { };

        /// <summary>
        /// Called when a noteblock is added.
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

            _in.Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, _in.Source);

            _in.Source.Pull.NoteBlock.SoundBlockEvent(e);
        }
    }
}