// ***********************************************************************
// <copyright file="CoinBlock.cs" company="">
//     Copyright 2014 (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************



namespace Skylight
{
    /// <summary>
    ///     Class CoinBlock.
    /// </summary>
    public class CoinBlock : Block
    {
        /// <summary>
        ///     The coins required to open the coinblock door.
        /// </summary>
        private int _coinsRequired = -1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CoinBlock" /> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="coinsRequired">The coins required to open the gate if applicable.</param>
        /// <param name="isGate">if set to <c>true</c> [is gate].</param>
        public CoinBlock(
            int x,
            int y,
            int coinsRequired,
            bool isGate) : base(Tools.CoinIdByGate(isGate), x, y, 0)
        {
            CoinsRequired = coinsRequired;
            IsGate = isGate;
        }

        /// <summary>
        ///     Gets a value indicating whether this instance is a gate.
        /// </summary>
        /// <value><c>true</c> if this instance is gate; otherwise, <c>false</c>.</value>
        public bool IsGate { get; internal set; }

        /// <summary>
        ///     Gets the coins required to open the gate (or close the door).
        /// </summary>
        /// <value>The coins required.</value>
        public int CoinsRequired
        {
            get { return _coinsRequired; }

            internal set { _coinsRequired = value; }
        }
    }
}