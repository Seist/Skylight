using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerIOClient;

namespace Skylight
{
    public class World : In
    {
        public static List<World> Worlds = new List<World>();



        public string name, owner, worldKey, editKey, id;
        public int plays, woots, totalWoots;
        public List<Player> onlinePlayers = new List<Player>();
        public List<Block> placedBlocks = new List<Block>();

        public In pull = new In();
        public Out push = new Out();
        public Connection C;
    }
}
