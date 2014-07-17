namespace Skylight
{
    public class HoldSpace
    {
        private readonly Out _out;

        public HoldSpace(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Tells the bot to jump from the specified coordinates.
        /// </summary>
        /// <param name="startX">The start x coordinate.</param>
        /// <param name="startY">The start y coordinate.</param>
        public void Jump(double startX, double startY)
        {
            var holdArgs = new object[11];

            holdArgs[0] = startX;
            holdArgs[1] = startY;
            holdArgs[2] = 0;
            holdArgs[3] = -52;
            holdArgs[4] = 0;
            holdArgs[5] = 2;
            holdArgs[6] = 0;
            holdArgs[7] = 0;
            holdArgs[8] = 4;
            holdArgs[9] = false;
            holdArgs[10] = true;

            _out.ReleaseArrowKey.Move(holdArgs);
        }
    }
}