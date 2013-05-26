// <author>TakoMan02</author>
// <summary>BotEventArgs.cs provides an in-depth description of the BotEvent.</summary> 
namespace Skylight
{
    using System;

    public class BotEventArgs : EventArgs
    {
        private Bot bot;

        private Room origin;

        public BotEventArgs(Bot bot, Room origin)
        {
            this.bot = bot;
            this.origin = origin;
        }

        public Player Bot
        {
            get { return this.bot; }
        }

        public Room Origin
        {
            get { return this.origin; }
        }
    }
}