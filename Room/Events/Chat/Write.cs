using System.Collections.Generic;
using PlayerIOClient;

namespace Skylight
{
    public class Write
    {
        private readonly In _in;

        public Write(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     All of the delegates for ChatEvent. Chat events are when the player
        ///     says something, and distinguishes between auto text and system messages
        ///     and much more.
        /// </summary>
        public event In.ChatEvent SystemMessageEvent = delegate { };

        public void OnWrite(Message m)
        {
            // Extract data.
            string message = m.GetString(1);

            // Update relevant objects.
            // Player system = new Player() { Name = prefix };
            _in.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, null));

            // Fire the event.
            var e = new ChatEventArgs(null, _in.Source);

            _in.Source.Pull.Write.SystemMessageEvent(e);
        }
    }
}