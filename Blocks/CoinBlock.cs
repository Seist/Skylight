// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoinBlock.cs" company="None">
//   Copyright 2014 (c) . All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using Skylight.Blocks;

    /// <summary>
    ///     Class CoinBlock.
    /// </summary>
    public class CoinBlock : Block
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CoinBlock" /> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="coinsRequired">The coins required to open the gate if applicable.</param>
        /// <param name="isGate">if set to <c>true</c> [is gate].</param>
        public CoinBlock(
            int id,
            int x,
            int y,
            int coinsRequired) : base(id, x, y, 0)
        {
            this.CoinsRequired = coinsRequired;
        }

        /// <summary>
        ///     Gets the coins required to open the gate (or close the door).
        /// </summary>
        /// <value>The coins required.</value>
        public int CoinsRequired { get; private set; }
    }
}