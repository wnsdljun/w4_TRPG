namespace w4_TRPG
{
    public abstract class Weapon : IEquipable
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public bool IsEquiped { get; set; } = false;
        public abstract int AttackIncrement { get; }
        public int Count => 1;
        public bool IsStackable => false;
    }
}
