using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Skylight
{
    public static class Tools
    {
        // Public tools.

        public static readonly Random ran = new Random();

        // Extensions.

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ran.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void Draw<T>(this IList<T> list, World w) where T : Block
        {
            foreach (Block b in list)
            {
                w.push.build(b);
            }
        }

        // Getters

        public static Player getCrownHolder(World w)
        {
            foreach (Player p in w.onlinePlayers)
            {
                if (p.hasCrown)
                {
                    return p;
                }
            }

            return new Player() { name = "null" };
        }

        // Internal tools.

        internal static string rot13(string worldKey)
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

        internal static string parseURL(string id)
        {
            // If it matches any type of URL and has 13 characters at the end, return the last 13 characters.
            // Supports haphazard copy/pasting.
            if (Regex.IsMatch(id, "[htp:/w.evrybodis.comga]{0,36}[a-zA-Z0-9_-]{13}"))
            {
                return id.Substring(id.ToCharArray().Length - 13, 12);
            }
            // I don't even know what you put in.
            return id;
        }

    }
}
