namespace Skylight
{
    using System;

    /// <summary>
    ///     The class that handles all chat-based messages from the server
    ///     including ones sent to the user through system.
    /// </summary>
    public class ChatEventArgs : EventArgs
    {
        /// <summary>
        ///     The player who sent the message.
        /// </summary>
        public readonly Player speaker;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatEventArgs"/> class. 
        ///     The main method where the chat messages are sent. This method sets the properties in
        ///     this class to the speaker and origin of the message, where it is handed off to a delegate
        ///     later.
        /// </summary>
        /// <param name="speaker">
        /// The player who said the message.
        /// </param>
        /// <param name="origin">
        /// The room where the message originated.
        /// </param>
        public ChatEventArgs(Player speaker, Room origin)
        {
            this.Origin = origin;
            if (this.Origin != null)
            {
                this.Origin.ChatLog = origin.ChatLog;
            }

            this.speaker = speaker;
        }

        /// <summary>
        ///     The origin (room) where the message came from.
        /// </summary>
        public Room Origin { get;  set; }
    }
}