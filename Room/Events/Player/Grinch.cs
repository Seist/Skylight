using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    /// Class Grinch.
    /// </summary>
    public class Grinch
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="Grinch"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public Grinch(In @in)
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
            GrinchEvent = delegate { };

        /// <summary>
        /// Called when the server gives a player grinch.
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnGiveGrinch(Message m)
        {
            // Extract data
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, _in.Source);

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.Grinch.GrinchEvent(e);
        }
    }
}