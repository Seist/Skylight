namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class ChatEventArgs : EventArgs
    {
        /// <summary>
        /// The player who sent the message.
        /// </summary>
        private Player speaker;

        /// <summary>
        /// The room where the message originated from.
        /// </summary>
        private Room origin;

        public ChatEventArgs(Player speaker, Room origin)
        {
            this.origin = origin;
            this.origin.ChatLog = origin.ChatLog;
            this.speaker = speaker;
        }

        public string Message
        {
            get { return this.Origin.ChatLog.Last().Key; }
        }

        public Room Origin
        {
            get { return this.origin; }
        }

        public Player Speaker
        {
            get { return this.speaker; }
        }
    }
}
