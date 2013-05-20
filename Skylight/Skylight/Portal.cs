namespace Skylight
{
    using System;

    public partial class Portal : Block
    {
        private const int
            MINPORTALID = 0,
            MAXPORTALID = 99;

        private int portalId, portalDestination;
        private bool visible;

        public int PortalId
        {
            get
            {
                return this.portalId;
            }

            set
            {
                if (value < MAXPORTALID && value > MINPORTALID)
                {
                    this.portalId = value;
                }
            }
        }

        public int PortalDestination
        {
            get
            {
                return this.portalDestination;
            }

            set
            {
                if (value > MINPORTALID && value < MAXPORTALID)
                {
                    this.portalDestination = value;
                }
            }
        }

        public bool Visible
        {
            get
            {
                return this.visible;
            }

            set
            {
                this.visible = value;
            }
        }
    }
}
