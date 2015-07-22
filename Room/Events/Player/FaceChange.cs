// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FaceChange.cs" company="None">
//   
// </copyright>
// <summary>
//   Class FaceChange.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    ///     Class FaceChange.
    /// </summary>
    public class FaceChange
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FaceChange" /> class.
        /// </summary>
        /// <param name="in">
        ///     The in.
        /// </param>
        public FaceChange(In @in)
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
        public event In.PlayerEvent FaceEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when a player's smiley changed.
        /// </summary>
        /// <param name="m">
        ///     The message.
        /// </param>
        public void OnFace(Message m)
        {
            // Extract data.
            int playerId = m.GetInteger(0), smileyId = m.GetInteger(1);

            // Update relevant objects.
            var subject = Tools.GetPlayer(playerId, _in.Source);

            subject.Smiley = smileyId;

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.FaceChange.FaceEvent(e);
        }

        #endregion
    }
}