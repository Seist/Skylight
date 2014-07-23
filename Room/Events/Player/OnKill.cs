using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    /// Class On Kill.
    /// </summary>
    public class OnKill
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnKill"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public OnKill(In @in)
        {
            _in = @in;
        }

        /// <summary>
        /// Occurs when the player dies.
        /// </summary>
        public event In.PlayerEvent DeathEvent = delegate { };

        /// <summary>
        /// Called when the player dies.
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnKillPlayer(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, _in.Source);

            subject.DeathCount++;

            // Fire the event.
            var e = new PlayerEventArgs(subject, _in.Source, m);

            _in.Source.Pull.OnKill1.DeathEvent(e);
        }
    }
}