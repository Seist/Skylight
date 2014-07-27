// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomPortalBlock.cs" company="None">
//   Copyright 2014 (c) . All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Skylight
{
    using System.Text.RegularExpressions;

    using Skylight.Blocks;

    /// <summary>
    ///     Class RoomPortalBlock.
    /// </summary>
    public class RoomPortalBlock : Block
    {
        /// <summary>
        ///     The portal destination
        /// </summary>
        private string portalDestination;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RoomPortalBlock" /> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="portalDestination">The portal destination.</param>
        public RoomPortalBlock(
            int x,
            int y,
            string portalDestination) : base(BlockIds.Action.Portals.World, x, y, 0)
        {
            this.PortalDestination = portalDestination;
        }

        /// <summary>
        ///     Gets the portal destination.
        /// </summary>
        /// <value>The portal destination.</value>
        public string PortalDestination
        {
            get
            {
                return this.portalDestination;
            }

            private set
            {
                string s = value;
                Tools.ParseUrl(s);
                if (Regex.IsMatch(s, "[A-Za-z0-9-_]{13}"))
                {
                    this.portalDestination = s;
                }
            }
        }
    }
}