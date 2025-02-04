using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_TRPG
{
    internal interface IItem
    {
        string Name { get; }

        public void Use(Warrior warrior);
    }
}
