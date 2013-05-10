using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skylight
{
    class Vector
    {

        public static object[] direction(int degree)
        {
            object[] args = new object[10];

            object[]
            north = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
            northeast = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
            east = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
            southeast = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
            south = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
            southwest = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
            west = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
            northwest = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
            stationary = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 0, 0, 0, 0, false };

            return args;
        }
    }
}
