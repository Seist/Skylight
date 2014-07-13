

namespace Skylight
{

	// <remarks>
	// Use the block object for adding blocks to your world. The block object is returned from
	// Skylight when a new block is added.
	// </remarks>
	// <param name="id">The id of the block (block id).</param>
	// <param name="x">The x coordinate of the block.</param>
	// <param name="y">The y coordinate of the block.</param>
	// <param name="z">The z coordinate of the block. Also known as the layer (background or foreground).
	// Default is foreground (0).</param>
	// <param name="direction">The direction of the block (if applicable). Default is normal.</param>
	// <param name="placer">If applicable, a Player object will be returned for the author of that block.</param>
    public class Block
    {
        
        public const int
            RIGHT = 1,
            DOWN  = 2,
            LEFT  = 3,
            UP    = 0,
            FOREGROUNDLAYER = 0,
            BACKGROUNDLAYER = 1;

        
        private int 
            direction,
            id,
            x,
            y,
            z;
            
        private Player 
            placer;
        
        public Block(
            int id,
            int x,
            int y,
            int z = 0,
            int direction = UP)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Id = id;
            this.Direction = direction;
        }

        
        public bool IsSolid
        {
            get { return (this.Id >= 9 && this.Id <= 97) || (this.Id >= 122 && this.Id <= 217); }
        }

        public int Direction
        {
            get;set;
        }

        public int Id
        {
            get;internal set;
        }

        public int Z
        {
            get
            {
                if (this.Id >= 500) { return 1; }
                if (this.Id == 0) { return this.z; } else { return 0; }
            }

            internal set
            {
                if (value == 0 || value == 1){this.z = value;}
            }
        }

        public int X {get;internal set;}

        public int Y{get;internal set;}

        public Player Placer{get;internal set;}
    }
}