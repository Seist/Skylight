namespace Skylight
{
    using System;

    public class PianoBlock : Block
    {
        public const int
            C1      = 1,
            CSHARP1 = 2,
            D1      = 3,
            DSHARP1 = 4,
            E1      = 5,
            F1      = 6,
            FSHARP1 = 7,
            G1      = 8,
            GSHARP1 = 9,
            A1      = 10,
            ASHARP1 = 11,
            B1      = 12,
            C2      = 13,
            CSHARP2 = 14,
            D2      = 15,
            DSHARP2 = 16,
            E2      = 17,
            F2      = 18,
            FSHARP2 = 19,
            G2      = 20,
            GSHARP2 = 21,
            A2      = 22,
            ASHARP2 = 23,
            B2      = 24,
            C3      = 25;

        private int pianoId = -1;
        
        public PianoBlock( 
            int x, 
            int y, 
            int key, 
            Room r, 
            Player placer = null) : base(BlockIds.Action.Music.PIANO, x, y, r, placer)
        {
            this.X = x;
            this.Y = y;
            this.PianoId = key;
            this.R = r;
            this.Placer = placer;
        }

        public int PianoId
        {
            get
            {
                return this.pianoId;
            }

            set
            {
                if (this.pianoId == -1)
                {
                    this.pianoId = value;
                }
            }
        }
    }
}
