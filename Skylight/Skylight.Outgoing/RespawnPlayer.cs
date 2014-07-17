namespace Skylight
{
    public class RespawnPlayer
    {
        private readonly Out _out;

        public RespawnPlayer(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Respawns the specified player by their username.
        /// </summary>
        /// <param name="name">The username.</param>
        public void Respawn(string name)
        {
            if (_out.Bot.Name == _out.R.Owner.Name)
            {
                _out.SayChatMessage.Say("/kill " + name);
            }
        }
    }
}