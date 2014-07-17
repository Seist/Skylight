using System;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class SetTitleOfRoom
    {
        private readonly Out _out;

        public SetTitleOfRoom(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Sets the title of the room.
        /// </summary>
        /// <param name="s">The new title.</param>
        public void SetTitle(string s)
        {
            try
            {
                if (s != string.Empty)
                {
                    _out.C.Send("name", s);
                }
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.SetTitle before connecting");
            }
        }
    }
}