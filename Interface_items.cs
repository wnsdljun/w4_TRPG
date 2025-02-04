using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_TRPG
{
    public interface IItem
    {
        string Name { get; }
        string Description { get; }
    }

    public interface IEquipable : IItem
    {
        bool IsEquiped { get; set; }
    }
    public interface IConsumable : IItem 
    {

    }
}
