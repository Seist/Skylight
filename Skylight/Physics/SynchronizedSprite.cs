using System.Drawing;
using System.Windows.Media.Imaging;


namespace Skylight.Physics
{
    public class SynchronizedSprite : SynchronizedObject
    {
        protected Rectangle rect;
        protected Bitmap bmd;
        protected int size;
        protected int frames;

        public SynchronizedSprite(Bitmap param1, int param2 = 0)
        {
            this.size = param2;
            this.width = param2;
            this.height = this.size;
            return;
        }

        public virtual void frame(int param1)
        {
            this.rect.X = param1 * this.size;
            return;
        }

        public virtual int frame()
        {
            return this.rect.X / this.size;
        }

        public bool hitTest(int param1, int param2)
        {
            return param1 >= x && param2 >= y && param1 <= x + this.size && param2 <= y + this.size;
        }

        public virtual void draw(BitmapSource param1, int param2, int param3)
        {
            //param1.CopyPixels(this.bmd, this.rect, new Point(x + param2, y + param3));
            return;
        }

    }
}
