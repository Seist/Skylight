// <author>TakoMan02</author>
// <summary>PlayerEventArs.cs provides an in-depth description of the PlayerEvent.</summary> 
namespace Skylight
{
    using System;

    public class PlayerEventArgs : EventArgs
    {
        private Player subject;

        private Room origin;

        public PlayerEventArgs(Player subject, Room origin)
        {
            this.subject = subject;
            this.origin = origin;
        }

        public Player Subject
        {
            get { return this.subject; }
        }

        public Room Origin
        {
            get { return this.origin; }
        }
    }
}
