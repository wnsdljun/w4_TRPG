using System.Threading;

namespace w4_TRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player;
            Shop normalShop;
            //시작 화면
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 던전에 오신 여러분, 환영합니다.");
                Console.WriteLine("원하시는 이름을 입력하거나 \"이어하기\" 를 입력해 이어서 할 수 있습니다.");
                Console.WriteLine("[경고]이름을 새로 입력하는 경우 이미 저장된 세이브파일이 덮어씌워질 수 있습니다.");

                string str = PlayerInput.ReadInput("수줍어 말고 뭐라도 적을 수 있도록!");

                if (str == "이어하기")
                {
                    Console.Clear();
                    Console.WriteLine("미구현");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"[{str}] 정말 이 이름을 사용하시겠습니까?");
                    Console.WriteLine("");
                    Console.WriteLine("1. 네");
                    Console.WriteLine("2. 아니오");

                    if (PlayerInput.ReadInput(1, 2) == 2) continue; //아니오 선택 시 다시 루프

                    //예 선택 시 워리어 이름 넣어 생성해 넣기.
                    player = new Player(str, Profession.Warrior, 100, 5, 10, 1500, 1);

                    normalShop = new Shop();
                    normalShop.AddStock(new Weapon_oldSword(), 600, 2);
                    normalShop.AddStock(new Weapon_BronzeAxe(), 1500, 2);
                    normalShop.AddStock(new Weapon_spartanSpear(), 3500, 1);
                    normalShop.AddStock(new Armor_novice(), 800, 1);
                    normalShop.AddStock(new Armor_castIron(), 1500, 1);
                    normalShop.AddStock(new Armor_spartan(), 3500, 1);
                    break;
                }
            }
            player.Inventory.AddItem(new Weapon_BronzeAxe());
            player.Inventory.AddItem(new Weapon_oldSword());
            //player.Inventory.AddItem(new Weapon_spartanSpear());
            player.Inventory.AddItem(new Armor_castIron());
            player.Inventory.AddItem(new Armor_novice());
            //player.Inventory.AddItem(new Armor_spartan());
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분, 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");



                int enter = PlayerInput.ReadInput(1, 3);
                switch (enter)
                {
                    case 1: //상태 보기
                        ShowStat(player);
                        break;
                    case 2: //인벤토리
                        ShowInventory(player);
                        break;
                    case 3: //상점
                        ShowShop(player, normalShop);
                        break;
                }
            }




        }
        public static void ShowShop(Player player, Shop shop)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("상점");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.Money} G");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                shop.Show(player);
                Console.WriteLine("");
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("0. 나가기");
                switch (PlayerInput.ReadInput(0, 1))
                {
                    case 0:
                        return;
                    case 1:
                        Trade(player,shop);
                        break;
                }
            }
        }

        public static void Trade(Player player, Shop shop)
        {
            TransactionCode code = TransactionCode.Empty;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("상점");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.Money} G");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                shop.Show(player, true);
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                Console.SetCursorPosition(0, Console.WindowHeight - 5);
                switch (code) //코드에 맞게 표시
                {
                    case TransactionCode.Empty:
                        break;
                    case TransactionCode.NoItem:
                        Console.Write("우리집은 그런거 안 팔아요~");
                        break;
                    case TransactionCode.OutOfStock:
                        Console.Write("다 팔려서 없어유~");
                        break;
                    case TransactionCode.OverCount:
                        Console.Write("그만큼은 업서!");
                        break;
                    case TransactionCode.NotEnoughMoney:
                        Console.Write("돈 더 갖고 와!");
                        break;
                    case TransactionCode.Success:
                        Console.Write("성공적으로 구매하였습니다.");
                        break;
                    case TransactionCode.Error:
                        Console.Write("알 수 없는 오류");
                        break;

                }

                int enter = PlayerInput.ReadInput(0, shop.stock.Count);
                if (enter == 0) return;
                else
                {
                    code = shop.Sell(player, shop.stock.Keys.ElementAt(enter - 1), 1);
                    continue;
                }
            }
        }
        public static void ShowStat(Player warrior)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("상태 보기");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
                Console.WriteLine("Lv. {0}", warrior.Level.ToString("00"));
                Console.WriteLine("Chad {0}", warrior.Profession);
                Console.WriteLine($"공격력 : {warrior.GetTotalAttackpower()}{(warrior.GetAdditionalAttackpower() > 0 ? $" (+{warrior.GetAdditionalAttackpower()})" : "")}");
                Console.WriteLine($"방어력 : {warrior.GetTotalDefensepower()}{(warrior.GetAdditionalDefensepower() > 0 ? $" (+{warrior.GetAdditionalDefensepower()})" : "")}");
                Console.WriteLine("체 력 : {0}", warrior.Health);
                Console.WriteLine("Gold : {0} G", warrior.Money);
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                PlayerInput.ReadInput(0, 0); //어차피 선택지 하나밖에 없으니 이부분 통과하면 복귀
                return;
            }
        }

        public static void ShowInventory(Player warrior)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("인벤토리");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                warrior.Inventory.Show();
                Console.WriteLine("");
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");
                switch (PlayerInput.ReadInput(0, 1))
                {
                    case 0:
                        return;
                    case 1:
                        ManageEquipment(warrior);
                        break;
                }
            }
        }

        public static void ManageEquipment(Player warrior)
        {
            int showTipMessgeType = 0;
            while (true)
            {
                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                warrior.Inventory.Show(true);
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                Console.SetCursorPosition(0, Console.WindowHeight - 5);
                switch (showTipMessgeType)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Write("장착했습니다.");
                        break;
                    case 2:
                        Console.Write("장착 해제 했습니다.");
                        break;
                    case 3:
                        Console.Write("장착할 수 없는 아이템입니다.");
                        break;
                }
                int enter = PlayerInput.ReadInput(0, warrior.Inventory.sortedItemList!.Count);
                if (enter == 0) return;
                else
                {
                    if (warrior.Inventory.sortedItemList[enter - 1] is IEquipable equipable)
                    {
                        equipable.IsEquiped = equipable.IsEquiped ? false : true;
                        showTipMessgeType = equipable.IsEquiped ? 1 : 2;
                        continue;
                    }
                    showTipMessgeType = 3;
                    continue;
                }
            }

        }
    }
}
