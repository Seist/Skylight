namespace Skylight
{
    public class Upgrade
    {
        private readonly In _in;

        public Upgrade(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, potion toggling and saved) for just
        ///     a few examples.
        /// </summary>
        public event In.RoomEvent UpdateEvent = delegate { };

        public void OnUpgrade()
        {
            // Nothing to extract from message.
            // Nothing to update.
            // Fire the event.
            var e = new RoomEventArgs(_in.Source);

            UpdateEvent(e);
        }
    }
}