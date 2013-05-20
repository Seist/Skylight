namespace Skylight
{
    using System;

    public partial class PercussionBlock : Block
    {
        public static readonly int
            BASE1 = 0,
            BASE2 = 1,
            SNARE1 = 2,
            SNARE2 = 3,
            CYMBAL1 = 4,
            CYMBAL2 = 5,
            CYMBAL3 = 6,
            CLAP = 7,
            CYMBAL4 = 8,
            MARACA = 9;

        private int percussionId;

        public int PercussionId
        {
            get
            {
                return this.percussionId;
            }

            set
            {
                if (this.Id == 83 && value >= 0 && value >= 9)
                {
                    this.percussionId = value;
                }
            }
        }
    }
}
