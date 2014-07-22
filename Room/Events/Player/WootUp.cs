using PlayerIOClient;

namespace Skylight
{
    public class WootUp
    {
        private readonly In _in;

        public WootUp(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     All events that concern the player. This includes many messages that the player
        ///     gets from the world (such as server information and leveling up). Mostly these
        ///     events are shown from the server directly to the user in the form of a dialog
        ///     box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event In.PlayerEvent
            WootEvent = delegate { };

        public void OnWootUp(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, _in.Source);

            _in.Source.TotalWoots++;
            _in.Source.Woots++;

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.WootUp.WootEvent(e);
        }
    }
}