// <author>TakoMan02</author>
// <summary>Tools.cs is the tools that belong to no specific class or are not related to EE.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading;
    using PlayerIOClient;

    public static class Tools
    {
        public static readonly Random
            Ran = new Random();

        internal const string GameID = "everybody-edits-su9rn58o40itdbnw69plyw";

        public delegate void ProgramEvent(string message);

        public static event ProgramEvent ProgramMessage = delegate { };

        public static List<Block> ConvertMessageToBlockList(Message m, uint start, Room r)
        {
            List<Block> list = new List<Block>();
            try
            {
                //// FULL CREDIT TO BASS5098 FOR THE FOLLOWING CODE
                //// I wrote it in my own way in C# but Bass5098 made the original.
                //// https://github.com/kevin-brown/ee-level-editor/blob/master/LevelEditor/WorldConverter.vb
                //// Lines 438-507
                //// Praise him. (this is mainly due to my laziness)

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

                    // Some variables to simplify things.
                    int x = 0, y = 0;

                    for (int pos = 0; pos < ya.Length; pos += 2)
                    {
                        x = (xa[pos] * 256) + xa[pos + 1];
                        y = (ya[pos] * 256) + ya[pos + 1];

                        if (blockId == BlockIds.Action.Portals.NORMAL ||
                            blockId == BlockIds.Action.Portals.INVISIBLE)
                        {
                            int direction = m.GetInteger(messageIndex);
                            messageIndex++;
                            
                            int portalId = m.GetInteger(messageIndex);
                            messageIndex++;
                            
                            int destination = m.GetInteger(messageIndex);
                            messageIndex++;
                            
                            bool isVisible = true;
                            if (blockId == BlockIds.Action.Portals.INVISIBLE)
                            {
                                isVisible = false;
                            }

                            list.Add(new PortalBlock(
                                blockId,
                                x,
                                y,
                                direction,
                                portalId,
                                destination,
                                isVisible,
                                r));
                        }
                        else if (blockId == BlockIds.Action.Portals.WORLD)
                        {                            
                            string destination = m.GetString(messageIndex);
                            messageIndex++;

                            list.Add(new RoomPortalBlock(
                                x,
                                y,
                                destination,
                                r));
                        }
                        else if (blockId == BlockIds.Action.Doors.COIN ||
                            blockId == BlockIds.Action.Gates.COIN)
                        {
                            int coins = m.GetInteger(messageIndex);
                            messageIndex++;
                            
                            bool isGate = false;
                            if (blockId == BlockIds.Action.Gates.COIN)
                            {
                                isGate = true;
                            }

                            list.Add(new CoinBlock(
                                blockId,
                                x,
                                y,
                                coins,
                                isGate,
                                r));
                        }
                        else if (blockId == BlockIds.Action.Music.PERCUSSION)
                        {
                            int type = m.GetInteger(messageIndex);
                            messageIndex++;

                            list.Add(new PercussionBlock(
                                x,
                                y,
                                type,
                                r));
                        }
                        else if (blockId == BlockIds.Action.Music.PIANO)
                        {
                            int note = m.GetInteger(messageIndex);
                            messageIndex++;

                            list.Add(new PianoBlock(
                                x,
                                y,
                                note,
                                r));
                        }
                        else if (blockId == BlockIds.Decorative.SciFi2013.BLUEBEND ||
                            blockId == BlockIds.Decorative.SciFi2013.BLUESTRAIGHT ||
                            blockId == BlockIds.Decorative.SciFi2013.GREENBEND ||
                            blockId == BlockIds.Decorative.SciFi2013.GREENSTRAIGHT ||
                            blockId == BlockIds.Decorative.SciFi2013.ORANGEBEND ||
                            blockId == BlockIds.Decorative.SciFi2013.ORANGESTRAIGHT ||
                            blockId == BlockIds.Action.Hazards.SPIKE)
                        {
                            int rotation = m.GetInteger(messageIndex);
                            messageIndex++;

                            list.Add(new Block(
                                blockId,
                                x,
                                y,
                                r,
                                null,
                                rotation));
                        }
                        else
                        {
                            list.Add(new Block(
                            blockId,
                            x,
                            y,
                            r,
                            null));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                SkylightMessage("Error loading existing blocks: " + e.Message);
            }
            
            return list;
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
            return new Player();
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
            return new Player();
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
            return new Player();
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
    }
}