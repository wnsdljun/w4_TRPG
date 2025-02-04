using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_TRPG
{
    public class StrengthPotion : IItem
    {
        public string Name => "공격력 포션";
        public string Description => "설명입니다.";
        public void Use(Warrior warrior)
        {
            Console.WriteLine("공격력 포션을 사용합니다. 공격력이 10 증가합니다.");
            warrior.AttackPower += 10;
        }
    }
}
