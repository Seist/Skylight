using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PlayerIOClient;


namespace Skylight
{
    public class Out
    {
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
        private static string GameID = "everybody-edits-su9rn58o40itdbnw69plyw";
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
                writeLine("Unable to connect: " + e.Message, error);

                loginError = true;

                return;
            }

            writeLine("Connected successfully.", success);

            loginError = false;
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

        public void move(object[] args, World w)
        {
            w.C.Send("m", args);
        }

        public void changeTitle(string s, World w)
        {
            w.C.Send("name", s);
        }
    }
}
