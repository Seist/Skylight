namespace Skylight
{
    public class SetCodeForRoom
    {
        private readonly Out _out;

        public SetCodeForRoom(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Sets the edit key for the current room.
        /// </summary>
        /// <param name="newCode">The new code.</param>
        public void SetCode(string newCode)
        {
            if (_out.Bot.Name == _out.R.Owner.Name)
            {
                _out.C.Send("key", newCode);
            }
        }
    }
}