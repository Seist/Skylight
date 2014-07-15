namespace Skylight
{
    using PlayerIOClient;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Logging
    {

        public static void SkylightMessage(string m)
        {
            ProgramMessage(m);
        }

    }


}