using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_TRPG
{
    public interface ICharacter
    {
        string Name { get; }
        int Health { get; set; }
        int Attack { get; }
        bool IsDead { get; }
        void TakeDamage(int damage);
    }
}
