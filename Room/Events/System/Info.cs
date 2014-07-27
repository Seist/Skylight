// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Info.cs" company="">
//   
// </copyright>
// <summary>
//   Class Info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class Info.
    /// </summary>
    public class Info
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Info"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Info(In @in)
        {
            this._in = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     All events that concern the player. This includes many messages that the player
        ///     gets from the world (such as server information and leveling up). Mostly these
        ///     events are shown from the server directly to the user in the form of a dialog
        ///     box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event In.PlayerEvent InfoEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when the server sends a system message to the bot.
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnInfo(Message m)
        {
            // Extract data.
            string title = m.GetString(0), body = m.GetString(1);

            // Update relevant objects.
            Tools.SkylightMessage(
                "Bot " + this._in.Bot.Name + " received a pop-up window:\n   " + title + "\n    " + body);

            if (title == "Limit reached")
            {
                this._in.Bot.Disconnect();
                Tools.SkylightMessage("The bot was forced to disconnect because the limit was reached.");
            }

            // Fire the event.
            var e = new PlayerEventArgs(this._in.Bot, this._in.Source, m);

            this._in.Source.Pull.Info.InfoEvent(e);
        }

        #endregion
    }
}