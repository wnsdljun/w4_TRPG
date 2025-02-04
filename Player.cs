namespace w4_TRPG
{
    public class Player : ICharacter
    {
        public int Level { get; }
        public string Name { get; }
        public Profession Profession { get; }
        public int Health { get; set; }
        public int Defense { get; set; }
        public int BaseAttackPower { get; set; }
        //public int Attack => new Random().Next(10, AttackPower);
        public bool IsDead => Health <= 0;
        public int Money { get; set; }
        public Inventory Inventory { get; set; }

        public Player(string name, Profession profession, int health, int defense, int attackPower, int money, int level = 1)
        {
            Level = level;
            Name = name;
            Profession = profession;
            Health = health;
            Defense = defense;
            BaseAttackPower = attackPower;
            Money = money;

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
        public int GetTotalAttackpower()
        {
            int additionalPower = 0;
            foreach (var item in Inventory.GetItemsinInventory())
            {
                if (item is Weapon tem) additionalPower += tem.IsEquiped ? tem.AttackIncrement : 0;
            }
            return BaseAttackPower + additionalPower;
        }
        public int GetTotalDefensepower()
        {
            int additionalPower = 0;
            foreach (var item in Inventory.GetItemsinInventory())
            {
                if (item is Armor tem) additionalPower += tem.IsEquiped ? tem.DefenseIncrement : 0;
            }
            return Defense + additionalPower;
        }
        public int GetAdditionalAttackpower()
        {
            int additionalPower = 0;
            foreach (var item in Inventory.GetItemsinInventory())
            {
                if (item is Weapon tem) additionalPower += tem.IsEquiped ? tem.AttackIncrement : 0;
            }
            return additionalPower;
        }
        public int GetAdditionalDefensepower()
        {
            int additionalPower = 0;
            foreach (var item in Inventory.GetItemsinInventory())
            {
                if (item is Armor tem) additionalPower += tem.IsEquiped ? tem.DefenseIncrement : 0;
            }
            return additionalPower;
        }
    }
}
