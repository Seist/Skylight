using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skylight
{
    public class Player
    {
        public string name { get; internal set; }
        public double x { get; internal set; }
        public double y { get; internal set; }
        public int id { get; internal set; }
        public int smiley { get; internal set; }
        public int coins { get; internal set; }
        public int xplevel { get; internal set; }
        public bool hasClub { get; internal set; }
        public bool isGod { get; internal set; }
        public bool isMod { get; internal set; }
        public bool hasBoost { get; internal set; }
        public bool isFriend { get; internal set; }
        public bool hasAccess { get; internal set; }
        public bool hasSilverCrown { get; internal set; }
        public bool hasCrown { get; internal set; }
    }
}