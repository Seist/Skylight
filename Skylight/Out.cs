// <author>TakoMan02</author>
// <summary>Out.cs is the methods that can be used to edit the world it is in.</summary>
namespace Skylight
{
    using PlayerIOClient;
    using System;
    using System.Collections.Generic;
    using System.Threading;

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
                if (this.C == null)
                {
                    Logging.SkylightMessage("Error: attempted to use Out.Build before connecting");
                }
                else
                {
                    Logging.SkylightMessage("Error: one or more of the specified parameters in Out.Build was invalid");
                }
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
                if (this.C == null)
                {
                    Logging.SkylightMessage("Error: attempted to use Out.Clear before connecting");
                }
                else
                {
                    Logging.SkylightMessage("Error: could not clear world because of an unknown error");
                }
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
                if (this.C == null)
                {
                    Logging.SkylightMessage("Error: attempted to use Out.InputCode before connecting");
                }
                else
                {
                    Logging.SkylightMessage("Error: access key '" + editKey + "' is invalid");
                }
            }
        }

        public void SetCode(string newCode)
        {
            this.C.Send("key", newCode);
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
                if (this.C == null)
                {
                    Logging.SkylightMessage("Error: attempted to use Out.Move before connecting");
                }
                else
                {
                    Logging.SkylightMessage("Error: invalid arguments specified to Out.Move. 11 arguments should have been specified");

                }
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
                Logging.SkylightMessage("Error: attempted to use Out.Move before connecting");
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
            if (this.Bot.Name == this.R.Owner.Name)
            {
                try
                {
                    if (s.StartsWith("/") || !useChatPrefix)
                    {
                        if (s.Length <= 80 && s.Length != 0)
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
                            this.Say(s.Substring(0, 80 - this.Bot.ChatPrefix.Length));

                            // Delete what you just said.
                            s = s.Substring(80 - this.Bot.ChatPrefix.Length);

                            // Repeat the process.
                            this.Say(s);
                        }
                    }
                }
                catch (Exception)
                {
                    Logging.SkylightMessage("Error: attempted to use Out.Say before connecting");
                }
            } // end on.this.say if statement
        }

        public void SetTitle(string s)
        {
            try
            {
                if (s != string.Empty)
                {
                    this.C.Send("name", s);
                }
                else
                {
                    Logging.SkylightMessage("The room title cannot be empty");
                }
            }
            catch (Exception)
            {
                if (this.C == null)
                {
                    Logging.SkylightMessage("Error: attempted to use Out.SetTitle before connecting");
                }
                else
                {
                    Logging.SkylightMessage("Error: an unknown error occured while using Out.SetTitle");
                }
            }
        }

        public void Kick(string name, string reason = "")
        {
            this.Say("/kick " + name + " " + reason);
        }

        public void Kick(Player p, string reason = "")
        {
            this.Say("/kick " + p.Name + " " + reason);
        }

        public void Loadlevel()
        {
            this.Say("/loadlevel");
        }

        public void Respawn(string name)
        {
            this.Say("/kill " + name);
        }

        public void Respawn(Player p)
        {
            this.Say("/kill " + p.Name);
        }

        public void RespawnAll()
        {
            this.Say("/respawnall");
        }

        public void Reset()
        {
            this.Say("/reset");
        }

        public void Save()
        {
            if (this.Bot.HasAccess)
            {
                this.C.Send("save");
            }
        }

        public void SetAllPotionBans(bool shouldAllowPotions)
        {
            if (this.Bot.HasAccess)
            {
                this.C.Send("allowpotions", shouldAllowPotions.ToString());
            }
        }

        public void SetEdit(string name, bool shouldHaveEdit)
        {

            if (shouldHaveEdit)
            {
                this.Say("/giveedit " + name);
            }
            else
            {
                this.Say("/removeedit " + name);
            }

        }

        public void SetEdit(Player p, bool shouldHaveEdit)
        {
            if (shouldHaveEdit)
            {
                this.Say("/giveedit " + p.Name);
            }
            else
            {
                this.Say("/removeedit " + p.Name);
            }

        }

        public void SetGod(bool isGod)
        {
            if (this.Bot.HasAccess)
            {
                this.C.Send("god", isGod);
            }
        }

        public void SetMute(string name, bool shouldMute)
        {

            if (shouldMute)
            {
                this.Say("/mute " + name);
            }
            else
            {
                this.Say("/unmute " + name);
            }

        }

        public void SetMute(Player p, bool shouldMute)
        {

            if (shouldMute)
            {
                this.Say("/mute " + p.Name);
            }
            else
            {
                this.Say("/unmute " + p.Name);
            }

        }

        public void SetPotionBan(int potionId, bool shouldBanPotion)
        {

            if (shouldBanPotion)
            {
                this.Say("/potionson " + potionId.ToString());
            }
            else
            {
                this.Say("/potionsoff " + potionId.ToString());
            }

        }

        public void SetSmiley(int smileyId)
        {
            try
            {
                this.C.Send(this.R.RoomKey + "f", smileyId.ToString());
            }
            catch (Exception)
            {
                Logging.SkylightMessage("Error: attempted to use Out.SetSmiley before connecting");
            }
        }

        public void SetVisibility(bool value)
        {
            this.Say("/visible " + value.ToString());
        }

        public void Teleport(int newXLocation, int newYLocation, string name = null)
        {
            this.Say("/teleport " + (name ?? this.Bot.Name) + " " + newXLocation.ToString() + " " + newYLocation.ToString());
        }

        public void Teleport(int newXLocation, int newYLocation, Player p = null)
        {
            this.Say("/teleport " + (p.Name ?? this.Bot.Name) + " " + newXLocation.ToString() + " " + newYLocation.ToString());
        }

        public void TeleportAll(int newXLocation, int newYLocation)
        {
            foreach (Player p in this.R.OnlinePlayers)
            {
                this.Teleport(newXLocation, newYLocation, p);
            }

        }
    }
}
