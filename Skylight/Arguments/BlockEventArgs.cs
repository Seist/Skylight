

namespace Skylight
{
    using System;

    public class BlockEventArgs : EventArgs
    {
        private Room origin;

        private Block placed;

        private Player placer;

        public BlockEventArgs(Block b, Room origin = null)
        {
            this.origin = (origin ?? Bot.currentRoom);
            this.placed = b;
            this.placer = b.Placer;
        }

        public Room Origin
        {
            get { return this.Origin; }
        }

        public Block Placed
        {
            get { return this.Placed; }
        }

        public Player Placer
        {
            get { return this.placer; }
        }
    }
}
