// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Chat.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Chat.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using System.Collections.Generic;

    using PlayerIOClient;

    /// <summary>
    ///     Class Chat.
    /// </summary>
    public class Chat
    {
        #region Fields

        /// <summary>
        ///     The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Chat"/> class.
        /// </summary>
        /// <param name="in">
        /// The in.
        /// </param>
        public Chat(Receiver @in)
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
        public event Receiver.ChatEvent NormalChatEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when someone says a message.
        /// </summary>
        /// <param name="m">
        /// The message.
        /// </param>
        public void OnSay(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            string message = m.GetString(1);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this._receiver.Source);

            this._receiver.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            var e = new ChatEventArgs(subject, m, this._receiver.Source, message);

            this._receiver.Source.MainReceiver.Chat.NormalChatEvent(e);
        }

        #endregion
    }
}
