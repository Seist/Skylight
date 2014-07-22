
using System;
using System.Collections.Generic;
using System.Threading;
using PlayerIOClient;
using Skylight.Blocks;

namespace Skylight
{
    /// <summary>
    ///     The entire bot (main core). This is what the user instantiates when they want
    ///     a new bot.
    /// </summary>
    public class Bot : Player
    {
        /// <summary>
        ///     All of the possible account types. Defaults to Regular if unknown.
        /// </summary>
        public enum AccountType : sbyte
        {
            /// <summary>
            ///     The regular login method via email and password on the official
            ///     everybodyedits.com website.
            /// </summary>
            Regular = 0,

            /// <summary>
            ///     Facebook login using an auth token.
            /// </summary>
            Facebook = 1,

            /// <summary>
            ///     Kongregate login using a kongregate user id (an integer) and an auth token.
            /// </summary>
            Kongregate = 2,

            /// <summary>
            ///     ArmorGames login using a user token and a password token, both of which are 32
            ///     chars long and hex.
            /// </summary>
            ArmorGames = 3
        }

        private static string _storedVersion;
        private readonly AccountType _accType;

        private readonly string
            _emailOrToken,
            _passwordOrToken;

        /// <summary>
        ///     The main bot class.
        /// </summary>
        /// <param name="r">The room object that the bot will join.</param>
        /// <param name="emailOrToken">The email or token.</param>
        /// <param name="passwordOrToken">The password or token.</param>
        /// <param name="accType">
        ///     The account type. Default is regular but it automatically
        ///     guesses.
        /// </param>
        public Bot(Room r,
            string emailOrToken,
            string passwordOrToken,
            AccountType accType = AccountType.Regular) : base(r, 0, "", 0, 0.0, 0.0, false,
                false, true, 0, false, false, 0, false, false, false, false, false, false)
        {
            _emailOrToken = emailOrToken;
            _passwordOrToken = passwordOrToken;
            R = r;
            _accType = accType;
            ShouldTickAll = true;
            BlockDelay = 10;
            SpeechDelay = 750;
        }

        /// <summary>
        ///     Whether or not the bot is connected to the world.
        /// </summary>
        public bool IsConnected { get; internal set; }

        /// <summary>
        ///     The room the bot is joined to.
        /// </summary>
        public bool Joined { internal get; set; }

        /// <summary>
        ///     If the physics clock should tick or not.
        /// </summary>
        public bool ShouldTickAll { get; set; }

        /// <summary>
        ///     The PlayerIO client class.
        /// </summary>
        public Client Client { get; internal set; }

        /// <summary>
        ///     The delay between block messages to the server in milliseconds.
        /// </summary>
        public int BlockDelay { get; set; }

        /// <summary>
        ///     The delay between speech messages to the server in milliseconds.
        /// </summary>
        public int SpeechDelay { get; set; }

        /// <summary>
        ///     The prefix to add to all outgoing chat messages.
        /// </summary>
        public string ChatPrefix { get; set; }

        /// <summary>
        ///     The current room object.
        /// </summary>
        public Room R { get; internal set; }

        /// <summary>
        ///     The active connection object to the room.
        /// </summary>
        public Connection Connection { get; internal set; }

        /// <summary>
        ///     The current room that the bot is in.
        /// </summary>
        public static Room CurrentRoom { get; set; }

        // Public methods
        /// <summary>
        ///     The main method to login the bot with the credentials already specified.
        /// </summary>
        /// 
        
        // TODO: switch authentication system to Rabbit.
        // TODO: fix authentication system.
        public void LogIn()
        {
            try
            {
                switch (_accType)
                {
                    case AccountType.Regular:
                        if (_emailOrToken == "guest" && _passwordOrToken == "guest")
                            Client = Tools.GuestClient.Value;
                        else
                            Client = PlayerIO.QuickConnect.SimpleConnect(Config.PlayerioGameId, _emailOrToken,
                                _passwordOrToken);
                        break;

                    case AccountType.Facebook:
                        Client = PlayerIO.QuickConnect.FacebookOAuthConnect(Config.PlayerioGameId, _emailOrToken, null);
                        break;

                    case AccountType.Kongregate:
                        Client = PlayerIO.QuickConnect.KongregateConnect(Config.PlayerioGameId, _emailOrToken,
                            _passwordOrToken);
                        break;

                    default: //case AccountType.ArmorGames:
                        var c = Tools.GuestClient.Value.Multiplayer.JoinRoom("", null);
                        c.OnMessage += (sender, message) =>
                        {
                            if (message.Type != "auth") return;

                            if (message.Count == 0)
                                Tools.SkylightMessage(
                                    "Cannot log in using ArmorGames. The response from the auth server is wrong.");
                            else
                            {
                                Client = PlayerIO.Connect(Config.PlayerioGameId, "secure",
                                    message.GetString(0), message.GetString(1),
                                    "armorgames");
                            }

                            c.Disconnect();
                        };

                        c.Send("auth", _emailOrToken, _passwordOrToken);
                        break;
                }
            }
            catch (PlayerIOError e)
            {
                Tools.SkylightMessage("Cannot log in: " + e.Message);
                IsConnected = false;
                return;
            }

            IsConnected = true;
        }

        /// <summary>
        ///     Join the room that was already set.
        /// </summary>
        /// <param name="createRoom"></param>
        public void Join(bool createRoom = true)
        {
            // Update the game version.
            Refresh();

            if (!IsConnected)
            {
                // Log in
                LogIn();

                // If you didn't connect, it must have failed.
                if (!IsConnected)
                {
                    return;
                }
            }

            // Parse the level ID (because some people like to put full URLs in).
            R.Id = Tools.ParseUrl(R.Id);

            try
            {
                if (createRoom)
                {
                    // Join room
                    Connection = Client.Multiplayer.CreateJoinRoom(
                        R.Id, // RoomId   (URL)
                        _storedVersion, // RoomType (Server)
                        true, // Visible
                        new Dictionary<string, string>(), // RoomData
                        new Dictionary<string, string>()); // JoinData
                }
                else
                {
                    Connection = Client.Multiplayer.JoinRoom(
                        R.Id,
                        new Dictionary<string, string>());
                }
                // Update room data
                Room.JoinedRooms.Add(R);

                // Everyone gets a connection.
                R.Connections.Add(Connection);

                // The following 25 lines deal with filtering messages from the client.
                // Every bot receives info from the room, because some of it is exclusive to the bot.
                // We call those "personal" pulls.
                // They are exactly the same as the main pull, except In.IsPersonal = true.
                var i = new In {IsPersonal = true, Source = R, Bot = this};
                Connection.OnMessage += i.OnMessage;
                R.Pulls.Add(i);

                // However, everything else only needs one bot to handle. Things like chat and movement.
                // We don't need five bots firing an event every time someone chats.
                if (!R.HasPull)
                {
                    R.HasPull = true;

                    R.Receiver = this;

                    Connection.OnMessage += R.Pull.OnMessage;
                    R.Pull.IsPersonal = false;
                    R.Pull.Bot = this;
                    R.Pull.Source = R;
                }

                // Once everything is internal settled, send the init.
                Connection.Send("init");
                Connection.Send("init2");

                R.OnlinePlayers.Add(this);

                Joined = true;

                // Wait until all the blocks are loaded before joining.
                while (!R.BlocksLoaded)
                {
                    Thread.Sleep(500);
                }
            }
            catch (Exception e)
            {
                Tools.SkylightMessage("Unable to join room \"" + R.Id + "\": " + e.Message);
            }
        }

        /// <summary>
        ///     Disconnect the bot.
        /// </summary>
        public void Disconnect()
        {
            // Basically undo everything you already did.
            Connection.Disconnect();

            Client = null;
            Connection = null;
            IsConnected = false;
            Joined = false;
        }

        private void Refresh()
        {
            _storedVersion = Convert.ToString(Client.BigDB.Load("config", "config")["version"]);
        }

        #region In-game functions

        /// <summary>
        ///     Builds the specified block.
        /// </summary>
        /// <param name="id">The id of the block.</param>
        /// <param name="x">The x coordinate of the block (in block units).</param>
        /// <param name="y">The y coordinate of the block (in block units).</param>
        public void Build(int id, int x, int y)
        {
            Build(new Block(id, x, y));
        }

        /// <summary>
        ///     Builds the specified block object.
        /// </summary>
        /// <param name="theBlock">The block.</param>
        public void Build(Block theBlock)
        {
            if (R.Map[theBlock.X, theBlock.Y, theBlock.Z] == theBlock)
            {
                // don't bother writing a block to the map if it's already there.
                return;
            }
            if (!HasAccess)
            {
                Tools.SkylightMessage("The bot cannot build because it is unauthorized.");
                return;
            }
            try
            {
                if (theBlock is CoinBlock)
                {
                    var c = theBlock as CoinBlock;

                    Connection.Send(R.RoomKey, c.Z, c.X, c.Y, c.Id, c.CoinsRequired);
                }
                else if (theBlock is PercussionBlock)
                {
                    var p = theBlock as PercussionBlock;

                    Connection.Send(R.RoomKey, p.Z, p.X, p.Y, p.Id, p.PercussionId);
                }
                else if (theBlock is PianoBlock)
                {
                    var p = theBlock as PianoBlock;

                    Connection.Send(R.RoomKey, p.Z, p.X, p.Y, p.Id, p.PianoId);
                }
                else if (theBlock is PortalBlock)
                {
                    var p = theBlock as PortalBlock;

                    Connection.Send(R.RoomKey, p.Z, p.X, p.Y, p.Id, p.Direction, p.PortalId, p.PortalDestination);
                }
                else if (theBlock is RoomPortalBlock)
                {
                    var r = theBlock as RoomPortalBlock;

                    Connection.Send(R.RoomKey, r.Z, r.X, r.Y, r.Id, r.PortalDestination);
                }
                else if (theBlock is TextBlock)
                {
                    var t = theBlock as TextBlock;
                    Connection.Send(R.RoomKey, t.Z, t.X, t.Y, t.Id, t.Text);
                }
                else
                {
                    
                    Connection.Send(R.RoomKey, theBlock.Z, theBlock.X, theBlock.Y, theBlock.Id, theBlock.Direction);
                }


                Thread.Sleep(BlockDelay);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Build before connecting");
            }
        }

        /// <summary>
        ///     Builds the specified block list.
        /// </summary>
        /// <param name="blockList">The block list.</param>
        public void Build(List<Block> blockList)
        {
            var tempList = new List<Block>();
            tempList.AddRange(blockList);

            foreach (var b in tempList)
            {
                if (R.Map[b.X, b.Y, b.Z] == b)
                {
                    // don't bother writing a block to the map if it's already there.
                    return;
                }
                Build(b); // this line has problems but I fixed it in a weird way.
            }
        }

        /// <summary>
        ///     Clears the entire world.
        /// </summary>
        public void ClearWorld()
        {
            try
            {
                Connection.Send("clear");
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Clear before connecting");
            }
        }

        /// <summary>
        ///     Inputs the edit key.
        /// </summary>
        /// <param name="editKey">The edit key.</param>
        public void InputCode(string editKey)
        {
            if (String.IsNullOrWhiteSpace(editKey))
            {
                throw new ArgumentException("editKey cannot be empty or null.");
            }

            try
            {
                Connection.Send("access", editKey);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.InputCode before connecting");
            }
        }

        /// <summary>
        ///     Kicks the specified player by their username.
        /// </summary>
        /// <param name="name">The username.</param>
        /// <param name="reason">The reason.</param>
        public void Kick(string name, string reason = "")
        {
            if (IsOwner)
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
            if (IsOwner)
            {
                Say("/kick " + p.Name + " " + reason);
            }
        }

        /// <summary>
        ///     Resets the level to its state when it was last saved.
        /// </summary>
        public void Loadlevel()
        {
            if (IsOwner)
            {
                Say("/loadlevel");
            }
            else
            {
                throw new Exception("You are not authorized to load the level.");
            }
        }

        /// <summary>
        ///     Moves the bot.
        /// </summary>
        /// <param name="m">The movement Message Object.</param>
        public void Move(Message m)
        {
            try
            {
                Connection.Send(
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
            catch (NullReferenceException)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Move before connecting");
            }
        }

        /// <summary>
        ///     Moves the bot.
        /// </summary>
        /// <param name="hSpeed">The horizontal speed.</param>
        /// <param name="vSpeed">The vertical speed. (-52 when jumping)</param>
        /// <param name="hMod">The horizontal acceleration. (usually -1 or 2)</param>
        /// <param name="vMod">The vertical acceleration. (usually -1 or 2)</param>
        /// <param name="hDirection">-1 is left, 0 is neither, 1 is right.</param>
        /// <param name="vDirection">-1 is up, 0 is neither, 1 is down.</param>
        public void Move(double hSpeed, double vSpeed,
            int hMod, int vMod, int hDirection, int vDirection)
        {
            try
            {
                Connection.Send("m", X, Y, hSpeed, vSpeed, hMod, vMod, hDirection, vDirection);
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Move before connecting");
            }
        }

        /// <summary>
        ///     Moves the bot.
        /// </summary>
        /// <param name="up">True if the up/'W' key should be pressed, False if not. If this is true, "down" must be false.</param>
        /// <param name="down">True if the down/'S' key should be pressed, False if not. If this is true, "up" must be false.</param>
        /// <param name="left">True if the left/'A' key should be pressed, False if not. If this is true, "right" must be false.</param>
        /// <param name="right">True if the right/'D' key should be pressed, False if not. If this is true, "left" must be false.</param>
        /// <param name="jump">True if the jump key/spacebar should be pressed, False" if not.</param>
        public void Move(bool up, bool down, bool left, bool right, bool jump)
        {
            if (left && right)
                throw new Exception("Out.Move() does not allow you to move left and right at the same time.");
            if (up && down)
                throw new Exception("Out.Move() does not allow you to move up and down at the same time.");

            var reset = new object[11] {X, Y, 0, 0, 0, 0, 0, 0, 0, false, false};

            var args = new object[11]
            {
                X, Y, 0,
                jump ? -52 : 0,
                left ? -1 : right ? 1 : 0,
                up ? -1 : down ? 2 : 0,
                left ? -1 : right ? 1 : 0,
                up ? -1 : down ? 1 : 0,
                0, false, false
            };

            Connection.Send("m", reset);
            Connection.Send("m", args);
        }

        /// <summary>
        ///     Returns all players to spawn and resets their coins.
        /// </summary>
        public void Reset()
        {
            if (IsOwner)
            {
                Say("/reset");
            }
        }

        /// <summary>
        ///     Respawns the specified Player object.
        /// </summary>
        /// <param name="p">The player.</param>
        public void Respawn(Player p)
        {
            if (IsOwner)
            {
                Say("/kill " + p.Name);
            }
        }

        /// <summary>
        ///     Respawns the specified player by their username.
        /// </summary>
        /// <param name="name">The username.</param>
        public void Respawn(string name)
        {
            if (IsOwner)
            {
                Say("/kill " + name);
            }
        }

        /// <summary>
        ///     Respawns everyone in the room.
        /// </summary>
        public void RespawnAll()
        {
            if (IsOwner)
            {
                Say("/respawnall");
            }
        }

        /// <summary>
        ///     Saves the world.
        /// </summary>
        public void Save()
        {
            try
            {
                if (IsOwner)
                {
                    Connection.Send("save");
                }
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Save before connecting");
            }
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
                        Connection.Send("say", s);
                        Thread.Sleep(SpeechDelay);
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
                    if (s.Length + ChatPrefix.Length <= 80)
                    {
                        Connection.Send("say", ChatPrefix + s);
                        Thread.Sleep(SpeechDelay);
                    }
                    else
                    {
                        // Say what you can.
                        Say(s.Substring(0, 80 - ChatPrefix.Length));

                        // Delete what you just said.
                        s = s.Substring(80 - ChatPrefix.Length);

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
        ///     Toggle all potion bans.
        /// </summary>
        /// <param name="value">if set to <c>true</c> then turn on potions.</param>
        public void SetAllPotionBans(bool shouldSetPotionBan)
        {
            try
            {
                if (IsOwner)
                {
                    Connection.Send("allowpotions", shouldSetPotionBan);
                }
                else
                {
                    throw new Exception("You are not authorized to allow potions.");
                }
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.SetAllPotionBans before connecting");
            }
        }

        /// <summary>
        ///     Sets the edit key for the current room.
        /// </summary>
        /// <param name="newCode">The new code.</param>
        public void SetCode(string newCode)
        {
            if (IsOwner)
            {
                Connection.Send("key", newCode);
            }
        }

        /// <summary>
        ///     Sets the edit of a player.
        /// </summary>
        /// <param name="name">The username of the player.</param>
        /// <param name="value">if set to <c>true</c> then the player will receive edit privileges.</param>
        public void SetEdit(string name, bool shouldSetEdit)
        {
            if (!IsOwner) return;
            if (shouldSetEdit)
            {
                Say("/giveedit " + name);
            }
            else
            {
                Say("/removeedit " + name);
            }
        }

        /// <summary>
        ///     Sets the edit for a Player object.
        /// </summary>
        /// <param name="p">The Player object.</param>
        /// <param name="value">if set to <c>true</c> then the Player object recieves edit.</param>
        public void SetEdit(Player p, bool shouldSetEdit)
        {
            if (!IsOwner) return;
            if (shouldSetEdit)
            {
                Say("/giveedit " + p.Name);
            }
            else
            {
                Say("/removeedit " + p.Name);
            }
        }

        /// <summary>
        ///     Sets the god mode for the bot.
        /// </summary>
        /// <param name="value">if set to <c>true</c> then the bot will go into god mode.</param>
        public void SetGod(bool shouldSetGodMode)
        {
            if (HasAccess)
            {
                Connection.Send("god", shouldSetGodMode);
            }
        }

        /// <summary>
        ///     Sets the mute for a player by their username. This will prevent chat messages from being
        ///     sent from that player to the server.
        /// </summary>
        /// <param name="name">The username.</param>
        /// <param name="value">if set to <c>true</c> then that username will be muted.</param>
        public void SetMute(string name, bool shouldMute)
        {
            if (shouldMute)
            {
                Say("/mute " + name);
            }
            else
            {
                Say("/unmute " + name);
            }
        }

        /// <summary>
        ///     Sets the mute for a Player object.
        /// </summary>
        /// <param name="p">The Player.</param>
        /// <param name="value">if set to <c>true</c> then that Player.subject object will be muted.</param>
        public void SetMute(Player p, bool shouldMute)
        {
            if (shouldMute)
            {
                Say("/mute " + p.Name);
            }
            else
            {
                Say("/unmute " + p.Name);
            }
        }

        /// <summary>
        ///     Sets the potion ban.
        /// </summary>
        /// <param name="potionId">The potion id.</param>
        /// <param name="value">if set to <c>true</c> then potions will be turned on for that potion.</param>
        public void SetPotionBan(int potionId, bool shouldSetPotionBans)
        {
            if (IsOwner)
            {
                if (shouldSetPotionBans)
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
                Connection.Send(R.RoomKey + "f", smileyId);
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
        public void SetRoomVisibility(bool visbility)
        {
            if (IsOwner)
            {
                Say("/visible " + visbility);
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
                if (!String.IsNullOrWhiteSpace(s) ||
                    s.Length < 22)
                {
                    Connection.Send("name", s);
                }
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.SetTitle before connecting");
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
            if (IsOwner)
            {
                if (name != "")
                {
                    Say("/teleport " + name + " " + newXLocation + " " + newYLocation);
                }
                else
                {
                    Say("/teleport " + Name + " " + newXLocation + " " + newYLocation);
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
            if (IsOwner)
            {
                if (p != null)
                {
                    Say("/teleport " + p.Name + " " + newXLocation + " " + newYLocation);
                }
                else
                {
                    Say("/teleport " + Name + " " + newXLocation + " " + newYLocation);
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
            if (IsOwner)
            {
                foreach (var p in R.OnlinePlayers)
                {
                    Teleport(newXLocation, newYLocation, p);
                }
            }
        }

        #endregion
    }
}