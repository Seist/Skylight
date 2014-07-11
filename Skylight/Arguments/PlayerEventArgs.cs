

namespace Skylight
{
    using PlayerIOClient;
    using System;

    public class PlayerEventArgs : EventArgs
    {
        private Player subject;

        private Room origin;

        private Message rawMessage;

        // Overload for PlayerEventArgs that accepts a player id and subsequently converts it into a player object
        public PlayerEventArgs(int player_id, Room origin, Message rawMessage)
        {
            Player subject = Tools.GetPlayerById(player_id, origin);
            this.subject = subject;
            this.origin = origin;
            this.rawMessage = rawMessage;
        }

        public PlayerEventArgs(Player subject, Room origin, Message rawMessage)
        {
            this.subject = subject;
            this.origin = origin;
            this.rawMessage = rawMessage;
        }

        public Player Subject
        {
            get { return this.subject; }
        }

        public Room Origin
        {
            get {return this.Origin;}
        }

        public Message RawMessage
        {
            get { return this.RawMessage; }
        }
    }
}
