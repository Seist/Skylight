namespace Skylight
{
    /// <summary>
    /// Class Hide.
    /// </summary>
    public class Hide
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hide"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public Hide(In @in)
        {
            _in = @in;
        }

        /// <summary>
        /// Delegates for RoomEvent. Are only invoked when commands that concern
        /// the room's state (such as global clear, potion toggling and saved) for just
        /// a few examples.
        /// </summary>
        public event In.RoomEvent HideEvent = delegate { };

        /// <summary>
        /// Called when the time doors are hidden
        /// </summary>
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