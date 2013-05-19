// <author>TakoMan02</author>
// <summary>In.cs is s receiver and processor for every event that happens in the world it is in.</summary>
namespace Skylight
{
    using System;

    public class In
    {
        private World w;

        public delegate void WorldEvent(object[] args);

        public delegate void PlayerEvent(object sender, PlayerEventArgs e);

        public delegate void BlockEvent(object sender, BlockEventArgs e);

        public delegate void ChatEvent(object sender, ChatEventArgs e);

        public delegate void InitEvent(object sender, InitEventArgs e);

        public static event WorldEvent
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

        public static event PlayerEvent
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

        public static event BlockEvent
            NormalBlockEvent = delegate { },
            CoinBlockEvent = delegate { },
            SoundBlockEvent = delegate { },
            PortalBlockEvent = delegate { },
            WorldPortalBlockEvent = delegate { },
            SignBlockEvent = delegate { };

        public static event ChatEvent
            AutotextEvent = delegate { },
            NormalChatEvent = delegate { };

        public static event InitEvent
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
                    break; // Triggered when someone joins.

                case "allowpotions": this.OnAllowPotions(m);
                    break; // Triggered when you allow/deny potions

                case "autotext": this.OnAutotext(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone says an autotext phrase. (e.g. "Help me!", "Left.")

                case "b": this.OnB(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone builds a brick.

                case "bc": this.OnBc(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone places a coin block.

                case "br": this.OnBr(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone rotates a block.

                case "bs": this.OnBs(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone creates a sound block.

                case "c": this.OnC(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone collects a coin.

                case "clear": this.OnClear(m);
                    break; // Triggered when someone clears level.

                case "face": this.OnFace(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone changes smiley.

                case "givegrinch": this.OnGiveGrinch(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone gets Grinch smiley.

                case "givewitch": this.OnGiveWitch(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone gets Witch smiley.

                case "givewizard": this.OnGiveWizard(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone gets Blue Wizard smiley.

                case "givewizard2": this.OnGiveWizard2(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone gets Red Wizard smiley.

                case "god": this.OnGod(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone goes into/out of god mode.

                case "hide": this.OnHide(m);
                    break; // Triggered when timed doors hide.

                case "info": this.OnInfo(m);
                    break; // Triggered when the bot receives a pop-up window (like kick, info).

                case "init": this.OnInit(m);
                    break; // Triggered when the bot joins the level.

                case "k": this.OnK(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone gets the crown.

                case "kill": this.OnKill(m);
                    break; // Triggered when the world crashes.

                case "ks": this.OnKs(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone touches trophy.

                case "lb": this.OnLb(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when a mod places a label.

                case "left": this.OnLeft(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone leaves.

                case "levelup": this.OnLevelUp(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone levels up.

                case "m": this.OnM(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone moves.

                case "mod": this.OnMod(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone goes into mod-mode.

                case "p": this.OnP(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone uses a potion

                case "pt": this.OnPt(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone places a portal.

                case "refreshshop": this.OnRefreshShop(m);
                    break; // Triggered when the shop is refreshed.

                case "reset": this.OnReset(m);
                    break; // Triggered when someone resets the level.

                case "say": this.OnSay(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone says something.

                case "say_old": this.OnSayOld(m);
                    break; // Triggered when the bot joins; gets old messages.

                case "saved": this.OnSaved(m);
                    break; // Triggered when the level is saved.

                case "show": this.OnShow(m);
                    break; // Triggered when timed doors show.

                case "tele": this.OnTele(m);
                    break; // Triggered when someone teleports via /reset or /loadlevel

                case "teleport": this.OnTeleport(m);
                    break; // Triggered when someone teleports.

                case "ts": this.OnTs(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone places a sign. (?)

                case "updatemeta": this.OnUpdateMeta(m);
                    break; // Automatically sent every 30 seconds with level info.

                case "upgrade": this.OnUpgrade(m);
                    break; // Triggered when game updates.

                case "wp": this.OnWp(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone places world portal.

                case "write": this.OnWrite(m);
                    break; // Triggered when the system says something in chat.

                case "w":
                case "wu": this.OnW(Tools.GameTools.GetPlayer(m.GetInt(0), this.W), m);
                    break; // Triggered when someone woots.

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

            // Trigger the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.W);

            AddEvent(this, e);
        }

        private void OnAllowPotions(PlayerIOClient.Message m)
        {
            // Extract data.
            bool potions = m.GetBoolean(0);

            // Update relevant objects.
            this.W.PotionsAllowed = potions;

            // Trigger the event.
            object[] args = new object[1] { potions };

            WorldEvent handler = PotionToggleEvent;
            handler(args);
        }

        private void OnAutotext(Player subject, PlayerIOClient.Message m)
        {
            // Extract data.
            string message = m.GetString(1);

            // Update relevant objects.
            this.W.ChatLog.Add(message);

            // Trigger the event.
            ChatEventArgs e = new ChatEventArgs(subject, this.W);

            AutotextEvent(this, e);
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
            Console.ForegroundColor = Tools.Info;
            Console.WriteLine(Convert.ToString(m));
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
            Tools.GameTools.GetCrownHolder(this.W).HasCrown = false;

            // Give it to the subject.
            subject.HasCrown = true;

            // Trigger the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.W);

            CrownEvent(this, e);
        }

        private void OnKs(Player subject, PlayerIOClient.Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

            // Update relevant objects.
            subject.HasSilverCrown = true;

            // Trigger the event.
            PlayerEventArgs e = new PlayerEventArgs(subject, this.W);

            TrophyEvent(this, e);
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
        }

        private void OnPt(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnTs(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnW(Player subject, PlayerIOClient.Message m)
        { 
        }

        private void OnWp(Player subject, PlayerIOClient.Message m)
        { 
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

            Tools.GameTools.Bot.Id = botID;
            Tools.GameTools.Bot.X = botX;
            Tools.GameTools.Bot.Y = botY;
            Tools.GameTools.Bot.Name = botName;
            Tools.GameTools.Bot.HasAccess = hasAccess;
            Tools.GameTools.Bot.IsOwner = isOwner;

            // msg[18] = 182 Roomdata start
            Console.ForegroundColor = Tools.Success;
            Console.WriteLine("Joined level \"" + this.W.Name + "\" successfully.");

            object[] args = new object[9] { owner, name, plays, woots, totalWoots, worldKey, botX, botY, botName };

            // Trigger the event.
            InitEventArgs e = new InitEventArgs(this.W);

            NormalInitEvent(this, e);
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
                // Trigger the jump event.
                PlayerEventArgs jumpEventArgs = new PlayerEventArgs(subject, this.W);

                JumpEvent(this, jumpEventArgs);
            }

            subject.X = myxLocation;
            subject.Y = myyLocation;

            // Trigger the movement event.
            object[] args = new object[10] { myxLocation, myyLocation, horizontalSpeed, verticalSpeed, horizontalModifier, verticalModifier, horizontalDirection, verticalDirection, gravityMultiplier, spacedown };

            PlayerEventArgs movementEventArgs = new PlayerEventArgs(subject, this.W);

            JumpEvent(this, movementEventArgs);
        }

        private void OnSay(Player subject, PlayerIOClient.Message m)
        {
            // Extract data.
            string message = m.GetString(1);

            // Update relevant objects.
            this.W.ChatLog.Add(message);

            // Trigger the event.
            ChatEventArgs e = new ChatEventArgs(subject, this.W);

            NormalChatEvent(this, e);
        }

        private void OnB(Player subject, PlayerIOClient.Message m)
        {
        }
    }
}