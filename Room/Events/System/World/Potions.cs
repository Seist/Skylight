using PlayerIOClient;

namespace Skylight
{
    public class Potions
    {
        private readonly In _in;

        public Potions(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, potion toggling and saved) for just
        ///     a few examples.
        /// </summary>
        public event In.RoomEvent
            PotionToggleEvent = delegate { };

        public void OnAllowPotions(Message m)
        {
            // Extract data.
            bool potions = m.GetBoolean(0);

            // Update relevant objects.
            _in.Source.PotionsAllowed = potions;

            // Fire the event.
            var e = new RoomEventArgs(_in.Source);

            _in.Source.Pull.Potions.PotionToggleEvent(e);
        }
    }
}