// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomEventArgs.cs" company="None">
//   Copyright 2014 (c) . All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    ///     Class RoomEventArgs.
    /// </summary>
    public class RoomEventArgs : EventArgs
    {
        /// <summary>
        ///     The changed room
        /// </summary>
        private readonly Room changedRoom;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RoomEventArgs" /> class.
        /// </summary>
        /// <param name="changedRoom">The changed room.</param>
        internal RoomEventArgs(Room changedRoom, Message m = null)
        {
            this.changedRoom = changedRoom;
            RawMessage = m;
        }

        /// <summary>
        ///     Gets the changed room.
        /// </summary>
        /// <value>The changed room.</value>
        public Room ChangedRoom
        {
            get { return changedRoom; }
        }

        /// <summary>
        ///     The unparsed message sent from the connection.
        /// </summary>
        public Message RawMessage { get; internal set; }
    }
}