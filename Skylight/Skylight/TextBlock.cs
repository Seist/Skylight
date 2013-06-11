namespace Skylight
{
    using System;

    public class TextBlock : Block
    {
        private string text = null;

        public TextBlock(
            int id,
            int x,
            int y,
            string text,
            Room r,
            Player placer = null) : base(x, y, id, r, placer)
        {
            this.X = x;
            this.Y = y;
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

                    set
                    {
                        this.text = value;
                    }
                }
    }
}
