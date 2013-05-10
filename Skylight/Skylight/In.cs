using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Skylight
{
    public class In
    {
        public delegate void playerEvent(object[] args, Player p, World w);
        public delegate void worldEvent(object[] args, World w);

        public static ConsoleColor blank = ConsoleColor.White, progress = ConsoleColor.Yellow, success = ConsoleColor.Green, error = ConsoleColor.Red, info = ConsoleColor.Cyan;

        public string parseLevelID(string unparsedLevelID)
        {
            string[] pathcomponents = unparsedLevelID.Split('/'); //Split the URL
            return pathcomponents[pathcomponents.Count() - 1];    //Return the last section: the ID
        }


         /*case


          */

        public static event worldEvent
            _onPotionToggle,
            _onSystemMessage,
            _onUpdate,
            _onUpdateMeta,
            _onShow,
            _onHide,
            _onSaved,
            _onOldChat,
            _onReset,
            _onRefreshshop,
            _onKill,
            _onInfo,
            _onClear;


        public static event playerEvent
            _onInit,
            _onAccess,
            _onLostAccess,
            _onAutotext,
            _onCrown,
            _onModMode,
            _onLevelUp,
            _onTrophy,
            _onLabel,
            _onFace,
            _onGod,
            _onGrinch,
            _onWitch,
            _onWizard,
            _onRedWizard,
            _onLeave,
            _onJoin,
            _onMovement,
            _onPotion,
            _onChat,
            _onRotate,
            _onCoinCollected,
            _onTeleport,
            _onTele,
            _onWoot,
            _onBlock,
            _onCoinBlock,
            _onSoundBlock,
            _onPortalBlock,
            _onWorldPortalBlock,
            _onSignBlock;

        public void onMessage(object sender, PlayerIOClient.Message m)
        {
            World w = getWorld(this);

            // This is where we diverge the messages.
            // I chose to use a switch for this, but an else-if chain would work just as well.
            // Also, don't feel compelled to make your bot do something for every message. 75% of these you will never see or need to use.

            switch (Convert.ToString(m.Type))
            {
                case "access":
                    break; // Triggered when someone gets edit rights.
                case "add": onAdd(m);
                    break; // Triggered when someone joins.
                case "allowpotions":
                    break; // Triggered when you allow/deny potions
                case "autotext":
                    break; // Triggered when someone says an autotext phrase. (e.g. "Help me!", "Left.")
                case "b": onB(m, getPlayer(m.GetInt(0)));
                    break; // Triggered when someone builds a brick.
                case "bc":
                    break; // Triggered when someone places a coin block.
                case "br":
                    break; // Triggered when someone rotates a block.
                case "bs":
                    break; // Triggered when someone creates a sound block.
                case "c":
                    break; // Triggered when someone collects a coin.
                case "clear":
                    break; // Triggered when someone clears level.
                case "face":
                    break; // Triggered when someone changes smiley.
                case "givegrinch":
                    break; // Triggered when someone gets Grinch smiley.
                case "givewitch":
                    break; // Triggered when someone gets Witch smiley.
                case "givewizard":
                    break; // Triggered when someone gets Blue Wizard smiley.
                case "givewizard2":
                    break; // Triggered when someone gets Red Wizard smiley.
                case "god":
                    break; // Triggered when someone goes into/out of god mode.
                case "hide":
                    break; // Triggered when timed doors hide.
                case "info":
                    break; // Triggered when the bot receives a pop-up window (like kick, info).
                case "init": onInit(m);
                    break; // Triggered when the bot joins the level.
                case "k":
                    break; // Triggered when someone gets the crown.
                case "kill":
                    break; // Triggered when the world crashes.
                case "ks":
                    break; // Triggered when someone touches trophy.
                case "lb":
                    break; // Triggered when a mod places a label.
                case "left": onLeft(m, getPlayer(m.GetInt(0)));
                    break; // Triggered when someone leaves.
                case "levelup":
                    break; // Triggered when someone levels up.
                case "lostaccess":
                    break; // Triggered when someone loses edit rights.
                case "m": onM(m, getPlayer(m.GetInt(0)));
                    break; // Triggered when someone moves.
                case "mod":
                    break; // Triggered when someone goes into mod-mode.
                case "p":
                    break; // Triggered when someone uses a potion
                case "pt":
                    break; // Triggered when someone places a portal.
                case "refreshshop":
                    break; // Triggered when the shop is refreshed.
                case "reset":
                    break; // Triggered when someone resets the level.
                case "say": onSay(m, getPlayer(m.GetInt(0)));
                    break; // Triggered when someone says something.
                case "say_old":
                    break; // Triggered when the bot joins; gets old messages.
                case "saved":
                    break; // Triggered when the level is saved.
                case "show":
                    break; // Triggered when timed doors show.
                case "tele": // Triggered when someone teleports via /reset or /loadlevel
                    break;
                case "teleport":
                    break; // Triggered when someone teleports.
                case "ts":
                    break; // Triggered when someone places a sign. (?)
                case "updatemeta":
                    break; // Automatically sent every 30 seconds with level info.
                case "upgrade":
                    break; //Triggered when game updates.
                case "wp":
                    break; // Triggered when someone places world portal.
                case "write":
                    break; // Triggered when the system says something in chat.
                case "w":
                case "wu":
                    break; // Triggered when someone woots.
                default:
                    break;
            }
        }

        private void onAdd(PlayerIOClient.Message m)
        {
            World w = getWorld(this);

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

            if (w.name == null)
            {
                w.alreadyJoined.Add(p);
            }
            else
            {
                Out.writeLine(name + " has joined " + w.name + ".", success);
            }
        }

        private void onLeft(PlayerIOClient.Message m, Player p)
        {

        }

        private void onInit(PlayerIOClient.Message m)
        {
            World w = getWorld(this);

            w.owner = m.GetString(0);
            w.name = m.GetString(1);
            w.plays = m.GetInt(2);
            w.woots = m.GetInt(3);
            w.totalWoots = m.GetInt(4);
            w.worldKey = rot13(m.GetString(5));

            Out.writeLine("Joined level \"" + w.name + "\" successfully.", success);

            foreach (Player p in w.alreadyJoined)
            {
                Out.writeLine(p.name + " has joined " + w.name + ".", success);
            }
        }

        private void onM(PlayerIOClient.Message m, Player p)
        {
            World w = getWorld(this);

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

            _onMovement.Invoke(args, p, w);
        }

        private void onSay(PlayerIOClient.Message m, Player p)
        {
            World w = getWorld(this);
            string message = m.GetString(1);
            object[] args = new object[1] { message };
            _onChat.Invoke(args, p, w);
        }

        private void onB(PlayerIOClient.Message m, Player p)
        {
            World w = getWorld(this);

            object[] args = new object[1] { m };
            _onBlock.Invoke(args, p, w);
        }

        public static string rot13(string worldKey)
        {
            char[] array = worldKey.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                int number = (int)array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                array[i] = (char)number;
            }
            return new string(array);
        }

        public static Player getPlayer(int id)
        {
            foreach (World w in World.Worlds)
            {
                foreach (Player p in w.onlinePlayers)
                {
                    if (p.id == id)
                    {
                        return p;
                    }
                }
            }

            return new Player();
        }
        public static World getWorld(In pull)
        {
            foreach (World w in World.Worlds)
            {
                if (w.pull == pull)
                {
                    return w;
                }
            }
            return new World() { name = "null" };
        }
    }
}
