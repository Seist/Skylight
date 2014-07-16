using System;
using PlayerIOClient;

namespace Skylight
{
    public class PlayerEventArgs : EventArgs
    {
        private readonly Room _origin;

        private readonly Message _rawMessage;
        private readonly Player _subject;

        public PlayerEventArgs(Player subject, Room origin, Message rawMessage)
        {
            this._subject = subject;
            this._origin = origin;
            this._rawMessage = rawMessage;
        }

        public Player Subject
        {
            get { return _subject; }
        }

        public Room Origin
        {
            get { return _origin; }
        }

        public Message RawMessage
        {
            get { return _rawMessage; }
        }
    }
}