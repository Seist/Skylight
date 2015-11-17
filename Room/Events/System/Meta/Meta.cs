// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Meta.cs" company="">
//   
// </copyright>
// <summary>
//   Class Meta.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    ///     Class Meta.
    /// </summary>
    public class Meta
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Meta"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Meta(In @in)
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
        public event In.RoomEvent UpdateMetaEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when the room metadata changes (such as title, likes or plays).
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnUpdateMeta(Message m)
        {
            // Extract data.
            string ownerName = m.GetString(0), roomName = m.GetString(1);

            int plays = m.GetInteger(2);
            // Update relevant objects.
            this._in.Source.Owner.Name = ownerName;
            this._in.Source.Name = roomName;
            this._in.Source.Plays = plays;

            // Fire the event.
            var e = new RoomEventArgs(this._in.Source, m);

            this._in.Source.Pull.Meta.UpdateMetaEvent(e);
        }

        #endregion
    }
}