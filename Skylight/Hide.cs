using Skylight.Arguments;

namespace Skylight
{
    public class Hide
    {
        private In _in;

        public Hide(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, potion toggling and saved) for just
        ///     a few examples.
        /// </summary>
        public event In.RoomEvent HideEvent = delegate { };

        public void OnHide()
        {
            // Like with "clear", there is data but it is irrelevant.
            // Update relevant objects.
            _in.Source.TimeDoorsVisible = false;

            // Fire the event.
            var e = new RoomEventArgs(_in.Source);

            _in.Source.Pull.Hide.HideEvent(e);
        }
    }
}