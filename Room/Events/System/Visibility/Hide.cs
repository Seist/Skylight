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
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Hide"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Hide(In @in)
        {
            this._in = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, saved) for just
        ///     a few examples.
        /// </summary>
        public event In.RoomEvent HideEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when the time doors are hidden
        /// </summary>
        public void OnHide()
        {
            // Like with "clear", there is data but it is irrelevant.
            // Update relevant objects.
            this._in.Source.TimeDoorsVisible = false;

            // Fire the event.
            var e = new RoomEventArgs(this._in.Source);

            this._in.Source.Pull.Hide.HideEvent(e);
        }

        #endregion
    }
}