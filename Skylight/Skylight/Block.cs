// <author>TakoMan02</author>
// <summary>A description of a singular block in a world.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BlockData;

    public class Block
    {
        public int X
        {
            get;
            internal set;
        }

        public int Y
        {
            get;
            internal set;
        }

        public int Id
        {
            get;
            internal set;
        }

        public int Layer
        {
            get;
            internal set;
        }

        public int Direction
        {
            get;
            internal set;
        }

        public Player Placer
        {
            get;
            internal set;
        }
    }
}