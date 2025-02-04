namespace w4_TRPG
{
    public class Armor_novice : Armor
    {
        public override string Name => "수련자 갑옷";
        public override string Description => "수련에 도움을 주는 갑옷입니다.";
        public override int DefenseIncrement => 5;
    }
    public class Armor_castIron : Armor
    {
        public override string Name => "무쇠 갑옷";
        public override string Description => "무쇠로 만들어져 튼튼한 갑옷입니다.";
        public override int DefenseIncrement => 9;
    }
    public class Armor_spartan : Armor
    {
        public override string Name => "스파르타의 갑옷";
        public override string Description => "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.";
        public override int DefenseIncrement => 15;
    }

    public class Weapon_oldSword : Weapon
    {
        public override string Name => "낡은 검";
        public override string Description => "쉽게 볼 수 있는 낡은 검 입니다.";
        public override int AttackIncrement => 2;
    }
    public class Weapon_BronzeAxe : Weapon
    {
        public override string Name => "청동 도끼";
        public override string Description => "어디선가 사용되었던 것 같은 도끼입니다.";
        public override int AttackIncrement => 5;
    }
    public class Weapon_spartanSpear : Weapon
    {
        public override string Name => "스파르타의 창";
        public override string Description => "스파르타의 전사들이 사용했다는 전설의 창입니다";
        public override int AttackIncrement => 7;
    }
}
