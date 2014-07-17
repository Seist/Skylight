using PlayerIOClient;
using Skylight.Arguments;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class Witch
    {
        private In _in;

        public Witch(In @in)
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
            WitchEvent = delegate { };

        public void OnGiveWitch(Message m)
        {
            // Extract data
            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, _in.Source);

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.Witch.WitchEvent(e);
        }
    }
}