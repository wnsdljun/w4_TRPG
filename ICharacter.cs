using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_TRPG
{
    public interface ICharacter
    {
        int Level { get; }
        string Name { get; }
        int Attack { get; }
        int Defense { get; }
        int Health { get; set; }
        bool IsDead { get; }
        void TakeDamage(int damage);
    }

    public enum Profession
    {
        Warrior = 0
    }
}
