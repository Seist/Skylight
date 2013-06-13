// <author>TakoMan02</author>
// <summary>Smiley.cs is a list of smileys and their IDs.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SmileyIds
    {
        public class Free
        {
            public const int
                SMILE = 0,
                BIGSMILE = 1,
                TONGUE = 2,
                SQUINTHAPPY = 3,
                FRUSTRATED = 4,
                FROWN = 5,
                INDIFFERENT = 6;
        }

        public class Beta
        {
            public const int
                TEAR = 6,
                WINK = 7,
                SUPERFRUSTRATED = 8,
                SHADES = 9,
                DEVIL = 10,
                BEWILDERED = 11;
        }

        public class Mod
        {
            public const int
                SUPERMAN = 16;
        }

        public class Shop
        {
            public const int
                NINJA = 12,
                SANTA = 13,
                WORKER = 14,
                TOPHAT = 15,
                SURPRISED = 16;
        }
    }
}
