// <copyright file="TextBlock.cs" company="">
//     Copyright 2014 (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Skylight.Blocks;

namespace Skylight
{
    /// <summary>
    ///     Class TextBlock.
    /// </summary>
    public class TextBlock : Block
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TextBlock" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="text">The text.</param>
        public TextBlock(
            int id,
            int x,
            int y,
            string text) : base(id, x, y, 0)
        {
            Text = text;
        }

        /// <summary>
        ///     Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; internal set; }
    }
}