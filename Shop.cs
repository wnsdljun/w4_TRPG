using System;

namespace w4_TRPG
{
    public class Shop
    {
        public class ShopItem
        {
            public IItem? item;
            public int price;
            public int count;

            public ShopItem(IItem item, int price, int count)
            {
                this.item = item;
                this.price = price;
                this.count = count;
            }
        }
        public Dictionary<IItem, ShopItem> stock = new Dictionary<IItem, ShopItem>();


        public void AddStock(IItem item, int price, int count)
        {
            if (stock.ContainsKey(item)) //상점에 이미 아이템이 있으면 수량 추가
            {
                stock[item].count += count; //stackable == true 라도 상점에서는 겹칠 수 있게 취급?
            }
            else
            {
                ShopItem shopItem = new ShopItem(item, price, count);
                stock.Add(item, shopItem);
            }
        }


        public TransactionCode Sell(Player player, IItem item, int count) //상점 기준에서
        {
            if (!stock.ContainsKey(item)) return TransactionCode.NoItem;
            if (stock[item].count < count) return TransactionCode.OverCount;
            if (stock[item].price > player.Money) return TransactionCode.NotEnoughMoney;

            if (stock.ContainsKey(item)) //조건을 다시 검사할 필요가 있을까...?
            {
                if (item.IsStackable) //겹칠 수 있는 아이템이라면
                {
                    if (player.Inventory.GetItemsinInventory().Contains(item))
                    {

                    }
                    else //인벤토리에 없는 아이템이라면
                    {
                        /*
                        IItem _item = item;
                        _item.Count = count;
                    
                        player.Inventory.AddItem(_item);
                        */
                    }
                }
                else //겹칠 수 없는 아이템이라면
                {
                    for (int i = 0; i < count; i++) //구매 수량만큼 반복구매
                    {
                        player.Inventory.AddItem(item); //겹칠수없는아이템이니까 있는지 없는지, 수량 검사할 필요가 없음.
                        player.Money -= stock[item].price;
                        stock[item].count--;
                        
                        //초과 수량 구매로 인해 돈이 음수로 내려가는 경우 처리 필요
                    }
                    return TransactionCode.Success;
                }
            }
            return TransactionCode.Error;
        }

        public void Show(Player player, bool tradeMode = false) //플레이어 인벤토리와 비교해 있으면 구매완료로 표시
        {
            int index = 0;
            //인벤토리 보여주는 코드 복사해 수정
            foreach (var item in stock)
            {
                //출력 양식 맞추기...(?)
                //bool isEquiped = false;
                string type = "";

                //착용 가능한 아이템의 경우
                if (item.Key is IEquipable equipable)
                {
                    //isEquiped = equipable.IsEquiped;
                    if (equipable is Weapon weapon) type = weapon.AttackIncrement >= 0 ? $"공격력 +{weapon.AttackIncrement}" : $"공격력 -{weapon.AttackIncrement}";
                    else if (equipable is Armor armor) type = armor.DefenseIncrement >= 0 ? $"방어력 +{armor.DefenseIncrement}" : $"방어력 -{armor.DefenseIncrement}";
                    //나머지 타입의 경우..나중에 추가하자.
                }


                //출력부
                Console.WriteLine($" {(tradeMode ? ++index : "-")} {item.Key.Name} | {type} | {item.Key.Description} | {(player.Inventory.GetItemsinInventory().Contains(item.Key) ? "구매완료" : $"{item.Value.price} G")}");
            }
        }
    }

    public enum TransactionCode
    {
        Empty = -2,
        Error = -1,
        Success = 0,
        OutOfStock = 1,
        NoItem = 2,
        OverCount = 3,
        NotEnoughMoney = 4
    }
}
