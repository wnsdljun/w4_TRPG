﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_TRPG
{
    public class Warrior : ICharacter
    {
        public string Name { get; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Attack => new Random().Next(10, AttackPower);
        public bool IsDead => Health <= 0;

        public Warrior(string name)
        {
            Name = name;
            Health = 100;
            AttackPower = 20;
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
