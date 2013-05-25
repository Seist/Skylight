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
                foreach (Room r in Room.JoinedRooms)
                {
                    foreach (Bot b in r.ConnectedBots)
                    {
                        if (b.Push == this)
                        {
                            return b;
                        }
                    }
                }

                Console.WriteLine("Throwing new bot...");
                return new Bot();
            }
        }

        public Connection C(Room r)
        {
            foreach (Connection c in Bot.BotClient.Connections)
            {
                foreach (Connection c2 in r.Connections)
                {
                    if (c == c2)
                    {
                        return c;
                    }
                }
            }

            return null;
        }

        public void Build(Block b, Room r)
        {
            if (this.C(r).Connected)
            {
                this.C(r).Send(r.RoomKey, b.Layer, b.Coords.X, b.Coords.Y, b.Id, b.Direction);
                Thread.Sleep(this.Bot.BlockDelay);
            }
        }

        public void Build(List<Block> blockList, Room r)
        {
            if (this.C(r).Connected)
            {
                foreach (Block b in blockList)
                {
                    this.Build(b, r);
                }
            }
        }
        
        public void HoldDown(Room r)
        {
            object[] holdArgs = new object[10];
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = 0;
            holdArgs[5] = 0;
            holdArgs[6] = 0;
            holdArgs[7] = 0;
            holdArgs[8] = 0;
        }

        public void HoldLeft(Room r)
        {
            object[] holdArgs = new object[10];
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = 0;
            holdArgs[5] = 0;
            holdArgs[6] = 0;
            holdArgs[7] = 0;
            holdArgs[8] = 0;
        }

        public void HoldRight(Room r)
        {
            object[] holdArgs = new object[10];
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = 0;
            holdArgs[5] = 0;
            holdArgs[6] = 0;
            holdArgs[7] = 0;
            holdArgs[8] = 0;
        }

        public void HoldUp(Room r)
        {
            object[] holdArgs = new object[10];
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = 0;
            holdArgs[5] = 0;
            holdArgs[6] = 0;
            holdArgs[7] = 0;
            holdArgs[8] = 0;
        }

        public void InputCode(string editKey, Room r)
        {
            this.C(r).Send("access", editKey);
        }

        public void Jump(Room r)
        {
            object[] holdArgs = new object[10];
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = 0;
            holdArgs[5] = 0;
            holdArgs[6] = 0;
            holdArgs[7] = 0;
            holdArgs[8] = 0;
        }

        public void Move(object[] args, Room r)
        {
            if (this.C(r).Connected)
            {
                this.C(r).Send("m", args);
            }
        }

        public void Release()
        {
            object[] holdArgs = new object[10];
            holdArgs[2] = 0;
            holdArgs[3] = 0;
            holdArgs[4] = 0;
            holdArgs[5] = 0;
            holdArgs[6] = 0;
            holdArgs[7] = 0;
            holdArgs[8] = 0;
        }

        public void Say(string s, Room r)
        {
            if (this.C(r).Connected)
            {
                this.C(r).Send("say", s);
                Thread.Sleep(this.Bot.SpeechDelay);
            }
        }

        public void SetTitle(string s, Room r)
        {
            if (this.C(r).Connected && s != string.Empty)
            {
                this.C(r).Send("name", s);
            }
        }

        // TODO: Add these
        // Room voids:
        public void Save(Room r)
        { 
        }

        public void Loadlevel(Room r)
        {
            if (this.Bot.IsOwner)
            {
                this.Say("/loadlevel", r);
            }
        }

        public void Reset(Room r)
        {
            if (this.Bot.IsOwner)
            {
                this.Say("/reset", r);
            }
        }

        public void RespawnAll(Room r)
        {
            if (this.Bot.IsOwner)
            {
                this.Say("/respawnall", r); 
            }
        }

        public void SetAllPotionBans(bool value)
        { 
        }

        public void SetAllPlayerBans(bool value)
        {
        }

        public void Ban(Potion p)
        { 
        }

        public void Ban(Player p)
        { 
        }

        public void Unban(Potion p)
        {
        }

        public void Unban(Player p)
        { 
        }

        public void Mute(Player p)
        {
        }

        public void GiveEdit(Player p, Room r)
        {
            if (this.Bot.IsOwner)
            {
                this.Say("/giveedit " + p.Name, r);
            }
        }

        public void RemoveEdit(Player p, Room r)
        {
            if (this.Bot.IsOwner)
            {
                this.Say("/removeedit " + p.Name, r);
            }
        }

        public void Respawn(Player p, Room r)
        {
            if (this.Bot.IsOwner)
            {
                this.Say("/kill " + p.Name, r);
            }
        }

        public void Kick(Player p)
        {
        }

        public void Kill(Player p)
        {
        }

        public void Teleport(Player p)
        {
        }
    }
}
