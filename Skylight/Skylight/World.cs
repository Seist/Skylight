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

        private static Player _bot = new Player();
        public static Player bot { get { return _bot; } internal set { _bot = value; } }

        private List<Block> _placedBlocks = new List<Block>();
        public List<Block> placedBlocks { get { return _placedBlocks; } internal set { _placedBlocks = value; } }
        
        private List<Player> _onlinePlayers = new List<Player>();
        public List<Player> onlinePlayers { get { return _onlinePlayers; } internal set { _onlinePlayers = value; } }

        private List<String> _chatLog = new List<String>();
        public List<String> chatLog { get { return _chatLog; } internal set { _chatLog = value; } }
        
        
        public string name { get; internal set { this.push.changeTitle(value); } }
        public string owner { get; internal set; }
        public string worldKey { get; internal set; }
        public string editKey { get; internal set; }
        public string id;

        public int plays { get; internal set; }
        public int woots { get; internal set; }
        public int totalWoots { get; internal set; }

        public bool potionsAllowed { get; internal set; }

        public void join()
        {
            // Create a connection to the level.
            // Connection can have some errors, so we add it seperately in a try-catch.

            World temp = this;

            try
            {
                temp.C = Out.client.Multiplayer.JoinRoom(this.id, new Dictionary<string, string>());

                temp.C.OnMessage += temp.pull.onMessage;

                temp.C.Send("init");

                temp.C.Send("init2");
            }
            catch (PlayerIOError e)
            {
                Console.ForegroundColor = Out.error;
                Console.WriteLine("Unable to join room \"{0}\": {1}", this.id, e.Message);

                Out.joinError = true;

                return;
            }

            Out.joinError = false;
        }

        public In pull = new In();
        public Out push = new Out();
        public Connection C;
    }
}
