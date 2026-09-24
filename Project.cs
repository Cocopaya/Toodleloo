using System;
using System.Collections.Generic;
using System.Text;

namespace Toodleloo
{
    internal class Project(string name)
    {
        public string Name { get; set; } = name;
    }
}
