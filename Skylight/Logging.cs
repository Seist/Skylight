namespace Skylight
{
    using PlayerIOClient;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public static class Logging
    {
        public delegate void ProgramEvent(string message);
        public static event ProgramEvent ProgramMessage = delegate { };

        public static void SkylightMessage(string m)
        {
            ProgramMessage(m);
        }

    }


}