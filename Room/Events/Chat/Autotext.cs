using System.Collections.Generic;
using PlayerIOClient;

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
            var id = m.GetInteger(0);

            var message = m.GetInteger(1);

            var autoTextConversions = new Dictionary<int, string>
            {
                {0, "Left."},
                {1, "Hi."},
                {2, "Goodbye."},
                {3, "Help me!"},
                {4, "Thank you."},
                {5, "Follow me."},
                {6, "Stop!"},
                {7, "Yes."},
                {8, "No."},
                {9, "Right."}
            };

            // Update relevant objects.
            var subject = Tools.GetPlayer(id, _in.Source);

            _in.Source.ChatLog.Add(new KeyValuePair<string, Player>(autoTextConversions[message], subject));

            // Fire the event.
            var e = new ChatEventArgs(subject, _in.Source);

            _in.Source.Pull.Autotext.AutotextEvent(e);
        }
    }
}