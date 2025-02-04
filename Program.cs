namespace w4_TRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior player;

            //시작 화면
            bool isValidInput = true;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 던전에 오신 여러분, 환영합니다.");
                Console.WriteLine("원하시는 이름을 입력하거나 \"이어하기\" 를 입력해 이어서 할 수 있습니다.");
                Console.WriteLine("[경고]이름을 새로 입력하는 경우 이미 저장된 세이브파일이 덮어씌워질 수 있습니다.");

                /*
                string str = PlayerInput.ReadInput("수줍어 말고 뭐라도 적을 수 있도록!");

                if (str == "이어하기")
                {
                    Console.WriteLine("미구현");
                    Thread.Sleep(2000);
                }
                else
                {
                    //PlayerInput.ReadInput(out int)
                    player = new Warrior(str);
                }
                */

                int i = PlayerInput.ReadInput(1,3);
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분, 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");

            }
        }
    }
}
