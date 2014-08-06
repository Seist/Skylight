// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayerEventArgs.cs" company="None">
//   
// </copyright>
// <summary>
//   This class sets the properties about a player such as who the player is (username), their most
//   recent message and where they are (the room that they are in).
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using System;

    using PlayerIOClient;

    /// <summary>
    ///     This class sets the properties about a player such as who the player is (username), their most
    ///     recent message and where they are (the room that they are in).
    /// </summary>
    public class PlayerEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerEventArgs"/> class. 
        ///     The main constructor method.
        /// </summary>
        /// <param name="subject">
        /// The player
        /// </param>
        /// <param name="origin">
        /// The room where the player is originating in.
        /// </param>
        /// <param name="rawMessage">
        /// The raw, unparsed message from the server (concerning player).
        /// </param>
        internal PlayerEventArgs(Player subject, Room origin, Message rawMessage)
        {
            this.Subject = subject;
            this.Origin = origin;
            this.RawMessage = rawMessage;
        }

        /// <summary>
        ///     Gets the username of the player.
        /// </summary>
        public Player Subject { get; internal set; }

        /// <summary>
        ///     Gets the room that the player is originating in.
        /// </summary>
        public Room Origin { get; internal set; }

        /// <summary>
        ///     Gets the raw, unparsed message from the server.
        /// </summary>
        public Message RawMessage { get; internal set; }
    }
}