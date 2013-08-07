using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Skylight
{
    //import SynchronizedSprite.*;
    //import flash.display.*;
    //import flash.geom.*;

    public class SynchronizedSprite : SynchronizedObject
    {
        internal Rectangle rect;
        internal int size;

        public SynchronizedSprite(int param2 = 0)
        {
            this.size = param2;
            width = param2;
            height = this.size;
            return;
        }

        public double frame
        {
            get
            {
                return this.rect.X / this.size;
            }
            set
            {
                this.rect.X = (int)(value * this.size);
            }
        }

        public bool hitTest(int param1, int param2)
        {
            return (param1 >= x && param2 >= y && param1 <= x + 16 && param2 <= y + 16);
        }
    }
}
