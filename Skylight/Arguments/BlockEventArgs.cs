//-----------------------------------------------------------------------
// <copyright file="BlockEventArgs.cs" company="TakoMan02">
//     Copyright TakoMan02
// </copyright>
//-----------------------------------------------------------------------

namespace Skylight
{
    using System;

    /// <summary>
    /// Sends the delegate an event based on the content of the block.
    /// </summary>
    public class BlockEventArgs : EventArgs
    {
        /// <summary>
        /// The originating room
        /// </summary>
        private Room origin;

        /// <summary>
        /// The block.
        /// </summary>
        private Block placed;

        /// <summary>
        /// A player object containing who was the author of the block.
        /// </summary>
        private Player placer;


        /// <summary>
        /// Initializes a new instance of the <see cref="BlockEventArgs" />. Send a block changed event.
        /// </summary>
        /// <param name="b">The block</param>
        /// <param name="origin">The room where the block originated from.</param>
        public BlockEventArgs(Block b, Room origin = null)
        {
            this.origin = origin ?? Bot.currentRoom;
            this.placed = b;
            this.placer = b.Placer;
        }

        public Room Origin
        {
            get { return this.origin; }
        }
        
        public Block Placed
        {
            get { return this.placed; }
        }

        public Player Placer
        {
            get { return this.placer; }
        }
    }
}
