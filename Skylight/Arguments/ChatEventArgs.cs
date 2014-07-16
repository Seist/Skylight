using System;
using System.Linq;

namespace Skylight
{
    public class ChatEventArgs : EventArgs
    {
        /// <summary>
        ///     The room where the message originated from.
        /// </summary>
        private readonly Room origin;

        /// <summary>
        ///     The player who sent the message.
        /// </summary>
        private readonly Player speaker;

        public ChatEventArgs(Player speaker, Room origin)
        {
            this.origin = origin;
            this.origin.ChatLog = origin.ChatLog;
            this.speaker = speaker;
        }

        public string Message
        {
            get { return Origin.ChatLog.Last().Key; }
        }

        public Room Origin
        {
            get { return origin; }
        }

        public Player Speaker
        {
            get { return speaker; }
        }
    }
}