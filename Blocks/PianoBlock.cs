// ***********************************************************************
// <copyright file="PianoBlock.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Skylight
{
    /// <summary>
    ///     Class PianoBlock.
    /// </summary>
    public class PianoBlock : Block
    {
        /// <summary>
        ///     The piano notes.
        /// </summary>
        public const int
            C1 = 1,
            Csharp1 = 2,
            D1 = 3,
            Dsharp1 = 4,
            E1 = 5,
            F1 = 6,
            Fsharp1 = 7,
            G1 = 8,
            Gsharp1 = 9,
            A1 = 10,
            Asharp1 = 11,
            B1 = 12,
            C2 = 13,
            Csharp2 = 14,
            D2 = 15,
            Dsharp2 = 16,
            E2 = 17,
            F2 = 18,
            Fsharp2 = 19,
            G2 = 20,
            Gsharp2 = 21,
            A2 = 22,
            Asharp2 = 23,
            B2 = 24,
            C3 = 25;

        /// <summary>
        ///     The piano block identifier
        /// </summary>
        private int _pianoId = -1;

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
            PianoId = key;
        }

        /// <summary>
        ///     Gets the piano identifier.
        /// </summary>
        /// <value>The piano identifier.</value>
        public int PianoId
        {
            get { return _pianoId; }

            internal set { _pianoId = value; }
        }
    }
}