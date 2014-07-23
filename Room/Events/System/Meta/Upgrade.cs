namespace Skylight
{
    /// <summary>
    /// Class Upgrade.
    /// </summary>
    public class Upgrade
    {
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="Upgrade"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
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

        /// <summary>
        /// Called when an upgrade event occurs at the server.
        /// </summary>
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