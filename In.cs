using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PlayerIOClient;

namespace Skylight
{
    public class In
    {
        public static ConsoleColor blank = ConsoleColor.White, progress = ConsoleColor.Yellow, success = ConsoleColor.Green, error = ConsoleColor.Red, info = ConsoleColor.Cyan;

        public static string parseLevelID(string unparsedLevelID)
        {
            string[] pathcomponents = unparsedLevelID.Split('/'); //Split the URL
            return pathcomponents[pathcomponents.Count() - 1];    //Return the last section: the ID
        }

        public void onMessage(object sender, PlayerIOClient.Message m)
        {
            //Player p = getPlayer(m.GetInt(0));
            Player p = new Player();
            World w = new World();

            foreach (World wl in World.Worlds)
            {
                if (wl.pull == this)
                {
                    w = wl;
                }
            }
            if (w == null)
                Out.writeLine("I don't know where that message came from", error);

            else
                Out.writeLine("Message came from " + w.name, success);


            // This is where we diverge the messages.
            // I chose to use a switch for this, but an else-if chain would work just as well.
            // Also, don't feel compelled to make your bot do something for every message. 75% of these you will never see or need to use.

            switch (Convert.ToString(m.Type))
            {
                case "access": onAccess(m);
                    break; // Triggered when someone gets edit rights.
                case "add": onAdd(m, w);
                    break; // Triggered when someone joins.
                case "allowpotions":
                    break; // Triggered when you allow/deny potions
                case "autotext":
                    break; // Triggered when someone says an autotext phrase. (e.g. "Help me!", "Left.")
                case "b": onB(m, p, w);
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
                case "init": onInit(m, w);
                    break; // Triggered when the bot joins the level.
                case "k":
                    break; // Triggered when someone gets the crown.
                case "kill":
                    break; // Triggered when the world crashes.
                case "ks":
                    break; // Triggered when someone touches trophy.
                case "lb":
                    break; // Triggered when a mod places a label.
                case "left": onLeft(m, p, w);
                    break; // Triggered when someone leaves.
                case "levelup":
                    break; // Triggered when someone levels up.
                case "lostaccess": onLostAccess(m);
                    break; // Triggered when someone loses edit rights.
                case "m": onM(m, p, w);
                    break; // Triggered when someone moves.
                case "mod":
                    break; // Triggered when someone goes into mod-mode.
                case "pt":
                    break; // Triggered when someone places a portal.
                case "refreshshop":
                    break; // Triggered when the shop is refreshed.
                case "reset":
                    break; // Triggered when someone resets the level.
                case "say": onSay(m, p, w);
                    break; // Triggered when someone says something.
                case "say_old":
                    break; // Triggered when the bot joins; gets old messages.
                case "saved":
                    break; // Triggered when the level is saved.
                case "show":
                    break; // Triggered when timed doors show.
                case "tele":
                    break; // Triggered when someone teleports.
                case "updatemeta":
                    break; // Automatically sent every 30 seconds with level info.
                case "upgrade":
                    break; //Triggered when game updates.
                case "wp":
                    break; // Triggered when someone places world portal.
                case "write":
                    break; // Triggered when the system says something in chat.
                case "wu":
                    break; // Triggered when someone woots.
                default:
                    break;
            }
        }

        private static void onAccess(PlayerIOClient.Message m)
        {
            Out.writeLine("You now have editing rights.", info);
        }

        private static void onLostAccess(PlayerIOClient.Message m)
        {
            Out.writeLine("You have lost your editing rights.", info);
        }

        private static void onAdd(PlayerIOClient.Message m, World w)
        {
            w.onlinePlayers.Add(new Player { });
        }

        private static void onLeft(PlayerIOClient.Message m, Player p, World w)
        {

        }

        private static void onInit(PlayerIOClient.Message m, World w)
        {
            w.owner = m.GetString(0);
            w.name = m.GetString(1);
            w.plays = m.GetInt(2);
            w.woots = m.GetInt(3);
            w.totalWoots = m.GetInt(4);
            w.worldKey = rot13(m.GetString(5));

            Out.writeLine("Joined level \"" + w.name + "\" successfully.", success);
        }

        private static void onM(PlayerIOClient.Message m, Player p, World w)
        {
            Console.WriteLine(m);
            int id = m.GetInt(0);
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

            Player subject = getPlayer(id);
            subject.x = x;
            subject.y = y;
        }

        private static void onSay(PlayerIOClient.Message m, Player p, World w)
        {

        }

        private static void onB(PlayerIOClient.Message m, Player p, World w)
        {

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
                        return p;
                }
            }
            return null;
        }
    }
}