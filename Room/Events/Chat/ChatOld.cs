using System.Collections.Generic;
using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    /// Class Chat Old.
    /// </summary>
    public class ChatOld
    {
        /// <summary>
        /// The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatOld"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public ChatOld(Receiver @in)
        {
            _receiver = @in;
        }

        /// <summary>
        /// All of the delegates for ChatEvent. Chat events are when the player
        /// says something, and distinguishes between auto text and system messages
        /// and much more.
        /// </summary>
        public event Receiver.ChatEvent SayOldEvent = delegate { };

        /// <summary>
        /// Called when premature messages are given to the client.
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnSayOld(Message m)
        {
            // Extract data.
            string message = m.GetString(1);

            // Update relevant objects.

            _receiver.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, null));

            // Fire the event.
            var e = new ChatEventArgs(null, m, _receiver.Source, message);

            _receiver.Source.MainReceiver.ChatOld.SayOldEvent(e);
        }
    }
}
