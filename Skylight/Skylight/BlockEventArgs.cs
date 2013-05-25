// <author>TakoMan02</author>
// <summary>BlockEventArgs.cs provides an in-depth description of the BlockEvent.</summary>
namespace Skylight
{
    using System;

    public class BlockEventArgs : EventArgs
    {
        private Block placed;
        private Player placer;
        private Room origin;

        public BlockEventArgs(Block b, Room origin)
        {
            this.origin = origin;
            this.placed = b;
            this.placer = b.Placer;
        }

        public Block Placed
        {
            get { return this.placed; }
        }

        public Player Placer
        {
            get { return this.placer; }
        }

        public Room Origin
        {
            get { return this.origin; }
        }
    }
}
