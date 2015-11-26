// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnKill.cs" company="None">
//   
// </copyright>
// <summary>
//   Class On Kill.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class On Kill.
    /// </summary>
    public class OnKill
    {
        #region Fields

        /// <summary>
        ///     The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OnKill"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public OnKill(Receiver @in)
        {
            this._receiver = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     Occurs when the player dies.
        /// </summary>
        public event Receiver.PlayerEvent DeathEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when the player dies.
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnKillPlayer(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this._receiver.Source);

            subject.DeathCount++;

            // Fire the event.
            var e = new PlayerEventArgs(subject, this._receiver.Source, m);

            this._receiver.Source.MainReceiver.OnKill1.DeathEvent(e);
        }

        #endregion
    }
}