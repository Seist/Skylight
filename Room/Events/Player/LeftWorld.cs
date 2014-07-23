using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    /// Class Lef tWorld.
    /// </summary>
    public class LeftWorld
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeftWorld"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public LeftWorld(In @in)
        {
            _in = @in;
        }

        /// <summary>
        /// All events that concern the player. This includes many messages that the player
        /// gets from the world (such as server information and leveling up). Mostly these
        /// events are shown from the server directly to the user in the form of a dialog
        /// box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event In.PlayerEvent
            LeaveEvent = delegate { };

        /// <summary>
        /// Called when a player left the world.
        /// </summary>
        /// <param name="m">The m.</param>
        public void OnLeft(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, _in.Source);
            for (int i = 0; i < _in.Source.OnlinePlayers.Count; i++)
            {
                if (_in.Source.OnlinePlayers[i] != subject) continue;
                _in.Source.OnlinePlayers.RemoveAt(i);
                break;
            }

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.LeftWorld.LeaveEvent(e);
        }
    }
}