using Skylight.Miscellaneous;

namespace Skylight.Blocks
{
    public class PortalBlock : Block
    {
        private const int
            Minportalid = 0,
            Maxportalid = 99;

        private int
            _portalDestination = -1,
            _portalId = -1;

        private bool
            _visible;

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
            get { return _portalDestination; }

            internal set
            {
                if (value > Minportalid && value < Maxportalid)
                {
                    _portalDestination = value;
                }
            }
        }

        public int PortalId
        {
            get { return _portalId; }

            internal set
            {
                if (value < Maxportalid && value > Minportalid)
                {
                    _portalId = value;
                }
            }
        }

        public bool Visible
        {
            get { return _visible; }

            internal set { _visible = value; }
        }
    }
}