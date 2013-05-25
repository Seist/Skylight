// <author>TakoMan02</author>
// <summary>In.cs is s receiver and processor for every event that happens in the world it is in.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using PlayerIOClient;

    public class In
    {
        private bool isPartial;
        private Bot bot;
        private Room source;
        private List<Message> prematureMessages = new List<Message>();

        public delegate void RoomEvent(RoomEventArgs e);

        public delegate void PlayerEvent(PlayerEventArgs e);

        public delegate void BlockEvent(BlockEventArgs e);

        public delegate void ChatEvent(ChatEventArgs e);

        public delegate void InitEvent(InitEventArgs e);

        public event RoomEvent
            PotionToggleEvent = delegate { },
            UpdateEvent = delegate { },
            UpdateMetaEvent = delegate { },
            ShowEvent = delegate { },
            HideEvent = delegate { },
            SavedEvent = delegate { },
            ResetEvent = delegate { },
            RefreshshopEvent = delegate { },
            KillEvent = delegate { },
            InfoEvent = delegate { },
            ClearEvent = delegate { };

        public event PlayerEvent
            GainAccessEvent = delegate { },
            AddEvent = delegate { },
            CoinCollectedEvent = delegate { },
            MagicCoinEvent = delegate { },
            CrownEvent = delegate { },
            FaceEvent = delegate { },
            GodEvent = delegate { },
            GrinchEvent = delegate { },
            JumpEvent = delegate { },
            LevelUpEvent = delegate { },
            LabelEvent = delegate { },
            LeaveEvent = delegate { },
            LoseAccessEvent = delegate { },
            ModModeEvent = delegate { },
            MovementEvent = delegate { },
            PotionEvent = delegate { },
            RedWizardEvent = delegate { },
            TrophyEvent = delegate { },
            TeleportEvent = delegate { },
            TeleEvent = delegate { },
            WootEvent = delegate { },
            WitchEvent = delegate { },
            WizardEvent = delegate { };

        public event BlockEvent
            NormalBlockEvent = delegate { },
            CoinBlockEvent = delegate { },
            SoundBlockEvent = delegate { },
            PortalBlockEvent = delegate { },
            RoomPortalBlockEvent = delegate { },
            SignBlockEvent = delegate { },
            RotateEvent = delegate { };

        public event ChatEvent
            AutotextEvent = delegate { },
            NormalChatEvent = delegate { },
            SystemMessageEvent = delegate { };

        public event InitEvent
            NormalInitEvent = delegate { };

        public Bot Bot
        {
            get
            {
                return this.bot;
            }

            internal set
            {
                this.bot = value;
            }
        }

        public Room Source
        {
            get
            {
                return this.source;
            }

            internal set
            {
                this.source = value;
            }
        }

        public bool IsPartial
        {
            get
            {
                return this.isPartial;
            }

            internal set
            {
                this.isPartial = value;
            }
        }

        internal void OnMessage(object sender, Message m)
        {
            // The order in which things are sent is jacked up, so we need to reorder them.
            // Until we get the init message (ie until the room is initialized), don't do anything.
            // Then, when the room is initialized, parse the messages.
            if (!this.Source.IsInitialized)
            {
                if (m.Type == "init")
                {
                    Console.WriteLine("Firing init before initialized.");
                    this.OnInit(m);
                }
                else
                {
                    this.prematureMessages.Add(m);
                }
            }
            else
            {
                switch (Convert.ToString(m.Type))
                {
                    case "add": this.OnAdd(m);
                        break; // Fired when someone joins.

                    case "allowpotions": this.OnAllowPotions(m);
                        break; // Fired when you allow/deny potions

                    case "autotext": this.OnAutotext(m);
                        break; // Fired when someone says an autotext phrase. (e.g. "Help me!", "Left.")

                    case "b": this.OnB(m);
                        break; // Fired when someone builds a brick.

                    case "bc": this.OnBc(m);
                        break; // Fired when someone places a coin block.

                    case "br": this.OnBr(m);
                        break; // Fired when someone rotates a block.

                    case "bs": this.OnBs(m);
                        break; // Fired when someone creates a sound block.

                    case "c": this.OnC(m);
                        break; // Fired when someone collects a coin.

                    case "clear": this.OnClear(m);
                        break; // Fired when someone clears level.

                    case "face": this.OnFace(m);
                        break; // Fired when someone changes smiley.

                    case "givegrinch": this.OnGiveGrinch(m);
                        break; // Fired when someone gets Grinch smiley.

                    case "givewitch": this.OnGiveWitch(m);
                        break; // Fired when someone gets Witch smiley.

                    case "givewizard": this.OnGiveWizard(m);
                        break; // Fired when someone gets Blue Wizard smiley.

                    case "givewizard2": this.OnGiveWizard2(m);
                        break; // Fired when someone gets Red Wizard smiley.

                    case "god": this.OnGod(m);
                        break; // Fired when someone goes into/out of god mode.

                    case "hide": this.OnHide(m);
                        break; // Fired when timed doors hide.

                    case "init":
                        Console.WriteLine("Firing init after intialized.");
                        this.OnInit(m);
                        break; // Fired when the bot joins the level.

                    case "k": this.OnK(m);
                        break; // Fired when someone gets the crown.

                    case "kill": this.OnKill(m);
                        break; // Fired when the world crashes.

                    case "ks": this.OnKs(m);
                        break; // Fired when someone touches trophy.

                    case "lb": this.OnLb(m);
                        break; // Fired when a mod places a label.

                    case "left": this.OnLeft(m);
                        break; // Fired when someone leaves.

                    case "levelup": this.OnLevelUp(m);
                        break; // Fired when someone levels up.

                    case "m": this.OnM(m);
                        break; // Fired when someone moves.

                    case "mod": this.OnMod(m);
                        break; // Fired when someone goes into mod-mode.

                    case "p": this.OnP(m);
                        break; // Fired when someone uses a potion

                    case "pt": this.OnPt(m);
                        break; // Fired when someone places a portal.

                    case "refreshshop": this.OnRefreshShop(m);
                        break; // Fired when the shop is refreshed.

                    case "reset": this.OnReset(m);
                        break; // Fired when someone resets the level.

                    case "say": this.OnSay(m);
                        break; // Fired when someone says something.

                    //// TODO: Re-add say_old

                    case "saved": this.OnSaved(m);
                        break; // Fired when the level is saved.

                    case "show": this.OnShow(m);
                        break; // Fired when timed doors show.

                    case "tele": this.OnTele(m);
                        break; // Fired when someone teleports via /reset or /loadlevel

                    case "teleport": this.OnTeleport(m);
                        break; // Fired when someone teleports.

                    case "ts": this.OnTs(m);
                        break; // Fired when someone places a sign. (?)

                    case "updatemeta": this.OnUpdateMeta(m);
                        break; // Automatically sent every 30 seconds with level info.

                    case "upgrade": this.OnUpgrade(m);
                        break; // Fired when game updates.

                    case "wp": this.OnWp(m);
                        break; // Fired when someone places world portal.

                    case "write": this.OnWrite(m);
                        break; // Fired when the system says something in chat.

                    case "w": this.OnW(m);
                        break; // Fired when someone gets a magic coin.

                    case "wu": this.OnWu(m);
                        break; // Fired when someone woots.

                    case "access": this.OnAccess(m);
                        break; // Fired when the bot gains access.

                    case "lostaccess": this.OnLostAccess(m);
                        break; // Fired when the bot loses access.

                    case "info": this.OnInfo(m);
                        break; // Fired when the bot receives a pop-up window (like kick, info).

                    default:
                        break;
                }
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

        /* DONE */
        private void OnAdd(Message m)
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
            Player subject = Tools.GetPlayer(m.GetInt(0), this.Source);

            this.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

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
                b.W = this.Source;
            }
            else
            {
                b.Coords = c;
                b.W = this.Source;
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
            Player subject = Tools.GetPlayer(name, this.Source);

            subject.Coins = totalCoins;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.CoinCollectedEvent(e);
        }

        private void OnFace(Message m)
        {
        }

        /* DONE */ private void OnGiveGrinch(Message m)
        {            
            // Extract data
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this.Source);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.GrinchEvent(e);
        }

        /* DONE */ private void OnGiveWitch(Message m)
        {
            // Extract data
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this.Source);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.WitchEvent(e);
        }

        /* DONE */ private void OnGiveWizard(Message m)
        {
            // Extract data
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this.Source);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.WizardEvent(e);
        }

        /* DONE */ private void OnGiveWizard2(Message m)
        {
            // Extract data
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this.Source);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.RedWizardEvent(e);
        }

        private void OnGod(Message m)
        {
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
            Player subject = Tools.GetPlayer(id, this.Source);

            // Take the crown from the current holder.
            Tools.GetCrownHolder(this.Source).HasCrown = false;

            // Give it to the subject.
            subject.HasCrown = true;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.CrownEvent(e);
        }

        /* DONE */ private void OnKs(Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this.Source);

            subject.HasSilverCrown = true;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.TrophyEvent(e);
        }

        private void OnKill(Message m, Player subject)
        {
        }

        private void OnLb(Message m)
        {
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
            Player subject = Tools.GetPlayer(id, this.Source);

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
            Player subject = Tools.GetPlayer(id, this.Source);

            subject.PotionEffect = new Potion() 
            { 
                Id = potionId, 
                IsActive = isActive 
            };

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.PotionEvent(e);
        }

        private void OnPt(Message m)
        {
            Console.WriteLine(m);
        }

        private void OnTs(Message m)
        {
        }

        private void OnKill(Message m)
        {
        }

        private void OnClear(Message m)
        {
        }

        private void OnHide(Message m)
        {
        }

        private void OnInfo(Message m)
        {
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
            Player subject = Tools.GetPlayer(id, this.Source);

            this.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            //ChatEventArgs e = new ChatEventArgs(subject, this.Source);

            //this.Source.Pull.NormalChatEvent(e);
            InitEventArgs e = new InitEventArgs(this.Source);

            this.Source.Pull.NormalInitEvent(e);
            Console.WriteLine("Fired init event. from chat.");
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

        private void OnUpdateMeta(Message m)
        {
        }

        private void OnUpgrade(Message m)
        {
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

        /* DONE */ private void OnLeft(Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this.Source);
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
            InitEventArgs e = new InitEventArgs(this.Source);

            this.Source.Pull.NormalInitEvent(e);
            Console.WriteLine("Fired init event.");
        }

        /* DONE */ private void OnW(Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this.Source);

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

        /* DONE */ private void OnWu(Message m)
        { 
            // Extract data.
            int id = m.GetInt(0);

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this.Source);

            this.Source.TotalWoots++;
            this.Source.Woots++;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.Source);

            this.Source.Pull.WootEvent(e);
        }
    }
}