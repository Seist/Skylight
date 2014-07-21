//-----------------------------------------------------------------------
// <copyright file="BlockEventArgs.cs" company="TakoMan02">
//     Copyright TakoMan02
// </copyright>
//-----------------------------------------------------------------------

using System;
using Skylight.Blocks;

namespace Skylight
{
    /// <summary>
    ///     Sends the delegate an event based on the content of the block.
    /// </summary>
    public class BlockEventArgs : EventArgs
    {
        /// <summary>
        ///     The block.
        /// </summary>
        private readonly Block _placed;

        /// <summary>
        ///     A player object containing who was the author of the block.
        /// </summary>
        private readonly Player _placer;


        /// <summary>
        ///     Initializes a new instance of the <see cref="BlockEventArgs" />. Send a block changed event.
        /// </summary>
        /// <param name="b">The block</param>
        /// <param name="origin">The room where the block originated from.</param>
        public BlockEventArgs(Block b, Room origin = null)
        {
            Origin = origin ?? Bot.CurrentRoom;
            _placed = b;
            _placer = b.Placer;
        }

        /// <summary>
        ///     The room object (with room id).
        /// </summary>
        public Room Origin { get; private set; }

        /// <summary>
        ///     A placed block.
        /// </summary>
        public Block Placed
        {
            get { return _placed; }
        }

        /// <summary>
        ///     The player who placed the block (see Placed).
        /// </summary>
        public Player Placer
        {
            get { return _placer; }
        }
    }
}