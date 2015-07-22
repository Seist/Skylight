// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Block.cs" company="None">
//   Copyright (c) . All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight.Blocks
{
    /// <summary>
    ///     Class Block.
    /// </summary>
    public class Block : ItemId
    {
        /// <summary>
        ///     The directions of the block.
        /// </summary>
        public const int
            Right = 1,
            Down = 2,
            Left = 3,
            Up = 0,
            Foregroundlayer = 0,
            Backgroundlayer = 1;

        /// <summary>
        ///     The z
        /// </summary>
        private int z;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Block" /> class.
        /// </summary>
        /// <param name="id">The id of the block.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="z">The z coordinate.</param>
        /// <param name="direction">The direction.</param>
        public Block(
            int id,
            int x,
            int y,
            int z = 0,
            int direction = Up)
        {
            X = x;
            Y = y;
            Z = z;
            Id = id;
            Direction = direction;
        }

        /// <summary>
        ///     Gets the y coordinate.
        /// </summary>
        /// <value>The y coordinate.</value>
        public int Y { get; private set; }

        /// <summary>
        ///     Gets the x coordinate.
        /// </summary>
        /// <value>The x coordinate.</value>
        public int X { get; private set; }

        /// <summary>
        ///     Gets the direction.
        /// </summary>
        /// <value>The direction.</value>
        public int Direction { get; private set; }

        /// <summary>
        ///     Gets the identifier from the block.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; private set; }

        /// <summary>
        ///     Gets the z coordinate (background or foreground)
        /// </summary>
        /// <value>The z coordinate.</value>
        public int Z
        {
            // Since ID:0 can exist on both layers, it needs to be handled differently.
            get
            {
                if (Id == 0)
                {
                    return z;
                }

                return Id >= 500 ? 1 : 0;
            }

            private set
            {
                if (value == 0 || value == 1)
                {
                    z = value;
                }
            }
        }

        /// <summary>
        ///     Gets the placer (the Player who placed the block).
        /// </summary>
        /// <value>The placer.</value>
        public Player Placer { get; internal set; }
    }
}