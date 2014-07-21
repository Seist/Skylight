using System.Collections.Generic;
using PlayerIOClient;



namespace Skylight
{
    public class Chat
    {
        private readonly In _in;

        public Chat(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     All of the delegates for ChatEvent. Chat events are when the player
        ///     says something, and distinguishes between auto text and system messages
        ///     and much more.
        /// </summary>
        public event In.ChatEvent NormalChatEvent = delegate { };

        public void OnSay(Message m)
        {
            // Extract data.
            var id = m.GetInteger(0);

            var message = m.GetString(1);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, _in.Source);

            _in.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            var e = new ChatEventArgs(subject, _in.Source);

            _in.Source.Pull.Chat.NormalChatEvent(e);
        }
    }
}