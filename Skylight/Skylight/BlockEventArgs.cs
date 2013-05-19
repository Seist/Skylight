// <author>TakoMan02</author>
// <summary>BlockEventArgs.cs provides an in-depth description of the BlockEvent.</summary>
namespace Skylight
{
    using System;

    public class BlockEventArgs : EventArgs
    {
        private Block placed;

        private Player placer;

        private World origin;

        public BlockEventArgs(Block b, World origin)
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

        public World Origin
        {
            get { return this.origin; }
        }
    }
}
