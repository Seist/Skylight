namespace Skylight
{
    using System;

    public partial class PortalBlock : Block
    {
        private static const int
            MINPORTALID = 0,
            MAXPORTALID = 99;

        private bool
            visible = false;

        private int
            portalDestination = -1,
            portalId = -1;

        public PortalBlock(
            int x,
            int y,
            int direction,
            int portalId,
            int portalDestination,
            bool visible)
            : base(Tools.PortalIdByVisible(visible), x, y, 0)
        {
            this.PortalDestination = portalDestination;
            this.PortalId = portalId;
            this.Visible = visible;
        }

        public int PortalDestination
        {
            get;

            internal set
            {
                if (isValidPortal(value))
                {
                    this.portalDestination = value;
                }
            }
        }

        public int PortalId
        {
            get;

            internal set
            {
                if (isValidPortal(value))
                {
                    this.portalId = value;
                }
            }
        }
        public bool isValidPortal(int b_id)
        {
            return (b_id < MAXPORTALID && b_id > MINPORTALID);

        }
        public bool Visible
        {
            get;

            internal set;
        }
    }
}
