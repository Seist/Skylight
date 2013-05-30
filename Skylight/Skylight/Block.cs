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
        private int 
            direction,
            id,
            x,
            y;
            
        private Player 
            placer = new Player();

        private Room 
            r = new Room();
        
        // Constructor
        public Block(
            int id, 
            int x, 
            int y, 
            Room r, 
            Player placer = null, 
            int direction = UP)
        {
            this.X = x;
            this.Y = y;
            this.Id = id;
            this.R = r;
            this.Placer = placer;
            this.Direction = direction;
        }

        // Public instance properties
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

        public int Z
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

        public int X
        {
            get
            {
                return this.x;
            }

            internal set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            internal set
            {
                this.y = value;
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