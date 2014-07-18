using System;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class InputCodeForRoom
    {
        private readonly Out _out;

        public InputCodeForRoom(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Inputs the edit key.
        /// </summary>
        /// <param name="editKey">The edit key.</param>
        public void InputCode(string editKey)
        {
            if (String.IsNullOrWhiteSpace(editKey)) {throw new ArgumentException("editKey cannot be empty or null.");}

            try
            {
                _out.C.Send("access", editKey);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.InputCode before connecting");
            }
        }
    }
}