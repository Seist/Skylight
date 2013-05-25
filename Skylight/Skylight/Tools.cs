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
        public static readonly Random Ran = new Random();

        public static readonly ConsoleColor
            Blank = ConsoleColor.White,
            Progress = ConsoleColor.Yellow,
            Success = ConsoleColor.Green,
            Error = ConsoleColor.Red,
            Info = ConsoleColor.Cyan;

        public static Player GetPlayer(int id, Room r)
        {
            foreach (Player p in r.OnlinePlayers)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }

            foreach (Bot bt in r.ConnectedBots)
            {
                if (bt.Id == id)
                {
                    return bt;
                }
            }

            Console.WriteLine("Could not find player {0} in {1}", id, r.Name);
            return new Player() { Name = "Null" };
        }

        public static Player GetPlayer(string name, Room r)
        {
            foreach (Player p in r.OnlinePlayers)
            {
                if (p.Name == name)
                {
                    return p;
                }
            }

            foreach (Bot bt in r.ConnectedBots)
            {
                if (bt.Name == name)
                {
                    return bt;
                }
            }

            Console.WriteLine("Could not find player {0}.", name);
            return new Player() { Name = "Null" };
        }

        public static Room GetRoom(string name)
        {
            foreach (Room r in Room.JoinedRooms)
            {
                if (r.Name == name)
                {
                    return r;
                }
            }

            Console.WriteLine("Could not find room \"{0}\"", name);
            return new Room();
        }

        public static Player GetCrownHolder(Room r)
        {
            foreach (Player p in r.OnlinePlayers)
            {
                if (p.HasCrown)
                {
                    return p;
                }
            }

            Console.WriteLine("Could not find crown holder.");
            return new Player() { Name = "null" };
        }

        public static List<Player> GetWinners(Room r)
        {
            List<Player> winners = new List<Player>();

            foreach (Player p in r.OnlinePlayers)
            {
                if (p.HasSilverCrown)
                {
                    winners.Add(p);
                }
            }

            return winners;
        }

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