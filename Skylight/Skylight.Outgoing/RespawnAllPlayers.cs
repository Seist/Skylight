namespace Skylight
{
    public class RespawnAllPlayers
    {
        private Out _out;

        public RespawnAllPlayers(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Respawns everyone in the room.
        /// </summary>
        public void RespawnAll()
        {
            if (_out.Bot.Name == _out.R.Owner.Name)
            {
                _out.SayChatMessage.Say("/respawnall");
            }
        }
    }
}