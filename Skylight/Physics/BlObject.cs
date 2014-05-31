using System;
using System.Drawing;

namespace Skylight.Physics
{
    //import flash.display.*;

    public class BlObject : object
    {
        public double x = 0;
        public double y = 0;
        public int width = 1;
        public int height = 1;
        public bool moving = false;
        //public var hitmap:BlTilemap;

        public BlObject()
        {
            return;
        }// end function

        public virtual void update()
        {
            return;
        }// end function

        public void draw(Bitmap param1, int param2, int param3)
        {
           // param1.SetPixel((int)(this.x + param2), (int)(this.y + param3), new Color(16777215));
            return;
        }// end function

        public void enterFrame()
        {
            return;
        }// end function

        public virtual void tick()
        {
            this.update();
            return;
        }// end function

        public void exitFrame()
        {
            return;
        }// end function

    }
}
