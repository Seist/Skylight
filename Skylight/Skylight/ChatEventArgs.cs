// <author>TakoMan02</author>
// <summary>ChatEventArgs.cs provides an in-depth description of the ChatEvent.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ChatEventArgs : EventArgs
    {
        private Player speaker;
        
        private World origin;

        public ChatEventArgs(Player speaker, World origin)
        {
            this.origin = origin;
            this.origin.ChatLog = origin.ChatLog;
            this.speaker = speaker;
        }

        public Player Speaker
        {
            get { return this.speaker; }
        }

        public World Origin
        {
            get { return this.origin; }
        }

        public string Message
        {
            get { return this.origin.ChatLog[this.origin.ChatLog.Count - 1]; }
        }

        public List<string> ChatLog
        {
            get { return this.origin.ChatLog; }
        }
    }
}
