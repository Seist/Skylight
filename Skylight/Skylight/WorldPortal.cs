namespace Skylight
{
    using System;
    using System.Text.RegularExpressions;

    public partial class WorldPortal : Block
    {
        private string portalDestination;

        public string PortalDestination
        {
            get
            {
                return this.portalDestination;
            }

            set
            {
                if (Regex.IsMatch(value, "[A-Za-z0-9-_]{13}"))
                {
                    this.portalDestination = value;
                }
            }
        }
    }
}