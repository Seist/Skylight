using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    /// Class Crown.
    /// </summary>
    public class Crown
    {
        /// <summary>
        /// The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="Crown"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public Crown(Receiver @in)
        {
            _receiver = @in;
        }

        /// <summary>
        /// All events that concern the player. This includes many messages that the player
        /// gets from the world (such as server information and leveling up). Mostly these
        /// events are shown from the server directly to the user in the form of a dialog
        /// box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event Receiver.PlayerEvent
            CrownEvent = delegate { };

        /// <summary>
        /// Called when a player gets the crown. Only one player can have the crown at one time.
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnCrown(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            if (id == -1)
            {
                return;
            }

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, _receiver.Source);

            // Take the crown from the current holder (if one exists)
            Player crownHolder = Tools.GetCrownHolder(_receiver.Source);

            if (crownHolder != null)
                crownHolder.HasCrown = false;

            // Give it to the subject.
            if (subject != null)
                subject.HasCrown = true;

            // Fire the event.
            var e = new PlayerEventArgs(subject, _receiver.Source, m);

            _receiver.Source.MainReceiver.Crown.CrownEvent(e);
        }
    }
}