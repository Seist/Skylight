namespace Skylight
{
    public class RespawnAllPlayers
    {
        private readonly Out _out;

        public RespawnAllPlayers(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Respawns everyone in the room.
        /// </summary>
        public void RespawnAll()
        {
            if (_out.Bot.Name != _out.R.Owner.Name) return;
            _out.SayChatMessage.Say("/respawnall");
        }
    }
}