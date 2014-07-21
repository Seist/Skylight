

namespace Skylight
{
    public class Save
    {
        private readonly In _in;

        public Save(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, potion toggling and saved) for just
        ///     a few examples.
        /// </summary>
        public event In.RoomEvent SavedEvent = delegate { };

        public void OnSaved()
        {
            // Nothing to extract from message.
            // Nothing to update because I have no idea what it is.
            // Fire the event.
            var e = new RoomEventArgs(_in.Source);

            _in.Source.Pull.Save.SavedEvent(e);
        }
    }
}