using System;
using System.Collections.Generic;
using System.Threading;
using Skylight.Blocks;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class Build
    {
        private readonly Out _out;

        private readonly In _in;
        public Build(Out @out, In @in)
        {
            _out = @out;
            _in = @in;
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
        /// <param name="theBlock">The block.</param>
        public void BuildBlock(Block theBlock)
        {
            if (_in.Source.Map[theBlock.X, theBlock.Y, theBlock.Z] == theBlock)
            {
                return;
            }
            try
            {
                if (theBlock is CoinBlock)
                {
                    var c = theBlock as CoinBlock;

                    _out.C.Send(_out.R.RoomKey, c.Z, c.X, c.Y, c.Id, c.CoinsRequired);
                }
                else if (theBlock is PercussionBlock)
                {
                    var p = theBlock as PercussionBlock;

                    _out.C.Send(_out.R.RoomKey, p.Z, p.X, p.Y, p.Id, p.PercussionId);
                }
                else if (theBlock is PianoBlock)
                {
                    var p = theBlock as PianoBlock;

                    _out.C.Send(_out.R.RoomKey, p.Z, p.X, p.Y, p.Id, p.PianoId);
                }
                else if (theBlock is PortalBlock)
                {
                    var p = theBlock as PortalBlock;

                    _out.C.Send(_out.R.RoomKey, p.Z, p.X, p.Y, p.Id, p.Direction, p.PortalId, p.PortalDestination);
                }
                else if (theBlock is RoomPortalBlock)
                {
                    var r = theBlock as RoomPortalBlock;

                    _out.C.Send(_out.R.RoomKey, r.Z, r.X, r.Y, r.Id, r.PortalDestination);
                }
                else if (theBlock is TextBlock)
                {
                    var t = theBlock as TextBlock;
                    _out.C.Send(_out.R.RoomKey, t.Z, t.X, t.Y, t.Id, t.Text);
                }
                else
                {
                    _out.C.Send(_out.R.RoomKey, theBlock.Z, theBlock.X, theBlock.Y, theBlock.Id, theBlock.Direction);
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
                BuildBlock(b); // this line has problems but I fixed it in a weird way.
            }
        }
    }
}