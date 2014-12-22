// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Chat.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Chat.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    ///     Class Chat.
    /// </summary>
    public class Chat
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Chat" /> class.
        /// </summary>
        /// <param name="in">
        ///     The in.
        /// </param>
        public Chat(In @in)
        {
            _in = @in;
        }

        #endregion

        #region Public Events

        /// <summary>
        ///     All of the delegates for ChatEvent. Chat events are when the player
        ///     says something, and distinguishes between auto text and system messages
        ///     and much more.
        /// </summary>
        public event In.ChatEvent NormalChatEvent = delegate { };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when someone says a message.
        /// </summary>
        /// <param name="m">
        ///     The message.
        /// </param>
        public void OnSay(Message m)
        {
            // Extract data.
            var id = m.GetInteger(0);

            var message = m.GetString(1);

            // Update relevant objects.
            var subject = Tools.GetPlayer(id, _in.Source);

            _in.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            var e = new ChatEventArgs(subject, m, _in.Source, message);

            _in.Source.Pull.Chat.NormalChatEvent(e);
        }

        #endregion
    }
}