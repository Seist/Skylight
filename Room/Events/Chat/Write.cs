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
        ///     The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Write"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Write(Receiver @in)
        {
            this._receiver = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     All of the delegates for ChatEvent. Chat events are when the player
        ///     says something, and distinguishes between auto text and system messages
        ///     and much more.
        /// </summary>
        public event Receiver.ChatEvent SystemMessageEvent = delegate { };

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
            this._receiver.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, null));

            // Fire the event.
            var e = new ChatEventArgs(null, m, this._receiver.Source, message);

            this._receiver.Source.MainReceiver.Write.SystemMessageEvent(e);
        }

        #endregion
    }
}
