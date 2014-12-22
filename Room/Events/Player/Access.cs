// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Access.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Access.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    ///     Class Access.
    /// </summary>
    public class Access
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Access" /> class.
        /// </summary>
        /// <param name="in">
        ///     The in.
        /// </param>
        public Access(In @in)
        {
            _in = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     All events that concern the player. This includes many messages that the player
        ///     gets from the world (such as server information and leveling up). Mostly these
        ///     events are shown from the server directly to the user in the form of a dialog
        ///     box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event In.PlayerEvent GainAccessEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when the bot received elevated permission access (god mode, changing blocks) to the room.
        /// </summary>
        /// <param name="m">
        ///     The message.
        /// </param>
        public void OnAccess(Message m)
        {
            // Nothing to extract from message.
            // Update relevant objects.
            _in.Bot.HasAccess = true;

            // Fire the event.
            var e = new PlayerEventArgs(_in.Bot, _in.Source, m);

            _in.Source.Pull.Access.GainAccessEvent(e);
        }

        #endregion
    }
}