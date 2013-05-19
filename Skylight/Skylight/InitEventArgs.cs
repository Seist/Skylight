// <author>TakoMan02</author>
// <summary>InitEventArgs.cs provides an in-depth description of the InitEvent.</summary>
namespace Skylight
{
    using System;

    public class InitEventArgs : EventArgs
    {
        private World joinedWorld;

        public InitEventArgs(World joinedWorld)
        {
            this.joinedWorld = joinedWorld;
        }

        public World JoinedWorld
        {
            get { return this.joinedWorld; }
        }
    }
}
