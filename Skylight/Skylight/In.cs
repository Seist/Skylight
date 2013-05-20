// <author>TakoMan02</author>
// <summary>In.cs is s receiver and processor for every event that happens in the world it is in.</summary>
namespace Skylight
{
    using System;

    public class In
    {
        private World w;

        public delegate void WorldEvent(object[] args);

        public delegate void PlayerEvent(PlayerEventArgs e);

        public delegate void BlockEvent(BlockEventArgs e);

        public delegate void ChatEvent(ChatEventArgs e);

        public delegate void InitEvent(InitEventArgs e);

        public event WorldEvent
            PotionToggleEvent = delegate { },
            SystemMessageEvent = delegate { },
            UpdateEvent = delegate { },
            UpdateMetaEvent = delegate { },
            ShowEvent = delegate { },
            HideEvent = delegate { },
            SavedEvent = delegate { },
            OldChatEvent = delegate { },
            ResetEvent = delegate { },
            RefreshshopEvent = delegate { },
            KillEvent = delegate { },
            InfoEvent = delegate { },
            ClearEvent = delegate { };

        public event PlayerEvent
            JumpEvent = delegate { },
            CrownEvent = delegate { },
            ModModeEvent = delegate { },
            LevelUpEvent = delegate { },
            TrophyEvent = delegate { },
            LabelEvent = delegate { },
            FaceEvent = delegate { },
            GodEvent = delegate { },
            GrinchEvent = delegate { },
            WitchEvent = delegate { },
            WizardEvent = delegate { },
            RedWizardEvent = delegate { },
            LeaveEvent = delegate { },
            AddEvent = delegate { },
            MovementEvent = delegate { },
            PotionEvent = delegate { },
            RotateEvent = delegate { },
            CoinCollectedEvent = delegate { },
            TeleportEvent = delegate { },
            TeleEvent = delegate { },
            WootEvent = delegate { };

        public event BlockEvent
            NormalBlockEvent = delegate { },
            CoinBlockEvent = delegate { },
            SoundBlockEvent = delegate { },
            PortalBlockEvent = delegate { },
            WorldPortalBlockEvent = delegate { },
            SignBlockEvent = delegate { };

        public event ChatEvent
            AutotextEvent = delegate { },
            NormalChatEvent = delegate { };

        public event InitEvent
            NormalInitEvent = delegate { };

        public World W
        {
            get
            {
                foreach (World wl in World.JoinedWorlds)
                {
                    if (wl.Pull == this)
                    {
                        return wl;
                    }
                }

                return new World() { Name = "Null" };
            }

            set
            {
                this.w = value;
            }
        }

        public void OnMessage(object sender, PlayerIOClient.Message m)
        {
            switch (Convert.ToString(m.Type))
            {
                case "add": this.OnAdd(m);
                    break; // Fireed when someone joins.

                case "allowpotions": this.OnAllowPotions(m);
                    break; // Fireed when you allow/deny potions

                case "autotext": this.OnAutotext(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone says an autotext phrase. (e.g. "Help me!", "Left.")

                case "b": this.OnB(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone builds a brick.

                case "bc": this.OnBc(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone places a coin block.

                case "br": this.OnBr(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone rotates a block.

                case "bs": this.OnBs(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone creates a sound block.

                case "c": this.OnC(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone collects a coin.

                case "clear": this.OnClear(m);
                    break; // Fireed when someone clears level.

                case "face": this.OnFace(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone changes smiley.

                case "givegrinch": this.OnGiveGrinch(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone gets Grinch smiley.

                case "givewitch": this.OnGiveWitch(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone gets Witch smiley.

                case "givewizard": this.OnGiveWizard(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone gets Blue Wizard smiley.

                case "givewizard2": this.OnGiveWizard2(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone gets Red Wizard smiley.

                case "god": this.OnGod(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone goes into/out of god mode.

                case "hide": this.OnHide(m);
                    break; // Fireed when timed doors hide.

                case "info": this.OnInfo(m);
                    break; // Fireed when the bot receives a pop-up window (like kick, info).

                case "init": this.OnInit(m);
                    break; // Fireed when the bot joins the level.

                case "k": this.OnK(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone gets the crown.

                case "kill": this.OnKill(m);
                    break; // Fireed when the world crashes.

                case "ks": this.OnKs(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone touches trophy.

                case "lb": this.OnLb(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when a mod places a label.

                case "left": this.OnLeft(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone leaves.

                case "levelup": this.OnLevelUp(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone levels up.

                case "m": this.OnM(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone moves.

                case "mod": this.OnMod(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone goes into mod-mode.

                case "p": this.OnP(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone uses a potion

                case "pt": this.OnPt(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone places a portal.

                case "refreshshop": this.OnRefreshShop(m);
                    break; // Fireed when the shop is refreshed.

                case "reset": this.OnReset(m);
                    break; // Fireed when someone resets the level.

                case "say": this.OnSay(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone says something.

                case "say_old": this.OnSayOld(m);
                    break; // Fireed when the bot joins; gets old messages.

                case "saved": this.OnSaved(m);
                    break; // Fireed when the level is saved.

                case "show": this.OnShow(m);
                    break; // Fireed when timed doors show.

                case "tele": this.OnTele(m);
                    break; // Fireed when someone teleports via /reset or /loadlevel

                case "teleport": this.OnTeleport(m);
                    break; // Fireed when someone teleports.

                case "ts": this.OnTs(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone places a sign. (?)

                case "updatemeta": this.OnUpdateMeta(m);
                    break; // Automatically sent every 30 seconds with level info.

                case "upgrade": this.OnUpgrade(m);
                    break; // Fireed when game updates.

                case "wp": this.OnWp(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone places world portal.

                case "write": this.OnWrite(m);
                    break; // Fireed when the system says something in chat.

                case "w":
                case "wu": this.OnW(Tools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Fireed when someone woots.

                default:
                    break;
            }
        }

        private void OnAdd(PlayerIOClient.Message m)
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

            this.W.OnlinePlayers.Add(subject);

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.W);

            AddEvent(e);
        }

        private void OnAllowPotions(PlayerIOClient.Message m)
        {
            // Extract data.
            bool potions = m.GetBoolean(0);

            // Update relevant objects.
            this.W.PotionsAllowed = potions;

            // Fire the event.
            object[] args = new object[1] { potions };

            WorldEvent handler = this.PotionToggleEvent;
            handler(args);
        }

        private void OnAutotext(Player subject, PlayerIOClient.Message m)
        {
            // Extract data.
            string message = m.GetString(1);

            // Update relevant objects.
            this.W.ChatLog.Add(message);

            // Fire the event.
            ChatEventArgs e = new ChatEventArgs(subject, this.W);

            this.AutotextEvent(e);
        }

        // TODO: Finish this.
        private void OnBc(Player subject, PlayerIOClient.Message m)
        {
            Console.ForegroundColor = Tools.Info;
            Console.WriteLine(Convert.ToString(m));
        }

        private void OnBr(Player subject, PlayerIOClient.Message m)
        {
            Console.ForegroundColor = Tools.Info;
            Console.WriteLine(Convert.ToString(m));
        }

        private void OnBs(Player subject, PlayerIOClient.Message m)
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
                b.W = this.w;
            }
            else
            {
                b.Coords = c;
                b.W = this.w;
            }

            this.w.Map[c] = b;

            // Fire the event.
            BlockEventArgs e = new BlockEventArgs(b, this.w);

            this.SoundBlockEvent(e);
        }

        private void OnC(Player subject, PlayerIOClient.Message m)
        {
            Console.ForegroundColor = Tools.Info;
            Console.WriteLine(Convert.ToString(m));
        }

        private void OnFace(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnGiveGrinch(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnGiveWitch(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnGiveWizard(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnGiveWizard2(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnGod(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnK(Player subject, PlayerIOClient.Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

            // Update relevant objects.
            // Take the crown from the current holder.
            Tools.GetCrownHolder(this.W).HasCrown = false;

            // Give it to the subject.
            subject.HasCrown = true;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.W);

            CrownEvent(e);
        }

        private void OnKs(Player subject, PlayerIOClient.Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

            // Update relevant objects.
            subject.HasSilverCrown = true;

            // Fire the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.W);

            TrophyEvent(e);
        }

        private void OnKill(PlayerIOClient.Message m, Player subject)
        { 
        }

        private void OnLb(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnLevelUp(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnMod(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnP(Player subject, PlayerIOClient.Message m)
        {
            Console.WriteLine(m);
        }

        private void OnPt(Player subject, PlayerIOClient.Message m)
        {
            Console.WriteLine(m);
        }

        private void OnTs(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnW(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnWp(Player subject, PlayerIOClient.Message m)
        {
            // Extract data.
            int x = m.GetInt(0),
                y = m.GetInt(1),
                id = m.GetInt(2);

            string destination = m.GetString(3);

            // Update relevant objects.
            Coords c = new Coords() { X = x, Y = x };
            Block b = new WorldPortal() { Id = id, Coords = c, PortalDestination = destination };

            this.w.Map[c] = b;

            // Fire the event
            BlockEventArgs e = new BlockEventArgs(b, this.w);

            WorldPortalBlockEvent(e);
        }

        private void OnKill(PlayerIOClient.Message m)
        {
        }

        private void OnClear(PlayerIOClient.Message m)
        { 
        }

        private void OnHide(PlayerIOClient.Message m)
        { 
        }

        private void OnInfo(PlayerIOClient.Message m)
        { 
        }

        private void OnRefreshShop(PlayerIOClient.Message m)
        { 
        }

        private void OnReset(PlayerIOClient.Message m)
        { 
        }

        private void OnSaved(PlayerIOClient.Message m)
        { 
        }

        private void OnSayOld(PlayerIOClient.Message m)
        { 
        }

        private void OnShow(PlayerIOClient.Message m)
        { 
        }

        private void OnTeleport(PlayerIOClient.Message m)
        { 
        }

        private void OnTele(PlayerIOClient.Message m)
        { 
        }

        private void OnUpdateMeta(PlayerIOClient.Message m)
        { 
        }

        private void OnUpgrade(PlayerIOClient.Message m)
        { 
        }

        private void OnWrite(PlayerIOClient.Message m)
        { 
        }

        private void OnLeft(Player subject, PlayerIOClient.Message m)
        {
        }

        private void OnInit(PlayerIOClient.Message m)
        {
            // Extract data
            string owner = m.GetString(0),
                name = m.GetString(1),
                worldKey = Tools.Derot(m.GetString(5)),
                botName = m.GetString(9);

            int plays = m.GetInt(2),
                woots = m.GetInt(3),
                totalWoots = m.GetInt(4),
                botID = m.GetInt(6),
                width = m.GetInt(12),
                height = m.GetInt(13);

            double botX = m.GetDouble(7),
                botY = m.GetDouble(8);

            bool potions = m.GetBoolean(16),
                hasAccess = m.GetBoolean(10),
                isOwner = m.GetBoolean(11);

            // Update relevant objects
            this.W.Owner = owner;
            this.W.Name = name;
            this.W.Plays = plays;
            this.W.Woots = woots;
            this.W.TotalWoots = totalWoots;
            this.W.WorldKey = worldKey;
            this.W.Height = height;
            this.W.Width = width;
            this.W.PotionsAllowed = potions;

            this.W.Bot.Id = botID;
            this.W.Bot.X = botX;
            this.W.Bot.Y = botY;
            this.W.Bot.Name = botName;
            this.W.Bot.HasAccess = hasAccess;
            this.W.Bot.IsOwner = isOwner;

            // msg[18] = 182 Roomdata start
            Console.ForegroundColor = Tools.Success;
            Console.WriteLine("Joined level \"" + this.W.Name + "\" successfully.");

            object[] args = new object[9] { owner, name, plays, woots, totalWoots, worldKey, botX, botY, botName };

            // Fire the event.
            InitEventArgs e = new InitEventArgs(this.W);

            this.NormalInitEvent(e);
        }

        private void OnM(Player subject, PlayerIOClient.Message m)
        {
            // Extract data.
            double myxLocation = m.GetDouble(1),
                myyLocation = m.GetDouble(2),
                horizontalSpeed = m.GetDouble(3),
                verticalSpeed = m.GetDouble(4),
                horizontalModifier = m.GetDouble(5),
                verticalModifier = m.GetDouble(6),
                horizontalDirection = m.GetDouble(7),
                verticalDirection = m.GetDouble(8),
                gravityMultiplier = m.GetDouble(9);

            bool spacedown = m.GetBoolean(11);

            // Update relevant objects.
            subject.IsHoldingUp = false;
            subject.IsHoldingDown = false;
            subject.IsHoldingLeft = false;
            subject.IsHoldingRight = false;

            if (verticalDirection == -1)
            {
                subject.IsHoldingUp = true;
            }

            if (verticalDirection == 1)
            {
                subject.IsHoldingDown = true;
            }

            if (horizontalDirection == -1)
            {
                subject.IsHoldingLeft = true;
            }

            if (horizontalDirection == 1)
            {
                subject.IsHoldingRight = true;
            }

            if (spacedown)
            {
                // Fire the jump event.
                PlayerEventArgs jumpEventArgs = new PlayerEventArgs(subject, this.W);

                this.JumpEvent(jumpEventArgs);
            }

            subject.X = myxLocation;
            subject.Y = myyLocation;

            // Fire the movement event.
            object[] args = new object[10] { myxLocation, myyLocation, horizontalSpeed, verticalSpeed, horizontalModifier, verticalModifier, horizontalDirection, verticalDirection, gravityMultiplier, spacedown };

            PlayerEventArgs movementEventArgs = new PlayerEventArgs(subject, this.W);

            this.JumpEvent(movementEventArgs);
        }

        private void OnSay(Player subject, PlayerIOClient.Message m)
        {
            // Extract data.
            string message = m.GetString(1);

            // Update relevant objects.
            this.W.ChatLog.Add(message);

            // Fire the event.
            ChatEventArgs e = new ChatEventArgs(subject, this.W);

            NormalChatEvent(e);
        }

        private void OnB(Player subject, PlayerIOClient.Message m)
        {
        }
    }
}