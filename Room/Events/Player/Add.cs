// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Add.cs" company="">
//   
// </copyright>
// <summary>
//   Class Add.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class Add.
    /// </summary>
    public class Add
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Add"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Add(In @in)
        {
            this._in = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     Occurs when a player joins the room.
        /// </summary>
        public event In.PlayerEvent OnAddEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when a player joins the room.
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnAdd(Message m)
        {
            // Extract data.
            string name = m.GetString(1);

            int id = m.GetInteger(0), smiley = m.GetInteger(2), coins = m.GetInteger(8), xplevel = m.GetInteger(11);

            double x = m.GetDouble(3), y = m.GetDouble(4);

            bool isGod = m.GetBoolean(5), 
                 isMod = m.GetBoolean(6), 
                 hasBoost = m.GetBoolean(9), 
                 isFriend = m.GetBoolean(10), 
                 hasClub = m.GetBoolean(12); // never used.

            // Update relevant objects.
            var subject = new Player(
                this._in.Source, 
                id, 
                name, 
                smiley, 
                x, 
                y, 
                isGod, 
                isMod, 
                true, 
                coins, 
                hasBoost, 
                isFriend, 
                xplevel, 
                hasClub, 
                false, 
                false, 
                false, 
                false, 
                false);

            this._in.Source.OnlinePlayers.Add(subject);

            // Fire the event.
            var e = new PlayerEventArgs(subject, this._in.Source, m);

            this._in.Source.Pull.Add.OnAddEvent(e);
        }

        #endregion
    }
}