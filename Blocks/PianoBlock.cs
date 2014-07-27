// ***********************************************************************
// <copyright file="PianoBlock.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Skylight
{
    using Skylight.Blocks;

    /// <summary>
    ///     Class PianoBlock.
    /// </summary>
    public class PianoBlock : Block
    {
        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            C1 = 1;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            Csharp1 = 2;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            D1 = 3;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            Dsharp1 = 4;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            E1 = 5;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            F1 = 6;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            Fsharp1 = 7;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            G1 = 8;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            Gsharp1 = 9;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            A1 = 10;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            Asharp1 = 11;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            B1 = 12;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            C2 = 13;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            Csharp2 = 14;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            D2 = 15;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            Dsharp2 = 16;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            E2 = 17;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            F2 = 18;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            Fsharp2 = 19;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            G2 = 20;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            Gsharp2 = 21;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            A2 = 22;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            Asharp2 = 23;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            B2 = 24;

        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            C3 = 25;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PianoBlock" /> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="key">The key (note).</param>
        public PianoBlock(
            int x,
            int y,
            int key) : base(BlockIds.Action.Music.Piano, x, y, 0)
        {
            this.PianoId = key;
        }

        /// <summary>
        ///     Gets the piano identifier.
        /// </summary>
        /// <value>The piano identifier.</value>
        public int PianoId { get; private set; }
    }
}