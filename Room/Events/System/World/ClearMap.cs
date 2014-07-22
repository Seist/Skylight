using Skylight.Blocks;

namespace Skylight
{
    public class ClearMap
    {
        private readonly In _in;

        public ClearMap(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, potion toggling and saved) for just
        ///     a few examples.
        /// </summary>
        public event In.RoomEvent
            ClearEvent = delegate { };

        public void OnClear()
        {
           Tools.ClearMap(_in.Source);

            // Fire the event.
            var e = new RoomEventArgs(_in.Source);

            _in.Source.Pull.ClearMap.ClearEvent(e);
        }
    }
}