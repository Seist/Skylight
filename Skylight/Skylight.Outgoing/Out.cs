// <author>TakoMan02</author>
// <summary>Out.cs is the methods that can be used to edit the world it is in.</summary>

using System;
using System.Linq;
using PlayerIOClient;
using Skylight.Miscellaneous;

namespace Skylight
{
    /// <summary>
    ///     Class Out. This class sends information to the server.
    /// </summary>
    public class Out
    {
        private readonly ReleaseArrowKey _releaseArrowKey;
        private readonly SayChatMessage _sayChatMessage;

        public Out()
        {
            new Build(this);
            new Clear(this);
            new HoldDownArrow(this);
            new HoldLeftArrow(this);
            new HoldRightArrow(this);
            new HoldUpArrow(this);
            new HoldSpace(this);
            new SetTitleOfRoom(this);
            _sayChatMessage = new SayChatMessage(this);
            new InputCodeForRoom(this);
            new SetCodeForRoom(this);
            _releaseArrowKey = new ReleaseArrowKey(this);
            new LoadLevelInWorld(this);
            new RespawnPlayer(this);
            new RespawnAllPlayers(this);
            new ResetWorld(this);
            new SaveTheWorld(this);
            new SetAllPotionBansInWorld(this);
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

        public ReleaseArrowKey ReleaseArrowKey
        {
            get { return _releaseArrowKey; }
        }

        public SayChatMessage SayChatMessage
        {
            get { return _sayChatMessage; }
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
        ///     Kicks the specified player by their username.
        /// </summary>
        /// <param name="name">The username.</param>
        /// <param name="reason">The reason.</param>
        public void Kick(string name, string reason = "")
        {
            if (Bot.Name == R.Owner.Name)
            {
                _sayChatMessage.Say("/kick " + name + " " + reason);
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
                _sayChatMessage.Say("/kick " + p.Name + " " + reason);
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
                _sayChatMessage.Say("/kill " + p.Name);
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
                    _sayChatMessage.Say("/giveedit " + name);
                }
                else
                {
                    _sayChatMessage.Say("/removeedit " + name);
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
                    _sayChatMessage.Say("/giveedit " + p.Name);
                }
                else
                {
                    _sayChatMessage.Say("/removeedit " + p.Name);
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
                    _sayChatMessage.Say("/mute " + name);
                }
                else
                {
                    _sayChatMessage.Say("/unmute " + name);
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
                    _sayChatMessage.Say("/mute " + p.Name);
                }
                else
                {
                    _sayChatMessage.Say("/unmute " + p.Name);
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
                    _sayChatMessage.Say("/potionson " + potionId);
                }
                else
                {
                    _sayChatMessage.Say("/potionsoff " + potionId);
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
                _sayChatMessage.Say("/visible " + value);
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
                    _sayChatMessage.Say("/teleport " + name + " " + newXLocation + " " + newYLocation);
                }
                else
                {
                    _sayChatMessage.Say("/teleport " + Bot.Name + " " + newXLocation + " " + newYLocation);
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
                    _sayChatMessage.Say("/teleport " + p.Name + " " + newXLocation + " " + newYLocation);
                }
                else
                {
                    _sayChatMessage.Say("/teleport " + Bot.Name + " " + newXLocation + " " + newYLocation);
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
                foreach (Player p in R.OnlinePlayers)
                {
                    Teleport(newXLocation, newYLocation, p);
                }
            }
        }
    }
}