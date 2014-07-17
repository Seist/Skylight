namespace Skylight
{
    public class ResetWorld
    {
        private Out _out;

        public ResetWorld(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Clears the entire world.
        /// </summary>
        public void Reset()
        {
            if (_out.Bot.Name == _out.R.Owner.Name)
            {
                _out.SayChatMessage.Say("/reset");
            }
        }
    }
}