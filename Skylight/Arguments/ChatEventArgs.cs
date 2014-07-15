

namespace Skylight
{
    using System;
    using System.Linq;

    public class ChatEventArgs : EventArgs
    {
        private Player speaker;

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
            get { return this.Origin; }
        }

        public Player Speaker
        {
            get { return this.Speaker; }
        }
    }
}
