namespace Skylight
{
    public class HoldDownArrow
    {
        private Out _out;

        public HoldDownArrow(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Holds the down arrow key, causing the bot to move downward.
        /// </summary>
        /// <param name="startX">The start x coordinate.</param>
        /// <param name="startY">The start y coordinate.</param>
        public void HoldDown(double startX, double startY)
        {
            var holdArgs = new object[11];

            holdArgs[0] = startX;
            holdArgs[1] = startY;
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = 0;
            holdArgs[5] = 2;
            holdArgs[6] = 0;
            holdArgs[7] = 1;
            holdArgs[8] = 4;
            holdArgs[9] = false;
            holdArgs[10] = false;

            _out.Move(holdArgs);
        }
    }
}