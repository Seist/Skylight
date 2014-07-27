// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Potions.cs" company="">
//   
// </copyright>
// <summary>
//   Class Potions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class Potions.
    /// </summary>
    public class Potions
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Potions"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Potions(In @in)
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
        public event In.RoomEvent PotionToggleEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when toggling potion access.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        public void OnAllowPotions(Message m)
        {
            // Extract data.
            bool potions = m.GetBoolean(0);

            // Update relevant objects.
            this._in.Source.PotionsAllowed = potions;

            // Fire the event.
            var e = new RoomEventArgs(this._in.Source);

            this._in.Source.Pull.Potions.PotionToggleEvent(e);
        }

        #endregion
    }
}