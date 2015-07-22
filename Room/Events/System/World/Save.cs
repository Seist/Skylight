// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Save.cs" company="">
//   
// </copyright>
// <summary>
//   Class Save.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    /// <summary>
    ///     Class Save.
    /// </summary>
    public class Save
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Save" /> class.
        /// </summary>
        /// <param name="in">
        ///     The in.
        /// </param>
        public Save(In @in)
        {
            _in = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, potion toggling and saved) for just
        ///     a few examples.
        /// </summary>
        public event In.RoomEvent SavedEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when the level is saved.
        /// </summary>
        public void OnSaved()
        {
            // Nothing to extract from message.
            // Nothing to update because I have no idea what it is.
            // Fire the event.
            var e = new RoomEventArgs(_in.Source);

            _in.Source.Pull.Save.SavedEvent(e);
        }

        #endregion
    }
}