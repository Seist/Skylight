// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Upgrade.cs" company="">
//   
// </copyright>
// <summary>
//   Class Upgrade.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    /// <summary>
    ///     Class Upgrade.
    /// </summary>
    public class Upgrade
    {
        #region Fields

        /// <summary>
        /// The _in.
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Upgrade"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Upgrade(In @in)
        {
            this._in = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, potion toggling and saved) for just
        ///     a few examples.
        /// </summary>
        public event In.RoomEvent UpdateEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when an upgrade event occurs at the server.
        /// </summary>
        public void OnUpgrade()
        {
            // Nothing to extract from message.
            // Nothing to update.
            // Fire the event.
            var e = new RoomEventArgs(this._in.Source);

            this.UpdateEvent(e);
        }

        #endregion
    }
}