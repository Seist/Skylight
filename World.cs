using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerIOClient;

namespace Skylight
{
    class World
    {
        public static World MainWorld = new World();
        public static List<World> Worlds = new List<World>();

        public string name, owner, worldKey, editKey, id;
        public int plays, woots, totalWoots;
        public List<Player> onlinePlayers = new List<Player>();

        public In pull;
        public Out push;
        public Connection C;
    }
}
