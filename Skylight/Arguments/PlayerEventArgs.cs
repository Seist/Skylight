using System;
using PlayerIOClient;

namespace Skylight.Arguments
{
    /// <summary>
    /// This class sets the properties about a player such as who the player is (username), their most
    /// recent message and where they are (the room that they are in).
    /// </summary>
    public class PlayerEventArgs : EventArgs
    {
        /// <summary>
        /// The main constructor method.
        /// </summary>
        /// <param name="subject">The player</param>
        /// <param name="origin">The room where the player is originating in.</param>
        /// <param name="rawMessage">The raw, unparsed message from the server (concerning player).</param>
        public PlayerEventArgs(Player subject, Room origin, Message rawMessage)
        {
            Subject = subject;
            Origin = origin;
            RawMessage = rawMessage;
        }

        public Player Subject { get; private set; }

        public Room Origin { get; private set; }

        public Message RawMessage { get; private set; }
    }
}