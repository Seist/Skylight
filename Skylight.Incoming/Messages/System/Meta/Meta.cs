using PlayerIOClient;
using Skylight.Arguments;

namespace Skylight
{
    public class Meta
    {
        private readonly In _in;

        public Meta(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, potion toggling and saved) for just
        ///     a few examples.
        /// </summary>
        public event In.RoomEvent UpdateMetaEvent = delegate { };

        public void OnUpdateMeta(Message m)
        {
            // Extract data.
            string
                ownerName = m.GetString(0),
                roomName = m.GetString(1);

            int plays = m.GetInteger(2),
                woots = m.GetInteger(3),
                totalWoots = m.GetInteger(4);

            // Update relevant objects.
            _in.Source.Owner.Name = ownerName;
            _in.Source.Name = roomName;
            _in.Source.Plays = plays;
            _in.Source.Woots = woots;
            _in.Source.TotalWoots = totalWoots;

            // Fire the event.
            var e = new RoomEventArgs(_in.Source);

            _in.Source.Pull.Meta.UpdateMetaEvent(e);
        }
    }
}