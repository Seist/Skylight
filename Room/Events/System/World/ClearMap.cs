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
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ClearMap" /> class.
        /// </summary>
        /// <param name="in">
        ///     The in.
        /// </param>
        public ClearMap(In @in)
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
        public event In.RoomEvent ClearEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when the room is completely cleared using the clear command.
        /// </summary>
        public void OnClear()
        {
            Tools.ClearMap(_in.Source);

            // Fire the event.
            var e = new RoomEventArgs(_in.Source);

            _in.Source.Pull.ClearMap.ClearEvent(e);
        }

        #endregion
    }
}