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

                Tools.SkylightMessage("Referenced to an unknown bot in Out.cs");
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

        public void Build(Block b)
        {
            if (this.C != null)
            {
                this.C.Send(this.R.RoomKey, b.Z, b.X, b.Y, b.Id, b.Direction);
                Thread.Sleep(this.Bot.BlockDelay);
            }
        }

        public void Build(List<Block> blockList)
        {
            if (this.C != null)
            {
                foreach (Block b in blockList)
                {
                    this.Build(b);
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
            if (this.C != null)
            {
                this.C.Send("access", editKey);
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
            if (this.C != null)
            {
                this.C.Send("m", args);
            }
        }

        public void Move(Message m)
        {
            if (this.C != null)
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

        public void Say(string s)
        {
            if (this.C != null)
            {
                this.C.Send("say", s);
                Thread.Sleep(this.Bot.SpeechDelay);
            }
        }

        public void SetTitle(string s)
        {
            if (this.C != null && s != string.Empty)
            {
                this.C.Send("name", s);
            }
        }

        public void BanPotion(int potionId)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                this.Say("/potionsoff " + potionId);
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
            if (this.C != null && this.Bot.Name == this.R.Owner.Name)
            {
                this.C.Send("save");
            }
        }

        public void SetAllPotionBans(bool value)
        {
            if (this.C != null && this.Bot.IsOwner)
            {
                this.C.Send("allowpotions", value);
            }
        }
        
        public void SetEdit(Player p)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                this.Say("/giveedit " + p.Name);
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
            if (this.C != null)
            {
                this.C.Send(this.R.RoomKey + "f", smileyId);
            }
        }

        public void SetVisibility(bool value)
        {
            if (this.Bot.Name == this.R.Owner.Name)
            {
                this.Say("/visible " + value);
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
                    this.Say("/teleport " + newXLocation + " " + newYLocation);
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

        public List<Room> ListLevels()
        {
            List<Room> roomList = new List<Room>();

            return roomList;
        }
    }
}
