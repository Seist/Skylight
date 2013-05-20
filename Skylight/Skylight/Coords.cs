namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Coords
    {
        private int x, y;

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                if (this.x == 0)
                {
                    this.x = value;
                }
            }
        }

        public int Y
        {
            get
            {
                return this.x;
            }

            set
            {
                if (this.y == 0)
                {
                    this.y = value;
                }
            }
        }
    }
}
