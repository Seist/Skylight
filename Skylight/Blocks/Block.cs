namespace Skylight
{
    public class Block
    {
        public const int
            RIGHT = 1,
            DOWN = 2,
            LEFT = 3,
            UP = 0,
            FOREGROUNDLAYER = 0,
            BACKGROUNDLAYER = 1;


        private int
            direction,
            id;

        private Player
            placer;

        private int
            x,
            y,
            z;

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


        public bool IsSolid
        {
            get { return (Id >= 9 && Id <= 97) || (Id >= 122 && Id <= 217); }
        }

        public int Direction
        {
            get { return direction; }

            set { direction = value; }
        }

        public int Id
        {
            get { return id; }

            internal set { id = value; }
        }

        public int Z
        {
            get
            {
                if (Id == 0)
                {
                    return z;
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
                    z = value;
                }
            }
        }

        public int X
        {
            get { return x; }

            internal set { x = value; }
        }

        public int Y
        {
            get { return y; }

            internal set { y = value; }
        }

        public Player Placer
        {
            get { return placer; }

            internal set { placer = value; }
        }
    }
}