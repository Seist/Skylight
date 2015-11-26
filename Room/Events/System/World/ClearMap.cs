// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClearMap.cs" company="">
//   
// </copyright>
// <summary>
//   Class Clear Map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    /// <summary>
    ///     Class Clear Map.
    /// </summary>
    public class ClearMap
    {
        #region Fields

        /// <summary>
        ///     The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearMap"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public ClearMap(Receiver @in)
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
        public event Receiver.RoomEvent ClearEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when the room is completely cleared using the clear command.
        /// </summary>
        public void OnClear()
        {
            Tools.ClearMap(this._receiver.Source);

            // Fire the event.
            var e = new RoomEventArgs(this._receiver.Source);

            this._receiver.Source.MainReceiver.ClearMap.ClearEvent(e);
        }

        #endregion
    }
}