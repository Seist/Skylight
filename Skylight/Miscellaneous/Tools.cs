// <author>TakoMan02</author>
// <summary>Tools.cs is the tools that belong to no specific class or are not related to EE.</summary>

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PlayerIOClient;

namespace Skylight
{
    public static class Tools
    {
        public delegate void ProgramEvent(string message);

        internal const string GameID = "everybody-edits-su9rn58o40itdbnw69plyw";
        internal const string GuestEmail = "guest";
        internal const string GuestPassword = "guest";

        // Compiler seems to choke on this line, saying that Lazy isn't supported in library.

        public const string NormalRoom = "Everybodyedits";
        public const string AuthRoom = "Auth";

        public static readonly Random
            Ran = new Random();

        internal static readonly Lazy<Client> GuestClient =
            new Lazy<Client>(() => PlayerIO.QuickConnect.SimpleConnect(GameID, GuestEmail, GuestPassword));

        public static event ProgramEvent ProgramMessage = delegate { };

        public static List<Player> GetWinners(Room r)
        {
            var winners = new List<Player>();

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
                    if (!onlyReturnBots)
                    {
                        return p;
                    }

                    // Otherwise, only return a bot.
                    if (p.IsBot)
                    {
                        return p;
                    }
                }
            }

            SkylightMessage("Could not find player " + id + " in " + r.Name);
            return null;
        }

        public static Player GetPlayerByName(string name, Room r, bool onlyReturnBots = false)
        {
            foreach (Player p in r.OnlinePlayers)
            {
                if (p.Name == name)
                {
                    // If value is false, return the first match.
                    if (!onlyReturnBots)
                    {
                        return p;
                    }

                    // Otherwise, only return a bot.
                    if (p.IsBot)
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

        internal static void SkylightMessage(string m)
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

                array[i] = (char) number;
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

        internal static List<Block> DeserializeInit(Message m, uint start, Room r)
        {
            var list = new List<Block>();
            try
            {
                //// FULL CREDIT TO BASS5098 FOR THE FOLLOWING CODE
                //// I wrote it in my own way in C# but Bass5098 made the original.
                //// Without it I would not know how to do this.
                //// https://github.com/kevin-brown/ee-level-editor/blob/master/LevelEditor/WorldConverter.vb
                //// Lines 438-507
                //// Praise him. (this is mainly due to my laziness)

                // First, fill the entire map with blank blocks (so that you don't get null exceptions).
                for (int x = 0; x < 700; x++)
                {
                    for (int y = 0; y < 400; y++)
                    {
                        for (int z = 0; z < 2; z++)
                        {
                            r.Map[x, y, z] = new Block(0, x, y, z);
                        }
                    }
                }

                // And now replace empty blocks with the ones that already exist.
                uint messageIndex = start;

                // Iterate through each internal set of messages.
                while (messageIndex < m.Count)
                {
                    // If it is a string, exit.
                    if (m[messageIndex] is string)
                    {
                        break;
                    }

                    // The ID is first.
                    int blockId = m.GetInteger(messageIndex);
                    messageIndex++;

                    // Then the z.
                    int z = m.GetInteger(messageIndex);
                    messageIndex++;

                    // Then the list of all X coordinates of given block
                    byte[] xa = m.GetByteArray(messageIndex);
                    messageIndex++;

                    // Then the list of all Y coordinates of given block
                    byte[] ya = m.GetByteArray(messageIndex);
                    messageIndex++;

                    int rotation = 0, note = 0, type = 0, portalId = 0, destination = 0, coins = 0;
                    bool isVisible = false, isGate = false;
                    string roomDestination = "";

                    // Get the variables that are unique to the current block
                    if (blockId == BlockIds.Action.Portals.NORMAL ||
                        blockId == BlockIds.Action.Portals.INVISIBLE)
                    {
                        rotation = m.GetInteger(messageIndex);
                        messageIndex++;

                        portalId = m.GetInteger(messageIndex);
                        messageIndex++;

                        destination = m.GetInteger(messageIndex);
                        messageIndex++;

                        isVisible = true;
                        if (blockId == BlockIds.Action.Portals.INVISIBLE)
                        {
                            isVisible = false;
                        }
                    }
                    else if (blockId == BlockIds.Action.Portals.WORLD)
                    {
                        roomDestination = m.GetString(messageIndex);
                        messageIndex++;
                    }
                    else if (blockId == BlockIds.Action.Doors.COIN ||
                             blockId == BlockIds.Action.Gates.COIN)
                    {
                        coins = m.GetInteger(messageIndex);
                        messageIndex++;

                        isGate = false;
                        if (blockId == BlockIds.Action.Gates.COIN)
                        {
                            isGate = true;
                        }
                    }
                    else if (blockId == BlockIds.Action.Music.PERCUSSION)
                    {
                        type = m.GetInteger(messageIndex);
                        messageIndex++;
                    }
                    else if (blockId == BlockIds.Action.Music.PIANO)
                    {
                        note = m.GetInteger(messageIndex);
                        messageIndex++;
                    }
                    else if (blockId == BlockIds.Decorative.SciFi2013.BLUEBEND ||
                             blockId == BlockIds.Decorative.SciFi2013.BLUESTRAIGHT ||
                             blockId == BlockIds.Decorative.SciFi2013.GREENBEND ||
                             blockId == BlockIds.Decorative.SciFi2013.GREENSTRAIGHT ||
                             blockId == BlockIds.Decorative.SciFi2013.ORANGEBEND ||
                             blockId == BlockIds.Decorative.SciFi2013.ORANGESTRAIGHT ||
                             blockId == BlockIds.Action.Hazards.SPIKE)
                    {
                        rotation = m.GetInteger(messageIndex);
                        messageIndex++;
                    }


                    // Some variables to simplify things.
                    int x = 0, y = 0;

                    for (int pos = 0; pos < ya.Length; pos += 2)
                    {
                        // Extract the X and Y positions from the array.
                        x = (xa[pos]*256) + xa[pos + 1];
                        y = (ya[pos]*256) + ya[pos + 1];

                        // Ascertain the block from the ID.
                        // Add block accordingly.
                        if (blockId == BlockIds.Action.Portals.NORMAL ||
                            blockId == BlockIds.Action.Portals.INVISIBLE)
                        {
                            list.Add(new PortalBlock(
                                x,
                                y,
                                rotation,
                                portalId,
                                destination,
                                isVisible));
                        }
                        else if (blockId == BlockIds.Action.Portals.WORLD)
                        {
                            list.Add(new RoomPortalBlock(
                                x,
                                y,
                                roomDestination));
                        }
                        else if (blockId == BlockIds.Action.Doors.COIN ||
                                 blockId == BlockIds.Action.Gates.COIN)
                        {
                            list.Add(new CoinBlock(
                                x,
                                y,
                                coins,
                                isGate));
                        }
                        else if (blockId == BlockIds.Action.Music.PERCUSSION)
                        {
                            list.Add(new PercussionBlock(
                                x,
                                y,
                                type));
                        }
                        else if (blockId == BlockIds.Action.Music.PIANO)
                        {
                            list.Add(new PianoBlock(
                                x,
                                y,
                                note));
                        }
                        else if (blockId == BlockIds.Decorative.SciFi2013.BLUEBEND ||
                                 blockId == BlockIds.Decorative.SciFi2013.BLUESTRAIGHT ||
                                 blockId == BlockIds.Decorative.SciFi2013.GREENBEND ||
                                 blockId == BlockIds.Decorative.SciFi2013.GREENSTRAIGHT ||
                                 blockId == BlockIds.Decorative.SciFi2013.ORANGEBEND ||
                                 blockId == BlockIds.Decorative.SciFi2013.ORANGESTRAIGHT ||
                                 blockId == BlockIds.Action.Hazards.SPIKE)
                        {
                            list.Add(new Block(
                                blockId,
                                x,
                                y,
                                0,
                                rotation));
                        }
                        else
                        {
                            list.Add(new Block(
                                blockId,
                                x,
                                y,
                                z));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                SkylightMessage("Error loading existing blocks:\n" + e);
            }

            SkylightMessage("Done loading blocks");
            return list;
        }

        // Return the correct portal ID based on whether or not the portal is visible or invisible.
        internal static int PortalIdByVisible(bool visible)
        {
            if (visible)
            {
                return BlockIds.Action.Portals.NORMAL;
            }
            return BlockIds.Action.Portals.INVISIBLE;
        }

        // Return the correct coin ID based based on whether or not the block is gate or door
        internal static int CoinIdByGate(bool isGate)
        {
            if (isGate)
            {
                return BlockIds.Action.Gates.COIN;
            }
            return BlockIds.Action.Doors.COIN;
        }
    }
}