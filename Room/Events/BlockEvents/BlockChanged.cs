using System.Collections.Generic;
using PlayerIOClient;
using Skylight.Blocks;

namespace Skylight
{
    using System;

    /// <summary>
    /// Class Block Changed.
    /// </summary>
    public class BlockChanged
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// These IDs do not have an associated Player id when sent.
        /// </summary>
        private readonly List<int> _specialBlockIds = new List<int>
        {
            BlockIds.Action.Switches.Switch,
            BlockIds.Action.Tools.Trophy,
            BlockIds.Action.Doors.Time,
            BlockIds.Action.Gates.Time,
            BlockIds.Action.Doors.Switch,
            BlockIds.Action.Gates.Switch,
            BlockIds.Action.Doors.Zombie,
            BlockIds.Action.Gates.Zombie,
            BlockIds.Blocks.Secrets.NONSOLID,
            BlockIds.Action.Tools.Spawn,
            BlockIds.Action.Cake.CAKE,
            BlockIds.Action.Tools.Checkpoint,
            BlockIds.Action.Hazards.Fire
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="BlockChanged"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public BlockChanged(In @in)
        {
            _in = @in;
        }
        /// <summary>
        /// All of the delegates for BlockEvent. These fire when events occur
        /// (such as when a block was added or updated).
        /// </summary>
        public event In.BlockEvent
            NormalBlockEvent = delegate { };
        /// <summary>
        /// Called when a block is changed.
        /// </summary>
        /// <param name="m">The message.</param>
        public void OnBlock(Message m)
        {
            // Extract data.
            int z = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2),
                blockId = m.GetInteger(3);
            // Update relevant objects.
            var b = new Block(blockId, x, y, z);
            int playerId = -1;
            try
            {
                playerId = m.GetInteger(4);
                Player subject = Tools.GetPlayer(playerId, _in.Source);
                b.Placer = subject;
            }
            catch
            {
                b.Placer = this._in.Source.Owner;
            }

            _in.Source.Map[x, y, z] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, m, _in.Source);

            _in.Source.Pull.BlockChanged.NormalBlockEvent(e);
        }
    }
}
