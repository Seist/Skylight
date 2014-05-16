using System.Drawing;
using System.Windows.Media.Imaging;

namespace MasterBot.Movement
{
    //import SynchronizedSprite.*;
    //import flash.display.*;
    //import flash.geom.*;

    public class SynchronizedSprite : SynchronizedObject
    {
        protected Rectangle rect;
        protected Bitmap bmd;
        protected int size;
        protected int frames;

        public SynchronizedSprite(Bitmap param1, int param2 = 0)
        {
            this.size = param2;
            width = param2;
            height = this.size;
            return;
        }// end function

        public virtual void frame(int param1)
        {
            this.rect.X = param1 * this.size;
            return;
        }// end function

        public virtual int frame()
        {
            return this.rect.X / this.size;
        }// end function

        public bool hitTest(int param1, int param2)
        {
            return param1 >= x && param2 >= y && param1 <= x + this.size && param2 <= y + this.size;
        }// end function

        public virtual void draw(BitmapSource param1, int param2, int param3)
        {
            //param1.CopyPixels(this.bmd, this.rect, new Point(x + param2, y + param3));
            return;
        }// end function

    }
}
