// <author>TakoMan02</author>
// <summary>ChatEventArgs.cs provides an in-depth description of the ChatEvent.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
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

        public Player Speaker
        {
            get { return this.speaker; }
        }

        public Room Origin
        {
            get { return this.origin; }
        }

        public string Message
        {
            get { return this.Origin.ChatLog.Last().Key; }
        }
    }
}
