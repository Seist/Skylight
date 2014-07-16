namespace Skylight.Blocks
{
    public class TextBlock : Block
    {
        private string _text = string.Empty;

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
            get { return _text; }

            internal set { _text = value; }
        }
    }
}