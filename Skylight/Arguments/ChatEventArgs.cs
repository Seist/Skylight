using System;
using System.Linq;

namespace Skylight.Arguments
{
    /// <summary>
    /// The class that handles all chat-based messages from the server
    /// including ones sent to the user through system.
    /// </summary>
    public class ChatEventArgs : EventArgs
    {
        /// <summary>
        ///     The room where the message originated from.
        /// </summary>
        private readonly Room _origin;

        /// <summary>
        ///     The player who sent the message.
        /// </summary>
        private readonly Player _speaker;

        /// <summary>
        /// The main method where the chat messages are sent. This method sets the properties in
        /// this class to the speaker and origin of the message, where it is handed off to a delegate
        /// later.
        /// </summary>
        /// <param name="speaker">The player who said the message.</param>
        /// <param name="origin">The room where the message originated.</param>
        public ChatEventArgs(Player speaker, Room origin)
        {
            _origin = origin;
            var room = _origin;
            if (room != null) {room.ChatLog = origin.ChatLog;}
            _speaker = speaker;
        }

        /// <summary>
        /// The message object containing the message content.
        /// </summary>
        public string Message
        {
            get { return Origin.ChatLog.Last().Key; }
        }

        /// <summary>
        /// The origin (room) where the message came from.
        /// </summary>
        public Room Origin
        {
            get { return _origin; }
        }

        /// <summary>
        /// Who said the message (player).
        /// </summary>
        public Player Speaker
        {
            get { return _speaker; }
        }
    }
}