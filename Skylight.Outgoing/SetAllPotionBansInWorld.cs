using System;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class SetAllPotionBansInWorld
    {
        private readonly Out _out;

        public SetAllPotionBansInWorld(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Toggle all potion bans.
        /// </summary>
        /// <param name="value">if set to <c>true</c> then turn on potions.</param>
        public void SetAllPotionBans(bool value)
        {
            try
            {
                if (_out.Bot.Name == _out.R.Owner.Name)
                {
                    _out.C.Send("allowpotions", value);
                }
                else
                {
                    throw new Exception("You are not authorized to allow potions.");
                }
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.SetAllPotionBans before connecting");
            }
        }
    }
}