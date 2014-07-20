using System;
using System.Collections.Generic;
using PlayerIOClient;
using Skylight.Miscellaneous;
using Skylight.Blocks;
using System.Threading;

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

        private int
            _blockDelay = 10;

        private string _chatPrefix = "";

        private int
            _speechDelay = 1000;

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
            string emailOrToken = Tools.GuestEmail,
            string passwordOrToken = Tools.GuestPassword,
            AccountType accType = AccountType.Regular)
            : base(
                r, 0, "", 0, 0.0, 0.0, false, false, true, 0, false, false, 0, false, false, false, false, false, false)
        {
            Push = new Out();
            _emailOrToken = emailOrToken;
            _passwordOrToken = passwordOrToken;
            R = r;
            _accType = accType;
            ShouldTick = true;
        }

        /// <summary>
        ///     Whether or not the bot is connected to the world.
        /// </summary>
        public bool IsConnected { get; internal set; }

        /// <summary>
        ///     The room the bot is joined to.
        /// </summary>
        public bool Joined { get; internal set; }

        /// <summary>
        ///     If the physics clock should tick or not.
        /// </summary>
        public bool ShouldTick { get; set; }

        /// <summary>
        ///     The PlayerIO client class.
        /// </summary>
        public Client Client { get; internal set; }

        /// <summary>
        ///     The delay between block messages to the server in milliseconds.
        /// </summary>
        public int BlockDelay
        {
            get { return _blockDelay; }

            set { _blockDelay = value; }
        }

        /// <summary>
        ///     The delay between speech messages to the server in milliseconds.
        /// </summary>
        public int SpeechDelay
        {
            get { return _speechDelay; }

            set { _speechDelay = value; }
        }

        /// <summary>
        ///     The prefix to add to all outgoing chat messages.
        /// </summary>
        public string ChatPrefix
        {
            get { return _chatPrefix; }

            set { _chatPrefix = value; }
        }

        /// <summary>
        ///     The object where the events go to the server.
        /// </summary>
        public Out Push { get; internal set; }

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
        public void LogIn()
        {
            try
            {
                switch (_accType)
                {
                    case AccountType.Regular:
                        if (_emailOrToken == Tools.GuestEmail && _passwordOrToken == Tools.GuestPassword)
                            Client = Tools.GuestClient.Value;
                        else
                            Client = PlayerIO.QuickConnect.SimpleConnect(Tools.GameId, _emailOrToken, _passwordOrToken);
                        break;

                    case AccountType.Facebook:
                        Client = PlayerIO.QuickConnect.FacebookOAuthConnect(Tools.GameId, _emailOrToken, null);
                        break;

                    case AccountType.Kongregate:
                        Client = PlayerIO.QuickConnect.KongregateConnect(Tools.GameId, _emailOrToken, _passwordOrToken);
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
                                Client = PlayerIO.Connect(Tools.GameId, "secure",
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

                while (!R.BlocksLoaded)
                {
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
            Push = null;
            IsConnected = false;
            Joined = false;
        }

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
                return;
            }
            if (!this.HasAccess)
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

        private void Refresh()
        {
            _storedVersion = Convert.ToString(Client.BigDB.Load("config", "config")["version"]);
        }
    }
}