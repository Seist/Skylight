

namespace Skylight
{
    public class RefreshShop
    {
        private readonly In _in;

        public RefreshShop(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, potion toggling and saved) for just
        ///     a few examples.
        /// </summary>
        public event In.RoomEvent RefreshshopEvent = delegate { };

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