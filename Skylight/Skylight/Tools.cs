// <author>TakoMan02</author>
// <summary>Tools.cs is the tools that belong to no specific class or are not related to EE.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using PlayerIOClient;

    public static class Tools
    {
        private static Client client;
        private static bool loginError = false, joinError = false;
        
        public static Client Client
        {
            get { return client; }
            internal set { client = value; }
        }

        public static bool LoginError
        {
            get { return loginError; }
            internal set { loginError = value; }
        }

        public static bool JoinError
        {
            get { return joinError; }
            internal set { joinError = value; }
        }

        public static readonly Random Ran = new Random();

        public static readonly ConsoleColor
            Blank = ConsoleColor.White,
            Progress = ConsoleColor.Yellow,
            Success = ConsoleColor.Green,
            Error = ConsoleColor.Red,
            Info = ConsoleColor.Cyan;

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Ran.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        // TODO: Create holdLeft, holdRight, holdUp, holdDown, holdSpace, etc methods.
        public static object[] HoldArgs = new object[10];

        public static void Connect(string email, string pass)
        {
            try
            {
                Tools.Client = PlayerIO.QuickConnect.SimpleConnect(Tools.GameID, email, pass);
            }
            catch (PlayerIOError e)
            {
                Console.ForegroundColor = Tools.Error;
                Console.WriteLine("Unable to connect: {0}", e.Message);

                LoginError = true;

                return;
            }

            Console.ForegroundColor = Tools.Success;
            Console.WriteLine("Connected successfully.");

            LoginError = false;
        }

        // Getters
        public static Player GetPlayer(int id, World w)
        {
            foreach (Player p in w.OnlinePlayers)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }

            return new Player() { Name = "Null" };
        }

        public static Player GetPlayer(string name, World w)
        {
            foreach (Player p in w.OnlinePlayers)
            {
                if (p.Name == name)
                {
                    return p;
                }
            }

            return new Player() { Name = "Null" };
        }

        public static Player GetCrownHolder(World w)
        {
            foreach (Player p in w.OnlinePlayers)
            {
                if (p.HasCrown)
                {
                    return p;
                }
            }

            return new Player() { Name = "null" };
        }

        public static List<Player> GetWinners(World w)
        {
            List<Player> winners = new List<Player>();

            foreach (Player p in w.OnlinePlayers)
            {
                if (p.HasSilverCrown)
                {
                    winners.Add(p);
                }
            }

            return winners;
        }
        
        internal static string ParseURL(string id)
        {
            // If it matches any type of URL and has 13 characters at the end, return the last 13 characters.
            // Supports haphazard copy/pasting.
            if (Regex.IsMatch(id, "[htp:/w.evrybodis.comga]{0,36}[a-zA-Z0-9_-]{13}"))
            {
                string parsedURL = id.Substring(id.ToCharArray().Length - 13, 13);
                return parsedURL;
            }

            // I don't even know what you put in.
            return null;
        }

        internal static readonly string GameID = "everybody-edits-su9rn58o40itdbnw69plyw";
        
        internal static string Derot(string worldKey)
        {
            char[] array = worldKey.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                int number = (int)array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }

                array[i] = (char)number;
            }

            return new string(array);
        }
    }
}