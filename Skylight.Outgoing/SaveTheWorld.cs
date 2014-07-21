using System;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class SaveTheWorld
    {
        private readonly Out _out;

        public SaveTheWorld(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Saves the world.
        /// </summary>
        public void Save()
        {
            try
            {
                if (_out.Bot.Name != _out.R.Owner.Name) return;
                _out.C.Send("save");
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Save before connecting");
            }
        }
    }
}