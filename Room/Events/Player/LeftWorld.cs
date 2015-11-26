// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeftWorld.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Lef tWorld.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class Left World.
    /// </summary>
    public class LeftWorld
    {
        #region Fields

        /// <summary>
        ///     The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LeftWorld"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public LeftWorld(Receiver @in)
        {
            this._receiver = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     All events that concern the player. This includes many messages that the player
        ///     gets from the world (such as server information and leveling up). Mostly these
        ///     events are shown from the server directly to the user in the form of a dialog
        ///     box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event Receiver.PlayerEvent LeaveEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when a player left the world.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        public void OnLeft(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this._receiver.Source);
            for (int i = 0; i < this._receiver.Source.OnlinePlayers.Count; i++)
            {
                if (this._receiver.Source.OnlinePlayers[i] != subject)
                {
                    continue;
                }

                this._receiver.Source.OnlinePlayers.RemoveAt(i);
                break;
            }

            // Fire the event.
            var e = new PlayerEventArgs(subject, this._receiver.Source, m);

            this._receiver.Source.MainReceiver.LeftWorld.LeaveEvent(e);
        }

        #endregion
    }
}