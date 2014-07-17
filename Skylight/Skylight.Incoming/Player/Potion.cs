using PlayerIOClient;
using Skylight.Arguments;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class Potion
    {
        private In _in;

        public Potion(In @in)
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
            PotionEvent = delegate { };

        public void OnP(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                potionId = m.GetInteger(1);

            var isActive = m.GetBoolean(2);

            // Update relevant objects
            var subject = Tools.GetPlayerById(id, _in.Source);

            if (isActive)
            {
                subject.PotionEffects.Add(potionId);
            }
            else
            {
                subject.PotionEffects.Remove(potionId);
            }

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.Potion.PotionEvent(e);
        }
    }
}