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
        // Public const ints
        public const int
            RIGHT = 0,
            DOWN  = 1,
            LEFT  = 2,
            UP    = 3;

        // Private instance fields
        private Coords 
            coords;
        
        private int 
            direction,
            id;
            
        private Player 
            placer;

        private Room 
            r;

        // Public isntance properties
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

        public Room R
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