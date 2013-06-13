// <author>TakoMan02</author>
// <summary>PlayerEventArs.cs provides an in-depth description of the PlayerEvent.</summary> 
namespace Skylight
{
    using System;
    using PlayerIOClient;

    public class PlayerEventArgs : EventArgs
    {
        private Player subject;

        private Room origin;

        private Message rawMessage;

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
            get { return this.origin; }
        }

        public Message RawMessage
        {
            get { return this.rawMessage; }
        }
    }
}
