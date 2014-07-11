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
                        case BlockIds.Action.Portals.NORMAL:
                        case BlockIds.Action.Portals.INVISIBLE:
                            {
                                rotation = m.GetInteger(messageIndex);
                                messageIndex++;

                                portalId = m.GetInteger(messageIndex);
                                messageIndex++;

                                destination = m.GetInteger(messageIndex);
                                messageIndex++;

                                isVisible = !(blockId == BlockIds.Action.Portals.INVISIBLE);
                                break;
                            }
                        case BlockIds.Action.Portals.WORLD:
                            {
                                roomDestination = m.GetString(messageIndex);
                                messageIndex++;
                                break;
                            }
                        case BlockIds.Action.Doors.COIN:
                        case BlockIds.Action.Gates.COIN:
                            {
                                coins = m.GetInteger(messageIndex);
                                messageIndex++;

                                isGate = (blockId == BlockIds.Action.Gates.COIN);
                                break;

                            }
                        case BlockIds.Action.Music.PERCUSSION:
                            {
                                type = m.GetInteger(messageIndex);
                                messageIndex++;
                                break;
                            }
                        case BlockIds.Action.Music.PIANO:
                            {
                                note = m.GetInteger(messageIndex);
                                messageIndex++;
                                break;
                            }
                        case BlockIds.Decorative.SciFi2013.BLUEBEND:
                        case BlockIds.Decorative.SciFi2013.BLUESTRAIGHT:
                        case BlockIds.Decorative.SciFi2013.GREENBEND:
                        case BlockIds.Decorative.SciFi2013.GREENSTRAIGHT:
                        case BlockIds.Decorative.SciFi2013.ORANGEBEND:
                        case BlockIds.Decorative.SciFi2013.ORANGESTRAIGHT:
                        case BlockIds.Action.Hazards.SPIKE:
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
                            case BlockIds.Action.Portals.NORMAL:
                            case BlockIds.Action.Portals.INVISIBLE:
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
                            case BlockIds.Action.Portals.WORLD:
                                {
                                    list.Add(new RoomPortalBlock(
                                        x,
                                        y,
                                        roomDestination));
                                    break;
                                }
                            case BlockIds.Action.Doors.COIN:
                            case BlockIds.Action.Gates.COIN:
                                {
                                    list.Add(new CoinBlock(
                                        x,
                                        y,
                                        coins,
                                        isGate));
                                    break;
                                }
                            case BlockIds.Action.Music.PERCUSSION:
                                {
                                    list.Add(new PercussionBlock(
                                        x,
                                        y,
                                        type));
                                    break;
                                }
                            case BlockIds.Action.Music.PIANO:
                                {
                                    list.Add(new PianoBlock(
                                        x,
                                        y,
                                        note));
                                    break;
                                }
                            case BlockIds.Decorative.SciFi2013.BLUEBEND:
                            case BlockIds.Decorative.SciFi2013.BLUESTRAIGHT:
                            case BlockIds.Decorative.SciFi2013.GREENBEND:
                            case BlockIds.Decorative.SciFi2013.GREENSTRAIGHT:
                            case BlockIds.Decorative.SciFi2013.ORANGEBEND:
                            case BlockIds.Decorative.SciFi2013.ORANGESTRAIGHT:
                            case BlockIds.Action.Hazards.SPIKE:
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