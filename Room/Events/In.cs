using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using PlayerIOClient;
using Skylight.Blocks;

namespace Skylight
{
    /// <summary>
    /// The main class that takes in events from the playerio client.
    /// </summary>
    public sealed class In
    {
        /// <summary>
        /// The block event compiled from the message from the server.
        /// </summary>
        /// <param name="e">The block object.</param>
        public delegate void BlockEvent(BlockEventArgs e);

        /// <summary>
        /// A chat event (when the player sends a message).
        /// </summary>
        /// <param name="e">The ChatEventArgs event.</param>
        public delegate void ChatEvent(ChatEventArgs e);

        /// <summary>
        /// An event that concerns the player.
        /// </summary>
        /// <param name="e">The player object.</param>
        public delegate void PlayerEvent(PlayerEventArgs e);

        /// <summary>
        /// Something changed in the room (for example the title).
        /// </summary>
        /// <param name="e">The room object.</param>
        public delegate void RoomEvent(RoomEventArgs e);

        /// <summary>
        /// The player physics stopwatch
        /// </summary>
        private readonly Stopwatch _playerPhysicsStopwatch = new Stopwatch();
        /// <summary>
        /// The premature messages
        /// </summary>
        private readonly List<Message> _prematureMessages = new List<Message>();
        /// <summary>
        /// The init message
        /// </summary>
        private Message _initMessage;
        /// <summary>
        /// The player physics thread
        /// </summary>
        private Thread _playerPhysicsThread;

        /// <summary>
        /// Initializes a new instance of the <see cref="In"/> class.
        /// </summary>
        public In()
        {
            Add = new Add(this);
            Potions = new Potions(this);
            Autotext = new Autotext(this);
            BlockChanged = new BlockChanged(this);
            CoinObject = new CoinObject(this);
            AddSpecialBlock = new AddSpecialBlock(this);
            NoteBlock = new NoteBlock(this);
            OnCoinGet = new OnCoinGet(this);
            ClearMap = new ClearMap(this);
            FaceChange = new FaceChange(this);
            Grinch = new Grinch(this);
            Witch = new Witch(this);
            Wizard = new Wizard(this);
            GiveWizard2 = new GiveWizard2(this);
            GodMode = new GodMode(this);
            Hide = new Hide(this);
            Crown = new Crown(this);
            OnKill1 = new OnKill(this);
            Trophy = new Trophy(this);
            SignBlock = new SignBlock(this);
            LeftWorld = new LeftWorld(this);
            LevelChange = new LevelChange(this);
            Move = new Move(this);
            Moderator = new Moderator(this);
            Potion = new Potion(this);
            RefreshShop = new RefreshShop(this);
            ResetWorld = new ResetWorld(this);
            Chat = new Chat(this);
            ChatOld = new ChatOld(this);
            Save = new Save(this);
            Show = new Show(this);
            Tele = new Tele(this);
            Teleport = new Teleport(this);
            Meta = new Meta(this);
            Upgrade = new Upgrade(this);
            Wp = new Wp(this);
            Write = new Write(this);
            GetWoot = new GetWoot(this);
            WootUp = new WootUp(this);
            Access = new Access(this);
            Info = new Info(this);
        }

        /// <summary>
        /// Gets or sets the bot.
        /// </summary>
        /// <value>The bot.</value>
        public Bot Bot { get; set; }

        /// <summary>
        /// Gets or sets the source (room source).
        /// </summary>
        /// <value>The source.</value>
        public Room Source { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is personal.
        /// </summary>
        /// <value><c>true</c> if this instance is personal; otherwise, <c>false</c>.</value>
        internal bool IsPersonal { private get; set; }

        /// <summary>
        /// Gets the add.
        /// </summary>
        /// <value>The add.</value>
        public Add Add { get; private set; }

        /// <summary>
        /// Gets the potions.
        /// </summary>
        /// <value>The potions.</value>
        public Potions Potions { get; private set; }

        /// <summary>
        /// Gets the autotext.
        /// </summary>
        /// <value>The autotext.</value>
        public Autotext Autotext { get; private set; }

        /// <summary>
        /// Gets the block changed.
        /// </summary>
        /// <value>The block changed.</value>
        public BlockChanged BlockChanged { get; private set; }

        /// <summary>
        /// Gets the coin object.
        /// </summary>
        /// <value>The coin object.</value>
        public CoinObject CoinObject { get; private set; }

        /// <summary>
        /// Gets the add special block.
        /// </summary>
        /// <value>The add special block.</value>
        public AddSpecialBlock AddSpecialBlock { get; private set; }

        /// <summary>
        /// Gets the note block.
        /// </summary>
        /// <value>The note block.</value>
        public NoteBlock NoteBlock { get; private set; }

        /// <summary>
        /// Gets the on coin get.
        /// </summary>
        /// <value>The on coin get.</value>
        public OnCoinGet OnCoinGet { get; private set; }

        /// <summary>
        /// Gets the clear map.
        /// </summary>
        /// <value>The clear map.</value>
        public ClearMap ClearMap { get; private set; }

        /// <summary>
        /// Gets the face change.
        /// </summary>
        /// <value>The face change.</value>
        public FaceChange FaceChange { get; private set; }

        /// <summary>
        /// Gets the grinch.
        /// </summary>
        /// <value>The grinch.</value>
        public Grinch Grinch { get; private set; }

        /// <summary>
        /// Gets the witch.
        /// </summary>
        /// <value>The witch.</value>
        public Witch Witch { get; private set; }

        /// <summary>
        /// Gets the wizard.
        /// </summary>
        /// <value>The wizard.</value>
        public Wizard Wizard { get; private set; }

        /// <summary>
        /// Gets the give wizard2.
        /// </summary>
        /// <value>The give wizard2.</value>
        public GiveWizard2 GiveWizard2 { get; private set; }

        /// <summary>
        /// Gets the god mode.
        /// </summary>
        /// <value>The god mode.</value>
        public GodMode GodMode { get; private set; }

        /// <summary>
        /// Gets the hide.
        /// </summary>
        /// <value>The hide.</value>
        public Hide Hide { get; private set; }

        /// <summary>
        /// Gets the crown.
        /// </summary>
        /// <value>The crown.</value>
        public Crown Crown { get; private set; }

        /// <summary>
        /// Gets the on kill1.
        /// </summary>
        /// <value>The on kill1.</value>
        public OnKill OnKill1 { get; private set; }

        /// <summary>
        /// Gets the trophy.
        /// </summary>
        /// <value>The trophy.</value>
        public Trophy Trophy { get; private set; }

        /// <summary>
        /// Gets the sign block.
        /// </summary>
        /// <value>The sign block.</value>
        public SignBlock SignBlock { get; private set; }

        /// <summary>
        /// Gets the left world.
        /// </summary>
        /// <value>The left world.</value>
        public LeftWorld LeftWorld { get; private set; }

        /// <summary>
        /// Gets the level change.
        /// </summary>
        /// <value>The level change.</value>
        public LevelChange LevelChange { get; private set; }

        /// <summary>
        /// Gets the move.
        /// </summary>
        /// <value>The move.</value>
        public Move Move { get; private set; }

        /// <summary>
        /// Gets the moderator.
        /// </summary>
        /// <value>The moderator.</value>
        public Moderator Moderator { get; private set; }

        /// <summary>
        /// Gets the potion.
        /// </summary>
        /// <value>The potion.</value>
        public Potion Potion { get; private set; }

        /// <summary>
        /// Gets the refresh shop.
        /// </summary>
        /// <value>The refresh shop.</value>
        public RefreshShop RefreshShop { get; private set; }

        /// <summary>
        /// Gets or sets the reset world.
        /// </summary>
        /// <value>The reset world.</value>
        private ResetWorld ResetWorld { get; set; }

        /// <summary>
        /// Gets the chat.
        /// </summary>
        /// <value>The chat.</value>
        public Chat Chat { get; private set; }

        /// <summary>
        /// Gets the chat old.
        /// </summary>
        /// <value>The chat old.</value>
        public ChatOld ChatOld { get; private set; }

        /// <summary>
        /// Gets the save.
        /// </summary>
        /// <value>The save.</value>
        public Save Save { get; private set; }

        /// <summary>
        /// Gets the show.
        /// </summary>
        /// <value>The show.</value>
        public Show Show { get; private set; }

        /// <summary>
        /// Gets the tele.
        /// </summary>
        /// <value>The tele.</value>
        public Tele Tele { get; private set; }

        /// <summary>
        /// Gets the teleport.
        /// </summary>
        /// <value>The teleport.</value>
        public Teleport Teleport { get; private set; }

        /// <summary>
        /// Gets the meta.
        /// </summary>
        /// <value>The meta.</value>
        public Meta Meta { get; private set; }

        /// <summary>
        /// Gets or sets the upgrade.
        /// </summary>
        /// <value>The upgrade.</value>
        private Upgrade Upgrade { get; set; }

        /// <summary>
        /// Gets the wp.
        /// </summary>
        /// <value>The wp.</value>
        public Wp Wp { get; private set; }

        /// <summary>
        /// Gets the write.
        /// </summary>
        /// <value>The write.</value>
        public Write Write { get; private set; }

        /// <summary>
        /// Gets the get woot.
        /// </summary>
        /// <value>The get woot.</value>
        public GetWoot GetWoot { get; private set; }

        /// <summary>
        /// Gets the woot up.
        /// </summary>
        /// <value>The woot up.</value>
        public WootUp WootUp { get; private set; }

        /// <summary>
        /// Gets the access.
        /// </summary>
        /// <value>The access.</value>
        public Access Access { get; private set; }

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <value>The information.</value>
        public Info Info { get; private set; }

        /// <summary>
        /// All of the delegates for BlockEvent. These fire when events occur
        /// (such as when a block was added or updated).
        /// </summary>
        public event BlockEvent
            CoinBlockEvent = delegate { };

        /// <summary>
        /// All of the delegates for BlockEvent. These fire when events occur
        /// (such as when a block was added or updated).
        /// </summary>
        public event BlockEvent
            PortalBlockEvent = delegate { };

        /// <summary>
        /// When a sign block is placed in the world.
        /// </summary>
        /// <param name="m">The m.</param>
        private void OnSignBlockEvent(Message m)
        {
        }

        /// <summary>
        /// All events that concern the player. This includes many messages that the player
        /// gets from the world (such as server information and leveling up). Mostly these
        /// events are shown from the server directly to the user in the form of a dialog
        /// box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event PlayerEvent
            AddEvent = delegate { };

        /// <summary>
        /// All events that concern the player. This includes many messages that the player
        /// gets from the world (such as server information and leveling up). Mostly these
        /// events are shown from the server directly to the user in the form of a dialog
        /// box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event PlayerEvent
            LoseAccessEvent = delegate { };

        /// <summary>
        /// All events that concern the player. This includes many messages that the player
        /// gets from the world (such as server information and leveling up). Mostly these
        /// events are shown from the server directly to the user in the form of a dialog
        /// box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event PlayerEvent
            TickEvent = delegate { };

        /// <summary>
        /// All events that concern the player. This includes many messages that the player
        /// gets from the world (such as server information and leveling up). Mostly these
        /// events are shown from the server directly to the user in the form of a dialog
        /// box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event PlayerEvent
            GuardianEvent = delegate { };

        /// <summary>
        /// Delegates for RoomEvent. Are only invoked when commands that concern
        /// the room's state (such as global clear, potion toggling and saved) for just
        /// a few examples.
        /// </summary>
        public event RoomEvent InitEvent = delegate { };

        /// <summary>
        /// Called when [message].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="m">The m.</param>
        internal void OnMessage(object sender, Message m)
        {
            // The order in which things are sent is jacked up, so we need to reorder them.
            // Until we get the init message (ie until the room is initialized), don't do anything.
            // Then, when the room is initialized, parse the messages.

            try
            {
                if (!Source.IsInitialized)
                {
                    if (IsPersonal) return;
                    switch (m.Type)
                    {
                        case "init":
                            OnInit(m);
                            break;
                        case "add":
                            Add.OnAdd(m);
                            break;
                        default:
                            _prematureMessages.Add(m);
                            break;
                    }
                }
                else
                {
                    if (!IsPersonal)
                    {
                        switch (Convert.ToString(m.Type))
                        {
                            case "add":
                                Add.OnAdd(m);
                                break;

                            case "allowpotions":
                                Potions.OnAllowPotions(m);
                                break;

                            case "autotext":
                                Autotext.OnAutotext(m);
                                break;

                            case "b":
                                BlockChanged.OnBlock(m);
                                break;

                            case "bc":
                                CoinObject.OnAddCoinDoorOrGate(m);
                                break;

                            case "br":
                                AddSpecialBlock.OnAddScifiOrSpikes(m);
                                break;

                            case "bs":
                                NoteBlock.OnAddNoteblock(m);
                                break;

                            case "c":
                                OnCoinGet.OnCoin(m);
                                break;

                            case "clear":
                                ClearMap.OnClear();
                                break;

                            case "face":
                                FaceChange.OnFace(m);
                                break;

                            case "givegrinch":
                                Grinch.OnGiveGrinch(m);
                                break;

                            case "givewitch":
                                Witch.OnGiveWitch(m);
                                break;

                            case "givewizard":
                                Wizard.OnGiveWizard(m);
                                break;

                            case "givewizard2":
                                GiveWizard2.OnGiveWizard2(m);
                                break;

                            case "god":
                                GodMode.OnGod(m);
                                break;
                            case "guardian":
                                OnGuardianMode(m);
                                break;
                            case "hide":
                                Hide.OnHide();
                                break;

                            case "k":
                                Crown.OnCrown(m);
                                break;

                            case "kill":
                                OnKill1.OnKillPlayer(m);
                                break;

                            case "ks":
                                Trophy.OnTrophy(m);
                                break;

                            case "lb":
                                SignBlock.OnSignBlockEvent(m);
                                break;

                            case "left":
                                LeftWorld.OnLeft(m);
                                break;

                            case "levelup":
                                LevelChange.OnLevelUp(m);
                                break;

                            case "m":
                                Move.OnMove(m);
                                break;

                            case "mod":
                                Moderator.OnMod(m);
                                break;

                            case "p":
                                Potion.OnP(m);
                                break;

                            case "pt":
                                OnPt(m);
                                break;

                            case "refreshshop":
                                RefreshShop.OnRefreshShop();
                                break;

                            case "reset":
                                ResetWorld.OnReset(m);
                                break;

                            case "say":
                                Chat.OnSay(m);
                                break;

                            case "say_old":
                                ChatOld.OnSayOld(m);
                                break;

                            case "saved":
                                Save.OnSaved();
                                break;

                            case "show":
                                Show.OnShow();
                                break;

                            case "tele":
                                Tele.OnTele(m);
                                break;

                            case "teleport":
                                Teleport.OnTeleport(m);
                                break;

                            case "ts":
                                OnTs(m);
                                break;

                            case "updatemeta":
                                Meta.OnUpdateMeta(m);
                                break;

                            case "upgrade":
                                Upgrade.OnUpgrade();
                                break;

                            case "wp":
                                Wp.OnWp(m);
                                break;

                            case "write":
                                Write.OnWrite(m);
                                break;

                            case "w":
                                GetWoot.OnGetWoot(m);
                                break;

                            case "wu":
                                WootUp.OnWootUp(m);
                                break;
                        }
                    }
                    else
                    {
                        switch (m.Type)
                        {
                            case "access":
                                Access.OnAccess(m);
                                break;

                            case "lostaccess":
                                OnLostAccess(m);
                                break;

                            case "init":
                                OnInit(m);
                                break;

                            case "info":
                                Info.OnInfo(m);
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Tools.SkylightMessage(e.ToString());
            }
        }

        /// <summary>
        /// Called when [guardian mode].
        /// </summary>
        /// <param name="m">The m.</param>
        private void OnGuardianMode(Message m)
        {
            int id = m.GetInteger(0);

            Player player = Tools.GetPlayer(id, Source);

            var e = new PlayerEventArgs(player, Source, null);
            Source.Pull.GuardianEvent(e);
        }


        /// <summary>
        /// Called when [initialize].
        /// </summary>
        /// <param name="m">The m.</param>
        private void OnInit(Message m)
        {
            // Extract data
            string owner = m.GetString(0),
                name = m.GetString(1),
                worldKey = Tools.Derot(m.GetString(5)),
                botName = m.GetString(9);

            int plays = m.GetInteger(2),
                woots = m.GetInteger(3),
                totalWoots = m.GetInteger(4),
                botId = m.GetInteger(6),
                width = m.GetInteger(12),
                height = m.GetInteger(13);

            double botX = m.GetDouble(7),
                botY = m.GetDouble(8),
                gravityMultiplier = m.GetDouble(15);

            bool isTutorialRoom = m.GetBoolean(14),
                potions = m.GetBoolean(16),
                hasAccess = m.GetBoolean(10),
                isOwner = m.GetBoolean(11);

            // Update relevant objects
            _initMessage = m;

            Bot.Name = botName;
            Bot.Id = botId;
            Bot.X = botX;
            Bot.Y = botY;
            Bot.HasAccess = hasAccess;
            Bot.IsOwner = isOwner;
            Bot.PlayingIn = Source;

            Source.OnlineBots.Add(Bot);

            if (Source.IsInitialized)
            {
                // You don't need to get the room data multiple times. Save time by returning.
                return;
            }

            // Update the room data.
            Source.Name = name;
            Source.Owner = Tools.GetPlayer(owner, Source);
            Source.Plays = plays;
            Source.Woots = woots;
            Source.TotalWoots = totalWoots;
            Source.RoomKey = worldKey;
            Source.Height = height;
            Source.Width = width;
            RoomAccessor.Width = width;
            RoomAccessor.Height = height;
            Source.PotionsAllowed = potions;
            Source.IsTutorialRoom = isTutorialRoom;
            Source.GravityMultiplier = gravityMultiplier;

            Source.IsInitialized = true;

            // Load the blocks
            var loadBlocks = new Thread(LoadBlocks);
            loadBlocks.Start();

            // Execute the messages that came prematurely.
            foreach (Message msg in _prematureMessages)
            {
                OnMessage(this, msg);
            }

            _prematureMessages.Clear();

            // Fire the event.
            var e = new RoomEventArgs(Source);

            Source.Pull.InitEvent(e);
        }


        /// <summary>
        /// Called when [lost access].
        /// </summary>
        /// <param name="m">The m.</param>
        private void OnLostAccess(Message m)
        {
            // Nothing to extract from message.
            // Update relevant objects.
            Bot.HasAccess = false;

            // Fire the event.
            var e = new PlayerEventArgs(Bot, Source, m);

            Source.Pull.LoseAccessEvent(e);
        }

        /// <summary>
        /// Called when [pt].
        /// </summary>
        /// <param name="m">The m.</param>
        private void OnPt(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                blockId = m.GetInteger(2),
                rotation = m.GetInteger(3),
                portalId = m.GetInteger(4),
                portalDestination = m.GetInteger(5);

            // Update relevant objects.
            bool isVisible = blockId == BlockIds.Action.Portals.Normal;

            var b = new PortalBlock(x, y, rotation, portalId, portalDestination, isVisible);

            Source.Map[x, y, 1] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, Source);

            Source.Pull.PortalBlockEvent(e);
        }

        /// <summary>
        /// Called when [ts].
        /// </summary>
        /// <param name="m">The m.</param>
        private void OnTs(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2);

            string text = m.GetString(3);

            // Update relevant objects.
            var b = new TextBlock(id, x, y, text);

            Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, Source);

            Source.Pull.CoinBlockEvent(e);
        }

        /// <summary>
        /// Loads the blocks.
        /// </summary>
        private void LoadBlocks()
        {
            foreach (Block b in Tools.DeserializeInit(_initMessage, 18, Source))
            {
                Source.Map[b.X, b.Y, b.Z] = b;
            }

            Source.BlocksLoaded = true;


            _playerPhysicsThread = new Thread(UpdatePhysics);
            _playerPhysicsThread.Start();
        }

        /// <summary>
        /// Updates the physics.
        /// </summary>
        private void UpdatePhysics()
        {
            _playerPhysicsStopwatch.Start();

            long accumulator = 0;

            while (Bot.ShouldTickAll)
            {
                try
                {
                    if (_playerPhysicsStopwatch.ElapsedMilliseconds >= accumulator + Config.PhysicsMsPerTick)
                    {
                        accumulator += Config.PhysicsMsPerTick;

                        foreach (Player player in Source.OnlinePlayers.Where(player => player.ShouldTick))
                        {
                            player.Tick();

                            var e = new PlayerEventArgs(player, Source, null);
                            Source.Pull.TickEvent(e);
                        }
                    }
                    else
                    {
                        //Since the timescales dealt with here should be subsecond, explicit unchecked casts
                        // to int should never overflow.
                        var difference = (int) (_playerPhysicsStopwatch.ElapsedMilliseconds - accumulator);
                        Thread.Sleep(difference);
                    }
                }
                catch (Exception e)
                {
                    Tools.SkylightMessage(e.ToString());
                }
            }
        }
    }
}