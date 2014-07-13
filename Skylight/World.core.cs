namespace Skylight
{
    using PlayerIOClient;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class World
    {
        internal static List<Block> DeserializeInit(Message m, uint start, Room r)
        {
            List<Block> list = new List<Block>();
            try
            {
                //// FULL CREDIT TO BASS5098 FOR THE FOLLOWING CODE
                //// I wrote it in my own way in C# but Bass5098 made the original.
                //// Without it I would not know how to do this.
                //// https://github.com/kevin-brown/ee-level-editor/blob/master/LevelEditor/WorldConverter.vb
                //// Lines 438-507
                //// Praise him. (this is mainly due to my laziness)

                // First, fill the entire map with blank blocks (so that you don't get null exceptions).
				// Is the world always 700x400 or am I missing something?
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
                    switch (blockId)
                    {
                        case (int)BlockIds.Portals.NORMAL:
                        case (int)BlockIds.Portals.INVISIBLE:
                            {
                                rotation = m.GetInteger(messageIndex);
                                messageIndex++;

                                portalId = m.GetInteger(messageIndex);
                                messageIndex++;

                                destination = m.GetInteger(messageIndex);
                                messageIndex++;

                                isVisible = !(blockId == (int)BlockIds.Portals.INVISIBLE);
                                break;
                            }
                        case (int)BlockIds.Portals.WORLD:
                            {
                                roomDestination = m.GetString(messageIndex);
                                messageIndex++;
                                break;
                            }
                        case (int)BlockIds.Doors.COIN:
                        case (int)BlockIds.Gates.COIN:
                            {
                                coins = m.GetInteger(messageIndex);
                                messageIndex++;

                                isGate = (blockId == (int)BlockIds.Gates.COIN);
                                break;

                            }
                        case (int)BlockIds.Music.PERCUSSION:
                            {
                                type = m.GetInteger(messageIndex);
                                messageIndex++;
                                break;
                            }
                        case (int)BlockIds.Music.PIANO:
                            {
                                note = m.GetInteger(messageIndex);
                                messageIndex++;
                                break;
                            }
                        case (int)BlockIds.SciFi2013.BLUEBEND:
                        case (int)BlockIds.SciFi2013.BLUESTRAIGHT:
                        case (int)BlockIds.SciFi2013.GREENBEND:
                        case (int)BlockIds.SciFi2013.GREENSTRAIGHT:
                        case (int)BlockIds.SciFi2013.ORANGEBEND:
                        case (int)BlockIds.SciFi2013.ORANGESTRAIGHT:
                        case (int)BlockIds.Hazards.SPIKE:
                            {
                                rotation = m.GetInteger(messageIndex);
                                messageIndex++;
                                break;
                            }

                    }

                    // Some variables to simplify things.
                    int x = 0, y = 0;

                    for (int pos = 0; pos < ya.Length; pos += 2)
                    {
                        // Extract the X and Y positions from the array.
                        x = (xa[pos] * 256) + xa[pos + 1];
                        y = (ya[pos] * 256) + ya[pos + 1];

                        // Ascertain the block from the ID.
                        // Add block accordingly.
                        switch (blockId)
                        {
                            case (int)BlockIds.Portals.NORMAL:
                            case (int)BlockIds.Portals.INVISIBLE:
                                {
                                    list.Add(new PortalBlock(
                                        x,
                                        y,
                                        rotation,
                                        portalId,
                                        destination,
                                        isVisible));
                                    break;
                                }
                            case (int)BlockIds.Portals.WORLD:
                                {
                                    list.Add(new RoomPortalBlock(
                                        x,
                                        y,
                                        roomDestination));
                                    break;
                                }
                            case (int)BlockIds.Doors.COIN:
                            case (int)BlockIds.Gates.COIN:
                                {
                                    list.Add(new CoinBlock(
                                        x,
                                        y,
                                        coins,
                                        isGate));
                                    break;
                                }
                            case (int)BlockIds.Music.PERCUSSION:
                                {
                                    list.Add(new PercussionBlock(
                                        x,
                                        y,
                                        type));
                                    break;
                                }
                            case (int)BlockIds.Music.PIANO:
                                {
                                    list.Add(new PianoBlock(
                                        x,
                                        y,
                                        note));
                                    break;
                                }
                            case (int)BlockIds.SciFi2013.BLUEBEND:
                            case (int)BlockIds.SciFi2013.BLUESTRAIGHT:
                            case (int)BlockIds.SciFi2013.GREENBEND:
                            case (int)BlockIds.SciFi2013.GREENSTRAIGHT:
                            case (int)BlockIds.SciFi2013.ORANGEBEND:
                            case (int)BlockIds.SciFi2013.ORANGESTRAIGHT:
                            case (int)BlockIds.Hazards.SPIKE:
                                {
                                    list.Add(new Block(
                                        blockId,
                                        x,
                                        y,
                                        0,
                                        rotation));
                                    break;
                                }
                            default:
                                {
                                    list.Add(new Block(
                                    blockId,
                                    x,
                                    y,
                                    z));
                                    break;
                                }
                        } // end switch
                    }
                }
            }
            catch (Exception e)
            {
                //SkylightMessage("Error loading existing blocks:\n" + e);
            }

            //SkylightMessage("Done loading blocks");
            return list;
        }

    }





}