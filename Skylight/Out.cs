// <author>TakoMan02</author>
// <summary>Out.cs is the methods that can be used to edit the world it is in.</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PlayerIOClient;
using Skylight.Blocks;
using Skylight.Miscellaneous;

namespace Skylight
{
    /// <summary>
    ///     Class Out. This class sends information to the server.
    /// </summary>
    public class Out
    {
        private readonly Build _build;
        private readonly Clear _clear;
        private readonly HoldDownArrow _holdDownArrow;

        public Out()
        {
            _build = new Build(this);
            _clear = new Clear(this);
            _holdDownArrow = new HoldDownArrow(this);
        }

        /// <summary>
        ///     Gets the bot. This is what the developer will instantiate when they need
        ///     to communicate with the bot.
        /// </summary>
        /// <value>The bot.</value>
        public Bot Bot
        {
            get
            {
                // Scan every bot for the match.
                return Room.JoinedRooms.SelectMany(r => r.OnlineBots).FirstOrDefault(b => b.Push == this);
            }
        }

        /// <summary>
        ///     Gets the connection.
        /// </summary>
        /// <value>The current connection.</value>
        public Connection C
        {
            get { return Bot.Connection; }
        }

        /// <summary>
        ///     Gets the room.
        /// </summary>
        /// <value>The room.</value>
        public Room R
        {
            get { return Bot.R; }
        }

        /// <summary>
        ///     Holds the left arrow key.
        /// </summary>
        /// <param name="startX">The start x coordinate.</param>
        /// <param name="startY">The start y coordinate.</param>
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

        /// <summary>
        ///     Holds the right arrow key.
        /// </summary>
        /// <param name="startX">The start x coordinate.</param>
        /// <param name="startY">The start y coordinate.</param>
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

        /// <summary>
        ///     Holds the up arrow key.
        /// </summary>
        /// <param name="startX">The start x coordinate.</param>
        /// <param name="startY">The start y coordinate.</param>
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

        /// <summary>
        ///     Inputs the edit key.
        /// </summary>
        /// <param name="editKey">The edit key.</param>
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

        /// <summary>
        ///     Sets the edit key for the current room.
        /// </summary>
        /// <param name="newCode">The new code.</param>
        public void SetCode(string newCode)
        {
            if (Bot.Name == R.Owner.Name)
            {
                C.Send("key", newCode);
            }
        }

        /// <summary>
        ///     Tells the bot to jump from the specified coordinates.
        /// </summary>
        /// <param name="startX">The start x coordinate.</param>
        /// <param name="startY">The start y coordinate.</param>
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

        /// <summary>
        ///     Moves the specified bot.
        /// </summary>
        /// <param name="args">The raw message where to move.</param>
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

        /// <summary>
        ///     Overload for Move. Moves using the Message object.
        /// </summary>
        /// <param name="m">The movement Message Object.</param>
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

        /// <summary>
        ///     Releases the arrow key.
        /// </summary>
        /// <param name="startX">The start x.</param>
        /// <param name="startY">The start y.</param>
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

        /// <summary>
        ///     Says the specified message.
        /// </summary>
        /// <param name="s">The message.</param>
        /// <param name="useChatPrefix">if set to <c>true</c> then [use chat prefix].</param>
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

        /// <summary>
        ///     Sets the title of the room.
        /// </summary>
        /// <param name="s">The new title.</param>
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

        /// <summary>
        ///     Kicks the specified player by their username.
        /// </summary>
        /// <param name="name">The username.</param>
        /// <param name="reason">The reason.</param>
        public void Kick(string name, string reason = "")
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/kick " + name + " " + reason);
            }
        }

        /// <summary>
        ///     Kicks the specified Player object.
        /// </summary>
        /// <param name="p">The player object.</param>
        /// <param name="reason">The reason.</param>
        public void Kick(Player p, string reason = "")
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/kick " + p.Name + " " + reason);
            }
        }

        /// <summary>
        ///     Resets the level to its state when it was last saved.
        /// </summary>
        public void Loadlevel()
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/loadlevel");
            }
        }

        /// <summary>
        ///     Respawns the specified player by their username.
        /// </summary>
        /// <param name="name">The username.</param>
        public void Respawn(string name)
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/kill " + name);
            }
        }

        /// <summary>
        ///     Respawns the specified Player object.
        /// </summary>
        /// <param name="p">The player.</param>
        public void Respawn(Player p)
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/kill " + p.Name);
            }
        }

        /// <summary>
        ///     Respawns everyone in the room.
        /// </summary>
        public void RespawnAll()
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/respawnall");
            }
        }

        /// <summary>
        ///     Clears the entire world.
        /// </summary>
        public void Reset()
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/reset");
            }
        }

        /// <summary>
        ///     Saves the world.
        /// </summary>
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

        /// <summary>
        ///     Toggle all potion bans.
        /// </summary>
        /// <param name="value">if set to <c>true</c> then turn on potions.</param>
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

        /// <summary>
        ///     Sets the edit of a player.
        /// </summary>
        /// <param name="name">The username of the player.</param>
        /// <param name="value">if set to <c>true</c> then the player will receive edit privileges.</param>
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

        /// <summary>
        ///     Sets the edit for a Player object.
        /// </summary>
        /// <param name="p">The Player object.</param>
        /// <param name="value">if set to <c>true</c> then the Player object recieves edit.</param>
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

        /// <summary>
        ///     Sets the god mode for the bot.
        /// </summary>
        /// <param name="value">if set to <c>true</c> then the bot will go into god mode.</param>
        public void SetGod(bool value)
        {
            if (Bot.HasAccess)
            {
                C.Send("god", value);
            }
        }

        /// <summary>
        ///     Sets the mute for a player by their username. This will prevent chat messages from being
        ///     sent from that player to the server.
        /// </summary>
        /// <param name="name">The username.</param>
        /// <param name="value">if set to <c>true</c> then that username will be muted.</param>
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

        /// <summary>
        ///     Sets the mute for a Player object.
        /// </summary>
        /// <param name="p">The Player.</param>
        /// <param name="value">if set to <c>true</c> then that Player.subject object will be muted.</param>
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

        /// <summary>
        ///     Sets the potion ban.
        /// </summary>
        /// <param name="potionId">The potion id.</param>
        /// <param name="value">if set to <c>true</c> then potions will be turned on for that potion.</param>
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

        /// <summary>
        ///     Sets the smiley.
        /// </summary>
        /// <param name="smileyId">The smiley id.</param>
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

        /// <summary>
        ///     Sets the visibility of the bot.
        /// </summary>
        /// <param name="value">if set to <c>true</c> then the bot will become visible.</param>
        public void SetVisibility(bool value)
        {
            if (Bot.Name == R.Owner.Name)
            {
                Say("/visible " + value);
            }
        }

        /// <summary>
        ///     Teleports the specified new x location.
        /// </summary>
        /// <param name="newXLocation">The new x location.</param>
        /// <param name="newYLocation">The new y location.</param>
        /// <param name="name">The name.</param>
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

        /// <summary>
        ///     Teleports the specified new x location.
        /// </summary>
        /// <param name="newXLocation">The new x location.</param>
        /// <param name="newYLocation">The new y location.</param>
        /// <param name="p">The p.</param>
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

        /// <summary>
        ///     Teleports all.
        /// </summary>
        /// <param name="newXLocation">The new x location.</param>
        /// <param name="newYLocation">The new y location.</param>
        public void TeleportAll(int newXLocation, int newYLocation)
        {
            if (Bot.Name == R.Owner.Name)
            {
                foreach (var p in R.OnlinePlayers)
                {
                    Teleport(newXLocation, newYLocation, p);
                }
            }
        }
    }
}