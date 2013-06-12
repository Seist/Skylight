// <author>TakoMan02</author>
// <summary>In.cs is s receiver and processor for every event that happens in the world it is in.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using PlayerIOClient;

    public class In
    {
        private bool isPersonal;

        private Bot bot;
        
        private List<Message> prematureMessages = new List<Message>();

        private Room source;

        public delegate void BlockEvent(BlockEventArgs e);

        public delegate void ChatEvent(ChatEventArgs e);
        
        public delegate void RoomEvent(RoomEventArgs e);

        public delegate void PlayerEvent(PlayerEventArgs e);

        public event BlockEvent
            CoinBlockEvent       = delegate { },
            NormalBlockEvent     = delegate { },
            PortalBlockEvent     = delegate { },
            RoomPortalBlockEvent = delegate { },
            RotateEvent          = delegate { },
            SignBlockEvent       = delegate { },
            SoundBlockEvent      = delegate { };
            
        public event ChatEvent
            AutotextEvent        = delegate { },
            LabelEvent           = delegate { },
            NormalChatEvent      = delegate { },
            SayOldEvent          = delegate { },
            SystemMessageEvent   = delegate { };
        
        public event PlayerEvent
            AddEvent             = delegate { },
            CoinCollectedEvent   = delegate { },
            CrownEvent           = delegate { },
            DeathEvent           = delegate { },
            FaceEvent            = delegate { },
            GainAccessEvent      = delegate { },
            GodEvent             = delegate { },
            GrinchEvent          = delegate { },
            InfoEvent            = delegate { },
            JumpEvent            = delegate { },
            LeaveEvent           = delegate { },
            LevelUpEvent         = delegate { },
            LoseAccessEvent      = delegate { },
            MagicCoinEvent       = delegate { },
            ModModeEvent         = delegate { },
            MovementEvent        = delegate { },
            PotionEvent          = delegate { },
            RedWizardEvent       = delegate { },
            TeleportEvent        = delegate { },
            TrophyEvent          = delegate { },
            WitchEvent           = delegate { },
            WizardEvent          = delegate { },
            WootEvent            = delegate { };
            
        public event RoomEvent
            ClearEvent           = delegate { },
            HideEvent            = delegate { },
            InitEvent            = delegate { },
            PotionToggleEvent    = delegate { },
            RefreshshopEvent     = delegate { },
            ResetEvent           = delegate { },
            SavedEvent           = delegate { },
            ShowEvent            = delegate { },
            UpdateEvent          = delegate { },
            UpdateMetaEvent      = delegate { };

        internal Bot Bot
        {
            get
            {
                return this.bot;
            }

            set
            {
                this.bot = value;
            }
        }

        internal Room Source
        {
            get
            {
                return this.source;
            }

            set 
            {
                this.source = value;
            }
        }

        internal bool IsPersonal
        {
            get
            {
                return this.isPersonal;
            }

            set
            {
                this.isPersonal = value;
            }
        }

        internal void OnMessage(object sender, Message m)
        {
            // The order in which things are sent is jacked up, so we need to reorder them.
            // Until we get the init message (ie until the room is initialized), don't do anything.
            // Then, when the room is initialized, parse the messages.
            if (!this.Source.IsInitialized)
            {
                if (!this.IsPersonal)
                {
                    if (m.Type == "init")
                    {
                        this.OnInit(m);
                    }
                    else
                    {
                        this.prematureMessages.Add(m);
                    }
                }
            }
            else
            {
                if (!this.IsPersonal)
                {
                    switch (Convert.ToString(m.Type))
                    {
                        case "add": this.OnAdd(m);
                            break;

                        case "allowpotions": this.OnAllowPotions(m);
                            break;

                        case "autotext": this.OnAutotext(m);
                            break;

                        case "b": this.OnB(m);
                            break;

                        case "bc": this.OnBc(m);
                            break;

                        case "br": this.OnBr(m);
                            break;

                        case "bs": this.OnBs(m);
                            break;

                        case "c": this.OnC(m);
                            break;

                        case "clear": this.OnClear(m);
                            break;

                        case "face": this.OnFace(m);
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

                        case "k": this.OnK(m);
                            break;

                        case "kill": this.OnKill(m);
                            break;

                        case "ks": this.OnKs(m);
                            break;

                        case "lb": this.OnLb(m);
                            break;

                        case "left": this.OnLeft(m);
                            break;

                        case "levelup": this.OnLevelUp(m);
                            break;

                        case "m": this.OnM(m);
                            break;

                        case "mod": this.OnMod(m);
                            break;

                        case "p": this.OnP(m);
                            break;

                        case "pt": this.OnPt(m);
                            break;

                        case "refreshshop": this.OnRefreshShop(m);
                            break;

                        case "resetset": this.OnReset(m);
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

                        case "ts": this.OnTs(m);
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

                        case "wu": this.OnWu(m);
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    switch (m.Type)
                    {
                        case "access":
                            this.OnAccess(m);
                            break;

                        case "lostaccess":
                            this.OnLostAccess(m);
                            break;

                        case "init": 
                            this.OnInit(m);
                            break;

                        case "info":
                            this.OnInfo(m);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private void OnAccess(Message m)
        {
            // Nothing to extract from message.
            // Update relevant objects.
            this.Bot.HasAccess = true;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(this.Bot, this.Source, m);

            this.Source.Pull.GainAccessEvent(e);
        }

        private void OnAdd(Message m)
        {
            // Extract data.
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
                hasClub = m.GetBoolean(12);

            // Update relevant objects.
            Player subject = new Player
            {
                Name = name,
                Id = id,
                Smiley = smiley,
                Coins = coins,
                XpLevel = xplevel,
                X = x,
                Y = y,
                IsGod = isGod,
                IsMod = isMod,
                PlayingIn = this.Source,
                IsFriend = isFriend,
                HasBoost = hasBoost,
                HasClub = hasClub
            };

            this.Source.OnlinePlayers.Add(subject);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.AddEvent(e);
        }

        private void OnAllowPotions(Message m)
        {
            // Extract data.
            bool potions = m.GetBoolean(0);

            // Update relevant objects.
            this.Source.PotionsAllowed = potions;

            // Fire the event.
            RoomEventArgs e = new RoomEventArgs(this.Source);

            this.Source.Pull.PotionToggleEvent(e);
        }

        private void OnAutotext(Message m)
        {
            // Extract data.
            string message = m.GetString(1);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(m.GetInteger(0), this.Source);

            this.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            ChatEventArgs e = new ChatEventArgs(subject, this.Source);

            this.Source.Pull.AutotextEvent(e);
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
            Player subject = Tools.GetPlayerById(playerId, this.Source);

            Block b = new Block(blockId, x, y, subject);

            this.Source.Map[x, y, z] = b;
            
            // Fire the event.
            BlockEventArgs e = new BlockEventArgs(b, this.Source);

            this.Source.Pull.NormalBlockEvent(e);
        }

        private void OnBc(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2),
                coinsRequired = m.GetInteger(3);

            // Update relevant objects.
            CoinBlock b = new CoinBlock(id, x, y, coinsRequired, false, this.Source);

            if (id == BlockIds.Action.Gates.COIN)
            {
                b.IsGate = true;
            }

            this.Source.Map[x, y, 0] = b;

            // Fire the event.
            BlockEventArgs e = new BlockEventArgs(b, this.Source);

            this.Source.Pull.CoinBlockEvent(e);
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
            Block b = new Block(id, x, y, null, rotation);

            this.Source.Map[x, y, z] = b;

            // Fire the event.
            BlockEventArgs e = new BlockEventArgs(b, this.Source);

            this.Source.Pull.RotateEvent(e);
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
                b = new PercussionBlock(x, y, note, this.Source);
            }
            else if (id == BlockIds.Action.Music.PIANO)
            {
                b = new PianoBlock(x, y, note);
            }

            this.Source.Map[x, y, 0] = b;

            // Fire the event.
            BlockEventArgs e = new BlockEventArgs(b, this.Source);

            this.Source.Pull.SoundBlockEvent(e);
        }

        private void OnC(Message m)
        {
            // Extract data.
            string name = m.GetString(0);
            int totalCoins = m.GetInteger(1);

            // Update relevant objects.
            Player subject = Tools.GetPlayerByName(name, this.Source);

            subject.Coins = totalCoins;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.CoinCollectedEvent(e);
        }

        private void OnClear(Message m)
        {
            // There is data, but it's kind of irrelevant.
            // Update relevant objects.
            for (int x = 0; x < this.Source.Width; x++)
            {
                for (int y = 0; y < this.Source.Height; y++)
                {
                    Block blankBlock = new Block(0, x, y);

                    this.Source.Map[x, y, 0] = blankBlock;
                    this.Source.Map[x, y, 1] = blankBlock;
                }
            }

            // Fire the event.
            RoomEventArgs e = new RoomEventArgs(this.Source);

            this.Source.Pull.ClearEvent(e);
        }

        private void OnFace(Message m)
        {
            // Extract data.
            int playerId = m.GetInteger(0),
                smileyId = m.GetInteger(1);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(playerId, this.Source);

            subject.Smiley = smileyId;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.FaceEvent(e);
        }

        private void OnGiveGrinch(Message m)
        {            
            // Extract data
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.GrinchEvent(e);
        }

        private void OnGiveWitch(Message m)
        {
            // Extract data
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.WitchEvent(e);
        }

        private void OnGiveWizard(Message m)
        {
            // Extract data
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.WizardEvent(e);
        }

        private void OnGiveWizard2(Message m)
        {
            // Extract data
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.RedWizardEvent(e);
        }

        private void OnGod(Message m)
        {
            // Extract data.
            bool isGod = m.GetBoolean(1);

            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            subject.IsGod = isGod;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.GodEvent(e);
        }
        
        private void OnHide(Message m)
        {
            // Like with "clear", there is data but it is irrelevant.
            // Update relevant objects.
            this.Source.TimeDoorsVisible = false;

            // Fire the event.
            RoomEventArgs e = new RoomEventArgs(this.Source);

            this.Source.Pull.HideEvent(e);
        }

        private void OnInfo(Message m)
        {
            // Extract data.
            string 
                title = m.GetString(0),
                body = m.GetString(1);

            // Update relevant objects.
            Tools.SkylightMessage("Bot " + this.Bot.Name + " received a pop-up window:\n" + title + "\n" + body);

            if (title == "Limit reached")
            {
                this.Bot.CancelConnection();
            }

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(this.Bot, this.Source, m);

            this.Source.Pull.InfoEvent(e);
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
                // You don't need to get the roomdata multiple times. Save time by returning.
                return;
            }

            this.Source.Owner.Name = owner;
            this.Source.Name = name;
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
            foreach (Block b in Tools.ConvertMessageToBlockList(m, 18, this.Source))
            {
                this.Source.Map[b.X, b.Y, b.Z] = b;
            }

            Tools.SkylightMessage("Loaded room.");

            foreach (Message msg in this.prematureMessages)
            {
                this.OnMessage(new object(), msg);
            }

            this.prematureMessages.Clear();

            // Fire the event.
            RoomEventArgs e = new RoomEventArgs(this.Source);

            this.Source.Pull.InitEvent(e);
        }

        private void OnK(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            if (id == -1)
            {
                return;
            }

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            // Take the crown from the current holder.
            Player crownHolder = Tools.GetCrownHolder(this.Source);
            crownHolder.HasCrown = false;

            // Give it to the subject.
            subject.HasCrown = true;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.CrownEvent(e);
        }
        
        private void OnKill(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            subject.DeathCount++;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.DeathEvent(e);
        }

        private void OnKs(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            subject.HasSilverCrown = true;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.TrophyEvent(e);
        }
        
        private void OnLb(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2);

            string text = m.GetString(3);

            // Update relevant objects.
            TextBlock b = new TextBlock(id, x, y, text);

            this.Source.Map[x, y, 0] = b;

            // Fire the event.
            BlockEventArgs e = new BlockEventArgs(b, this.Source);

            this.Source.Pull.CoinBlockEvent(e);
        }
        
        private void OnLeft(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);
            foreach (Player p in this.Source.OnlinePlayers)
            {
                if (p == subject)
                {
                    this.Source.OnlinePlayers.Remove(p);
                }
            }

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.LeaveEvent(e);
        }

        private void OnLevelUp(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                level = m.GetInteger(1);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);
            subject.XpLevel++;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.LevelUpEvent(e);
        }

        private void OnLostAccess(Message m)
        {
            // Nothing to extract from message.
            // Update relevant objects.
            this.Bot.HasAccess = false;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(this.Bot, this.Source, m);

            this.Source.Pull.LoseAccessEvent(e);
        }

        private void OnM(Message m)
        {
            // Extract data.
            double xLocation = m.GetDouble(1),
                yLocation = m.GetDouble(2),
                horizontalSpeed = m.GetDouble(3),
                verticalSpeed = m.GetDouble(4),
                horizontalModifier = m.GetDouble(5),
                verticalModifier = m.GetDouble(6),
                horizontalDirection = m.GetDouble(7),
                verticalDirection = m.GetDouble(8);

            int id = m.GetInteger(0),
                coins = m.GetInteger(9);

            bool hasGravityModifier = m.GetBoolean(10),
                spaceDown = m.GetBoolean(11);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            subject.IsHoldingSpace = false;
            if (spaceDown)
            {
                subject.IsHoldingSpace = true;

                // If they are simply switching between keys whilst holding space, ignore it
                if ((subject.VerticalDirection == verticalDirection) &&
                    (subject.HorizontalDirection == horizontalDirection))
                {
                    // Fire the jump event.
                    PlayerEventArgs jumpEventArgs = new PlayerEventArgs(subject, this.Source, m);

                    this.Source.Pull.JumpEvent(jumpEventArgs);
                }
            }

            subject.X = xLocation;
            subject.Y = yLocation;
            subject.HorizontalSpeed = horizontalSpeed;
            subject.VerticalSpeed = verticalSpeed;
            subject.HorizontalModifier = horizontalModifier;
            subject.VerticalModifier = verticalModifier;
            subject.HorizontalDirection = horizontalDirection;
            subject.VerticalDirection = verticalDirection;
            subject.HasGravityModifier = hasGravityModifier;

            subject.IsHoldingUp = false;
            if (verticalDirection == -1)
            {
                subject.IsHoldingUp = true;
            }

            subject.IsHoldingDown = false;
            if (verticalDirection == 1)
            {
                subject.IsHoldingDown = true;
            }

            subject.IsHoldingLeft = false;
            if (horizontalDirection == -1)
            {
                subject.IsHoldingLeft = true;
            }

            subject.IsHoldingRight = false;
            if (horizontalDirection == 1)
            {
                subject.IsHoldingRight = true;
            }

            // Fire the event.
            PlayerEventArgs movementEventArgs = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.MovementEvent(movementEventArgs);
        }

        private void OnMod(Message m)
        {
            // Extract data.
            bool isMod = m.GetBoolean(1);

            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            subject.IsMod = isMod;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.ModModeEvent(e);
        }

        private void OnP(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                potionId = m.GetInteger(1);

            bool isActive = m.GetBoolean(2);

            // Update relevant objects
            Player subject = Tools.GetPlayerById(id, this.Source);

            if (isActive)
            {
                subject.PotionEffects.Add(id);
            }
            else
            {
                subject.PotionEffects.Remove(id);
            }

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.PotionEvent(e);
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
            PortalBlock b = new PortalBlock(blockId, x, y, rotation, portalId, portalDestination, false);
            
            if (blockId == BlockIds.Action.Portals.INVISIBLE)
            {
                b.Visible = false;
            }
            else if (blockId == BlockIds.Action.Portals.NORMAL)
            {
                b.Visible = true;
            }

            this.Source.Map[x, y, 1] = b;

            // Fire the event.
            BlockEventArgs e = new BlockEventArgs(b, this.Source);

            this.Source.Pull.PortalBlockEvent(e);
        }

        private void OnRefreshShop(Message m)
        {
            // Nothing to extract.
            // Nothing to update.
            // Fire the event.
            RoomEventArgs e = new RoomEventArgs(this.Source);

            this.Source.Pull.RefreshshopEvent(e);
        }

        private void OnReset(Message m)
        {
            foreach (Block b in Tools.ConvertMessageToBlockList(m, 1, this.Source))
            {
                this.Source.Map[b.X, b.Y, b.Z] = b;
            }
        }

        private void OnSaved(Message m)
        {
            // Nothing to extract from message.
            // Nothing to update because I have no idea what it is.
            // Fire the event.
            RoomEventArgs e = new RoomEventArgs(this.Source);

            this.Source.Pull.SavedEvent(e);
        }

        private void OnSay(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            string message = m.GetString(1);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            this.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            ChatEventArgs e = new ChatEventArgs(subject, this.Source);

            this.Source.Pull.NormalChatEvent(e);
        }

        private void OnSayOld(Message m)
        {
            // Extract data.
            string message = m.GetString(1),
                name = m.GetString(0);

            // Update relevant objects.
            Player subject = new Player() { Name = name };

            this.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            ChatEventArgs e = new ChatEventArgs(subject, this.Source);

            this.Source.Pull.NormalChatEvent(e);
        }

        private void OnShow(Message m)
        {
            // Like with "hide", there is data but it is irrelevant.
            // Update relevant objects.
            this.Source.TimeDoorsVisible = true;

            // Fire the event.
            RoomEventArgs e = new RoomEventArgs(this.Source);

            this.Source.Pull.ShowEvent(e);
        }

        private void OnTeleport(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            subject.X = x;
            subject.Y = y;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.TeleportEvent(e);
        }

        private void OnTele(Message m)
        {
            // Extract some of the data.
            bool isReset = m.GetBoolean(0);

            // On resetset
            if (isReset)
            {
                // Extract more data and update relevant objects.
                uint index = 1;

                while (index < m.Count)
                {
                    int id = m.GetInteger(index),
                        x = m.GetInteger(index + 1),
                        y = m.GetInteger(index + 2);

                    Player tempSubject = Tools.GetPlayerById(id, this.Source);
                    tempSubject.X = x;
                    tempSubject.Y = y;
                    
                    index += 3;
                }

                // Fire the event.
                RoomEventArgs e = new RoomEventArgs(this.Source);

                this.Source.Pull.ResetEvent(e);
            }
            else
            {
                // On death (or whatever else isn't a resetset).
                // Extract data.
                int id = m.GetInteger(1),
                    x = m.GetInteger(2),
                    y = m.GetInteger(3);

                // Update relevant objects.
                Player subject = Tools.GetPlayerById(id, this.Source);

                subject.X = x;
                subject.Y = y;

                // Fire the event.
                PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

                this.Source.Pull.DeathEvent(e);
            }
        }
        
        private void OnTs(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0),
                x = m.GetInteger(1),
                y = m.GetInteger(2);

            string text = m.GetString(3);

            // Update relevant objects.
            TextBlock b = new TextBlock(id, x, y, text);

            this.Source.Map[x, y, 0] = b;

            // Fire the event.
            BlockEventArgs e = new BlockEventArgs(b, this.Source);

            this.Source.Pull.CoinBlockEvent(e);
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
            RoomEventArgs e = new RoomEventArgs(this.Source);

            this.Source.Pull.UpdateMetaEvent(e);
        }

        private void OnUpgrade(Message m)
        {
            // Nothing to extract from message.
            // Nothing to update.
            // Fire the event.
            RoomEventArgs e = new RoomEventArgs(this.Source);

            this.UpdateEvent(e);
        }

        private void OnW(Message m)
        {
            // "W" stands for "woot" which is the old name for magic.
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            subject.CollectedMagic++;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.MagicCoinEvent(e);
        }

        private void OnWp(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1),
                id = m.GetInteger(2);

            string destination = m.GetString(3);

            // Update relevant objects.
            Block b = new RoomPortalBlock(x, y, destination);

            this.Source.Map[x, y, 0] = b;

            // Fire the event
            BlockEventArgs e = new BlockEventArgs(b, this.Source);

            this.Source.Pull.RoomPortalBlockEvent(e);
        }
        
        private void OnWrite(Message m)
        {
            // Extract data.
            string prefix = m.GetString(0),
                message = m.GetString(1);

            // Update relevant objects.
            Player system = new Player() { Name = prefix };
            this.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, system));

            // Fire the event.
            ChatEventArgs e = new ChatEventArgs(system, this.Source);

            this.Source.Pull.SystemMessageEvent(e);
        }

        private void OnWu(Message m)
        { 
            // Extract data.
            int id = m.GetInteger(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            this.Source.TotalWoots++;
            this.Source.Woots++;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source, m);

            this.Source.Pull.WootEvent(e);
        }
    }
}