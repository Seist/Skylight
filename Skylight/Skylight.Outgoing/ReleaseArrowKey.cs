using System;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class ReleaseArrowKey
    {
        private Out _out;

        public ReleaseArrowKey(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Moves the specified bot.
        /// </summary>
        /// <param name="args">The raw message where to move.</param>
        public void Move(object[] args)
        {
            try
            {
                _out.C.Send("m", args);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Move before connecting");
            }
        }

        /// <summary>
        ///     Releases the arrow key.
        /// </summary>
        /// <param name="startX">The start x.</param>
        /// <param name="startY">The start y.</param>
        public void Release(double startX, double startY)
        {
            var holdArgs = new object[11];
            holdArgs[0] = startX;
            holdArgs[1] = startY;
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = 0;
            holdArgs[5] = 2;
            holdArgs[6] = 0;
            holdArgs[7] = 0;
            holdArgs[8] = 4;
            holdArgs[9] = false;
            holdArgs[10] = false;

            Move(holdArgs);
        }
    }
}