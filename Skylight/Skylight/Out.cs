using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PlayerIOClient;
using System.Runtime.CompilerServices;


namespace Skylight
{
    public class Out
    {
        public World w
        {
            get
            {
                foreach (World w in World.Worlds)
                {
                    if (w.push == this)
                        return w;
                }
                return new World() { name = "null" };
            }
        }

        private const string GameID = "everybody-edits-su9rn58o40itdbnw69plyw";
        public static ConsoleColor blank = ConsoleColor.White, progress = ConsoleColor.Yellow, success = ConsoleColor.Green, error = ConsoleColor.Red, info = ConsoleColor.Cyan;
        public static Client client;

        public int blockDelay = 6, speechDelay = 60;
        internal static bool loginError = false, joinError = false;

        public static void connect(string email, string pass)
        {
            try
            {
                client = PlayerIO.QuickConnect.SimpleConnect(GameID, email, pass);
            }
            catch (PlayerIOError e)
            {
                Console.ForegroundColor = error;
                Console.WriteLine("Unable to connect: {0}", e.Message);

                loginError = true;

                return;
            }

            Console.ForegroundColor = success;
            Console.WriteLine("Connected successfully.");

            loginError = false;
        }

        public void build(Block b)
        {
            w.C.Send(w.worldKey, b.x, b.y, b.id, b.layer);
            Thread.Sleep(blockDelay);
        }

        public void say(string s)
        {
            w.C.Send("say", s);
            Thread.Sleep(speechDelay);
        }

        public void move(object[] args)
        {
            w.C.Send("m", args);
        }

        public void changeTitle(string s)
        {
            w.C.Send("name", s);
        }
    }
}
