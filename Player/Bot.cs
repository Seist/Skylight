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
        private Receiver _receiver;

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
            AccountType accType = AccountType.Regular) : base(r, 0, string.Empty, 0, 0, 0, false, false, false, 0, false, false, 0)
        {
            _emailOrToken = emailOrToken;
            _passwordOrToken = passwordOrToken;
            R = r;
            _accType = accType;
            ShouldTickAll = true;
            BlockDelay = 10;
            SpeechDelay = 750;

            ChatPrefix = "";
        }

        public bool Verbose = true;

        /// <summary>
        ///     Whether or not the bot is connected to the world.
        /// </summary>
        public bool IsConnected { get; internal set; }

        public bool HasFavorited { get; internal set; }

        public bool HasLiked { get; internal set; }

        public bool CanChangeRoomOptions { get; internal set; }

        public bool IsCrewMember { get; internal set; }

        /// <summary>
        ///     The room the bot is joined to.
        /// </summary>
        public bool Joined { internal get; set; }

        /// <summary>
        ///     If the physics clock should tick or not.
        /// </summary>
        public bool ShouldTickAll
        {
            get
        {
            return true;
        }
            set
            {
                // do nothing.
            }
        }

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

        /// <summary>
        ///     Join the room that was already set.
        /// </summary>
        /// <param name="createRoom"></param>
        public void Join(bool createRoom = true)
        {
            try {
                this.Client = PlayerIO.QuickConnect.SimpleConnect("everybody-edits-su9rn58o40itdbnw69plyw", this._emailOrToken, this._passwordOrToken, null);
                this.Connection = Client.Multiplayer.JoinRoom(this.R.Id, new Dictionary<string, string>());
                
                // Update room data
                if (!Room.JoinedRooms.Contains(R))
                    Room.JoinedRooms.Add(R);

                // Everyone gets a connection.
                R.Connections.Add(Connection);

                /*
                 * Brief explanation of "Receiver"
                 * Receivers process EE messages
                 * If there is just one bot, there are two receivers, one for messages unique to this bot ("personal"),
                 * and one for messages that have nothing to do with the bot
                 * 
                 * Every additional bot after the first one gets an impersonal receiver.
                 */

                // Every bot gets a personal receiver.
                _receiver = new Receiver(this.R, this, Connection, true);
                Connection.OnMessage += _receiver.OnMessage;

                //
                R.Receivers.Add(_receiver);

                if (!R.HasReceiver)
                {
                    R.MainReceiver = new Receiver(this.R, this, Connection, false);

                    Connection.OnMessage += R.MainReceiver.OnMessage;
                    R.MainReceiver.Source = R;

                    R.HasReceiver = true;
                    R.MainReceiver.IsPersonal = false;

                    R.ReceiverBot = this;
                    R.MainReceiver.Bot = this;
                }

                // Once everything is internal settled, send the init.
                Connection.Send("init");
                Connection.Send("init2");

                R.OnlinePlayers.Add(this);

                Joined = true;

                while (!R.BlocksLoaded);
            }
            catch (Exception e)
            {
                Tools.SkylightMessage("Unable to join room \"" + R.Id + "\": " + e);
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
            List<int> verslist = new List<int>();
            try
            {
                Client versClient;
                Connection versCon;
                versClient = PlayerIO.QuickConnect.SimpleConnect("everybody-edits-su9rn58o40itdbnw69plyw", "guest", "guest", null);
                versCon = versClient.Multiplayer.CreateJoinRoom("PWROOM", "0", true, new Dictionary<string, string>(), new Dictionary<string, string>());
            }
            catch (PlayerIOError m)
            {
                _storedVersion = m.Message;
                string[] eevers;
                eevers = _storedVersion.Split(' ');
                foreach (string s in eevers)
                {
                    if (s.StartsWith("Everybodyedits"))
                    {
                        int num = int.Parse(s.Replace("Everybodyedits", "").Replace(",", ""));
                        verslist.Add(num);
                    }
                }
                _storedVersion = verslist[verslist.Count - 1].ToString();
            }
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
            if (R.Map.BlockAt(theBlock.X, theBlock.Y, theBlock.Z) == theBlock)
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
            catch (Exception e)
            {
                Tools.SkylightMessage("Error in Bot.Build: " + e.ToString());
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

            foreach (Block b in tempList)
            {
                if (R.Map.BlockAt(b.X, b.Y, b.Z) == b)
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

            var reset = new object[11] { X, Y, 0, 0, 0, 0, 0, 0, 0, false, false};

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
        public void Say(string s = "", bool useChatPrefix = true)
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
            catch (Exception e)
            {
                Tools.SkylightMessage(e.ToString());
            }

            /*
            var chatPieces = SplitOnLength(s, 80 - (useChatPrefix ? ChatPrefix.Length : 0));

            foreach (var aPiece in chatPieces)
            {
                this.say((useChatPrefix ? ChatPrefix : "") + aPiece);
            }*/
        }

        // This code was directly copied from http://stackoverflow.com/questions/4556151/
        public enum WordPolicy
        {
            None,
            ThrowIfTooLong,
            CutIfTooLong
        }

        public static IEnumerable<string> SplitOnLength(string input, int length, WordPolicy wordPolicy = WordPolicy.CutIfTooLong)
        {
            int index = 0;
            while (index < input.Length)
            {
                int stepsBackward = 0;

                if (index + length < input.Length)
                {
                    if (wordPolicy != WordPolicy.None)
                    {
                        yield return GetBiggestAllowableSubstring(input, index, length, wordPolicy, out stepsBackward);
                    }
                    else
                    {
                        yield return input.Substring(index, length);
                    }
                }
                else
                {
                    yield return input.Substring(index);
                }

                index += (length - stepsBackward);
            }
        }

        static string GetBiggestAllowableSubstring(string input, int index, int length, WordPolicy wordPolicy, out int stepsBackward)
        {
            stepsBackward = 0;

            int lastIndex = index + length - 1;

            if (!char.IsWhiteSpace(input[lastIndex + 1]))
            {
                int adjustedLastIndex = input.LastIndexOf(' ', lastIndex, length);
                stepsBackward = lastIndex - adjustedLastIndex;
                lastIndex = adjustedLastIndex;
            }

            if (lastIndex == -1)
            {
                if (wordPolicy == WordPolicy.ThrowIfTooLong)
                {
                    throw new ArgumentOutOfRangeException("The input string contains at least one word greater in length than the specified length.");
                }
                else
                {
                    stepsBackward = 0;
                    lastIndex = index + length - 1;
                }
            }

            return input.Substring(index, lastIndex - index + 1);
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
        /// <param name="shouldSetEdit">if set to <c>true</c> then the player will receive edit privileges.</param>
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
        /// <param name="shouldSetEdit">if set to <c>true</c> then the Player object recieves edit.</param>
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
        /// <param name="shouldSetGodMode">if set to <c>true</c> then the bot will go into god mode.</param>
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
        /// <param name="shouldMute">if set to <c>true</c> then that username will be muted.</param>
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
        /// <param name="shouldMute">if set to <c>true</c> then that Player.subject object will be muted.</param>
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
        /// <param name="visbility">if set to <c>true</c> then the bot will become visible.</param>
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
                if (!String.IsNullOrWhiteSpace(s) &&
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
            if (!IsOwner) return;
            if (name != string.Empty)
            {
                Say("/teleport " + name + " " + newXLocation + " " + newYLocation);
            }
            else
            {
                Say("/teleport " + Name + " " + newXLocation + " " + newYLocation);
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
            if (!IsOwner) return;
            if (p != null)
            {
                Say("/teleport " + p.Name + " " + newXLocation + " " + newYLocation);
            }
            else
            {
                Say("/teleport " + Name + " " + newXLocation + " " + newYLocation);
            }
        }

        /// <summary>
        ///     Teleports all.
        /// </summary>
        /// <param name="newXLocation">The new x location.</param>
        /// <param name="newYLocation">The new y location.</param>
        public void TeleportAll(int newXLocation, int newYLocation)
        {
            if (!IsOwner) return;
            foreach (Player p in R.OnlinePlayers)
            {
                Teleport(newXLocation, newYLocation, p);
            }
        }

        #endregion
    }
}