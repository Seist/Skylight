// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResetWorld.cs" company="">
//   
// </copyright>
// <summary>
//   Class Reset World.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using PlayerIOClient;

namespace Skylight
{
    /// <summary>
    ///     Class Reset World.
    /// </summary>
    public class ResetWorld
    {
        #region Fields

        /// <summary>
        ///     The _in
        /// </summary>
        private readonly In _in;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResetWorld" /> class.
        /// </summary>
        /// <param name="in">
        ///     The in.
        /// </param>
        public ResetWorld(In @in)
        {
            _in = @in;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Called when the world is cleared (then the internal map is).
        /// </summary>
        /// <param name="m">
        ///     The message.
        /// </param>
        public void OnReset(Message m)
        {
            foreach (var b in Tools.DeserializeInit(m, 1, _in.Source))
            {
                _in.Source.Map[b.X, b.Y, b.Z] = b;
            }
        }

        #endregion
    }
}