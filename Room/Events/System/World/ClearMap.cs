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
            // There is data, but it's kind of irrelevant.
            // Update relevant objects.
            for (int x = 0; x < _in.Source.Width; x++)
            {
                for (int y = 0; y < _in.Source.Height; y++)
                {
                    var blankBlock = new Block(0, x, y);

                    _in.Source.Map[x, y, 0] = blankBlock;
                    _in.Source.Map[x, y, 1] = blankBlock;
                }
            }

            // Fire the event.
            var e = new RoomEventArgs(_in.Source);

            _in.Source.Pull.ClearMap.ClearEvent(e);
        }
    }
}