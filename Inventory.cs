using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_TRPG
{
    public class Inventory
    {
        private List<IItem> itemList = new List<IItem>();

        public void AddItem(IItem item)
        {
            itemList.Add(item);
        }
        public void RemoveItem(IItem item)
        {
            itemList.Remove(item);
        }
        public void Show()
        {
            foreach (var item in itemList)
            {
                Console.WriteLine($"");
            }
        }
    }
}
