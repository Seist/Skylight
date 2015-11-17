using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skylight
{
    public sealed class Crew
    {
        public Crew(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; internal set; }

        public string Name { get; internal set; }
    }
}
