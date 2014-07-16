//-----------------------------------------------------------------------
// <copyright file="BlockEventArgs.cs" company="TakoMan02">
//     Copyright TakoMan02
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Skylight.Arguments
{
    /// <summary>
    ///     Sends the delegate an event based on the content of the block.
    /// </summary>
    public class BlockEventArgs : EventArgs
    {
        /// <summary>
        ///     The originating room
        /// </summary>
        private readonly Room origin;

        /// <summary>
        ///     The block.
        /// </summary>
        private readonly Block placed;

        /// <summary>
        ///     A player object containing who was the author of the block.
        /// </summary>
        private readonly Player placer;


        /// <summary>
        ///     Initializes a new instance of the <see cref="BlockEventArgs" />. Send a block changed event.
        /// </summary>
        /// <param name="b">The block</param>
        /// <param name="origin">The room where the block originated from.</param>
        public BlockEventArgs(Block b, Room origin = null)
        {
            this.origin = origin ?? Bot.currentRoom;
            placed = b;
            placer = b.Placer;
        }

        public Room Origin
        {
            get { return origin; }
        }

        public Block Placed
        {
            get { return placed; }
        }

        public Player Placer
        {
            get { return placer; }
        }
    }
}