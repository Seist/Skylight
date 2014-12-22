// ***********************************************************************
// <copyright file="CoinObject.cs" company="None">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    ///     Class CoinObject.
    /// </summary>
    public class CoinObject
    {
        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CoinObject" /> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public CoinObject(In @in)
        {
            _in = @in;
        }

        /// <summary>
        ///     Occurs when [coin block event].
        /// </summary>
        public event In.BlockEvent CoinBlockEvent = delegate { };

        /// <summary>
        ///     Called when [add coin door or gate].
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
            var b = new CoinBlock(x, y, coinsRequired, false) {IsGate = id == BlockIds.Action.Gates.Coin};

            _in.Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, m, _in.Source);

            _in.Source.Pull.CoinObject.CoinBlockEvent(e);
        }
    }
}