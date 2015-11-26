// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GiveWizard2.cs" company="">
//   
// </copyright>
// <summary>
//   Class Give Wizard 2.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class Give Wizard 2.
    /// </summary>
    public class GiveWizard2
    {
        #region Fields

        /// <summary>
        ///     The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GiveWizard2"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public GiveWizard2(Receiver @in)
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
        public event Receiver.PlayerEvent RedWizardEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when the server gives a different wizard smiley to a player.
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnGiveWizard2(Message m)
        {
            // Extract data
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this._receiver.Source);

            // Fire the event.
            var e = new PlayerEventArgs(subject, this._receiver.Source, m);

            this._receiver.Source.MainReceiver.GiveWizard2.RedWizardEvent(e);
        }

        #endregion
    }
}