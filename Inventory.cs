using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_TRPG
{
    public class Inventory
    {
        private List<IItem> itemList = new List<IItem>();
        public List<IItem>? sortedItemList;

        public void AddItem(IItem item)
        {
            itemList.Add(item);
        }
        public void RemoveItem(IItem item)
        {
            itemList.Remove(item);
        }
        public void Show(bool showIndex = false)
        {
            int index = 1;
            //우선 아이템을 정렬
            sortedItemList = itemList.OrderBy(item =>
            {
                if (item is Weapon) return 0;
                if (item is Armor) return 1;
                return 2;
            }).ToList();

            //아이템 출력
            foreach (var item in sortedItemList)
            {
                //출력 양식 맞추기...(?)
                bool isEquiped = false;
                string type = "";
      
                //착용 가능한 아이템의 경우
                if (item is IEquipable equipable)
                {
                    isEquiped = equipable.IsEquiped;
                    if (equipable is Weapon weapon) type = weapon.AttackIncrement >= 0 ? $"공격력 +{weapon.AttackIncrement}" : $"공격력 -{weapon.AttackIncrement}";
                    else if (equipable is Armor armor) type = armor.DefenseIncrement >= 0 ? $"방어력 +{armor.DefenseIncrement}" : $"방어력 -{armor.DefenseIncrement}";
                    //나머지 타입의 경우..나중에 추가하자.
                }


                //출력부
                Console.Write(" {0} ",showIndex ? index++ : "-");
                if (isEquiped)
                {
                    Console.Write('[');
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('E');
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(']');
                }
                Console.WriteLine($"{item.Name} | {type} | {item.Description}");
            }
        }

        public List<IItem> GetItemsinInventory()
        {
            return new List<IItem>(itemList);
        }
    }
}
