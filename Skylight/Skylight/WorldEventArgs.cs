namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RoomEventArgs : EventArgs
    {        
        private Room changedRoom;

        public RoomEventArgs(Room changedRoom)
        {
            this.changedRoom = changedRoom;
        }

        public Room ChangedRoom
        {
            get
            {
                return this.changedRoom;
            }
        }
    }
}
