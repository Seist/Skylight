using System.Collections.Generic;
using PlayerIOClient;
using Skylight.Arguments;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class Autotext
    {
        private readonly In _in;

        public Autotext(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     All of the delegates for ChatEvent. Chat events are when the player
        ///     says something, and distinguishes between auto text and system messages
        ///     and much more.
        /// </summary>
        public event In.ChatEvent
            AutotextEvent = delegate { };

        public void OnAutotext(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            string message = m.GetString(1);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, _in.Source);

            _in.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            var e = new ChatEventArgs(subject, _in.Source);

            _in.Source.Pull.Autotext.AutotextEvent(e);
        }
    }
}