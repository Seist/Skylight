namespace Skylight
{
    public class HoldLeftArrow
    {
        private Out _out;

        public HoldLeftArrow(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Holds the left arrow key.
        /// </summary>
        /// <param name="startX">The start x coordinate.</param>
        /// <param name="startY">The start y coordinate.</param>
        public void HoldLeft(double startX, double startY)
        {
            var holdArgs = new object[11];

            holdArgs[0] = startX;
            holdArgs[1] = startY;
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = -1;
            holdArgs[5] = 2;
            holdArgs[6] = -1;
            holdArgs[7] = 0;
            holdArgs[8] = 4;
            holdArgs[9] = false;
            holdArgs[10] = false;

            _out.ReleaseArrowKey.Move(holdArgs);
        }
    }
}