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

        public ChatEventArgs(Player speaker, Room origin)
        {
            this._origin = origin;
            this._origin.ChatLog = origin.ChatLog;
            this._speaker = speaker;
        }

        public string Message
        {
            get { return Origin.ChatLog.Last().Key; }
        }

        public Room Origin
        {
            get { return _origin; }
        }

        public Player Speaker
        {
            get { return _speaker; }
        }
    }
}