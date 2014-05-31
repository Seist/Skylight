

namespace Skylight
{
    using System;

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
            get
            {
                return (this.Id >= 9 && this.Id <= 97) || (this.Id >= 122 && this.Id <= 217);
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
                
                
                if (this.Id == 0)
                {
                    return this.z;
                }

                
                if (this.Id >= 500)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            internal set
            {
                if (value == 0 && value == 1)
                {
                    this.z = value;
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
    }
}