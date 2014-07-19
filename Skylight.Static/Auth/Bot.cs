using System;
using System.Collections.Generic;
using PlayerIOClient;
using Skylight.Miscellaneous;
using Rabbit;

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

        public void LogIn() { throw new Exception("Please use Join() instead.");}

        /// <summary>
        ///     Join the room that was already set.
        /// </summary>
        /// <param name="createRoom"></param>
        public void Join(bool createRoom = true)
        {

            // Parse the level ID (because some people like to put full URLs in).
            R.Id = Tools.ParseUrl(R.Id);

           var rabbitAuth = new Rabbit.Auth();

            try
            {
                Connection = rabbitAuth.LogIn(_emailOrToken, _passwordOrToken, R.Id);
            }
            catch (PlayerIOError e)
            {
                Tools.SkylightMessage("Cannot log in: " + e.Message);
                IsConnected = false;
                return;
            }
            IsConnected = true;
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

        private void Refresh()
        {
            _storedVersion = Convert.ToString(Client.BigDB.Load("config", "config")["version"]);
        }
    }
}