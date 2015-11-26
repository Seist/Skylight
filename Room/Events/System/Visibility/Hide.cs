// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Hide.cs" company="">
//   
// </copyright>
// <summary>
//   Class Hide.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    /// <summary>
    ///     Class Hide.
    /// </summary>
    public class Hide
    {
        #region Fields

        /// <summary>
        ///     The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Hide"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Hide(Receiver @in)
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
        public event Receiver.RoomEvent HideEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when the time doors are hidden
        /// </summary>
        public void OnHide()
        {
            // Like with "clear", there is data but it is irrelevant.
            // Update relevant objects.
            this._receiver.Source.TimeDoorsVisible = false;

            // Fire the event.
            var e = new RoomEventArgs(this._receiver.Source);

            this._receiver.Source.MainReceiver.Hide.HideEvent(e);
        }

        #endregion
    }
}