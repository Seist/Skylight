// <author>TakoMan02</author>
// <summary>In.cs is s receiver and processor for every event that happens
// in the world it is in.</summary>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using PlayerIOClient;
using Skylight.Arguments;
using Skylight.Blocks;
using Skylight.Miscellaneous;
using Skylight.Physics;

namespace Skylight
{
    /// <summary>
    ///     The main class that takes in events from the playerio client.
    /// </summary>
    public class In
    {
        /// <summary>
        ///     The block event compiled from the message from the server.
        /// </summary>
        /// <param name="e">The block object.</param>
        public delegate void BlockEvent(BlockEventArgs e);

        /// <summary>
        ///     A chat event (when the player sends a message).
        /// </summary>
        /// <param name="e">The ChatEventArgs event.</param>
        public delegate void ChatEvent(ChatEventArgs e);

        /// <summary>
        ///     An event that concerns the player.
        /// </summary>
        /// <param name="e">The player object.</param>
        public delegate void PlayerEvent(PlayerEventArgs e);

        /// <summary>
        ///     Something changed in the room (for example the title).
        /// </summary>
        /// <param name="e">The room object.</param>
        public delegate void RoomEvent(RoomEventArgs e);

        private readonly Access _access;

        private readonly Add _add;
        private readonly AddSpecialBlock _addSpecialBlock;
        private readonly Autotext _autotext;
        private readonly BlockChanged _blockChanged;
        private readonly Chat _chat;
        private readonly ChatOld _chatOld;
        private readonly ClearMap _clearMap;
        private readonly CoinObject _coinObject;
        private readonly Crown _crown;
        private readonly FaceChange _faceChange;
        private readonly GetWoot _getWoot;
        private readonly GiveWizard2 _giveWizard2;
        private readonly GodMode _godMode;
        private readonly Grinch _grinch;
        private readonly Hide _hide;
        private readonly Info _info;
        private readonly LeftWorld _leftWorld;
        private readonly LevelChange _levelChange;
        private readonly Meta _meta;
        private readonly Moderator _moderator;
        private readonly Move _move;
        private readonly NoteBlock _noteBlock;
        private readonly OnCoinGet _onCoinGet;
        private readonly OnKill _onKill;
        private readonly Stopwatch _playerPhysicsStopwatch = new Stopwatch();
        private readonly Potion _potion;
        private readonly Potions _potions;
        private readonly List<Message> _prematureMessages = new List<Message>();
        private readonly RefreshShop _refreshShop;
        private readonly ResetWorld _resetWorld;
        private readonly Save _save;
        private readonly Show _show;
        private readonly SignBlock _signBlock;
        private readonly Tele _tele;
        private readonly Teleport _teleport;
        private readonly Trophy _trophy;
        private readonly Upgrade _upgrade;
        private readonly Witch _witch;
        private readonly Wizard _wizard;
        private readonly WootUp _wootUp;
        private readonly Wp _wp;
        private readonly Write _write;
        private Message _initMessage;
        private Thread _playerPhysicsThread;

        public In()
        {
            _add = new Add(this);
            _potions = new Potions(this);
            _autotext = new Autotext(this);
            _blockChanged = new BlockChanged(this);
            _coinObject = new CoinObject(this);
            _addSpecialBlock = new AddSpecialBlock(this);
            _noteBlock = new NoteBlock(this);
            _onCoinGet = new OnCoinGet(this);
            _clearMap = new ClearMap(this);
            _faceChange = new FaceChange(this);
            _grinch = new Grinch(this);
            _witch = new Witch(this);
            _wizard = new Wizard(this);
            _giveWizard2 = new GiveWizard2(this);
            _godMode = new GodMode(this);
            _hide = new Hide(this);
            _crown = new Crown(this);
            _onKill = new OnKill(this);
            _trophy = new Trophy(this);
            _signBlock = new SignBlock(this);
            _leftWorld = new LeftWorld(this);
            _levelChange = new LevelChange(this);
            _move = new Move(this);
            _moderator = new Moderator(this);
            _potion = new Potion(this);
            _refreshShop = new RefreshShop(this);
            _resetWorld = new ResetWorld(this);
            _chat = new Chat(this);
            _chatOld = new ChatOld(this);
            _save = new Save(this);
            _show = new Show(this);
            _tele = new Tele(this);
            _teleport = new Teleport(this);
            _meta = new Meta(this);
            _upgrade = new Upgrade(this);
            _wp = new Wp(this);
            _write = new Write(this);
            _getWoot = new GetWoot(this);
            _wootUp = new WootUp(this);
            _access = new Access(this);
            _info = new Info(this);
        }

        public Bot Bot { get; set; }

        public Room Source { get; set; }

        internal bool IsPersonal { get; set; }

        public Add Add
        {
            get { return _add; }
        }

        public Potions Potions
        {
            get { return _potions; }
        }

        public Autotext Autotext
        {
            get { return _autotext; }
        }

        public BlockChanged BlockChanged
        {
            get { return _blockChanged; }
        }

        public CoinObject CoinObject
        {
            get { return _coinObject; }
        }

        public AddSpecialBlock AddSpecialBlock
        {
            get { return _addSpecialBlock; }
        }

        public NoteBlock NoteBlock
        {
            get { return _noteBlock; }
        }

        public OnCoinGet OnCoinGet
        {
            get { return _onCoinGet; }
        }

        public ClearMap ClearMap
        {
            get { return _clearMap; }
        }

        public FaceChange FaceChange
        {
            get { return _faceChange; }
        }

        public Grinch Grinch
        {
            get { return _grinch; }
        }

        public Witch Witch
        {
            get { return _witch; }
        }

        public Wizard Wizard
        {
            get { return _wizard; }
        }

        public GiveWizard2 GiveWizard2
        {
            get { return _giveWizard2; }
        }

        public GodMode GodMode
        {
            get { return _godMode; }
        }

        public Hide Hide
        {
            get { return _hide; }
        }

        public Crown Crown
        {
            get { return _crown; }
        }

        public OnKill OnKill1
        {
            get { return _onKill; }
        }

        public Trophy Trophy
        {
            get { return _trophy; }
        }

        public SignBlock SignBlock
        {
            get { return _signBlock; }
        }

        public LeftWorld LeftWorld
        {
            get { return _leftWorld; }
        }

        public LevelChange LevelChange
        {
            get { return _levelChange; }
        }

        public Move Move
        {
            get { return _move; }
        }

        public Moderator Moderator
        {
            get { return _moderator; }
        }

        public Potion Potion
        {
            get { return _potion; }
        }

        public RefreshShop RefreshShop
        {
            get { return _refreshShop; }
        }

        public ResetWorld ResetWorld
        {
            get { return _resetWorld; }
        }

        public Chat Chat
        {
            get { return _chat; }
        }

        public ChatOld ChatOld
        {
            get { return _chatOld; }
        }

        public Save Save
        {
            get { return _save; }
        }

        public Show Show
        {
            get { return _show; }
        }

        public Tele Tele
        {
            get { return _tele; }
        }

        public Teleport Teleport
        {
            get { return _teleport; }
        }

        public Meta Meta
        {
            get { return _meta; }
        }

        public Upgrade Upgrade
        {
            get { return _upgrade; }
        }

        public Wp Wp
        {
            get { return _wp; }
        }

        public Write Write
        {
            get { return _write; }
        }

        public GetWoot GetWoot
        {
            get { return _getWoot; }
        }

        public WootUp WootUp
        {
            get { return _wootUp; }
        }

        public Access Access
        {
            get { return _access; }
        }

        public Info Info
        {
            get { return _info; }
        }

        /// <summary>
        ///     All of the delegates for BlockEvent. These fire when events occur
        ///     (such as when a block was added or updated).
        /// </summary>
        public event BlockEvent
            CoinBlockEvent = delegate { } , PortalBlockEvent = delegate { };

        /// <summary>
        ///     When a sign block is placed in the world.
        /// </summary>
        protected virtual void OnSignBlockEvent(Message m)
        {
            _signBlock.OnSignBlockEvent(m);
        }

        /// <summary>
        ///     All events that concern the player. This includes many messages that the player
        ///     gets from the world (such as server information and leveling up). Mostly these
        ///     events are shown from the server directly to the user in the form of a dialog
        ///     box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event PlayerEvent
            AddEvent = delegate { } , LoseAccessEvent = delegate { } , TickEvent = delegate { };

        /// <summary>
        ///     Delegates for RoomEvent. Are only invoked when commands that concern
        ///     the room's state (such as global clear, potion toggling and saved) for just
        ///     a few examples.
        /// </summary>
        public event RoomEvent InitEvent = delegate { };

        internal void OnMessage(object sender, Message m)
        {
            // The order in which things are sent is jacked up, so we need to reorder them.
            // Until we get the init message (ie until the room is initialized), don't do anything.
            // Then, when the room is initialized, parse the messages.

            try
            {
                if (!Source.IsInitialized)
                {
                    if (!IsPersonal)
                    {
                        if (m.Type == "init")
                        {
                            OnInit(m);
                        }
                        else if (m.Type == "add")
                        {
                            Add.OnAdd(m);
                        }
                        else
                        {
                            _prematureMessages.Add(m);
                        }
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
                                OnSignBlockEvent(m);
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
            Source.Owner = Tools.GetPlayerByName(owner, Source);
            Source.Plays = plays;
            Source.Woots = woots;
            Source.TotalWoots = totalWoots;
            Source.RoomKey = worldKey;
            Source.Height = height;
            Source.Width = width;
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


        private void OnLostAccess(Message m)
        {
            // Nothing to extract from message.
            // Update relevant objects.
            Bot.HasAccess = false;

            // Fire the event.
            var e = new PlayerEventArgs(Bot, Source, m);

            Source.Pull.LoseAccessEvent(e);
        }

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

        private void LoadBlocks()
        {
            foreach (Block b in Tools.DeserializeInit(_initMessage, 18, Source))
            {
                Source.Map[b.X, b.Y, b.Z] = b;
            }

            Source.BlocksLoaded = true;

            Thread.Sleep(1000);

            _playerPhysicsThread = new Thread(UpdatePhysics);
            _playerPhysicsThread.Start();
        }

        private void UpdatePhysics()
        {
            _playerPhysicsStopwatch.Start();

            long accumulator = 0;

            while (Bot.ShouldTick)
            {
                try
                {
                    if (_playerPhysicsStopwatch.ElapsedMilliseconds >= accumulator + Config.PhysicsMsPerTick)
                    {
                        accumulator += Config.PhysicsMsPerTick;

                        foreach (Player player in Source.OnlinePlayers)
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