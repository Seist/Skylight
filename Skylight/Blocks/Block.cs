namespace Skylight
{

	/// <summary>
    /// Use the block object for adding blocks to your world. The block object is returned from
    ///  Skylight when a new block is added.
	/// </summary>
    /// 
    public class Block
    {
        
        public const int
            RIGHT = 0,
            DOWN  = 1,
            LEFT  = 2,
            UP    = 3,
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
<<<<<<< HEAD
                if (value == 0 || value == 1){this.z = value;}
=======
                if (value == 0 && value == 1)
                {
                    this.z = value;
                }
>>>>>>> parent of d8a8469... Fixed BID:0 layering bug; fixed ticking defaults
            }
        }

        public int X {get;internal set;}

        public int Y{get;internal set;}

        public Player Placer{get;internal set;}
    }
}