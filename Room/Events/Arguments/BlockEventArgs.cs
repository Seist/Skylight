//-----------------------------------------------------------------------
// <copyright file="BlockEventArgs.cs" company="TakoMan02">
//     Copyright TakoMan02
// </copyright>
//-----------------------------------------------------------------------

namespace Skylight
{
    using System;

    using Skylight.Blocks;

    /// <summary>
    ///     Sends the delegate an event based on the content of the block.
    /// </summary>
    public class BlockEventArgs : EventArgs
    {
        /// <summary>
        ///     The block.
        /// </summary>
        private readonly Block placed;

        /// <summary>
        ///     A player object containing who was the author of the block.
        /// </summary>
        private readonly Player placer;


        /// <summary>
        /// Initializes a new instance of the <see cref="BlockEventArgs"/> class. 
        ///     Initializes a new instance of the <see cref="BlockEventArgs"/>. Send a block changed event.
        /// </summary>
        /// <param name="b">
        /// The block
        /// </param>
        /// <param name="origin">
        /// The room where the block originated from.
        /// </param>
        public BlockEventArgs(Block b, Room origin = null)
        {
            Origin = origin ?? Bot.CurrentRoom;
            this.placed = b;
            this.placer = b.Placer;
        }

        /// <summary>
        ///     Gets the room object (with room id).
        /// </summary>
        public Room Origin { get; internal set; }

        /// <summary>
        ///     A placed block.
        /// </summary>
        public Block Placed
        {
            get { return this.placed; }
        }

        /// <summary>
        ///     Gets the player who placed the block (see Placed).
        /// </summary>
        public Player Placer
        {
            get { return this.placer; }
        }
    }
}