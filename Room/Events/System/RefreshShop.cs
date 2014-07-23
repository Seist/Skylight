namespace Skylight
{
    /// <summary>
    /// Class Refresh Shop.
    /// </summary>
    public class RefreshShop
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshShop"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public RefreshShop(In @in)
        {
            _in = @in;
        }

        /// <summary>
        /// Delegates for RoomEvent. Are only invoked when commands that concern
        /// the room's state (such as global clear, potion toggling and saved) for just
        /// a few examples.
        /// </summary>
        public event In.RoomEvent RefreshshopEvent = delegate { };

        /// <summary>
        /// Called when the shop has been refreshed.
        /// </summary>
        public void OnRefreshShop()
        {
            // Nothing to extract.
            // Nothing to update.
            // Fire the event.
            var e = new RoomEventArgs(_in.Source);

            _in.Source.Pull.RefreshShop.RefreshshopEvent(e);
        }
    }
}