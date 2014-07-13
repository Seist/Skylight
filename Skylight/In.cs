// <author>TakoMan02</author>
// <summary>In.cs is a receiver and processor for every event that happens in the world it is in.</summary>
namespace Skylight
{
    using PlayerIOClient;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;

    public class In
    {
        private bool isPersonal;

        private Bot bot;

        /// <summary>
        /// These IDs do not have an associated Player id when sent.
        /// </summary>
        private List<int> specialBlockIds = new List<int>() 
        { 
            (int)BlockIds.Switches.SWITCH,
            (int)BlockIds.Tools.TROPHY,
            (int)BlockIds.Doors.TIME,
            (int)BlockIds.Gates.TIME,
            (int)BlockIds.Doors.SWITCH,
            (int)BlockIds.Gates.SWITCH,
            (int)BlockIds.Doors.ZOMBIE,
            (int)BlockIds.Gates.ZOMBIE,
            (int)BlockIds.Secrets.NONSOLID,
            (int)BlockIds.Tools.SPAWN,
            (int)BlockIds.Cake.CAKE,
            (int)BlockIds.Tools.CHECKPOINT,
            (int)BlockIds.Hazards.FIRE
        };

        private List<Message> prematureMessages = new List<Message>();

        private Room source;

        private Stopwatch playerPhysicsStopwatch = new Stopwatch();

        private Thread playerPhysicsThread;

        public delegate void BlockEvent(BlockEventArgs e);

        public delegate void ChatEvent(ChatEventArgs e);

        public delegate void RoomEvent(RoomEventArgs e);

        public delegate void PlayerEvent(PlayerEventArgs e);

        public event BlockEvent
            CoinBlockEvent = delegate { },
            NormalBlockEvent = delegate { },
            PortalBlockEvent = delegate { },
            RoomPortalBlockEvent = delegate { },
            RotateEvent = delegate { },
            SignBlockEvent = delegate { },
            SoundBlockEvent = delegate { };

        public event ChatEvent
            AutotextEvent = delegate { },
            LabelEvent = delegate { },
            NormalChatEvent = delegate { },
            SayOldEvent = delegate { },
            SystemMessageEvent = delegate { };

        public event PlayerEvent
            AddEvent = delegate { },
            CoinCollectedEvent = delegate { },
            CrownEvent = delegate { },
            DeathEvent = delegate { },
            FaceEvent = delegate { },
            GainAccessEvent = delegate { },
            GodEvent = delegate { },
            GrinchEvent = delegate { },
            InfoEvent = delegate { },
            JumpEvent = delegate { },
            LeaveEvent = delegate { },
            LevelUpEvent = delegate { },
            LoseAccessEvent = delegate { },
            MagicCoinEvent = delegate { },
            ModModeEvent = delegate { },
            MovementEvent = delegate { },
            PotionEvent = delegate { },
            RedWizardEvent = delegate { },
            TeleportEvent = delegate { },
            TickEvent = delegate { },
            TrophyEvent = delegate { },
            WitchEvent = delegate { },
            WizardEvent = delegate { },
            WootEvent = delegate { };

        public event RoomEvent
            ClearEvent = delegate { },
            HideEvent = delegate { },
            InitEvent = delegate { },
            PotionToggleEvent = delegate { },
            RefreshshopEvent = delegate { },
            ResetEvent = delegate { },
            SavedEvent = delegate { },
            ShowEvent = delegate { },
            UpdateEvent = delegate { },
            UpdateMetaEvent = delegate { };

        internal Bot Bot
        {
            get;

            set;
        }

        internal Room Source
        {
            get;

            set;
        }

        internal bool IsPersonal
        {
            get;

            set;
        }

        internal void OnMessage(object sender, Message m)
        {
            // The order in which things are sent is jacked up, so we need to reorder them.
            // Until we get the init message (ie until the room is initialized), don't do anything.
            // Then, when the room is initialized, parse the messages.

            try
            {


                if (this.Source.IsInitialized)
                {
                    if (!this.IsPersonal)
                    {
                        messageToWorld(m);
                    }
                    else
                    {
                        messageToBot(m);
                    }
                }
                else
                {
                    if (!this.IsPersonal)
                    {
                        sourceNotInitialized(m);
                    }
                }


            }
            catch (Exception e)
            {
                Logging.SkylightMessage(e.ToString());
            }
        }

        private void messageToBot(Message m)
        {
            switch (m.Type)
            {
                case "access": this.OnAccess(m);
                    break;

                case "lostaccess": this.OnLostAccess(m);
                    break;

                case "init": this.OnInit(m);
                    break;

                case "info": this.OnInfo(m);
                    break;

                default:
                    break;
            }
        }

        private void messageToWorld(Message m)
        {
            switch (m.Type.ToString())
            {
                case "add": this.OnAdd(m);
                    break;

                case "allowpotions": this.OnAllowPotions(m);
                    break;

                case "autotext": this.OnAutotext(m);
                    break;

                case "b": this.OnBlock(m);
                    break;

                case "bc": this.OnBuildCoinBlock(m);
                    break;

                case "br": this.OnAddSpikes(m);
                    break;

                case "bs": this.OnBuildSoundBlock(m);
                    break;

                case "c": this.OnCoinCollected(m);
                    break;

                case "clear": this.OnClear(m);
                    break;

                case "face": this.OnSmileyChange(m);
                    break;

                case "givegrinch": this.OnGiveGrinch(m);
                    break;

                case "givewitch": this.OnGiveWitch(m);
                    break;

                case "givewizard": this.OnGiveWizard(m);
                    break;

                case "givewizard2": this.OnGiveWizard2(m);
                    break;

                case "god": this.OnGod(m);
                    break;

                case "hide": this.OnHide(m);
                    break;

                case "k": this.OnGetCrown(m);
                    break;

                case "kill": this.OnKill(m);
                    break;

                case "ks": this.OnGetSilverCrown(m);
                    break;

                case "lb": this.OnAddText(m);
                    break;

                case "left": this.OnLeft(m);
                    break;

                case "levelup": this.OnLevelUp(m);
                    break;

                case "m": this.OnMove(m);
                    break;

                case "mod": this.OnMod(m);
                    break;

                case "p": this.OnPotion(m);
                    break;

                case "pt": this.OnAddPortal(m);
                    break;

                case "refreshshop": this.OnRefreshShop(m);
                    break;

                case "reset": this.OnReset(m);
                    break;

                case "say": this.OnSay(m);
                    break;

                case "say_old": this.OnSayOld(m);
                    break;

                case "saved": this.OnSaved(m);
                    break;

                case "show": this.OnShow(m);
                    break;

                case "tele": this.OnTele(m);
                    break;

                case "teleport": this.OnTeleport(m);
                    break;

                case "ts": this.OnAddSign(m);
                    break;

                case "updatemeta": this.OnUpdateMeta(m);
                    break;

                case "upgrade": this.OnUpgrade(m);
                    break;

                case "wp": this.OnWp(m);
                    break;

                case "write": this.OnWrite(m);
                    break;

                case "w": this.OnW(m);
                    break;

                case "wu": this.OnWoot(m);
                    break;

                default:
                    break;
            }
        }

        private void sourceNotInitialized(Message m)
        {
            switch (m.Type.ToString())
            {
                case "init":
                    this.OnInit(m);
                    break;
                case "add":
                    this.OnAdd(m);
                    break;
                default:
                    this.prematureMessages.Add(m);
                    break;
            }

        }

        private void OnAccess(Message m)
        {
            // Nothing to extract from message.
            // Update relevant objects.
            this.Bot.HasAccess = true;

            // Fire the event.
            var e = new PlayerEventArgs(this.Bot);

            this.Source.Pull.GainAccessEvent(e);
        }

        private void OnAdd(Message m)
        {
            string name = m.GetString(1);

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
                hasClub = m.GetBoolean(12),
                hasChat = m.GetBoolean(7); // added seven

            // Update relevant objects.
            var subject = new Player(this.Source, id, name, smiley, x, y, isGod, isMod, true, coins, hasBoost, isFriend, xplevel);

            this.Source.OnlinePlayers.Add(subject);

            // Fire the event.
            var e = new PlayerEventArgs(subject);

            this.Source.Pull.AddEvent(e);
        }


        private void OnAllowPotions(Message m)
        {
            // Extract data.
            bool potions = m.GetBoolean(0);

            // Update relevant objects.
            this.Source.PotionsAllowed = potions;

            // Fire the event.
            var e = new RoomEventArgs();

            this.Source.Pull.PotionToggleEvent(e);
        }

        private void OnAutotext(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);
            string message = m.GetString(1);

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(id);

            this.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            var e = new ChatEventArgs(subject, this.Source);

            this.Source.Pull.AutotextEvent(e);
        }

        private void OnBlock(Message m)
        {
            // Extract data.
            int z = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2),
                blockId = m.GetInteger(3),
                playerId = m.GetInteger(4);

            // Update relevant objects.
            var b = new Block(blockId, x, y, z);

            if (!specialBlockIds.Contains(blockId))
            {
                var subject = Utilities.GetPlayerById(playerId);

                b.Placer = subject;
            }

            this.Source.Map[x, y, z] = b;

            // Fire the event.
            var e = new BlockEventArgs(b);

            this.Source.Pull.NormalBlockEvent(e);
        }

        private void OnBuildCoinBlock(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                coinsRequired = m.GetInteger(3);

            // Update relevant objects.
            var b = new CoinBlock(x, y, coinsRequired, false);

            b.IsGate = (id == (int)BlockIds.Gates.COIN);


            this.Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b);

            this.Source.Pull.CoinBlockEvent(e);
        }

        private void OnAddSpikes(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                rotation = m.GetInteger(3),
                z = m.GetInteger(4);

            // Update relevant objects.
            var b = new Block(id, x, y, 0, rotation);

            this.Source.Map[x, y, z] = b;

            // Fire the event.
            var e = new BlockEventArgs(b);

            this.Source.Pull.RotateEvent(e);
        }

        private void OnBuildSoundBlock(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                note = m.GetInteger(3);
            
            // Update relevant objects.
            Block b = null;

            if (id == (int)BlockIds.Music.PERCUSSION)
            {
                b = new PercussionBlock(x, y, note);
            }
            else if (id == (int)BlockIds.Music.PIANO)
            {
                b = new PianoBlock(x, y, note);
            }

            this.Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b);

            this.Source.Pull.SoundBlockEvent(e);
        }

        private void OnCoinCollected(Message m)
        {
            try
            {
                // Extract data.
                int id = m.GetInteger(0),
                    totalCoins = m.GetInteger(1);

                // Update relevant objects.
                var subject = Utilities.GetPlayerById(id);

                subject.Coins = totalCoins;

                // Fire the event.
                var e = new PlayerEventArgs(subject);

                this.Source.Pull.CoinCollectedEvent(e);
            }
            catch (Exception ex)
            {
                Logging.SkylightMessage(ex.ToString());
            }
        }

        private void OnClear(Message m)
        {
            // There is data, but it's kind of irrelevant.
            // Update relevant objects.
            World.clearWorld(this.Source);

            // Fire the event.
            var e = new RoomEventArgs();

            this.Source.Pull.ClearEvent(e);
        }

        private void OnSmileyChange(Message m)
        {
            // Extract data.
            int playerId = m.GetInteger(0),
                smileyId = m.GetInteger(1);

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(playerId);

            subject.Smiley = smileyId;

            // Fire the event.
            var e = new PlayerEventArgs(subject);

            this.Source.Pull.FaceEvent(e);
        }

        private void OnGiveGrinch(Message m)
        {

            this.Source.Pull.GrinchEvent(
                preparePlayerWithId(m)
                );
        }

        private void OnGiveWitch(Message m)
        {

            this.Source.Pull.WitchEvent(
                preparePlayerWithId(m)
                );
        }

        private void OnGiveWizard(Message m)
        {
            var e = preparePlayerWithId(m);

            this.Source.Pull.WizardEvent(e);
        }

        private PlayerEventArgs preparePlayerWithId(Message m)
        {
            // Extract data
            int id = m.GetInteger(0);

            // Fire the event.
            return new PlayerEventArgs(id, this.Source, m);
        }

        private void OnGiveWizard2(Message m)
        {

            this.Source.Pull.RedWizardEvent(
                preparePlayerWithId(m)
                );
        }

        private void OnGod(Message m)
        {
            // Extract data.
            bool isGod = m.GetBoolean(1);

            int id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(id);

            subject.IsGod = isGod;

            // Fire the event.
            var e = new PlayerEventArgs(subject);

            this.Source.Pull.GodEvent(e);
        }

        private void OnHide(Message m)
        {
            // Like with "clear", there is data but it is irrelevant.
            // Update relevant objects.
            this.Source.TimeDoorsVisible = false;

            // Fire the event.
            var e = new RoomEventArgs();

            this.Source.Pull.HideEvent(e);
        }

        private void OnInfo(Message m)
        {
            // Extract data.
            string
                title = m.GetString(0),
                body = m.GetString(1);

            // Update relevant objects.
            Logging.SkylightMessage("Bot " + this.Bot.Name + " received a pop-up window:\n   " + title + "\n    " + body);

            if (title == "Limit reached")
            {
                this.Bot.Disconnect();
                Logging.SkylightMessage("The bot has disconnected because the limit was reached.");
            }

            // Fire the event.
            var e = new PlayerEventArgs(this.Bot);

            this.Source.Pull.InfoEvent(e);
        }

        private void OnInit(Message m)
        {
            // Extract data
            string owner = m.GetString(0),
                name = m.GetString(1),
                worldKey = Utilities.Derot(m.GetString(5)),
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
            this.InitMessage = m;

            this.Bot.Name = botName;
            this.Bot.Id = botId;
            this.Bot.X = botX;
            this.Bot.Y = botY;
            this.Bot.HasAccess = hasAccess;
            this.Bot.IsOwner = isOwner;
            this.Bot.PlayingIn = this.Source;

            this.Source.OnlineBots.Add(this.Bot);

            if (this.Source.IsInitialized)
            {
                // You don't need to get the room data multiple times. Save time by returning.
                return;
            }

            // Update the room data.
            this.Source.Name = name;
            this.Source.Owner = Utilities.GetPlayerByName(owner, this.Source);
            this.Source.Plays = plays;
            this.Source.Woots = woots;
            this.Source.TotalWoots = totalWoots;
            this.Source.RoomKey = worldKey;
            this.Source.Height = height;
            this.Source.Width = width;
            this.Source.PotionsAllowed = potions;
            this.Source.IsTutorialRoom = isTutorialRoom;
            this.Source.GravityMultiplier = gravityMultiplier;

            this.Source.IsInitialized = true;

            // Load the blocks
            Thread loadBlocks = new Thread(LoadBlocks);
            loadBlocks.Start();

            // Execute the messages that came prematurely.
            foreach (Message msg in this.prematureMessages)
            {
                this.OnMessage(this, msg);
            }

            this.prematureMessages.Clear();

            // Fire the event.
            var e = new RoomEventArgs();

            this.Source.Pull.InitEvent(e);
        }

        private void OnGetCrown(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            if (id == -1)
            {
                return;
            }

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(id);

            // Take the crown from the current holder (if one exists)
            var crownHolder = Utilities.GetCrownHolder(this.Source);

            if (crownHolder != null)
            {
                crownHolder.HasCrown = false;
            }

            // Give it to the subject.
            if (subject != null)
            {
                subject.HasCrown = true;
            }

            // Fire the event.
            var e = new PlayerEventArgs(subject);

            this.Source.Pull.CrownEvent(e);
        }

        private void OnKill(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(id);

            subject.DeathCount++;

            // Fire the event.
            var e = new PlayerEventArgs(subject);

            this.Source.Pull.DeathEvent(e);
        }

        private void OnGetSilverCrown(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(id);

            subject.HasSilverCrown = true;

            // Fire the event.
            var e = new PlayerEventArgs(subject);

            this.Source.Pull.TrophyEvent(e);
        }

        private void OnAddText(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2);

            string text = m.GetString(3);

            // Update relevant objects.
            var b = new TextBlock(id, x, y, text);

            this.Source.Map[x, y, 0] = b;

            // Fire the event.
            var e = new BlockEventArgs(b);

            this.Source.Pull.CoinBlockEvent(e);
        }

        private void OnLeft(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(id);
            for (int i = 0; i < this.Source.OnlinePlayers.Count; i++)
            {
                if (this.Source.OnlinePlayers[i] == subject)
                {
                    this.Source.OnlinePlayers.RemoveAt(i);
                    break;
                }
            }

            // Fire the event.
            var e = new PlayerEventArgs(subject);

            this.Source.Pull.LeaveEvent(e);
        }

        private void OnLevelUp(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                level = m.GetInteger(1);

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(id);
            subject.XpLevel++;

            // Fire the event.
            var e = new PlayerEventArgs(subject);

            this.Source.Pull.LevelUpEvent(e);
        }

        private void OnLostAccess(Message m)
        {
            // Nothing to extract from message.
            // Update relevant objects.
            this.Bot.HasAccess = false;

            // Fire the event.
            var e = new PlayerEventArgs(this.Bot);

            this.Source.Pull.LoseAccessEvent(e);
        }

        private void OnMove(Message m)
        {
            // Extract data.
            double xLocation = m.GetDouble(1),
                yLocation = m.GetDouble(2),
                horizontalSpeed = m.GetDouble(3),
                verticalSpeed = m.GetDouble(4);

            int id = m.GetInteger(0),
                coins = m.GetInteger(9), horizontalModifier = m.GetInteger(5),
                verticalModifier = m.GetInteger(6),
                horizontalDirection = m.GetInteger(7),
                verticalDirection = m.GetInteger(8);

            bool hasGravityModifier = m.GetBoolean(10),
                spaceDown = m.GetBoolean(11);

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(id);

            subject.IsHoldingSpace = false;
            if (spaceDown)
            {
                subject.IsHoldingSpace = true;

                // If they are simply switching between keys whilst holding space, ignore it
                if (subject.vertical == verticalDirection &&
                    subject.horizontal == horizontalDirection)
                {
                    // Fire the jump event.
                    var jumpEventArgs = new PlayerEventArgs(subject);

                    this.Source.Pull.JumpEvent(jumpEventArgs);
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

            subject.IsHoldingUp = (bool)(verticalDirection == -1);
            subject.IsHoldingDown = (bool)(verticalDirection == 1);

            subject.IsHoldingLeft = (bool)(horizontalDirection == -1);
            subject.IsHoldingRight = (bool)(horizontalDirection == 1);

            // Fire the event.

            this.Source.Pull.MovementEvent(
                new PlayerEventArgs(subject)
                );
        }

        private void OnMod(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);
            bool isMod = m.GetBoolean(1);

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(id);

            subject.IsMod = isMod;

            // Fire the event.

            this.Source.Pull.ModModeEvent(
                new PlayerEventArgs(subject)
                );
        }

        private void OnPotion(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                potionId = m.GetInteger(1);

            bool isActive = m.GetBoolean(2);

            // Update relevant objects
            var subject = Utilities.GetPlayerById(id);

            if (isActive)
            {
                subject.PotionEffects.Add(id);
            }
            else
            {
                subject.PotionEffects.Remove(id);
            }

            // Fire the event.

            this.Source.Pull.PotionEvent(
                new PlayerEventArgs(subject)
                );
        }

        private void OnAddPortal(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                blockId = m.GetInteger(2),
                rotation = m.GetInteger(3),
                portalId = m.GetInteger(4),
                portalDestination = m.GetInteger(5);

            // Update relevant objects.
            bool isVisible = (blockId == (int)BlockIds.Portals.NORMAL);

            var b = new PortalBlock(x, y, rotation, portalId, portalDestination, isVisible);

            this.Source.Map[x, y, 1] = b;

            // Fire the event.

            this.Source.Pull.PortalBlockEvent(
                new BlockEventArgs(b)
                );
        }

        private void OnRefreshShop(Message m)
        {
            // Nothing to extract.
            // Nothing to update.
            // Fire the event.

            this.Source.Pull.RefreshshopEvent(
                new RoomEventArgs()
                );
        }

        private void OnReset(Message m)
        {
            foreach (Block b in World.DeserializeInit(m, 1, this.Source))
            {
                this.Source.Map[b.X, b.Y, b.Z] = b;
            }
        }

        private void OnSaved(Message m)
        {
            // Nothing to extract from message.
            // Nothing to update because I have no idea what it is.
            // Fire the event.

            this.Source.Pull.SavedEvent(new RoomEventArgs());
        }

        private void OnSay(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);
            string message = m.GetString(1);

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(id);

            this.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            var e = new ChatEventArgs(subject, this.Source);

            this.Source.Pull.NormalChatEvent(e);
        }

        private void OnSayOld(Message m)
        {
            // Extract data.
            string message = m.GetString(1),
                name = m.GetString(0);

            this.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, null));

            // Fire the event.
            var e = new ChatEventArgs(null, this.Source);

            this.Source.Pull.SayOldEvent(e);
        }

        private void OnShow(Message m)
        {
            // Like with "hide", there is data but it is irrelevant.
            // Update relevant objects.
            this.Source.TimeDoorsVisible = true; // Be careful. Could be a red, blue or green key.

            // Fire the event.
            var e = new RoomEventArgs();

            this.Source.Pull.ShowEvent(e);
        }

        private void OnTeleport(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2);

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(id);

            subject.X = x;
            subject.Y = y;

            // Fire the event.
            var e = new PlayerEventArgs(subject);

            this.Source.Pull.TeleportEvent(e);
        }

        private void OnTele(Message m)
        {
            // Extract some of the data.
            bool isReset = m.GetBoolean(0);

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

                    var tempSubject = Utilities.GetPlayerById(id);
                    tempSubject.X = x;
                    tempSubject.Y = y;

                    index += 3;
                }

                // Fire the event.
                var e = new RoomEventArgs();

                this.Source.Pull.ResetEvent(e);
            }
            else
            {
                // On death (or whatever else isn't a reset).
                // Extract data.
                int id = m.GetInteger(1);


                // Update relevant objects.
                var subject = Utilities.GetPlayerById(id);

                subject.X = m.GetInteger(2);
                subject.Y = m.GetInteger(3);

                // Fire the event.
                this.Source.Pull.DeathEvent(
                    new PlayerEventArgs(subject)
                    );
            }
        }

        private void OnAddSign(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2);

            string text = m.GetString(3);

            // Update relevant objects.
            var b = new TextBlock(id, x, y, text);

            this.Source.Map[x, y, 0] = b;

            // Fire the event.

            this.Source.Pull.CoinBlockEvent(
                new BlockEventArgs(b)
                );
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
            this.Source.Owner.Name = ownerName;
            this.Source.Name = roomName;
            this.Source.Plays = plays;
            this.Source.Woots = woots;
            this.Source.TotalWoots = totalWoots;

            // Fire the event.

            this.Source.Pull.UpdateMetaEvent(
                new RoomEventArgs()
                );
        }

        private void OnUpgrade(Message m)
        {
            // Nothing to extract from message.
            // Nothing to update.
            // Fire the event.

            this.UpdateEvent(
                new RoomEventArgs()
                );
        }

        private void OnW(Message m)
        {
            // "W" stands for "woot" which is the old name for magic.
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            var subject = Utilities.GetPlayerById(id);

            subject.CollectedMagic++;

            // Fire the event.

            this.Source.Pull.MagicCoinEvent(
                new PlayerEventArgs(subject)
                );
        }

        private void OnWp(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2);

            string destination = m.GetString(3);

            // Update relevant objects.
            var b = new RoomPortalBlock(x, y, destination);

            this.Source.Map[x, y, 0] = b;

            // Fire the event
            this.Source.Pull.RoomPortalBlockEvent(
                new BlockEventArgs(b)
                );
        }

        private void OnWrite(Message m)
        {
            // Extract data.
            string prefix = m.GetString(0),
                   message = m.GetString(1);

            // Update relevant objects.
            this.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, null));

            // Fire the event.
            this.Source.Pull.SystemMessageEvent(
                new ChatEventArgs(null, this.Source)
                );
        }

        private void OnWoot(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            this.Source.TotalWoots++;
            this.Source.Woots++;

            // Fire the event.

            this.Source.Pull.WootEvent(
                new PlayerEventArgs(id, this.Source, m)
                );
        }

        private Message InitMessage;

        private void LoadBlocks()
        {
            foreach (Block b in World.DeserializeInit(InitMessage, 18, this.Source))
            {
                this.Source.Map[b.X, b.Y, b.Z] = b;
            }

            this.Source.BlocksLoaded = true;

            Thread.Sleep(1000);

            playerPhysicsThread = new Thread(UpdatePhysics);
            playerPhysicsThread.Start();
        }

        private void UpdatePhysics()
        {
            playerPhysicsStopwatch.Start();
            while (this.Bot.ShouldTick)
            {
                try
                {
                    if (playerPhysicsStopwatch.ElapsedMilliseconds >= Physics.Config.physics_ms_per_tick)
                    {
                        playerPhysicsStopwatch.Restart();
                        foreach (Player player in this.Source.OnlinePlayers)
                        {
                            player.tick();

                            var e = new PlayerEventArgs(player);
                            this.Source.Pull.TickEvent(e);
                        }
                    }
                }
                catch (Exception e)
                {
                    Logging.SkylightMessage(e.ToString());
                }
            }
        }
    }
}