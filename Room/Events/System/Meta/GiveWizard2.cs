using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    /// Class Give Wizard 2.
    /// </summary>
    public class GiveWizard2
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="GiveWizard2"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public GiveWizard2(In @in)
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
            RedWizardEvent = delegate { };

        /// <summary>
        /// Called when the server gives a different wizard smiley to a player.
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnGiveWizard2(Message m)
        {
            // Extract data
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, _in.Source);

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.GiveWizard2.RedWizardEvent(e);
        }
    }
}