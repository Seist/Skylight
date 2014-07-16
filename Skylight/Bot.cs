using System;
using System.Collections.Generic;
using PlayerIOClient;

namespace Skylight
{
    public class Bot : Player
    {
        /// <summary>
        /// All of the possible account types. Defaults to Regular if unknown.
        /// </summary>
        public enum AccountType : sbyte
        {
            /// <summary>
            /// The regular login method via email and password on the official
            /// everybodyedits.com website.
            /// </summary>
            Regular = 0,
            /// <summary>
            /// Facebook login using an auth token.
            /// </summary>
            Facebook = 1,
            /// <summary>
            /// Kongregate login using a kongregate user id (an integer) and an auth token.
            /// </summary>
            Kongregate = 2,
            /// <summary>
            /// ArmorGames login using a user token and a password token, both of which are 32
            /// chars long and hex.
            /// </summary>
            ArmorGames = 3
        }

        private static string storedVersion;
        private readonly AccountType accType;

        private readonly string
            emailOrToken,
            passwordOrToken;

        private int
            blockDelay = 10;

        private string chatPrefix = "";
        private Client client;

        private Connection connection;

        private bool
            isConnected,
            joined;

        private Out push = new Out();

        private Room r = new Room(null);

        private int
            speechDelay = 1000;

        /// <param name="password">Make this field null if it isn't needed for your log-in method.</param>
        public Bot(Room r,
            string emailOrToken = Tools.GuestEmail,
            string passwordOrToken = Tools.GuestPassword,
            AccountType accType = AccountType.Regular)
            : base(r, 0, "", 0, 0.0, 0.0, false, false, true, 0, false, false, 0)
        {
            this.emailOrToken = emailOrToken;
            this.passwordOrToken = passwordOrToken;
            R = r; //
            this.accType = accType;
            ShouldTick = true;
        }

        public bool IsConnected
        {
            get { return isConnected; }

            internal set { isConnected = value; }
        }

        public bool Joined
        {
            get { return joined; }
            internal set { joined = value; }
        }

        public bool ShouldTick { get; set; }

        public Client Client
        {
            get { return client; }

            internal set { client = value; }
        }

        public int BlockDelay
        {
            get { return blockDelay; }

            set { blockDelay = value; }
        }

        public int SpeechDelay
        {
            get { return speechDelay; }

            set { speechDelay = value; }
        }

        public string ChatPrefix
        {
            get { return chatPrefix; }

            set { chatPrefix = value; }
        }

        public Out Push
        {
            get { return push; }

            internal set { push = value; }
        }

        public Room R { get; internal set; }

        public Connection Connection
        {
            get { return connection; }

            internal set { connection = value; }
        }

        public static Room currentRoom { get; set; }

        // Public methods
        public void LogIn()
        {
            try
            {
                switch (accType)
                {
                    case AccountType.Regular:
                        if (emailOrToken == Tools.GuestEmail && passwordOrToken == Tools.GuestPassword)
                            Client = Tools.GuestClient.Value;
                        else
                            Client = PlayerIO.QuickConnect.SimpleConnect(Tools.GameID, emailOrToken, passwordOrToken);
                        break;

                    case AccountType.Facebook:
                        Client = PlayerIO.QuickConnect.FacebookOAuthConnect(Tools.GameID, emailOrToken, null);
                        break;

                    case AccountType.Kongregate:
                        Client = PlayerIO.QuickConnect.KongregateConnect(Tools.GameID, emailOrToken, passwordOrToken);
                        break;

                    default: //case AccountType.ArmorGames:
                        Connection c = Tools.GuestClient.Value.Multiplayer.JoinRoom("", null);
                        c.OnMessage += (sender, message) =>
                        {
                            if (message.Type != "auth") return;

                            if (message.Count == 0)
                                Tools.SkylightMessage(
                                    "Cannot log in using ArmorGames. The response from the auth server is wrong.");
                            else
                            {
                                Client = PlayerIO.Connect(Tools.GameID, "secure",
                                    message.GetString(0), message.GetString(1),
                                    "armorgames");
                            }

                            c.Disconnect();
                        };

                        c.Send("auth", emailOrToken, passwordOrToken);
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
            R.Id = Tools.ParseURL(R.Id);

            try
            {
                if (createRoom)
                {
                    // Join room
                    Connection = Client.Multiplayer.CreateJoinRoom(
                        R.Id, // RoomId   (URL)
                        storedVersion, // RoomType (Server)
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
                var i = new In();
                i.IsPersonal = true;
                i.Source = R;
                i.Bot = this;
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

        private string Version(bool cached = true, string prefix = Tools.NormalRoom)
        {
            if (!cached || storedVersion == null)
                return prefix + Refresh();

            return prefix + storedVersion;
        }

        private string Refresh()
        {
            storedVersion = Convert.ToString(Client.BigDB.Load("config", "config")["version"]);
            return storedVersion;
        }
    }
}