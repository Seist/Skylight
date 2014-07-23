using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    /// Class Info.
    /// </summary>
    public class Info
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="Info"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public Info(In @in)
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
            InfoEvent = delegate { };

        /// <summary>
        /// Called when the server sends a system message to the bot.
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnInfo(Message m)
        {
            // Extract data.
            string
                title = m.GetString(0),
                body = m.GetString(1);

            // Update relevant objects.
            Tools.SkylightMessage("Bot " + _in.Bot.Name + " received a pop-up window:\n   " +
                                  title + "\n    " + body);

            if (title == "Limit reached")
            {
                _in.Bot.Disconnect();
                Tools.SkylightMessage("The bot was forced to disconnect because the limit was reached.");
            }

            // Fire the event.
            var e = new PlayerEventArgs(_in.Bot, _in.Source, m);

            _in.Source.Pull.Info.InfoEvent(e);
        }
    }
}