// <author>TakoMan02</author>
// <summary>BlockEventArgs.cs provides an in-depth description of the BlockEvent.</summary>
namespace Skylight
{
    using System;

    public class BlockEventArgs : EventArgs
    {
        private Room origin;

        private Block placed;

        private Player placer;
        
        public BlockEventArgs(Block b, Room origin)
        {
            this.origin = origin;
            this.placed = b;
            this.placer = b.Placer;
        }

        public Room Origin
        {
            get { return this.origin; }
        }
        
        public Block Placed
        {
            get { return this.placed; }
        }

        public Player Placer
        {
            get { return this.placer; }
        }
    }
}
