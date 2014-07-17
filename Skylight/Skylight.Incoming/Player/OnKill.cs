using PlayerIOClient;
using Skylight.Arguments;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class OnKill
    {
        private In _in;

        public OnKill(In @in)
        {
            _in = @in;
        }
        public event In.PlayerEvent DeathEvent = delegate { };
        public void OnKillPlayer(Message m)
        {
            // Extract data.
            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, _in.Source);

            subject.DeathCount++;

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.OnKill1.DeathEvent(e);
        }
    }
}