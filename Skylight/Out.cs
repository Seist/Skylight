// <author>TakoMan02</author>
// <summary>Out.cs is the methods that can be used to edit the world it is in.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using PlayerIOClient;

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
            get
            {
                return this.Bot.Connection;
            }
        }

        public Room R
        {
            get
            {
                return this.Bot.R;
            }
        }

        public void Build(int id, int x, int y)
        {
            this.Build(new Block(id, x, y));
        }

        public void Build(Block b)
        {
            try
            {
                if (b is CoinBlock)
                {
                    CoinBlock c = b as CoinBlock;

                    this.C.Send(this.R.RoomKey, c.Z, c.X, c.Y, c.Id, c.CoinsRequired);
                }
                else if (b is PercussionBlock)
                {
                    PercussionBlock p = b as PercussionBlock;

                    this.C.Send(this.R.RoomKey, p.Z, p.X, p.Y, p.Id, p.PercussionId);
                }
                else if (b is PianoBlock)
                {
                    PianoBlock p = b as PianoBlock;

                    this.C.Send(this.R.RoomKey, p.Z, p.X, p.Y, p.Id, p.PianoId);
                }
                else if (b is PortalBlock)
                {
                    PortalBlock p = b as PortalBlock;

                    this.C.Send(this.R.RoomKey, p.Z, p.X, p.Y, p.Id, p.Direction, p.PortalId, p.PortalDestination);
                }
                else if (b is RoomPortalBlock)
                {
                    RoomPortalBlock r = b as RoomPortalBlock;

                    this.C.Send(this.R.RoomKey, r.Z, r.X, r.Y, r.Id, r.PortalDestination);
                }
                else if (b is TextBlock)
                {
                    TextBlock t = b as TextBlock;
                    this.C.Send(this.R.RoomKey, t.Z, t.X, t.Y, t.Id, t.Text);
                }
                else
                {
                    this.C.Send(this.R.RoomKey, b.Z, b.X, b.Y, b.Id, b.Direction);
                }
                
                Thread.Sleep(this.Bot.BlockDelay);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Build before connecting");
            }
        }

        public void Build(List<Block> blockList)
        {
            List<Block> tempList = new List<Block>();
            tempList.AddRange(blockList);

            foreach (Block b in tempList)
            {
                this.Build(b);
            }
        }

        public void Clear()
        {
            try
            {
                this.C.Send("clear");
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Clear before connecting");
            }
        }

        public void HoldDown(double startX, double startY)
        {
            object[] holdArgs = new object[11];

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

            this.Move(holdArgs);
        }

        public void HoldLeft(double startX, double startY)
        {
            object[] holdArgs = new object[11];

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

            this.Move(holdArgs);
        }

        public void HoldRight(double startX, double startY)
        {
            object[] holdArgs = new object[11];

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

            this.Move(holdArgs);
        }

        public void HoldUp(double startX, double startY)
        {
            object[] holdArgs = new object[11];

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

            this.Move(holdArgs);
        }

        public void InputCode(string editKey)
        {
            try
            {
                this.C.Send("access", editKey);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.InputCode before connecting");
            }
        }

        public void SetCode(string newCode)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                this.C.Send("key", newCode);
            }
        }

        public void Jump(double startX, double startY)
        {
            object[] holdArgs = new object[11];

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

            this.Move(holdArgs);
        }

        public void Move(object[] args)
        {
            try
            {
                this.C.Send("m", args);
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
                this.C.Send(
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
            object[] holdArgs = new object[11];
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

            this.Move(holdArgs);
        }

        public void Say(string s, bool useChatPrefix = true)
        {
            try
            {
                if (s.StartsWith("/") || !useChatPrefix)
                {
                    if (s.Length <= 80 && s.Length > 0)
                    {
                        this.C.Send("say", s);
                        Thread.Sleep(this.Bot.SpeechDelay);
                    }
                    else
                    {
                        // Say what you can.
                        this.Say(s.Substring(0, 80));

                        // Delete what you just said.
                        s = s.Substring(80);

                        // Repeat the process.
                        this.Say(s);
                    }
                }
                else
                {
                    if (s.Length + this.Bot.ChatPrefix.Length <= 80)
                    {
                        this.C.Send("say", this.Bot.ChatPrefix + s);
                        Thread.Sleep(this.Bot.SpeechDelay);
                    }
                    else
                    {
                        // Say what you can.
                        this.Say(s.Substring(0, 80));

                        // Delete what you just said.
                        s = s.Substring(80);

                        // Repeat the process.
                        this.Say(s);
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
                    this.C.Send("name", s);
                }
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.SetTitle before connecting");
            }
        }

        public void Kick(string name, string reason = "")
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                this.Say("/kick " + name + " " + reason);
            }
        }

        public void Kick(Player p, string reason = "")
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                this.Say("/kick " + p.Name + " " + reason);
            }
        }

        public void Loadlevel()
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                this.Say("/loadlevel");
            }
        }

        public void Respawn(string name)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                this.Say("/kill " + name);
            }
        }

        public void Respawn(Player p)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                this.Say("/kill " + p.Name);
            }
        }

        public void RespawnAll()
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                this.Say("/respawnall");
            }
        }

        public void Reset()
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                this.Say("/reset");
            }
        }

        public void Save()
        {
            try
            {
                if (this.Bot.Name == this.R.Owner.Name)
                {
                    this.C.Send("save");
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
                if (this.Bot.Name == this.R.Owner.Name)
                {
                    this.C.Send("allowpotions", value);
                }
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.SetAllPotionBans before connecting");
            }
        }

        public void SetEdit(string name, bool value)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                if (value)
                {
                    this.Say("/giveedit " + name);
                }
                else
                {
                    this.Say("/removeedit " + name);
                }
            }
        }

        public void SetEdit(Player p, bool value)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                if (value)
                {
                    this.Say("/giveedit " + p.Name);
                }
                else
                {
                    this.Say("/removeedit " + p.Name);
                }
            }
        }

        public void SetGod(bool value)
        {
            if (this.Bot.HasAccess)
            {
                if (value)
                {
                    this.C.Send("god", true);
                }
                else
                {
                    this.C.Send("god", false);
                }
            }
        }

        public void SetMute(string name, bool value)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                if (value)
                {
                    this.Say("/mute " + name);
                }
                else
                {
                    this.Say("/unmute " + name);
                }
            }
        }

        public void SetMute(Player p, bool value)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                if (value)
                {
                    this.Say("/mute " + p.Name);
                }
                else
                {
                    this.Say("/unmute " + p.Name);
                }
            }
        }

        public void SetPotionBan(int potionId, bool value)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                if (value)
                {
                    this.Say("/potionson " + potionId);
                }
                else
                {
                    this.Say("/potionsoff " + potionId);
                }
            }
        }

        public void SetSmiley(int smileyId)
        {
            try
            {
                this.C.Send(this.R.RoomKey + "f", smileyId);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.SetSmiley before connecting");
            }
        }

        public void SetVisibility(bool value)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                this.Say("/visible " + value);
            }
        }

        public void Teleport(int newXLocation, int newYLocation, string name = "")
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                if (name != "")
                {
                    this.Say("/teleport " + name + " " + newXLocation + " " + newYLocation);
                }
                else
                {
                    this.Say("/teleport " + this.Bot.Name + " " + newXLocation + " " + newYLocation);
                }
            }
        }

        public void Teleport(int newXLocation, int newYLocation, Player p = null)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                if (p != null)
                {
                    this.Say("/teleport " + p.Name + " " + newXLocation + " " + newYLocation);
                }
                else
                {
                    this.Say("/teleport " + this.Bot.Name + " " + newXLocation + " " + newYLocation);
                }
            }
        }

        public void TeleportAll(int newXLocation, int newYLocation)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                foreach (Player p in this.R.OnlinePlayers)
                {
                    this.Teleport(newXLocation, newYLocation, p);
                }
            }
        }
    }
}
