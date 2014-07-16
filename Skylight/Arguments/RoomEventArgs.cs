using System;

namespace Skylight
{
    public class RoomEventArgs : EventArgs
    {
        private readonly Room changedRoom;

        public RoomEventArgs(Room changedRoom)
        {
            this.changedRoom = changedRoom;
        }

        public Room ChangedRoom
        {
            get { return changedRoom; }
        }
    }
}