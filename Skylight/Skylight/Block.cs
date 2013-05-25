// <author>TakoMan02</author>
// <summary>A description of a singular block in a world.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BlockData;

    public class Block
    {
        public static readonly int
            RIGHT = 0,
            DOWN = 1,
            LEFT = 2,
            UP = 3;

        // Fields
        private int id, direction;
        private Player placer;
        private Room r;
        private Coords coords;

        // Properties
        public Coords Coords
        {
            get
            {
                return this.coords;
            }

            set
            {
                if (this.coords == null)
                {
                    this.coords = value;
                }
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (this.id == 0)
                {
                    this.id = value;
                }
            }
        }

        public int Layer
        {
            get
            {
                if (this.Id >= 500)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                if (this.direction == 0)
                {
                    this.direction = value;
                }
            }
        }

        public Player Placer
        {
            get
            {
                return this.placer;
            }

            internal set
            {
                this.placer = value;
            }
        }

        public Room W
        {
            get
            {
                return this.r;
            }

            internal set
            {
                this.r = value;
            }
        }
    }
}