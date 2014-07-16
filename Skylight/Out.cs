// <author>TakoMan02</author>
// <summary>Out.cs is the methods that can be used to edit the world it is in.</summary>

using System;
using System.Collections.Generic;
using System.Threading;
using PlayerIOClient;
using Skylight.Blocks;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class Out
    {
        public Bot Bot
        {
            get
            {
                // Scan every bot for the match.
                foreach (Room r in Room.JoinedRooms)
                {
                    foreach (Bot b in r.OnlineBots)
                    {
                        if (b.Push == this)
                        {
                            return b;
                        }
                    }
                }

                return null;
            }
        }

        public Connection C
        {
            get { return Bot.Connection; }
        }

        public Room R
        {
            get { return Bot.R; }
        }

        public void Build(int id, int x, int y)
        {
            Build(new Block(id, x, y));
        }

        public void Build(Block b)
        {
            try
            {
                if (b is CoinBlock)
                {
                    var c = b as CoinBlock;

                    C.Send(R.RoomKey, c.Z, c.X, c.Y, c.Id, c.CoinsRequired);
                }
                else if (b is PercussionBlock)
                {
                    var p = b as PercussionBlock;

                    C.Send(R.RoomKey, p.Z, p.X, p.Y, p.Id, p.PercussionId);
                }
                else if (b is PianoBlock)
                {
                    var p = b as PianoBlock;

                    C.Send(R.RoomKey, p.Z, p.X, p.Y, p.Id, p.PianoId);
                }
                else if (b is PortalBlock)
                {
                    var p = b as PortalBlock;

                    C.Send(R.RoomKey, p.Z, p.X, p.Y, p.Id, p.Direction, p.PortalId, p.PortalDestination);
                }
                else if (b is RoomPortalBlock)
                {
                    var r = b as RoomPortalBlock;

                    C.Send(R.RoomKey, r.Z, r.X, r.Y, r.Id, r.PortalDestination);
                }
                else if (b is TextBlock)
                {
                    var t = b as TextBlock;
                    C.Send(R.RoomKey, t.Z, t.X, t.Y, t.Id, t.Text);
                }
                else
                {
                    C.Send(R.RoomKey, b.Z, b.X, b.Y, b.Id, b.Direction);
                }


                Thread.Sleep(Bot.BlockDelay);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Build before connecting");
            }
        }

        public void Build(List<Block> blockList)
        {
            var tempList = new List<Block>();
            tempList.AddRange(blockList);

            foreach (Block b in tempList)
            {
                Build(b);
            }
        }

        public void Clear()
        {
            try
            {
                C.Send("clear");
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Clear before connecting");
            }
        }

        public void HoldDown(double startX, double startY)
        {
            var holdArgs = new object[11];

            holdArgs[0] = startX;
            holdArgs[1] = startY;
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = 0;
            holdArgs[5] = 2;
            holdArgs[6] = 0;
            holdArgs[7] = 1;
            holdArgs[8] = 4;
            holdArgs[9] = false;
            holdArgs[10] = false;

            Move(holdArgs);
        }

        public void HoldLeft(double startX, double startY)
        {
            var holdArgs = new object[11];

            holdArgs[0] = startX;
            holdArgs[1] = startY;
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = -1;
            holdArgs[5] = 2;
            holdArgs[6] = -1;
            holdArgs[7] = 0;
            holdArgs[8] = 4;
            holdArgs[9] = false;
            holdArgs[10] = false;

            Move(holdArgs);
        }

        public void HoldRight(double startX, double startY)
        {
            var holdArgs = new object[11];

            holdArgs[0] = startX;
            holdArgs[1] = startY;
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = 1;
            holdArgs[5] = 2;
            holdArgs[6] = 1;
            holdArgs[7] = 0;
            holdArgs[8] = 0;
            holdArgs[9] = false;
            holdArgs[10] = false;

            Move(holdArgs);
        }

        public void HoldUp(double startX, double startY)
        {
            var holdArgs = new object[11];

            holdArgs[0] = startX;
            holdArgs[1] = startY;
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = 0;
            holdArgs[5] = 2;
            holdArgs[6] = 0;
            holdArgs[7] = -1;
            holdArgs[8] = 4;
            holdArgs[9] = false;
            holdArgs[10] = false;

            Move(holdArgs);
        }

        public void InputCode(string editKey)
        {
            try
            {
                C.Send("access", editKey);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.InputCode before connecting");
            }
        }

        public void SetCode(string newCode)
        {
            if (Bot.Name == R.Owner.Name)
            {
                C.Send("key", newCode);
            }
        }

        public void Jump(double startX, double startY)
        {
            var holdArgs = new object[11];

            holdArgs[0] = startX;
            holdArgs[1] = startY;
            holdArgs[2] = 0;
            holdArgs[3] = -52;
            holdArgs[4] = 0;
            holdArgs[5] = 2;
            holdArgs[6] = 0;
            holdArgs[7] = 0;
            holdArgs[8] = 4;
            holdArgs[9] = false;
            holdArgs[10] = true;

            Move(holdArgs);
        }

        public void Move(object[] args)
        {
            try
            {
                C.Send("m", args);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Move before connecting");
            }
        }

        public void Move(Message m)
        {
            try
            {
                C.Send(
                    "m",
                    m.GetDouble(1),
                    m.GetDouble(2),
                    m.GetDouble(3),
                    m.GetDouble(4),
                    m.GetDouble(5),
                    m.GetDouble(6),
                    m.GetDouble(7),
                    m.GetDouble(8),
                    m.GetInt(9),
                    m.GetBoolean(10),
                    m.GetBoolean(11));
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Move before connecting");
            }
        }

        public void Release(double startX, double startY)
        {
            var holdArgs = new object[11];
            holdArgs[0] = startX;
            holdArgs[1] = startY;
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = 0;
            holdArgs[5] = 2;
            holdArgs[6] = 0;
            holdArgs[7] = 0;
            holdArgs[8] = 4;
            holdArgs[9] = false;
            holdArgs[10] = false;

            Move(holdArgs);
        }

        public void Say(string s, bool useChatPrefix = true)
        {
            try
            {
                if (s.StartsWith("/") || !useChatPrefix)
                {
                    if (s.Length <= 80 && s.Length > 0)
                    {
                        C.Send("say", s);
                        Thread.Sleep(Bot.SpeechDelay);
                    }
                    else
                    {
                        // Say what you can.
                        Say(s.Substring(0, 80));

                        // Delete what you just said.
                        s = s.Substring(80);

                        // Repeat the process.
                        Say(s);
                    }
                }
                else
                {
                    if (s.Length + Bot.ChatPrefix.Length <= 80)
                    {
                        C.Send("say", Bot.ChatPrefix + s);
                        Thread.Sleep(Bot.SpeechDelay);
                    }
                    else
                    {
                        // Say what you can.
                        Say(s.Substring(0, 80 - Bot.ChatPrefix.Length));

                        // Delete what you just said.
                        s = s.Substring(80 - Bot.ChatPrefix.Length);

                        // Repeat the process.
                        Say(s);
                    }
                }
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Say before connecting");
            }
        }

        public void SetTitle(string s)
        {
            try
            {
                if (s != string.Empty)
                {
                    C.Send("name", s);
                }
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.SetTitle before connecting");
            }
        }

        public void Kick(string name, string reason = "")
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/kick " + name + " " + reason);
            }
        }

        public void Kick(Player p, string reason = "")
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/kick " + p.Name + " " + reason);
            }
        }

        public void Loadlevel()
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/loadlevel");
            }
        }

        public void Respawn(string name)
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/kill " + name);
            }
        }

        public void Respawn(Player p)
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/kill " + p.Name);
            }
        }

        public void RespawnAll()
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/respawnall");
            }
        }

        public void Reset()
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/reset");
            }
        }

        public void Save()
        {
            try
            {
                if (Bot.Name == R.Owner.Name)
                {
                    C.Send("save");
                }
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Save before connecting");
            }
        }

        public void SetAllPotionBans(bool value)
        {
            try
            {
                if (Bot.Name == R.Owner.Name)
                {
                    C.Send("allowpotions", value);
                }
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.SetAllPotionBans before connecting");
            }
        }

        public void SetEdit(string name, bool value)
        {
            if (Bot.Name == R.Owner.Name)
            {
                if (value)
                {
                    Say("/giveedit " + name);
                }
                else
                {
                    Say("/removeedit " + name);
                }
            }
        }

        public void SetEdit(Player p, bool value)
        {
            if (Bot.Name == R.Owner.Name)
            {
                if (value)
                {
                    Say("/giveedit " + p.Name);
                }
                else
                {
                    Say("/removeedit " + p.Name);
                }
            }
        }

        public void SetGod(bool value)
        {
            if (Bot.HasAccess)
            {
                if (value)
                {
                    C.Send("god", true);
                }
                else
                {
                    C.Send("god", false);
                }
            }
        }

        public void SetMute(string name, bool value)
        {
            if (Bot.Name == R.Owner.Name)
            {
                if (value)
                {
                    Say("/mute " + name);
                }
                else
                {
                    Say("/unmute " + name);
                }
            }
        }

        public void SetMute(Player p, bool value)
        {
            if (Bot.Name == R.Owner.Name)
            {
                if (value)
                {
                    Say("/mute " + p.Name);
                }
                else
                {
                    Say("/unmute " + p.Name);
                }
            }
        }

        public void SetPotionBan(int potionId, bool value)
        {
            if (Bot.Name == R.Owner.Name)
            {
                if (value)
                {
                    Say("/potionson " + potionId);
                }
                else
                {
                    Say("/potionsoff " + potionId);
                }
            }
        }

        public void SetSmiley(int smileyId)
        {
            try
            {
                C.Send(R.RoomKey + "f", smileyId);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.SetSmiley before connecting");
            }
        }

        public void SetVisibility(bool value)
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/visible " + value);
            }
        }

        public void Teleport(int newXLocation, int newYLocation, string name = "")
        {
            if (Bot.Name == R.Owner.Name)
            {
                if (name != "")
                {
                    Say("/teleport " + name + " " + newXLocation + " " + newYLocation);
                }
                else
                {
                    Say("/teleport " + Bot.Name + " " + newXLocation + " " + newYLocation);
                }
            }
        }

        public void Teleport(int newXLocation, int newYLocation, Player p = null)
        {
            if (Bot.Name == R.Owner.Name)
            {
                if (p != null)
                {
                    Say("/teleport " + p.Name + " " + newXLocation + " " + newYLocation);
                }
                else
                {
                    Say("/teleport " + Bot.Name + " " + newXLocation + " " + newYLocation);
                }
            }
        }

        public void TeleportAll(int newXLocation, int newYLocation)
        {
            if (Bot.Name == R.Owner.Name)
            {
                foreach (Player p in R.OnlinePlayers)
                {
                    Teleport(newXLocation, newYLocation, p);
                }
            }
        }
    }
}