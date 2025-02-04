using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_TRPG
{
    public class HealthPotion : IItem
    {
        public string Name => "체력 포션";
        public string Description => "설명입니다.";
        public void Use(Warrior warrior)
        {
            Console.WriteLine("체력 포션을 사용합니다. 체력이 50 증가합니다.");
            warrior.Health += 50;
            if (warrior.Health > 100)
            {
                warrior.Health = 100;
            } 
        }
    }
}
