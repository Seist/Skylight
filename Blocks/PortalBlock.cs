// ***********************************************************************
// <copyright file="PortalBlock.cs" company="">
//     Copyright 2014 (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************



namespace Skylight
{
    /// <summary>
    ///     Class PortalBlock.
    /// </summary>
    public class PortalBlock : Block
    {
        /// <summary>
        ///     The minportalid
        /// </summary>
        private const int
            Minportalid = 0,
            Maxportalid = 99;

        /// <summary>
        ///     The _portal destination
        /// </summary>
        private int
            _portalDestination = -1, _portalId = -1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PortalBlock" /> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordiante.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="portalId">The portal identifier.</param>
        /// <param name="portalDestination">The portal destination.</param>
        /// <param name="visible">if set to <c>true</c> then the portal is active.</param>
        public PortalBlock(
            int x,
            int y,
            int direction,
            int portalId,
            int portalDestination,
            bool visible) : base(Tools.PortalIdByVisible(visible), x, y, 0)
        {
            Direction = direction;
            PortalDestination = portalDestination;
            PortalId = portalId;
            Visible = visible;
        }

        /// <summary>
        ///     The direction of the portal.
        /// </summary>
        public new int Direction { get; set; }

        /// <summary>
        ///     Gets the portal destination.
        /// </summary>
        /// <value>The portal destination.</value>
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

        /// <summary>
        ///     Gets the portal identifier.
        /// </summary>
        /// <value>The portal identifier.</value>
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

        /// <summary>
        ///     Gets a value indicating whether this <see cref="PortalBlock" /> is visible.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        public bool Visible { get; internal set; }
    }
}