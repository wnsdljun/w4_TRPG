using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_TRPG
{
    public abstract class Armor : IEquipable
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public bool IsEquiped { get; set; }
        public abstract int DefenseIncrement { get; }
    }
}
