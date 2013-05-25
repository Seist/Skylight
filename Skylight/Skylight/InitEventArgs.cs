// <author>TakoMan02</author>
// <summary>InitEventArgs.cs provides an in-depth description of the InitEvent.</summary>
namespace Skylight
{
    using System;

    public class InitEventArgs : EventArgs
    {
        private Room joinedRoom;

        public InitEventArgs(Room joinedRoom)
        {
            this.joinedRoom = joinedRoom;
        }

        public Room JoinedRoom
        {
            get { return this.joinedRoom; }
        }
    }
}
