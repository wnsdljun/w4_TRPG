namespace w4_TRPG
{
    public interface IItem
    {
        string Name { get; }
        string Description { get; }
    }
    public interface IStackable
    {
        int Count { get; }
        bool IsStackable { get; }
    }

    public interface IEquipable : IItem , IStackable
    {
        bool IsEquiped { get; set; }
    }
    public interface IConsumable : IItem , IStackable
    {

    }
}
