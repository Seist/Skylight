namespace Skylight
{
    public partial class ResetWorld
    {
        private readonly Out _out;

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