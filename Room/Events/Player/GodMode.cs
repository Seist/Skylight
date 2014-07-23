using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    /// Class God Mode.
    /// </summary>
    public class GodMode
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="GodMode"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public GodMode(In @in)
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
            GodEvent = delegate { };

        /// <summary>
        /// Called when a player toggles god mode.
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnGod(Message m)
        {
            // Extract data.
            bool isGod = m.GetBoolean(1);

            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, _in.Source);

            subject.IsGod = isGod;

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.GodMode.GodEvent(e);
        }
    }
}