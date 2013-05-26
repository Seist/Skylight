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
        private Bot bot;
        
        private List<Message> prematureMessages = new List<Message>();

        private Room source;

        public delegate void BlockEvent(BlockEventArgs e);

        public delegate void BotEvent(BotEventArgs e);
        
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
            SystemMessageEvent   = delegate { };
        
        public event PlayerEvent
            AddEvent             = delegate { },
            CoinCollectedEvent   = delegate { },
            CrownEvent           = delegate { },
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
            TeleEvent            = delegate { },
            TeleportEvent        = delegate { },
            TrophyEvent          = delegate { },
            WitchEvent           = delegate { },
            WizardEvent          = delegate { },
            WootEvent            = delegate { };
            
        public event RoomEvent
            ClearEvent           = delegate { },
            HideEvent            = delegate { },
            InitEvent            = delegate { },
            KillEvent            = delegate { },
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

        internal void OnMessage(object sender, Message m)
        {
            // The order in which things are sent is jacked up, so we need to reorder them.
            // Until we get the init message (ie until the room is initialized), don't do anything.
            // Then, when the room is initialized, parse the messages.
            if (!this.Source.IsInitialized)
            {
                Console.WriteLine("{0} is something that is premature.", m.Type);

                if (m.Type == "init")
                {
                    this.OnInit(m);
                }
                else
                {
                    this.prematureMessages.Add(m);
                }
            }
            else if (this.Source.Pull == this)
            {
                Console.WriteLine("{0} is something that should be handled by the proprietary puller.", m.Type);

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

                    case "init":
                        this.OnInit(m);
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

                    case "access": this.OnAccess(m);
                        break;

                    case "lostaccess": this.OnLostAccess(m);
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("{0} is something that should be handled by the bot to which it belongs.", m.Type);
            }
        }

        /* DONE */ private void OnAccess(Message m)
        {
            // Nothing to extract from message.
            // Update relevant objects.
            foreach (Bot bt in this.Source.ConnectedBots)
            {
                ////if (bt.
            }

            this.Bot.HasAccess = true;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(this.Bot, this.Source);

            this.Source.Pull.GainAccessEvent(e);
        }

        /* DONE */ private void OnAdd(Message m)
        {
            // Extract data.
            string name = m.GetString(1);

            int id = m.GetInt(0),
                smiley = m.GetInt(2),
                coins = m.GetInt(8),
                xplevel = m.GetInt(11);

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
                IsFriend = isFriend,
                HasBoost = hasBoost,
                HasClub = hasClub
            };

            this.Source.OnlinePlayers.Add(subject);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

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
            Player subject = Tools.GetPlayerById(m.GetInt(0), this.Source);

            this.Source.ChatLog.Add(message, subject);

            // Fire the event.
            ChatEventArgs e = new ChatEventArgs(subject, this.Source);

            this.Source.Pull.AutotextEvent(e);
        }

        private void OnB(Message m)
        {
        }

        private void OnBc(Message m)
        {
            Console.ForegroundColor = Tools.Info;
            Console.WriteLine(Convert.ToString(m));
        }

        private void OnBr(Message m)
        {
            Console.ForegroundColor = Tools.Info;
            Console.WriteLine(Convert.ToString(m));
        }

        private void OnBs(Message m)
        {
            // Extract data.
            int x = m.GetInt(0),
                y = m.GetInt(1),
                id = m.GetInt(2),
                note = m.GetInt(3);

            // Update relevant objects.
            Block b = new Block();
            Coords c = new Coords() { X = x, Y = y };

            if (id == 77)
            {
                b.Coords = c;
                b.R = this.Source;
            }
            else
            {
                b.Coords = c;
                b.R = this.Source;
            }

            this.Source.Map[c] = b;

            // Fire the event.
            BlockEventArgs e = new BlockEventArgs(b, this.Source);

            this.Source.Pull.SoundBlockEvent(e);
        }

        /* DONE */ private void OnC(Message m)
        {
            // Extract data.
            string name = m.GetString(0);
            int totalCoins = m.GetInt(1);

            // Update relevant objects.
            Player subject = Tools.GetPlayerByName(name, this.Source);

            subject.Coins = totalCoins;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.CoinCollectedEvent(e);
        }
        
        private void OnClear(Message m)
        {
        }
        
        private void OnFace(Message m)
        {
        }

        /* DONE */ private void OnGiveGrinch(Message m)
        {            
            // Extract data
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.GrinchEvent(e);
        }

        /* DONE */ private void OnGiveWitch(Message m)
        {
            // Extract data
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.WitchEvent(e);
        }

        /* DONE */ private void OnGiveWizard(Message m)
        {
            // Extract data
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.WizardEvent(e);
        }

        /* DONE */ private void OnGiveWizard2(Message m)
        {
            // Extract data
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.RedWizardEvent(e);
        }

        private void OnGod(Message m)
        {
        }
        
        private void OnHide(Message m)
        {
        }

        private void OnInfo(Message m)
        {
        }
        
        private void OnInit(Message m)
        {
            // Extract data
            string owner = m.GetString(0),
                name = m.GetString(1),
                worldKey = Tools.Derot(m.GetString(5)),
                botName = m.GetString(9);

            int plays = m.GetInt(2),
                woots = m.GetInt(3),
                totalWoots = m.GetInt(4),
                botId = m.GetInt(6),
                width = m.GetInt(12),
                height = m.GetInt(13);

            double botX = m.GetDouble(7),
                botY = m.GetDouble(8),
                gravityMultiplier = m.GetDouble(15);

            bool isTutorialRoom = m.GetBoolean(14),
                potions = m.GetBoolean(16),
                hasAccess = m.GetBoolean(10),
                isOwner = m.GetBoolean(11);

            // Update relevant objects
            this.Bot.Id = botId;
            this.Bot.X = botX;
            this.Bot.Y = botY;
            this.Bot.Name = botName;
            this.Bot.HasAccess = hasAccess;
            this.Bot.IsOwner = isOwner;
            
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
            
            if (!this.Source.IsInitialized)
            {
                this.Source.IsInitialized = true;
            }
            else
            {
                // If the room has already been initialized, don't fire the event.
                return;
            }

            foreach (Message msg in this.prematureMessages)
            {
                this.OnMessage(new object(), msg);
            }

            this.prematureMessages.Clear();

            //// msg[18] = 182 Roomdata start
            //// TODO: Add blocks from init data

            // Fire the event.
            RoomEventArgs e = new RoomEventArgs(this.Source);

            this.Source.Pull.InitEvent(e);
        }

        /* DONE */ private void OnK(Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

            if (id == -1)
            {
                return;
            }

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            // Take the crown from the current holder.
            Tools.GetCrownHolder(this.Source).HasCrown = false;

            // Give it to the subject.
            subject.HasCrown = true;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.CrownEvent(e);
        }
        
        private void OnKill(Message m)
        {
        }

        /* DONE */ private void OnKs(Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            subject.HasSilverCrown = true;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.TrophyEvent(e);
        }
        
        private void OnLb(Message m)
        {
        }
        
        /* DONE */ private void OnLeft(Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

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
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.LeaveEvent(e);
        }

        private void OnLevelUp(Message m)
        {
        }

        /* DONE */ private void OnLostAccess(Message m)
        {
            // Nothing to extract from message.
            // Update relevant objects.
            this.Bot.HasAccess = false;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(this.Bot, this.Source);

            this.Source.Pull.LoseAccessEvent(e);
        }

        /* DONE */ private void OnM(Message m)
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

            int id = m.GetInt(0),
                coins = m.GetInt(9);

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
                    PlayerEventArgs jumpEventArgs = new PlayerEventArgs(subject, this.Source);

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
            PlayerEventArgs movementEventArgs = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.MovementEvent(movementEventArgs);
        }

        private void OnMod(Message m)
        {
        }

        /* DONE */ private void OnP(Message m)
        {
            // Extract data.
            int id = m.GetInt(0),
                potionId = m.GetInt(1);

            bool isActive = m.GetBoolean(2); 

            // Update relevant objects
            Player subject = Tools.GetPlayerById(id, this.Source);

            subject.PotionEffects.Add(new Potion() 
            { 
                Id = potionId, 
                IsActive = isActive 
            });

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.PotionEvent(e);
        }

        private void OnPt(Message m)
        {
            Console.WriteLine(m);
        }

        private void OnRefreshShop(Message m)
        {
        }

        private void OnReset(Message m)
        {
        }

        /* DONE */ private void OnSaved(Message m)
        {
            // Nothing to extract from message.
            // Nothing to update because I have no idea what it is.
            // Fire the event.
            RoomEventArgs e = new RoomEventArgs(this.Source);

            this.Source.Pull.SavedEvent(e);
        }

        /* DONE */ private void OnSay(Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

            string message = m.GetString(1);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            this.Source.ChatLog.Add(message, subject);

            // Fire the event.
            ChatEventArgs e = new ChatEventArgs(subject, this.Source);

            this.Source.Pull.NormalChatEvent(e);
        }

        private void OnSayOld(Message m)
        { 
        }

        private void OnShow(Message m)
        {
        }

        private void OnTeleport(Message m)
        {
        }

        private void OnTele(Message m)
        {
        }
        
        private void OnTs(Message m)
        {
        }

        private void OnUpdateMeta(Message m)
        {
        }

        private void OnUpgrade(Message m)
        {
        }

        /* DONE */ private void OnW(Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            subject.CollectedMagic++;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.MagicCoinEvent(e);
        }

        private void OnWp(Message m)
        {
            // Extract data.
            int x = m.GetInt(0),
                y = m.GetInt(1),
                id = m.GetInt(2);

            string destination = m.GetString(3);

            // Update relevant objects.
            Coords c = new Coords() { X = x, Y = x };
            Block b = new RoomPortal() { Id = id, Coords = c, PortalDestination = destination };

            this.Source.Map[c] = b;

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
            this.Source.ChatLog.Add(message, system);

            // Fire the event.
            ChatEventArgs e = new ChatEventArgs(system, this.Source);

            this.Source.Pull.SystemMessageEvent(e);
        }

        /* DONE */ private void OnWu(Message m)
        { 
            // Extract data.
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayerById(id, this.Source);

            this.Source.TotalWoots++;
            this.Source.Woots++;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.WootEvent(e);
        }
    }
}