namespace Skylight
{
    /// <summary>
    /// Class Clear Map.
    /// </summary>
    public class ClearMap
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearMap"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public ClearMap(In @in)
        {
            _in = @in;
        }

        /// <summary>
        /// Delegates for RoomEvent. Are only invoked when commands that concern
        /// the room's state (such as global clear, potion toggling and saved) for just
        /// a few examples.
        /// </summary>
        public event In.RoomEvent
            ClearEvent = delegate { };

        /// <summary>
        /// Called when the room is completely cleared using the clear command.
        /// </summary>
        public void OnClear()
        {
           Tools.ClearMap(_in.Source);

            // Fire the event.
            var e = new RoomEventArgs(_in.Source);

            _in.Source.Pull.ClearMap.ClearEvent(e);
        }
    }
}