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
            coords = new Coords(0, 0);
        
        private int 
            direction,
            id;
            
        private Player 
            placer = new Player();

        private Room 
            r = new Room();
        
        // Constructor
        public Block(
            int x, 
            int y, 
            int id, 
            Room r, 
            Player placer = null, 
            int direction = UP)
        {
            this.Coords.X = x;
            this.Coords.Y = y;
            this.Id = id;
            this.R = r;
            this.Placer = placer;
            this.Direction = direction;
        }

        // Public instance properties
        public Coords Coords
        {
            get
            {
                return this.coords;
            }

            set
            {
                this.coords = value;
            }
        }

        public int Direction
        {
            get
            {
                return this.direction;
            }

            internal set
            {
                this.direction = value;
            }
        }
        
        public int Id
        {
            get
            {
                return this.id;
            }

            internal set
            {
                this.id = value;
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