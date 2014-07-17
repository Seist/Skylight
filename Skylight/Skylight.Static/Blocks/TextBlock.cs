// <copyright file="TextBlock.cs" company="">
//     Copyright 2014 (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Skylight.Blocks
{
    /// <summary>
    /// Class TextBlock.
    /// </summary>
    public class TextBlock : Block
    {
        /// <summary>
        /// The message that is on the text block.
        /// </summary>
        private string _text = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBlock"/> class.
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
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return _text; }

            internal set { _text = value; }
        }
    }
}