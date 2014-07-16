using System.Text.RegularExpressions;

namespace Skylight
{
    public class RoomPortalBlock : Block
    {
        private string portalDestination;

        public RoomPortalBlock(
            int x,
            int y,
            string portalDestination) : base(BlockIds.Action.Portals.WORLD, x, y, 0)
        {
            PortalDestination = portalDestination;
        }

        public string PortalDestination
        {
            get { return portalDestination; }

            internal set
            {
                string s = value;
                Tools.ParseURL(s);
                if (Regex.IsMatch(s, "[A-Za-z0-9-_]{13}"))
                {
                    portalDestination = s;
                }
            }
        }
    }
}