using System;
using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    ///     The class that handles all chat-based messages from the server
    ///     including ones sent to the user through system.
    /// </summary>
    public class ChatEventArgs : EventArgs
    {
        /// <summary>
        ///     The message sent by player.
        /// </summary>
        public readonly string message;

        /// <summary>
        ///     The origin (room) where the message came from.
        ///     <summary>
        public readonly Room origin;

        /// <summary>
        ///     The player who sent the message.
        /// </summary>
        public readonly Player speaker;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChatEventArgs" /> class.
        ///     The main method where the chat messages are sent. This method sets the properties in
        ///     this class to the speaker and origin of the message, where it is handed off to a delegate
        ///     later.
        /// </summary>
        /// <param name="speaker">
        ///     The player who said the message.
        /// </param>
        /// <param name="origin">
        ///     The room where the message originated.
        /// </param>
        internal ChatEventArgs(Player speaker, Message m, Room origin, string message)
        {
            this.origin = origin;
            if (Origin != null)
            {
                Origin.ChatLog = origin.ChatLog;
            }

            this.speaker = speaker;
            this.message = message;
            RawMessage = m;
        }

        /// <summary>
        ///     Gets the player whe sent the message.
        /// </summary>
        /// <value>The player who sent the message.</value>
        public Player Speaker
        {
            get { return speaker; }
        }

        /// <summary>
        ///     Gets the message sent by player
        ///     <summary>
        ///         <value>The message sent by player.</value>
        public string ChatMessage
        {
            get { return message; }
        }

        /// <summary>
        ///     The unparsed message sent from the connection.
        /// </summary>
        public Message RawMessage { get; internal set; }

        /// <summary>
        ///     Gets the origin (room) where the message came from.
        /// </summary>
        /// <value>The origin (room) where the message came from.</value>
        public Room Origin
        {
            get { return origin; }
        }
    }
}