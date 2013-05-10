using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skylight
{
    public class Player
    {
        public string name = null;
        public double x = 0, y = 0;
        public int id = -1, smiley = 0, coins, xplevel;
        public bool hasClub, isGod, isMod, hasBoost, isFriend, hasAccess;
    }
}