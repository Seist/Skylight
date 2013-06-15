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
            string text,
            Player placer = null) : base(id, x, y, placer)
        {
            this.X = x;
            this.Y = y;
            this.Text = text;
            this.Placer = placer;
        }

        public string Text
        {
            get
            {
                return this.text;
            }

            internal set
            {
                this.text = value;
            }
        }
    }
}
