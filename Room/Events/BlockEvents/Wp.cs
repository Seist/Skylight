// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Wp.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Wp.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Skylight
{
    using PlayerIOClient;

    using Skylight.Blocks;

    /// <summary>
    /// Class Wp.
    /// </summary>
    public class Wp
    {
        /// <summary>
        /// The _in
        /// </summary>
        private readonly In _in;

        /// <summary>
        /// Initializes a new instance of the <see cref="Wp"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public Wp(In @in)
        {
            _in = @in;
        }

        /// <summary>
        /// All of the delegates for BlockEvent. These fire when events occur
        /// (such as when a block was added or updated).
        /// </summary>
        public event In.BlockEvent
            RoomPortalBlockEvent = delegate { };

        /// <summary>
        /// Called when [wp].
        /// </summary>
        /// <param name="m">The m.</param>
        public void OnWp(Message m)
        {
            // Extract data.
            int x = m.GetInteger(0),
                y = m.GetInteger(1);

            // possible bug if the id of the block isn't definied then it could
            // mean that the portal is disabled, in which it would go under a seperate
            // category. The destination (below) may not exist.
            string destination = m.GetString(3);

            // Update relevant objects.
            Block b = new RoomPortalBlock(x, y, destination);

            this._in.Source.Map[x][y][0] = b;

            // Fire the event
            var e = new BlockEventArgs(b, m, _in.Source);

            this._in.Source.Pull.Wp.RoomPortalBlockEvent(e);
        }
    }
}