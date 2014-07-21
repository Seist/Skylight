using PlayerIOClient;

namespace Skylight
{
    public class Add
    {
        private readonly In _in;

        public Add(In @in)
        {
            _in = @in;
        }

        public event In.PlayerEvent OnAddEvent = delegate { };

        public void OnAdd(Message m)
        {
            // Extract data.
            string name = m.GetString(1);

            int id = m.GetInteger(0),
                smiley = m.GetInteger(2),
                coins = m.GetInteger(8),
                xplevel = m.GetInteger(11);

            double x = m.GetDouble(3),
                y = m.GetDouble(4);

            bool isGod = m.GetBoolean(5),
                isMod = m.GetBoolean(6),
                hasBoost = m.GetBoolean(9),
                isFriend = m.GetBoolean(10),
                hasClub = m.GetBoolean(12); // never used.

            // Update relevant objects.
            var subject = new Player(_in.Source, id, name, smiley, x, y, isGod, isMod, true, coins, hasBoost, isFriend,
                xplevel, hasClub, false, false, false, false, false);

            _in.Source.OnlinePlayers.Add(subject);

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.Add.OnAddEvent(e);
        }
    }
}