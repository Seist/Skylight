using System;
using PlayerIOClient;

namespace Skylight
{
    public class PlayerEventArgs : EventArgs
    {
        private readonly Room origin;

        private readonly Message rawMessage;
        private readonly Player subject;

        public PlayerEventArgs(Player subject, Room origin, Message rawMessage)
        {
            this.subject = subject;
            this.origin = origin;
            this.rawMessage = rawMessage;
        }

        public Player Subject
        {
            get { return subject; }
        }

        public Room Origin
        {
            get { return origin; }
        }

        public Message RawMessage
        {
            get { return rawMessage; }
        }
    }
}