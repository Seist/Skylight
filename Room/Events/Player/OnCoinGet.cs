using System;
using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    /// Class On Coin Get.
    /// </summary>
    public class OnCoinGet
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCoinGet"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public OnCoinGet(In @in)
        {
            _in = @in;
        }

        /// <summary>
        /// All events that concern the player. This includes many messages that the player
        /// gets from the world (such as server information and leveling up). Mostly these
        /// events are shown from the server directly to the user in the form of a dialog
        /// box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event In.PlayerEvent
            CoinCollectedEvent = delegate { };

        /// <summary>
        /// Called when a player recieves a coin (by touching it) or loosing
        /// coins because they were removed from the level.
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnCoin(Message m)
        {
            try
            {
                // Extract data.
                int id = m.GetInteger(0),
                    totalCoins = m.GetInteger(1);

                // Update relevant objects.
                Player subject = Tools.GetPlayer(id, _in.Source);

                subject.Coins = totalCoins;

                // Fire the event.
                var e = new PlayerEventArgs(subject, _in.Source, m);

                _in.Source.Pull.OnCoinGet.CoinCollectedEvent(e);
            }
            catch (Exception ex)
            {
                Tools.SkylightMessage(ex.ToString());
            }
        }
    }
}