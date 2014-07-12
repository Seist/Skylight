namespace Skylight
{
    using System;

    public class RoomEventArgs : EventArgs
    {
        private Room changedRoom;

        public RoomEventArgs(Room changedRoom)
        {
            this.changedRoom = changedRoom;
        }

        public Room ChangedRoom
        {
            get { return this.changedRoom; }
        }
    }
}
