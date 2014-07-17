using System;
using System.Collections.Generic;
using System.Threading;
using Skylight.Blocks;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class Build
    {
        private Out _out;

        public Build(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Builds the specified block.
        /// </summary>
        /// <param name="id">The id of the block.</param>
        /// <param name="x">The x coordinate of the block (in block units).</param>
        /// <param name="y">The y coordinate of the block (in block units).</param>
        public void BuildBlock(int id, int x, int y)
        {
            BuildBlock(new Block(id, x, y));
        }

        /// <summary>
        ///     Builds the specified block object.
        /// </summary>
        /// <param name="b">The block.</param>
        public void BuildBlock(Block b)
        {
            try
            {
                if (b is CoinBlock)
                {
                    var c = b as CoinBlock;

                    _out.C.Send(_out.R.RoomKey, c.Z, c.X, c.Y, c.Id, c.CoinsRequired);
                }
                else if (b is PercussionBlock)
                {
                    var p = b as PercussionBlock;

                    _out.C.Send(_out.R.RoomKey, p.Z, p.X, p.Y, p.Id, p.PercussionId);
                }
                else if (b is PianoBlock)
                {
                    var p = b as PianoBlock;

                    _out.C.Send(_out.R.RoomKey, p.Z, p.X, p.Y, p.Id, p.PianoId);
                }
                else if (b is PortalBlock)
                {
                    var p = b as PortalBlock;

                    _out.C.Send(_out.R.RoomKey, p.Z, p.X, p.Y, p.Id, p.Direction, p.PortalId, p.PortalDestination);
                }
                else if (b is RoomPortalBlock)
                {
                    var r = b as RoomPortalBlock;

                    _out.C.Send(_out.R.RoomKey, r.Z, r.X, r.Y, r.Id, r.PortalDestination);
                }
                else if (b is TextBlock)
                {
                    var t = b as TextBlock;
                    _out.C.Send(_out.R.RoomKey, t.Z, t.X, t.Y, t.Id, t.Text);
                }
                else
                {
                    _out.C.Send(_out.R.RoomKey, b.Z, b.X, b.Y, b.Id, b.Direction);
                }


                Thread.Sleep(_out.Bot.BlockDelay);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Build before connecting");
            }
        }

        /// <summary>
        ///     Builds the specified block list.
        /// </summary>
        /// <param name="blockList">The block list.</param>
        public void BuildBlock(List<Block> blockList)
        {
            var tempList = new List<Block>();
            tempList.AddRange(blockList);

            foreach (var b in tempList)
            {
                BuildBlock(b);
            }
        }
    }
}