using System;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class Clear
    {
        private readonly Out _out;

        public Clear(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Clears the entire world.
        /// </summary>
        public void ClearWorld()
        {
            try
            {
                _out.C.Send("clear");
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Clear before connecting");
            }
        }
    }
}