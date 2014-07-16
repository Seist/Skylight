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
            _direction,
            _id;

        private Player
            _placer;

        private int
            _x,
            _y,
            _z;

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
            get { return _direction; }

            set { _direction = value; }
        }

        public int Id
        {
            get { return _id; }

            internal set { _id = value; }
        }

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

        public int X
        {
            get { return _x; }

            internal set { _x = value; }
        }

        public int Y
        {
            get { return _y; }

            internal set { _y = value; }
        }

        public Player Placer
        {
            get { return _placer; }

            internal set { _placer = value; }
        }
    }
}