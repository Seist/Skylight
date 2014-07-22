// ***********************************************************************
// ***********************************************************************
// <copyright file="PercussionBlock.cs" company="">
//     Copyright 2014 (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Skylight.Blocks;

namespace Skylight
{
    /// <summary>
    ///     Class PercussionBlock.
    /// </summary>
    public class PercussionBlock : Block
    {
        /// <summary>
        ///     The types of notes that can be played.
        /// </summary>
        public const int
            Base1 = 0;

        /// <summary>
        ///     The types of notes that can be played.
        /// </summary>
        public const int
            Base2 = 1;

        /// <summary>
        ///     The types of notes that can be played.
        /// </summary>
        public const int
            Snare1 = 2;

        /// <summary>
        ///     The types of notes that can be played.
        /// </summary>
        public const int
            Snare2 = 3;

        /// <summary>
        ///     The types of notes that can be played.
        /// </summary>
        public const int
            Cymbal1 = 4;

        /// <summary>
        ///     The types of notes that can be played.
        /// </summary>
        public const int
            Cymbal2 = 5;

        /// <summary>
        ///     The types of notes that can be played.
        /// </summary>
        public const int
            Cymbal3 = 6;

        /// <summary>
        ///     The types of notes that can be played.
        /// </summary>
        public const int
            Clap = 7;

        /// <summary>
        ///     The types of notes that can be played.
        /// </summary>
        public const int
            Cymbal4 = 8;

        /// <summary>
        ///     The types of notes that can be played.
        /// </summary>
        public const int
            Maraca = 9;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PercussionBlock" /> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="percussionId">The percussion identifier.</param>
        public PercussionBlock(
            int x,
            int y,
            int percussionId) : base(BlockIds.Action.Music.Percussion, x, y, 0)
        {
            PercussionId = percussionId;
        }

        /// <summary>
        ///     Gets the percussion identifier.
        /// </summary>
        /// <value>The percussion identifier.</value>
        public int PercussionId { get; internal set; }
    }
}