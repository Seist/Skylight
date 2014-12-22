// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Witch.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Witch.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    ///     Class Witch.
    /// </summary>
    public class Witch
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Witch" /> class.
        /// </summary>
        /// <param name="in">
        ///     The in.
        /// </param>
        public Witch(In @in)
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
        public event In.PlayerEvent WitchEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when the player is given the witch smiley.
        /// </summary>
        /// <param name="m">
        ///     The message.
        /// </param>
        public void OnGiveWitch(Message m)
        {
            // Extract data
            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayer(id, _in.Source);

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.Witch.WitchEvent(e);
        }

        #endregion
    }
}