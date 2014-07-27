// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetWoot.cs" company="">
//   
// </copyright>
// <summary>
//   Class Get Woot.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class Get Woot.
    /// </summary>
    public class GetWoot
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GetWoot"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public GetWoot(In @in)
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
        public event In.PlayerEvent MagicCoinEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when a room gets a woot from a player.
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnGetWoot(Message m)
        {
            // "W" stands for "woot" which is the old name for magic.
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this._in.Source);

            subject.CollectedMagic++;

            // Fire the event.
            var e = new PlayerEventArgs(subject, this._in.Source, m);

            this._in.Source.Pull.GetWoot.MagicCoinEvent(e);
        }

        #endregion
    }
}