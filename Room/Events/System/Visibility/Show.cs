// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Show.cs" company="">
//   
// </copyright>
// <summary>
//   Class Show.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    /// <summary>
    ///     Class Show.
    /// </summary>
    public class Show
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Show"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Show(In @in)
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
        public event In.RoomEvent ShowEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when the time doors are visible
        /// </summary>
        public void OnShow()
        {
            // Like with "hide", there is data but it is irrelevant.
            // Update relevant objects.
            this._in.Source.TimeDoorsVisible = true;

            // Fire the event.
            var e = new RoomEventArgs(this._in.Source);

            this._in.Source.Pull.Show.ShowEvent(e);
        }

        #endregion
    }
}