// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Teleport.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Teleport.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    ///     Class Teleport.
    /// </summary>
    public class Teleport
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Teleport" /> class.
        /// </summary>
        /// <param name="in">
        ///     The in.
        /// </param>
        public Teleport(In @in)
        {
            _in = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     All events that concern the player. This includes many messages that the player
        ///     gets from the world (such as server information and leveling up). Mostly these
        ///     events are shown from the server directly to the user in the form of a dialog
        ///     box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event In.PlayerEvent TeleportEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when a player teleports to a location.
        /// </summary>
        /// <param name="m">
        ///     The message.
        /// </param>
        public void OnTeleport(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0), x = m.GetInteger(1), y = m.GetInteger(2);

            // Update relevant objects.
            var subject = Tools.GetPlayer(id, _in.Source);

            subject.X = x;
            subject.Y = y;

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.Teleport.TeleportEvent(e);
        }

        #endregion
    }
}