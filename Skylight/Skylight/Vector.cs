using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skylight
{
    public class Vector
    {
        public static object[] direction(int degree)
        {
            if (degree > 360 || degree < 0)
                return null;

            object[] 
                args = new object[10],
                north = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                northeast = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                east = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, -1, 0, -1, 0, false },
                southeast = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                south = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                southwest = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                west = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                northwest = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                stationary = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 0, 0, 0, 0, false };

            if (degree == 90)
                args = east;

            return args;
        }
    }
}
