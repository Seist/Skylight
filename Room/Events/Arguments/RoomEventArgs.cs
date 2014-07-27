// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomEventArgs.cs" company="None">
//   Copyright 2014 (c) . All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using System;

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
        public RoomEventArgs(Room changedRoom)
        {
            this.changedRoom = changedRoom;
        }

        /// <summary>
        ///     Gets the changed room.
        /// </summary>
        /// <value>The changed room.</value>
        public Room ChangedRoom
        {
            get { return this.changedRoom; }
        }
    }
}