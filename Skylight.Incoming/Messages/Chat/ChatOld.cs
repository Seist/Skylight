using System.Collections.Generic;
using PlayerIOClient;
using Skylight.Arguments;

namespace Skylight
{
    public class ChatOld
    {
        private readonly In _in;

        public ChatOld(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     All of the delegates for ChatEvent. Chat events are when the player
        ///     says something, and distinguishes between auto text and system messages
        ///     and much more.
        /// </summary>
        public event In.ChatEvent SayOldEvent = delegate { };

        public void OnSayOld(Message m)
        {
            // Extract data.
            string message = m.GetString(1);

            // Update relevant objects.
            // Player subject = new Player() { Name = name };

            _in.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, null));

            // Fire the event.
            var e = new ChatEventArgs(null, _in.Source);

            _in.Source.Pull.ChatOld.SayOldEvent(e);
        }
    }
}