// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LevelChange.cs" company="">
//   
// </copyright>
// <summary>
//   Class Level Change.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class Level Change.
    /// </summary>
    public class LevelChange
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelChange"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public LevelChange(In @in)
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
        public event In.PlayerEvent LevelUpEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when a player levels up.
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnLevelUp(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0), level = m.GetInteger(1);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this._in.Source);
            subject.Level = level;

            // Fire the event.
            var e = new PlayerEventArgs(subject, this._in.Source, m);

            this._in.Source.Pull.LevelChange.LevelUpEvent(e);
        }

        #endregion
    }
}