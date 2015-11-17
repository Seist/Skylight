// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tele.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Tele.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class Tele.
    /// </summary>
    public class Tele
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Tele"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Tele(In @in)
        {
            this._in = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     All events that concern the player. This includes many messages that the player
        ///     gets from the world (such as server information and leveling up). Mostly these
        ///     events are shown from the server directly to the user in the form of a dialog
        ///     box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event In.PlayerEvent DeathEvent = delegate { };

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, saved) for just
        ///     a few examples.
        /// </summary>
        public event In.RoomEvent ResetEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when a player teleports?
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnTele(Message m)
        {
            // Extract some of the data.
            bool isReset = m.GetBoolean(0);

            // On reset
            if (isReset)
            {
                // Extract more data and update relevant objects.
                uint index = 1;

                while (index < m.Count)
                {
                    int id = m.GetInteger(index), x = m.GetInteger(index + 1), y = m.GetInteger(index + 2);

                    Player tempSubject = Tools.GetPlayer(id, this._in.Source);
                    tempSubject.X = x;
                    tempSubject.Y = y;

                    index += 3;
                }

                // Fire the event.
                var e = new RoomEventArgs(this._in.Source, m);

                this._in.Source.Pull.Tele.ResetEvent(e);
            }
            else
            {
                // On death (or whatever else isn't a reset).
                // Extract data.
                int id = m.GetInteger(1), x = m.GetInteger(2), y = m.GetInteger(3);

                // Update relevant objects.
                Player subject = Tools.GetPlayer(id, this._in.Source);

                subject.X = x;
                subject.Y = y;

                // Fire the event.
                var e = new PlayerEventArgs(subject, this._in.Source, m);

                this._in.Source.Pull.Tele.DeathEvent(e);
            }
        }

        #endregion
    }
}