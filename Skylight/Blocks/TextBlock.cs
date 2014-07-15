namespace Skylight
{
    using System;

    public class TextBlock : Block
    {
        private string text = string.Empty;

        public TextBlock(
            int id,
            int x,
            int y,
            string text) : base(id, x, y, 0)
        {
            this.Text = text;
        }

        public string Text
        {
            get;

            internal set;
        }
    }
}
