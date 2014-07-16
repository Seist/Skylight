
// <copyright file="Block.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>

namespace Skylight.Blocks
{
    /// <summary>
    /// Class Block.
    /// </summary>
    public class Block
    {
        /// <summary>
        /// The directions of the block.
        /// </summary>
        public const int
            RIGHT = 1,
            DOWN = 2,
            LEFT = 3,
            UP = 0,
            FOREGROUNDLAYER = 0,
            BACKGROUNDLAYER = 1;


        /// <summary>
        /// The direction of the blocks and the id.
        /// </summary>
        private int
            _direction, _id;

        /// <summary>
        /// The _placer
        /// </summary>
        private Player
            _placer;

        /// <summary>
        /// The _x
        /// </summary>
        private int
            _x, _y, _z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Block"/> class.
        /// </summary>
        /// <param name="id">The id of the block.</param>
        /// <param name="x">The x coord.</param>
        /// <param name="y">The y coord.</param>
        /// <param name="z">The z coord.</param>
        /// <param name="direction">The direction.</param>
        public Block(
            int id,
            int x,
            int y,
            int z = 0,
            int direction = UP)
        {
            X = x;
            Y = y;
            Z = z;
            Id = id;
            Direction = direction;
        }


        /// <summary>
        /// Gets a value indicating whether this instance is solid.
        /// </summary>
        /// <value><c>true</c> if this instance is solid; otherwise, <c>false</c>.</value>
        public bool IsSolid
        {
            get { return (Id >= 9 && Id <= 97) || (Id >= 122 && Id <= 217); }
        }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        public int Direction
        {
            get { return _direction; }

            set { _direction = value; }
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get { return _id; }

            internal set { _id = value; }
        }

        /// <summary>
        /// Gets the z coordinate (background or foreground)
        /// </summary>
        /// <value>The z.</value>
        public int Z
        {
            get
            {
                if (Id == 0)
                {
                    return _z;
                }


                if (Id >= 500)
                {
                    return 1;
                }
                return 0;
            }

            internal set
            {
                if (value == 0 || value == 1)
                {
                    _z = value;
                }
            }
        }

        /// <summary>
        /// Gets the x coordinate
        /// </summary>
        /// <value>The x.</value>
        public int X
        {
            get { return _x; }

            internal set { _x = value; }
        }

        /// <summary>
        /// Gets the y coordinate
        /// </summary>
        /// <value>The y.</value>
        public int Y
        {
            get { return _y; }

            internal set { _y = value; }
        }

        /// <summary>
        /// Gets the placer (the Player who placed the block).
        /// </summary>
        /// <value>The placer.</value>
        public Player Placer
        {
            get { return _placer; }

            internal set { _placer = value; }
        }
    }
}