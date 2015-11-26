// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Access.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Access.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class Access.
    /// </summary>
    public class Access
    {
        #region Fields

        /// <summary>
        ///     The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Access"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Access(Receiver @in)
        {
            this._receiver = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     All events that concern the player. This includes many messages that the player
        ///     gets from the world (such as server information and leveling up). Mostly these
        ///     events are shown from the server directly to the user in the form of a dialog
        ///     box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event Receiver.PlayerEvent GainAccessEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when the bot received elevated permission access (god mode, changing blocks) to the room.
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnAccess(Message m)
        {
            // Nothing to extract from message.
            // Update relevant objects.
            this._receiver.Bot.HasAccess = true;

            // Fire the event.
            var e = new PlayerEventArgs(this._receiver.Bot, this._receiver.Source, m);

            this._receiver.Source.MainReceiver.Access.GainAccessEvent(e);
        }

        #endregion
    }
}