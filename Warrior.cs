using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_TRPG
{
    public class Warrior : ICharacter
    {
        public int Level {  get; }
        public string Name { get; }
        public Profession Profession => Profession.Warrior;
        public int Health { get; set; }
        public int Defense { get; set; }
        public int AttackPower { get; set; }
        public int Attack => new Random().Next(10, AttackPower);
        public bool IsDead => Health <= 0;
        public int Money { get; set; }
        public Inventory Inventory { get; set; }

        public Warrior(string name)
        {
            Name = name;
            Health = 100;
            AttackPower = 10;
            Defense = 5;
            Money = 1500;
            Level = 1;
            Inventory = new Inventory();
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (IsDead)
            {
                Console.WriteLine($"{Name}이(가) 죽었습니다.");
            }
            else
            {
                Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {Health}");
            }
        }
    }
}
