// <author>TakoMan02</author>
// <summary>In.cs is s receiver and processor for every event that happens in the world it is in.</summary>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using PlayerIOClient;
using Skylight.Physics;

namespace Skylight
{
    /// <summary>
    /// The main class that takes in events from the playerio client.
    /// </summary>
    public class In
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

        private readonly Stopwatch _playerPhysicsStopwatch = new Stopwatch();
        private readonly List<Message> _prematureMessages = new List<Message>();

        /// <summary>
        ///     These IDs do not have an associated Player id when sent.
        /// </summary>
        private readonly List<int> _specialBlockIds = new List<int>
        {
            BlockIds.Action.Switches.SWITCH,
            BlockIds.Action.Tools.TROPHY,
            BlockIds.Action.Doors.TIME,
            BlockIds.Action.Gates.TIME,
            BlockIds.Action.Doors.SWITCH,
            BlockIds.Action.Gates.SWITCH,
            BlockIds.Action.Doors.ZOMBIE,
            BlockIds.Action.Gates.ZOMBIE,
            BlockIds.Blocks.Secrets.NONSOLID,
            BlockIds.Action.Tools.SPAWN,
            BlockIds.Action.Cake.CAKE,
            BlockIds.Action.Tools.CHECKPOINT,
            BlockIds.Action.Hazards.FIRE
        };

        private Message _initMessage;
        private Thread _playerPhysicsThread;
        internal Bot Bot { get; set; }

        internal Room Source { get; set; }

        internal bool IsPersonal { get; set; }

        /// <summary>
        /// All of the delegates for BlockEvent. These fire when events occur
        /// (such as when a block was added or updated).
        /// </summary>
        public event BlockEvent
            CoinBlockEvent = delegate { } ,
            NormalBlockEvent = delegate { } ,
            PortalBlockEvent = delegate { } ,
            RoomPortalBlockEvent = delegate { } ,
            RotateEvent = delegate { } ,
            SignBlockEvent = delegate { } , // never invoked... hmm..
            SoundBlockEvent = delegate { };

        /// <summary>
        /// All of the delegates for ChatEvent. Chat events are when the player
        /// says something, and distinguishes between auto text and system messages
        /// and much more.
        /// </summary>
        public event ChatEvent
            AutotextEvent = delegate { } ,
            LabelEvent = delegate { } , // never invoked.
            NormalChatEvent = delegate { } ,
            SayOldEvent = delegate { } ,
            SystemMessageEvent = delegate { };

        /// <summary>
        /// All events that concern the player. This includes many messages that the player
        /// gets from the world (such as server information and leveling up). Mostly these
        /// events are shown from the server directly to the user in the form of a dialog
        /// box or by prefixing a chat message with *SYSTEM.
        /// </summary>
        public event PlayerEvent
            AddEvent = delegate { } ,
            CoinCollectedEvent = delegate { } ,
            CrownEvent = delegate { } ,
            DeathEvent = delegate { } ,
            FaceEvent = delegate { } ,
            GainAccessEvent = delegate { } ,
            GodEvent = delegate { } ,
            GrinchEvent = delegate { } ,
            InfoEvent = delegate { } ,
            JumpEvent = delegate { } ,
            LeaveEvent = delegate { } ,
            LevelUpEvent = delegate { } ,
            LoseAccessEvent = delegate { } ,
            MagicCoinEvent = delegate { } ,
            ModModeEvent = delegate { } ,
            MovementEvent = delegate { } ,
            PotionEvent = delegate { } ,
            RedWizardEvent = delegate { } ,
            TeleportEvent = delegate { } ,
            TickEvent = delegate { } ,
            TrophyEvent = delegate { } ,
            WitchEvent = delegate { } ,
            WizardEvent = delegate { } ,
            WootEvent = delegate { };

        /// <summary>
        /// Delegates for RoomEvent. Are only invoked when commands that concern
        /// the room's state (such as global clear, potion toggling and saved) for just
        /// a few examples.
        /// </summary>
        public event RoomEvent
            ClearEvent = delegate { } ,
            HideEvent = delegate { } ,
            InitEvent = delegate { } ,
            PotionToggleEvent = delegate { } ,
            RefreshshopEvent = delegate { } ,
            ResetEvent = delegate { } ,
            SavedEvent = delegate { } ,
            ShowEvent = delegate { } ,
            UpdateEvent = delegate { } ,
            UpdateMetaEvent = delegate { };

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
                            OnAdd(m);
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
                                OnAdd(m);
                                break;

                            case "allowpotions":
                                OnAllowPotions(m);
                                break;

                            case "autotext":
                                OnAutotext(m);
                                break;

                            case "b":
                                OnB(m);
                                break;

                            case "bc":
                                OnBc(m);
                                break;

                            case "br":
                                OnBr(m);
                                break;

                            case "bs":
                                OnBs(m);
                                break;

                            case "c":
                                OnC(m);
                                break;

                            case "clear":
                                OnClear();
                                break;

                            case "face":
                                OnFace(m);
                                break;

                            case "givegrinch":
                                OnGiveGrinch(m);
                                break;

                            case "givewitch":
                                OnGiveWitch(m);
                                break;

                            case "givewizard":
                                OnGiveWizard(m);
                                break;

                            case "givewizard2":
                                OnGiveWizard2(m);
                                break;

                            case "god":
                                OnGod(m);
                                break;

                            case "hide":
                                OnHide();
                                break;

                            case "k":
                                OnK(m);
                                break;

                            case "kill":
                                OnKill(m);
                                break;

                            case "ks":
                                OnKs(m);
                                break;

                            case "lb":
                                OnLb(m);
                                break;

                            case "left":
                                OnLeft(m);
                                break;

                            case "levelup":
                                OnLevelUp(m);
                                break;

                            case "m":
                                OnM(m);
                                break;

                            case "mod":
                                OnMod(m);
                                break;

                            case "p":
                                OnP(m);
                                break;

                            case "pt":
                                OnPt(m);
                                break;

                            case "refreshshop":
                                OnRefreshShop();
                                break;

                            case "reset":
                                OnReset(m);
                                break;

                            case "say":
                                OnSay(m);
                                break;

                            case "say_old":
                                OnSayOld(m);
                                break;

                            case "saved":
                                OnSaved();
                                break;

                            case "show":
                                OnShow(m);
                                break;

                            case "tele":
                                OnTele(m);
                                break;

                            case "teleport":
                                OnTeleport(m);
                                break;

                            case "ts":
                                OnTs(m);
                                break;

                            case "updatemeta":
                                OnUpdateMeta(m);
                                break;

                            case "upgrade":
                                OnUpgrade(m);
                                break;

                            case "wp":
                                OnWp(m);
                                break;

                            case "write":
                                OnWrite(m);
                                break;

                            case "w":
                                OnW(m);
                                break;

                            case "wu":
                                OnWu(m);
                                break;
                        }
                    }
                    else
                    {
                        switch (m.Type)
                        {
                            case "access":
                                OnAccess(m);
                                break;

                            case "lostaccess":
                                OnLostAccess(m);
                                break;

                            case "init":
                                OnInit(m);
                                break;

                            case "info":
                                OnInfo(m);
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

        private void OnAccess(Message m)
        {
            // Nothing to extract from message.
            // Update relevant objects.
            Bot.HasAccess = true;

            // Fire the event.
            var e = new PlayerEventArgs(Bot, Source, m);

            Source.Pull.GainAccessEvent(e);
        }

        private void OnAdd(Message m)
        {
            // Extract data.
            var name = m.GetString(1);

            int id = m.GetInteger(0),
                smiley = m.GetInteger(2),
                coins = m.GetInteger(8),
                xplevel = m.GetInteger(11);

            double x = m.GetDouble(3),
                y = m.GetDouble(4);

            bool isGod = m.GetBoolean(5),
                isMod = m.GetBoolean(6),
                hasBoost = m.GetBoolean(9),
                isFriend = m.GetBoolean(10),
                hasClub = m.GetBoolean(12); // never used.

            // Update relevant objects.
            var subject = new Player(Source, id, name, smiley, x, y, isGod, isMod, true, coins, hasBoost, isFriend,
                xplevel);

            Source.OnlinePlayers.Add(subject);

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.AddEvent(e);
        }

        private void OnAllowPotions(Message m)
        {
            // Extract data.
            var potions = m.GetBoolean(0);

            // Update relevant objects.
            Source.PotionsAllowed = potions;

            // Fire the event.
            var e = new RoomEventArgs(Source);

            Source.Pull.PotionToggleEvent(e);
        }

        private void OnAutotext(Message m)
        {
            // Extract data.
            var id = m.GetInteger(0);

            var message = m.GetString(1);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            var e = new ChatEventArgs(subject, Source);

            Source.Pull.AutotextEvent(e);
        }

        private void OnB(Message m)
        {
            // Extract data.
            int z = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2),
                blockId = m.GetInteger(3),
                playerId = m.GetInteger(4);

            // Update relevant objects.
            var b = new Block(blockId, x, y, z);

            if (!_specialBlockIds.Contains(blockId))
            {
                var subject = Tools.GetPlayerById(playerId, Source);

                b.Placer = subject;
            }

            Source.Map[x, y, z] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, Source);

            Source.Pull.NormalBlockEvent(e);
        }

        private void OnBc(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                coinsRequired = m.GetInteger(3);

            // Update relevant objects.
            var b = new CoinBlock(x, y, coinsRequired, false);

            if (id == BlockIds.Action.Gates.COIN)
            {
                b.IsGate = true;
            }

            Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, Source);

            Source.Pull.CoinBlockEvent(e);
        }

        private void OnBr(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                rotation = m.GetInteger(3),
                z = m.GetInteger(4);

            // Update relevant objects.
            var b = new Block(id, x, y, 0, rotation);

            Source.Map[x, y, z] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, Source);

            Source.Pull.RotateEvent(e);
        }

        private void OnBs(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                note = m.GetInteger(3);

            // Update relevant objects.
            Block b = null;

            if (id == BlockIds.Action.Music.PERCUSSION)
            {
                b = new PercussionBlock(x, y, note);
            }
            else if (id == BlockIds.Action.Music.PIANO)
            {
                b = new PianoBlock(x, y, note);
            }

            Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, Source);

            Source.Pull.SoundBlockEvent(e);
        }

        private void OnC(Message m)
        {
            try
            {
                // Extract data.
                int id = m.GetInteger(0),
                    totalCoins = m.GetInteger(1);

                // Update relevant objects.
                var subject = Tools.GetPlayerById(id, Source);

                subject.Coins = totalCoins;

                // Fire the event.
                var e = new PlayerEventArgs(subject, Source, m);

                Source.Pull.CoinCollectedEvent(e);
            }
            catch (Exception ex)
            {
                Tools.SkylightMessage(ex.ToString());
            }
        }

        private void OnClear()
        {
            // There is data, but it's kind of irrelevant.
            // Update relevant objects.
            for (var x = 0; x < Source.Width; x++)
            {
                for (var y = 0; y < Source.Height; y++)
                {
                    var blankBlock = new Block(0, x, y);

                    Source.Map[x, y, 0] = blankBlock;
                    Source.Map[x, y, 1] = blankBlock;
                }
            }

            // Fire the event.
            var e = new RoomEventArgs(Source);

            Source.Pull.ClearEvent(e);
        }

        private void OnFace(Message m)
        {
            // Extract data.
            int playerId = m.GetInteger(0),
                smileyId = m.GetInteger(1);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(playerId, Source);

            subject.Smiley = smileyId;

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.FaceEvent(e);
        }

        private void OnGiveGrinch(Message m)
        {
            // Extract data
            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.GrinchEvent(e);
        }

        private void OnGiveWitch(Message m)
        {
            // Extract data
            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.WitchEvent(e);
        }

        private void OnGiveWizard(Message m)
        {
            // Extract data
            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.WizardEvent(e);
        }

        private void OnGiveWizard2(Message m)
        {
            // Extract data
            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.RedWizardEvent(e);
        }

        private void OnGod(Message m)
        {
            // Extract data.
            var isGod = m.GetBoolean(1);

            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            subject.IsGod = isGod;

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.GodEvent(e);
        }

        private void OnHide()
        {
            // Like with "clear", there is data but it is irrelevant.
            // Update relevant objects.
            Source.TimeDoorsVisible = false;

            // Fire the event.
            var e = new RoomEventArgs(Source);

            Source.Pull.HideEvent(e);
        }

        private void OnInfo(Message m)
        {
            // Extract data.
            string
                title = m.GetString(0),
                body = m.GetString(1);

            // Update relevant objects.
            Tools.SkylightMessage("Bot " + Bot.Name + " received a pop-up window:\n   " + title + "\n    " + body);

            if (title == "Limit reached")
            {
                Bot.Disconnect();
            }

            // Fire the event.
            var e = new PlayerEventArgs(Bot, Source, m);

            Source.Pull.InfoEvent(e);
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
            foreach (var msg in _prematureMessages)
            {
                OnMessage(this, msg);
            }

            _prematureMessages.Clear();

            // Fire the event.
            var e = new RoomEventArgs(Source);

            Source.Pull.InitEvent(e);
        }

        private void OnK(Message m)
        {
            // Extract data.
            var id = m.GetInteger(0);

            if (id == -1)
            {
                return;
            }

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            // Take the crown from the current holder (if one exists)
            var crownHolder = Tools.GetCrownHolder(Source);

            if (crownHolder != null)
                crownHolder.HasCrown = false;

            // Give it to the subject.
            if (subject != null)
                subject.HasCrown = true;

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.CrownEvent(e);
        }

        private void OnKill(Message m)
        {
            // Extract data.
            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            subject.DeathCount++;

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.DeathEvent(e);
        }

        private void OnKs(Message m)
        {
            // Extract data.
            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            subject.HasSilverCrown = true;

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.TrophyEvent(e);
        }

        private void OnLb(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2);

            var text = m.GetString(3);

            // Update relevant objects.
            var b = new TextBlock(id, x, y, text);

            Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, Source);

            Source.Pull.CoinBlockEvent(e);
        }

        private void OnLeft(Message m)
        {
            // Extract data.
            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);
            for (var i = 0; i < Source.OnlinePlayers.Count; i++)
            {
                if (Source.OnlinePlayers[i] == subject)
                {
                    Source.OnlinePlayers.RemoveAt(i);
                    break;
                }
            }

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.LeaveEvent(e);
        }

        private void OnLevelUp(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                level = m.GetInteger(1); // never used.

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);
            subject.XpLevel++;

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.LevelUpEvent(e);
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

        private void OnM(Message m)
        {
            // Extract data.
            double xLocation = m.GetDouble(1),
                yLocation = m.GetDouble(2),
                horizontalSpeed = m.GetDouble(3),
                verticalSpeed = m.GetDouble(4);

            int id = m.GetInteger(0),
                coins = m.GetInteger(9),                // never used.
                horizontalModifier = m.GetInteger(5),
                verticalModifier = m.GetInteger(6),
                horizontalDirection = m.GetInteger(7),
                verticalDirection = m.GetInteger(8);

            bool hasGravityModifier = m.GetBoolean(10),
                spaceDown = m.GetBoolean(11);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            subject.IsHoldingSpace = false;
            if (spaceDown)
            {
                subject.IsHoldingSpace = true;

                // If they are simply switching between keys whilst holding space, ignore it
                if (subject.vertical == verticalDirection &&
                    subject.horizontal == horizontalDirection)
                {
                    // Fire the jump event.
                    var jumpEventArgs = new PlayerEventArgs(subject, Source, m);

                    Source.Pull.JumpEvent(jumpEventArgs);
                }
            }

            subject.X = xLocation;
            subject.Y = yLocation;

            subject.speedX = horizontalSpeed;
            subject.speedY = verticalSpeed;

            subject.modifierX = horizontalModifier;
            subject.modifierY = verticalModifier;

            subject.horizontal = horizontalDirection;
            subject.vertical = verticalDirection;

            subject.HasGravityModifier = hasGravityModifier;

            subject.IsHoldingUp = verticalDirection == -1;

            subject.IsHoldingDown = verticalDirection == 1;

            subject.IsHoldingLeft = horizontalDirection == -1;

            subject.IsHoldingRight = horizontalDirection == 1;

            // Fire the event.
            var movementEventArgs = new PlayerEventArgs(subject, Source, m);

            Source.Pull.MovementEvent(movementEventArgs);
        }

        private void OnMod(Message m)
        {
            // Extract data.
            var isMod = m.GetBoolean(1);

            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            subject.IsMod = isMod;

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.ModModeEvent(e);
        }

        private void OnP(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                potionId = m.GetInteger(1);

            var isActive = m.GetBoolean(2);

            // Update relevant objects
            var subject = Tools.GetPlayerById(id, Source);

            if (isActive)
            {
                subject.PotionEffects.Add(potionId);
            }
            else
            {
                subject.PotionEffects.Remove(potionId);
            }

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.PotionEvent(e);
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
            var isVisible = blockId == BlockIds.Action.Portals.NORMAL;

            var b = new PortalBlock(x, y, rotation, portalId, portalDestination, isVisible);

            Source.Map[x, y, 1] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, Source);

            Source.Pull.PortalBlockEvent(e);
        }

        private void OnRefreshShop()
        {
            // Nothing to extract.
            // Nothing to update.
            // Fire the event.
            var e = new RoomEventArgs(Source);

            Source.Pull.RefreshshopEvent(e);
        }

        private void OnReset(Message m)
        {
            foreach (var b in Tools.DeserializeInit(m, 1, Source))
            {
                Source.Map[b.X, b.Y, b.Z] = b;
            }
        }

        private void OnSaved()
        {
            // Nothing to extract from message.
            // Nothing to update because I have no idea what it is.
            // Fire the event.
            var e = new RoomEventArgs(Source);

            Source.Pull.SavedEvent(e);
        }

        private void OnSay(Message m)
        {
            // Extract data.
            var id = m.GetInteger(0);

            var message = m.GetString(1);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            var e = new ChatEventArgs(subject, Source);

            Source.Pull.NormalChatEvent(e);
        }

        private void OnSayOld(Message m)
        {
            // Extract data.
            string message = m.GetString(1),
                name = m.GetString(0); // never used.

            // Update relevant objects.
            // Player subject = new Player() { Name = name };

            Source.ChatLog.Add(new KeyValuePair<string, Player>(message, null));

            // Fire the event.
            var e = new ChatEventArgs(null, Source);

            Source.Pull.SayOldEvent(e);
        }

        private void OnShow(Message m)
        {
            // Like with "hide", there is data but it is irrelevant.
            // Update relevant objects.
            Source.TimeDoorsVisible = true;

            // Fire the event.
            var e = new RoomEventArgs(Source);

            Source.Pull.ShowEvent(e);
        }

        private void OnTeleport(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            subject.X = x;
            subject.Y = y;

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.TeleportEvent(e);
        }

        private void OnTele(Message m)
        {
            // Extract some of the data.
            var isReset = m.GetBoolean(0);

            // On reset
            if (isReset)
            {
                // Extract more data and update relevant objects.
                uint index = 1;

                while (index < m.Count)
                {
                    int id = m.GetInteger(index),
                        x = m.GetInteger(index + 1),
                        y = m.GetInteger(index + 2);

                    var tempSubject = Tools.GetPlayerById(id, Source);
                    tempSubject.X = x;
                    tempSubject.Y = y;

                    index += 3;
                }

                // Fire the event.
                var e = new RoomEventArgs(Source);

                Source.Pull.ResetEvent(e);
            }
            else
            {
                // On death (or whatever else isn't a reset).
                // Extract data.
                int id = m.GetInteger(1),
                    x = m.GetInteger(2),
                    y = m.GetInteger(3);

                // Update relevant objects.
                var subject = Tools.GetPlayerById(id, Source);

                subject.X = x;
                subject.Y = y;

                // Fire the event.
                var e = new PlayerEventArgs(subject, Source, m);

                Source.Pull.DeathEvent(e);
            }
        }

        private void OnTs(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2);

            var text = m.GetString(3);

            // Update relevant objects.
            var b = new TextBlock(id, x, y, text);

            Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b, Source);

            Source.Pull.CoinBlockEvent(e);
        }

        private void OnUpdateMeta(Message m)
        {
            // Extract data.
            string
                ownerName = m.GetString(0),
                roomName = m.GetString(1);

            int plays = m.GetInteger(2),
                woots = m.GetInteger(3),
                totalWoots = m.GetInteger(4);

            // Update relevant objects.
            Source.Owner.Name = ownerName;
            Source.Name = roomName;
            Source.Plays = plays;
            Source.Woots = woots;
            Source.TotalWoots = totalWoots;

            // Fire the event.
            var e = new RoomEventArgs(Source);

            Source.Pull.UpdateMetaEvent(e);
        }

        private void OnUpgrade(Message m)
        {
            // Nothing to extract from message.
            // Nothing to update.
            // Fire the event.
            var e = new RoomEventArgs(Source);

            UpdateEvent(e);
        }

        private void OnW(Message m)
        {
            // "W" stands for "woot" which is the old name for magic.
            // Extract data.
            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            subject.CollectedMagic++;

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.MagicCoinEvent(e);
        }

        private void OnWp(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2);

            var destination = m.GetString(3);

            // Update relevant objects.
            Block b = new RoomPortalBlock(x, y, destination);

            Source.Map[x, y, 0] = b;

            // Fire the event
            var e = new BlockEventArgs(b, Source);

            Source.Pull.RoomPortalBlockEvent(e);
        }

        private void OnWrite(Message m)
        {
            // Extract data.
            string prefix = m.GetString(0),
                message = m.GetString(1);

            // Update relevant objects.
            // Player system = new Player() { Name = prefix };
            Source.ChatLog.Add(new KeyValuePair<string, Player>(message, null));

            // Fire the event.
            var e = new ChatEventArgs(null, Source);

            Source.Pull.SystemMessageEvent(e);
        }

        private void OnWu(Message m)
        {
            // Extract data.
            var id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Tools.GetPlayerById(id, Source);

            Source.TotalWoots++;
            Source.Woots++;

            // Fire the event.
            var e = new PlayerEventArgs(subject, Source, m);

            Source.Pull.WootEvent(e);
        }

        private void LoadBlocks()
        {
            foreach (var b in Tools.DeserializeInit(_initMessage, 18, Source))
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
                    if (_playerPhysicsStopwatch.ElapsedMilliseconds >= accumulator + Config.physics_ms_per_tick)
                    {
                        accumulator += Config.physics_ms_per_tick;

                        foreach (var player in Source.OnlinePlayers)
                        {
                            player.tick();

                            var e = new PlayerEventArgs(player, Source, null);
                            Source.Pull.TickEvent(e);
                        }
                    }
                    else
                    {
                        //Since the timescales dealt with here should be subsecond, explicit unchecked casts to int should never overflow.
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