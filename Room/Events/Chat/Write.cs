// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Write.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Write.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using System.Collections.Generic;

    using PlayerIOClient;

    /// <summary>
    ///     Class Write.
    /// </summary>
    public class Write
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Write"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Write(In @in)
        {
            this._in = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     All of the delegates for ChatEvent. Chat events are when the player
        ///     says something, and distinguishes between auto text and system messages
        ///     and much more.
        /// </summary>
        public event In.ChatEvent SystemMessageEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when a player says something in the chat box (other than a native command).
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnWrite(Message m)
        {
            // Extract data.
            string message = m.GetString(1);

            // Update relevant objects.
            // Player system = new Player() { Name = prefix };
            this._in.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, null));

            // Fire the event.
            var e = new ChatEventArgs(null, this._in.Source);

            this._in.Source.Pull.Write.SystemMessageEvent(e);
        }

        #endregion
    }
}