// <copyright file="RoomPortalBlock.cs" company="">
//     Copyright 2014 (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Text.RegularExpressions;
using Skylight.Blocks;


namespace Skylight
{
    /// <summary>
    ///     Class RoomPortalBlock.
    /// </summary>
    public class RoomPortalBlock : Block
    {
        /// <summary>
        ///     The portal destination
        /// </summary>
        private string _portalDestination;

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
            PortalDestination = portalDestination;
        }

        /// <summary>
        ///     Gets the portal destination.
        /// </summary>
        /// <value>The portal destination.</value>
        public string PortalDestination
        {
            get { return _portalDestination; }

            internal set
            {
                var s = value;
                Tools.ParseUrl(s);
                if (Regex.IsMatch(s, "[A-Za-z0-9-_]{13}"))
                {
                    _portalDestination = s;
                }
            }
        }
    }
}