using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skylight
{
    public class Vector
    {
        private static object[] direction(int degree)
        {
            if (degree > 360 || degree < 0)
                return null;

            object[] 
                args = new object[10],
                north = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                northeast = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                east = new object[10] { World.bot.x, World.bot.y, 0.981319527991571, 0, 1, 2, 1, 0, 0, false },
                southeast = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                south = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                southwest = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                west = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                northwest = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 2, 0, -1, 0, false },
                stationary = new object[10] { World.bot.x, World.bot.y, 0, 0, 0, 0, 0, 0, 0, false };

            switch (degree)
            {
                case 90:
                    args = north;
                    break;

                case 180:
                    args = west;
                    break;

                case 270:
                    args = south;
                    break;

                case 0:
                    args = east;
                    break;
                case 360:
                    args = east;
                    break;
                default:
                    break;
            }


            return args;
        }
    }
}
