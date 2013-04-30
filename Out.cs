using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PlayerIOClient;

namespace Skylight
{
    public class Out
    {
        private int blockDelay = 6, speechDelay = 60;
        private bool loginError = false, joinError = false;
        private string GameID = "everybody-edits-su9rn58o40itdbnw69plyw";
        
        public static ConsoleColor blank = ConsoleColor.White, progress = ConsoleColor.Yellow, success = ConsoleColor.Green, error = ConsoleColor.Red, info = ConsoleColor.Cyan;
        public static Client client;

        public void connect(string email, string pass)
        {
            try
            {
                client = PlayerIO.QuickConnect.SimpleConnect(GameID, email, pass);
            }

            catch (PlayerIOError e)
            {
                writeLine("Unable to connect: " + e.Message, error);

                loginError = true;

                return;
            }

            writeLine("Connected successfully.", success);

            loginError = false;
        }

        public void joinRoom(string levelID)
        {
            // Create a connection, push, and pull.
            // Connection can have some errors, so we add it seperately in a try-catch.

            World temp = new World() { id = levelID, pull = new In()};

            try
            {
                temp.C = client.Multiplayer.JoinRoom(levelID, new Dictionary<string, string>());

                temp.C.OnMessage += temp.pull.onMessage;

                temp.C.Send("init");

                temp.C.Send("init2");
            }
            catch (PlayerIOError e)
            {
                writeLine("Unable to join room \"" + levelID + "\": " + e.Message, error);

                joinError = true;

                return;
            }

            World.Worlds.Add(temp);

            joinError = false;
        }

        public static void writeLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);

        }

        public static void write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
        }

        public void build(Block b, World w)
        {
            w.C.Send(w.worldKey, b.x, b.y, b.id, b.layer);
            Thread.Sleep(blockDelay);
        }

        public void say(string s, World w)
        {
            w.C.Send("say", s);
            Thread.Sleep(speechDelay);
        }

        public void move(double[] args, World w)
        {
            w.C.Send("m", args);
        }

        public void changeTitle(string s, World w)
        {
            w.C.Send("name", s);
        }
    }
}
