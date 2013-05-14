using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Skylight
{
    public class In
    {
        public static ConsoleColor blank = ConsoleColor.White, progress = ConsoleColor.Yellow, success = ConsoleColor.Green, error = ConsoleColor.Red, info = ConsoleColor.Cyan;

        public void onMessage(object sender, PlayerIOClient.Message m)
        {
            World w = thisWorld();
            switch (Convert.ToString(m.Type))
            {
                case "add": onAdd(w, m);
                    break; // Triggered when someone joins.

                case "allowpotions": onAllowPotions(w, m);
                    break; // Triggered when you allow/deny potions

                case "autotext": onAutotext(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone says an autotext phrase. (e.g. "Help me!", "Left.")

                case "b": onB(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone builds a brick.

                case "bc": onBc(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone places a coin block.

                case "br": onBr(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone rotates a block.

                case "bs": onBs(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone creates a sound block.

                case "c": onC(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone collects a coin.

                case "clear": onClear(w, m);
                    break; // Triggered when someone clears level.

                case "face": onFace(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone changes smiley.

                case "givegrinch": onGiveGrinch(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone gets Grinch smiley.

                case "givewitch": onGiveWitch(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone gets Witch smiley.

                case "givewizard": onGiveWizard(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone gets Blue Wizard smiley.

                case "givewizard2": onGiveWizard2(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone gets Red Wizard smiley.

                case "god": onGod(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone goes into/out of god mode.

                case "hide": onHide(w, m);
                    break; // Triggered when timed doors hide.

                case "info": onInfo(w, m);
                    break; // Triggered when the bot receives a pop-up window (like kick, info).

                case "init": onInit(w, m);
                    break; // Triggered when the bot joins the level.

                case "k": onK(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone gets the crown.

                case "kill": onKill(w, m);
                    break; // Triggered when the world crashes.

                case "ks": onKs(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone touches trophy.

                case "lb": onLb(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when a mod places a label.

                case "left": onLeft(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone leaves.

                case "levelup": onLevelUp(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone levels up.

                case "m": onM(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone moves.

                case "mod": onMod(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone goes into mod-mode.

                case "p": onP(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone uses a potion

                case "pt": onPt(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone places a portal.

                case "refreshshop": onRefreshShop(w, m);
                    break; // Triggered when the shop is refreshed.

                case "reset": onReset(w, m);
                    break; // Triggered when someone resets the level.

                case "say": onSay(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone says something.

                case "say_old": onSayOld(w, m);
                    break; // Triggered when the bot joins; gets old messages.

                case "saved": onSaved(w, m);
                    break; // Triggered when the level is saved.

                case "show": onShow(w, m);
                    break; // Triggered when timed doors show.

                case "tele": onTele(w, m);
                    break; // Triggered when someone teleports via /reset or /loadlevel

                case "teleport": onTeleport(w, m);
                    break; // Triggered when someone teleports.

                case "ts": onTs(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone places a sign. (?)

                case "updatemeta": onUpdateMeta(w, m);
                    break; // Automatically sent every 30 seconds with level info.

                case "upgrade": onUpgrade(w, m);
                    break; //Triggered when game updates.

                case "wp": onWp(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone places world portal.

                case "write": onWrite(w, m);
                    break; // Triggered when the system says something in chat.

                case "w":
                case "wu": onW(w, getPlayer(m.GetInt(0)), m);
                    break; // Triggered when someone woots.

                default:
                    break;
            }
        }

        private void onAdd(World w, PlayerIOClient.Message m)
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
            Player p = new Player
                {
                    name = name,
                    id = id,
                    smiley = smiley,
                    coins = coins,
                    xplevel = xplevel,
                    x = x,
                    y = y,
                    isGod = isGod,
                    isMod = isMod,
                    isFriend = isFriend,
                    hasBoost = hasBoost,
                    hasClub = hasClub
                };

            w.onlinePlayers.Add(p);

            // Trigger the event.
            object[] args = new object[12] { name, id, smiley, coins, xplevel, x, y, isGod, isMod, isFriend, hasBoost, hasClub};

            playerEvent handler = _onJoin;
            handler(w, p, args);
        }

        private void onAllowPotions(World w, PlayerIOClient.Message m)
        {
            // Extract data.
            bool potions = m.GetBoolean(0);
            
            // Update relevant objects.
            w.potionsAllowed = potions;

            // Trigger the event.
            object[] args = new object[1] { potions };

            worldEvent handler = _onPotionToggle;
            handler(w, args);
        }

        private void onAutotext(World w, Player p, PlayerIOClient.Message m)
        {
            // Extract data.
            string message = m.GetString(1);


            // Trigger the events.
            object[] args = new object[1] { message };

            playerEvent handler = _onAutotext;
            handler(w, p, args);
        }

        private void onBc(World w, Player p, PlayerIOClient.Message m)
        {
            Console.ForegroundColor = info;
            Console.WriteLine(Convert.ToString(m));
        }

        private void onBr(World w, Player p, PlayerIOClient.Message m)
        {
            Console.ForegroundColor = info;
            Console.WriteLine(Convert.ToString(m));
        }

        private void onBs(World w, Player p, PlayerIOClient.Message m)
        {
            Console.ForegroundColor = info;
            Console.WriteLine(Convert.ToString(m));
        }

        private void onC(World w, Player p, PlayerIOClient.Message m)
        {
            Console.ForegroundColor = info;
            Console.WriteLine(Convert.ToString(m));
        }

        private void onFace(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onGiveGrinch(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onGiveWitch(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onGiveWizard(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onGiveWizard2(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onGod(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onK(World w, Player subject, PlayerIOClient.Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

            // Update relevant objects.
            // Take the crown from the current holder.
            Tools.getCrownHolder(w).hasCrown = false;
            // Give it to the subject.
            subject.hasCrown = true;

            // Trigger the event.
            object[] args = new object[1] { id };

            playerEvent handler = _onCrown;
            handler(w, subject, args);
        }

        private void onKs(World w, Player p, PlayerIOClient.Message m)
        {
            // Extract data.
            int id = m.GetInt(0);

            // Update relevant objects.
            p.hasSilverCrown = true;

            // Trigger the event.
            object[] args = new object[1] { id };

            playerEvent handler = _onTrophy;
            handler(w, p, args);
        }

        private void onKill(PlayerIOClient.Message m, Player p)
        { }

        private void onLb(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onLevelUp(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onMod(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onP(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onPt(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onTs(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onW(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onWp(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onKill(World w, PlayerIOClient.Message m)
        { }

        private void onClear(World w, PlayerIOClient.Message m)
        { }

        private void onHide(World w, PlayerIOClient.Message m)
        { }

        private void onInfo(World w, PlayerIOClient.Message m)
        { }

        private void onRefreshShop(World w, PlayerIOClient.Message m)
        { }

        private void onReset(World w, PlayerIOClient.Message m)
        { }

        private void onSaved(World w, PlayerIOClient.Message m)
        { }

        private void onSayOld(World w, PlayerIOClient.Message m)
        { }

        private void onShow(World w, PlayerIOClient.Message m)
        { }

        private void onTeleport(World w, PlayerIOClient.Message m)
        { }

        private void onTele(World w, PlayerIOClient.Message m)
        { }

        private void onUpdateMeta(World w, PlayerIOClient.Message m)
        { }

        private void onUpgrade(World w, PlayerIOClient.Message m)
        { }

        private void onWrite(World w, PlayerIOClient.Message m)
        { }

        private void onLeft(World w, Player p, PlayerIOClient.Message m)
        { }

        private void onInit(World w, PlayerIOClient.Message m)
        {
            string owner = m.GetString(0),
                name = m.GetString(1),
                worldKey = Tools.rot13(m.GetString(5)),
                botName = m.GetString(9);

            int plays = m.GetInt(2),
                woots = m.GetInt(3),
                totalWoots = m.GetInt(4);

            double botX = m.GetDouble(7),
                botY = m.GetDouble(8);

            w.owner = owner;
            w.name = name;
            w.plays = plays;
            w.woots = woots;
            w.totalWoots = totalWoots;
            w.worldKey = worldKey;

            World.bot.x = botX;
            World.bot.y = botY;
            World.bot.name = botName;

            //msg[6] = 58  (0)
            //...
            //msg[10] = False  (8)
            //msg[11] = False  (8)
            //msg[12] = 100  (0)
            //msg[13] = 400  (0)
            //msg[14] = False  (8)
            //msg[15] = 1  (4)
            //msg[16] = False  (8)
            //msg[17] = ws  (6)
            //msg[18] = 182  (1)
            //msg[19] = 0  (0)

            Console.WriteLine("Joined level \"" + w.name + "\" successfully.", success);

            World.Worlds.Add(w);

            object[] args = new object[9] { owner, name, plays, woots, totalWoots, worldKey, botX, botY, botName };

            playerEvent handler = _onInit;
            handler(w, World.bot, args);
        }

        private void onM(World w, Player p, PlayerIOClient.Message m)
        {
            double x = m.GetDouble(1), // Starting x location
                y = m.GetDouble(2), // Starting y location
                speedX = m.GetDouble(3), // Starting horizontal speed
                speedY = m.GetDouble(4), // Starting vertical speed
                modifierX = m.GetDouble(5), // Horizontal modifier
                modifierY = m.GetDouble(6), // Vertical modifier
                horizontal = m.GetDouble(7), // Horizontal angle
                vertical = m.GetDouble(8), // Vertical angle
                gravityMultiplier = m.GetDouble(9); // Gravity multiplier

            bool spacedown = m.GetBoolean(10);

            p.x = x;
            p.y = y;

            object[] args = new object[10] { x, y, speedX, speedY, modifierX, modifierY, horizontal, vertical, gravityMultiplier, spacedown };

            playerEvent handler = _onMovement;
            handler(w, p, args);
        }

        private void onSay(World w, Player p, PlayerIOClient.Message m)
        {
            string message = m.GetString(1);

            object[] args = new object[1] { message };

            playerEvent handler = _onChat;
            handler(w, p, args);
        }

        private void onB(World w, Player p, PlayerIOClient.Message m)
        {
            Console.WriteLine(m);
        }




        public Player getPlayer(int id)
        {
            World w = thisWorld();

            foreach (Player p in w.onlinePlayers)
            {
                if (p.id == id)
                {
                    return p;
                }
            }

            return new Player();
        }

        public World thisWorld()
        {
            foreach (World w in World.Worlds)
            {
                if (w.pull == this)
                {
                    return w;
                }
            }
            return new World() { name = "null" };
        }

        public delegate void worldEvent(World origin, object[] args);
        
        public delegate void playerEvent(World origin, Player sender, object[] args);

        public event worldEvent
            _onPotionToggle = delegate { },
            _onSystemMessage = delegate { },
            _onUpdate = delegate { },
            _onUpdateMeta = delegate { },
            _onShow = delegate { },
            _onHide = delegate { },
            _onSaved = delegate { },
            _onOldChat = delegate { },
            _onReset = delegate { },
            _onRefreshshop = delegate { },
            _onKill = delegate { },
            _onInfo = delegate { },
            _onClear = delegate { };

        public event playerEvent
            _onInit = delegate { },
            _onAutotext = delegate { },
            _onCrown = delegate { },
            _onModMode = delegate { },
            _onLevelUp = delegate { },
            _onTrophy = delegate { },
            _onLabel = delegate { },
            _onFace = delegate { },
            _onGod = delegate { },
            _onGrinch = delegate { },
            _onWitch = delegate { },
            _onWizard = delegate { },
            _onRedWizard = delegate { },
            _onLeave = delegate { },
            _onJoin = delegate { },
            _onMovement = delegate { },
            _onPotion = delegate { },
            _onChat = delegate { },
            _onRotate = delegate { },
            _onCoinCollected = delegate { },
            _onTeleport = delegate { },
            _onTele = delegate { },
            _onWoot = delegate { },
            _onBlock = delegate { },
            _onCoinBlock = delegate { },
            _onSoundBlock = delegate { },
            _onPortalBlock = delegate { },
            _onWorldPortalBlock = delegate { },
            _onSignBlock = delegate { };
    }
}
