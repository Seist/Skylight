namespace Skylight
{
    using System;

    public class TextBlock : Block
    {
        private string text = null;

        public TextBlock(
            int x,
            int y,
            int id,
            string text,
            Room r,
            Player placer = null) : base(x, y, id, r, placer)
        {
            this.Coords.X = x;
            this.Coords.Y = y;
            this.Text = text;
            this.R = r;
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
