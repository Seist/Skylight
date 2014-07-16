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
        private readonly Room _origin;

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
            this._origin = origin ?? Bot.currentRoom;
            _placed = b;
            _placer = b.Placer;
        }

        public Room Origin
        {
            get { return _origin; }
        }

        public Block Placed
        {
            get { return _placed; }
        }

        public Player Placer
        {
            get { return _placer; }
        }
    }
}