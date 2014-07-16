namespace Skylight
{
    public class PortalBlock : Block
    {
        private const int
            MINPORTALID = 0,
            MAXPORTALID = 99;

        private int
            portalDestination = -1,
            portalId = -1;

        private bool
            visible;

        public PortalBlock(
            int x,
            int y,
            int direction,
            int portalId,
            int portalDestination,
            bool visible) : base(Tools.PortalIdByVisible(visible), x, y, 0)
        {
            PortalDestination = portalDestination;
            PortalId = portalId;
            Visible = visible;
        }

        public int PortalDestination
        {
            get { return portalDestination; }

            internal set
            {
                if (value > MINPORTALID && value < MAXPORTALID)
                {
                    portalDestination = value;
                }
            }
        }

        public int PortalId
        {
            get { return portalId; }

            internal set
            {
                if (value < MAXPORTALID && value > MINPORTALID)
                {
                    portalId = value;
                }
            }
        }

        public bool Visible
        {
            get { return visible; }

            internal set { visible = value; }
        }
    }
}