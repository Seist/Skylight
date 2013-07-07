namespace Skylight
{
    using System;
    using System.Text.RegularExpressions;

    public partial class RoomPortalBlock : Block
    {
        private string portalDestination;
        
        public RoomPortalBlock(
            int x,
            int y,
            string portalDestination,
            Player placer = null) : base(BlockIds.Action.Portals.WORLD, x, y, 0)
        {
            this.PortalDestination = portalDestination;
        }

        public string PortalDestination
        {
            get
            {
                return this.portalDestination;
            }

            internal set
            {
                string s = value;
                Tools.ParseURL(s);
                if (Regex.IsMatch(s, "[A-Za-z0-9-_]{13}"))
                {
                    this.portalDestination = s;
                }
            }
        }
    }
}