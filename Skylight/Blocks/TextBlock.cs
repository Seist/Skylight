namespace Skylight
{
    public class TextBlock : Block
    {
        private string text = string.Empty;

        public TextBlock(
            int id,
            int x,
            int y,
            string text) : base(id, x, y, 0)
        {
            Text = text;
        }

        public string Text
        {
            get { return text; }

            internal set { text = value; }
        }
    }
}