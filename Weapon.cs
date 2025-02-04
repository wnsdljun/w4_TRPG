using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace w4_TRPG
{
    public abstract class Weapon : IEquipable
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public bool IsEquiped { get; set; }
        public abstract int AttackIncrement { get; }

    }
}
