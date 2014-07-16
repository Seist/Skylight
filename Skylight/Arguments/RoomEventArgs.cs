using System;

namespace Skylight.Arguments
{
    public class RoomEventArgs : EventArgs
    {
        private readonly Room _changedRoom;

        public RoomEventArgs(Room changedRoom)
        {
            _changedRoom = changedRoom;
        }

        public Room ChangedRoom
        {
            get { return _changedRoom; }
        }
    }
}