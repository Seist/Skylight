﻿// <author>TakoMan02</author>
// <summary>Tools.cs is the tools that belong to no specific class or are not related to EE.</summary>
namespace Skylight
{
    using PlayerIOClient;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class Tools
    {
        public static readonly Random
            Ran = new Random();

        internal const string GameID = "everybody-edits-su9rn58o40itdbnw69plyw";
        internal const string GuestEmail = "guest";
        internal const string GuestPassword = "guest";

        internal static readonly Lazy<PlayerIOClient.Client> GuestClient =
            new Lazy<PlayerIOClient.Client>(() => PlayerIO.QuickConnect.SimpleConnect(GameID, GuestEmail, GuestPassword));

        public const string NormalRoom = "Everybodyedits";
        public const string AuthRoom = "Auth";

        public delegate void ProgramEvent(string message);

        public static event ProgramEvent ProgramMessage = delegate { };

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

        public static Player GetCrownHolder(Room r)
        {
            foreach (Player p in r.OnlinePlayers)
            {
                if (p.HasCrown)
                {
                    return p;
                }
            }

            SkylightMessage("Could not find crown holder.");
            return null;
        }

        public static Player GetPlayerById(int id, Room r, bool onlyReturnBots = false)
        {
            foreach (Player p in r.OnlinePlayers)
            {
                if (p.Id == id)
                {
                    // If value is false, return the first match.
                    if (!onlyReturnBots || p.IsBot)
                    {
                        return p;
                    }
                }
            }

            SkylightMessage("Could not find player " + id.ToString() + " in " + r.Name);
            return null;
        }

        public static Player GetPlayerByName(string name, Room r, bool onlyReturnBots = false)
        {
            foreach (Player p in r.OnlinePlayers)
            {
                if (p.Name == name)
                {
                    // If value is false, return the first match.
                    if (!onlyReturnBots || p.IsBot)
                    {
                        return p;
                    }

                }
            }

            SkylightMessage("Could not find player " + name + " in " + r.Name);
            return null;
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

            SkylightMessage("Could not find room \"" + name + "\"");
            return null;
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

        public static void SkylightMessage(string m)
        {
            ProgramMessage(m);
        }

        internal static string Derot(string worldKey)
        {
            char[] array = worldKey.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                int number = array[i];

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

        internal static string ParseURL(string id)
        {
            // If it matches any type of URL and has 13 characters at the end, return the last 13 characters.
            // Supports haphazard copy/pasting.
            if (Regex.IsMatch(id, "[htp:/w.evrybodis.comga]{0,36}[a-zA-Z0-9_-]{13}"))
            {
                string parsedURL = id.Substring(id.ToCharArray().Length - 13, 13);
                return parsedURL;
            }

            return id;
        }



        // Return the correct portal ID based on whether or not the portal is visible or invisible.
        internal static int PortalIdByVisible(bool visible)
        {
            if (visible)
            {
                return BlockIds.Action.Portals.NORMAL;
            }
            else
            {
                return BlockIds.Action.Portals.INVISIBLE;
            }
        }

        // Return the correct coin ID based based on whether or not the block is gate or door
        internal static int CoinIdByGate(bool isGate)
        {
            if (isGate)
            {
                return BlockIds.Action.Gates.COIN;
            }
            else
            {
                return BlockIds.Action.Doors.COIN;
            }
        }
    }
}