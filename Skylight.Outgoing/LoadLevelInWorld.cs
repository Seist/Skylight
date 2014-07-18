using System;
using System.Drawing;

namespace Skylight
{
    public class LoadLevelInWorld
    {
        private readonly Out _out;

        public LoadLevelInWorld(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Resets the level to its state when it was last saved.
        /// </summary>
        public void Loadlevel()
        {
            if (_out.Bot.Name == _out.R.Owner.Name)
            {
                _out.SayChatMessage.Say("/loadlevel");
            }
            else
            {
                throw new Exception("You are not authorized to load the level.");
            }
        }
    }
}