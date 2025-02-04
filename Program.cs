namespace w4_TRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior player;

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
                    player = new Warrior(str);
                    break;
                }
            }
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

                        break;
                }
            }




        }

        public static void ShowStat(Warrior warrior)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("상태 보기");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Lv. {0}", warrior.Level.ToString("00"));
            Console.WriteLine("Chad {0}", warrior.Profession);
            Console.WriteLine("공격력 : {0}", warrior.AttackPower);
            Console.WriteLine("방어력 : {0}", warrior.Defense);
            Console.WriteLine("체 력 : {0}", warrior.Health);
            Console.WriteLine("Gold : {0} G", warrior.Money);
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            PlayerInput.ReadInput(0,0);
        }
        public static void ShowInventory(Warrior warrior)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("인벤토리");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            PlayerInput.ReadInput(0, 1);
        }
    }
}
