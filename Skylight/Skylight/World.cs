using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerIOClient;

namespace Skylight
{
    public class World
    {
        public static List<World> Worlds = new List<World>();
        public static Player bot = new Player();
        public List<Block> placedBlocks = new List<Block>();
        public List<Player> onlinePlayers = new List<Player>();
        public List<Player> alreadyJoined = new List<Player>();

        public string name, owner, worldKey, editKey, id;
        public int plays, woots, totalWoots;

        public void joinRoom()
        {
            // Create a connection, push, and pull.
            // Connection can have some errors, so we add it seperately in a try-catch.

            World temp = new World() { id = this.id };

            try
            {
                temp.C = Out.client.Multiplayer.JoinRoom(this.id, new Dictionary<string, string>());

                temp.C.OnMessage += temp.pull.onMessage;

                temp.C.Send("init");

                temp.C.Send("init2");
            }
            catch (PlayerIOError e)
            {
                Out.writeLine("Unable to join room \"" + this.id + "\": " + e.Message, Out.error);

                Out.joinError = true;

                return;
            }

            World.Worlds.Add(temp);

            Out.joinError = false;
        }

        public In pull = new In();
        public Out push = new Out();
        public Connection C;
    }
}
