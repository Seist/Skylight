namespace Skylight
{
    using System;

    public class RoomEventArgs : EventArgs
    {
        private Room changedRoom;

        public RoomEventArgs(Room changedRoom = null)
        {
            this.changedRoom = (changedRoom ?? Bot.currentRoom);
        }

        public Room ChangedRoom
        {
            get { return this.changedRoom; }
        }
    }
}
