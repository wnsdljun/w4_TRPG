namespace w4_TRPG
{
    public interface IItem : IStackable
    {
        string Name { get; }
        string Description { get; }
    }
    public interface IStackable
    {
        int Count { get; }
        bool IsStackable { get; }
    }

    public interface IEquipable : IItem
    {
        bool IsEquiped { get; set; }
    }
    public interface IConsumable : IItem
    {

    }
}
