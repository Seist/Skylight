using System;

namespace Skylight
{
    public class RoomEventArgs : EventArgs
    {
        private readonly Room _changedRoom;

        public RoomEventArgs(Room changedRoom)
        {
            this._changedRoom = changedRoom;
        }

        public Room ChangedRoom
        {
            get { return _changedRoom; }
        }
    }
}