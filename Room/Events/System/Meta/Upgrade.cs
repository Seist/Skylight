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
        /// The _receiver.
        /// </summary>
        private readonly Receiver _receiver;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Upgrade"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Upgrade(Receiver @in)
        {
            this._receiver = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, saved) for just
        ///     a few examples.
        /// </summary>
        public event Receiver.RoomEvent UpdateEvent = delegate { };

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
            var e = new RoomEventArgs(this._receiver.Source);

            this.UpdateEvent(e);
        }

        #endregion
    }
}