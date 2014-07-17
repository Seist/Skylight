using PlayerIOClient;
using Skylight.Arguments;
using Skylight.Blocks;

namespace Skylight
{
    public class NoteBlock
    {
        private In _in;

        public NoteBlock(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     All of the delegates for BlockEvent. These fire when events occur
        ///     (such as when a block was added or updated).
        /// </summary>
        public event In.BlockEvent
            SoundBlockEvent = delegate { };

        public void OnAddNoteblock(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                note = m.GetInteger(3);

            // Update relevant objects.
            Block b = null;

            if (id == BlockIds.Action.Music.Percussion)
            {
                b = new PercussionBlock(x, y, note);
            }
            else if (id == BlockIds.Action.Music.Piano)
            {
                b = new PianoBlock(x, y, note);
            }

            _in.Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, _in.Source);

            _in.Source.Pull.NoteBlock.SoundBlockEvent(e);
        }
    }
}