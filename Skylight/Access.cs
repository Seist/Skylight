using PlayerIOClient;
using Skylight.Arguments;

namespace Skylight
{
    public class Access
    {
        private In _in;

        public Access(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     All events that concern the player. This includes many messages that the player
        ///     gets from the world (such as server information and leveling up). Mostly these
        ///     events are shown from the server directly to the user in the form of a dialog
        ///     box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event In.PlayerEvent
            GainAccessEvent = delegate { };

        public void OnAccess(Message m)
        {
            // Nothing to extract from message.
            // Update relevant objects.
            _in.Bot.HasAccess = true;

            // Fire the event.
            var e = new PlayerEventArgs(_in.Bot, _in.Source, m);

            _in.Source.Pull.Access.GainAccessEvent(e);
        }
    }
}