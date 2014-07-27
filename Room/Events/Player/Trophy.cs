// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trophy.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Trophy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class Trophy.
    /// </summary>
    public class Trophy
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Trophy"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Trophy(In @in)
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
        public event In.PlayerEvent TrophyEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when a player touches the trophy (silver crown).
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnTrophy(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this._in.Source);

            subject.HasSilverCrown = true;

            // Fire the event.
            var e = new PlayerEventArgs(subject, this._in.Source, m);

            this._in.Source.Pull.Trophy.TrophyEvent(e);
        }

        #endregion
    }
}