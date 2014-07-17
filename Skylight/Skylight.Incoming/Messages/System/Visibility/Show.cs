using Skylight.Arguments;

namespace Skylight
{
    public class Show
    {
        private In _in;

        public Show(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, potion toggling and saved) for just
        ///     a few examples.
        /// </summary>
        public event In.RoomEvent ShowEvent = delegate { };

        public void OnShow()
        {
            // Like with "hide", there is data but it is irrelevant.
            // Update relevant objects.
            _in.Source.TimeDoorsVisible = true;

            // Fire the event.
            var e = new RoomEventArgs(_in.Source);

            _in.Source.Pull.Show.ShowEvent(e);
        }
    }
}