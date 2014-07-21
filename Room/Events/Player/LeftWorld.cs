using PlayerIOClient;

namespace Skylight
{
    public class LeftWorld
    {
        private readonly In _in;

        public LeftWorld(In @in)
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
            LeaveEvent = delegate { };

        public void OnLeft(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, _in.Source);
            for (int i = 0; i < _in.Source.OnlinePlayers.Count; i++)
            {
                if (_in.Source.OnlinePlayers[i] == subject)
                {
                    _in.Source.OnlinePlayers.RemoveAt(i);
                    break;
                }
            }

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.LeftWorld.LeaveEvent(e);
        }
    }
}