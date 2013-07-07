namespace Skylight
{
    using System;

    public partial class PortalBlock : Block
    {
        private const int
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
            bool visible) : base(Tools.IdByVisible(visible), x, y, 0)
        {
            this.PortalDestination = portalDestination;
            this.PortalId = portalId;
            this.Visible = visible;
        }

        public int PortalDestination
        {
            get
            {
                return this.portalDestination;
            }

            internal set
            {
                if (value > MINPORTALID && value < MAXPORTALID)
                {
                    this.portalDestination = value;
                }
            }
        }
        
        public int PortalId
        {
            get
            {
                return this.portalId;
            }

            internal set
            {
                if (value < MAXPORTALID && value > MINPORTALID)
                {
                    this.portalId = value;
                }
            }
        }

        public bool Visible
        {
            get
            {
                return this.visible;
            }

            internal set
            {
                this.visible = value;
            }
        }
    }
}
