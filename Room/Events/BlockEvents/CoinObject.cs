// ***********************************************************************
// <copyright file="CoinObject.cs" company="None">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Skylight
{
    using PlayerIOClient;

    /// <summary>
    /// Class CoinObject.
    /// </summary>
    public class CoinObject
    {
        /// <summary>
        /// The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoinObject"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public CoinObject(Receiver @in)
        {
            this._receiver = @in;
        }

        /// <summary>
        /// Occurs when [coin block event].
        /// </summary>
        public event Receiver.BlockEvent CoinBlockEvent = delegate { };

        /// <summary>
        /// Called when [add coin door or gate].
        /// </summary>
        /// <param name="m">The m.</param>
        public void OnAddCoinDoorOrGate(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                coinsRequired = m.GetInteger(3);

            // Update relevant objects.
            // TODO Update this and Coin implementation in lieu of blue and regrouping
            //var b = new CoinBlock(x, y, coinsRequired) { IsGate = id == BlockIds.Action.Coins.GoldGate };

            //this._receiver.Source.Map[x][y][0] = b;

            // Fire the event.
            //var e = new BlockEventArgs(b, m, this._receiver.Source);

            //this._receiver.Source.Receiver.CoinObject.CoinBlockEvent(e);
        }
    }
}