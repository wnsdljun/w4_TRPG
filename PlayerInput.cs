namespace w4_TRPG
{
    internal class PlayerInput
    {
        private static bool b = false;
        private static string WriteWaitingInput()
        {
            Console.Write(">>>");
            return Console.ReadLine() ?? ""; //Null-Coalescing Operator: 좌항이 null 이면 우항을 반환. 이거 개꿀이자너...!
        }

        private static bool ReadInput(out string result)
        {
            string str = WriteWaitingInput();
            if (string.IsNullOrWhiteSpace(str)) //null: ctrl+z 입력시, 비어있거나 빈칸만 존재하는경우.
            {
                result = "";
                return false; //입력 실패
            }
            result = str;
            return true; //입력 성공
        }

        public static string ReadInput(string failMessage = "입력값은 비워둘 수 없습니다.") //틀렸을 경우 메시지 출력.
        {
            while (true)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 2); //입력 위치를 창 맨 밑으로 고정
                Console.Write(new string(' ', Console.WindowWidth)); //기존 메시지 지우기
                Console.SetCursorPosition(0, Console.WindowHeight - 2); //커서 위치 재설정

                if (ReadInput(out string result)) return result; //정상 입력시 바로 반환.

                Console.SetCursorPosition(0, Console.WindowHeight - 3);
                Console.Write(new string(' ', Console.WindowWidth)); // 기존 메시지 지우기
                Console.SetCursorPosition(0, Console.WindowHeight - 3);
                Console.WriteLine(failMessage);
            }
        }

        public static bool ReadInput(out string result, string tip)
        {
            Console.WriteLine(tip);
            return ReadInput(out result);
        }

        public static bool ReadInput(out string result, string failMessage, bool previousResult)
        {
            if (!previousResult)
            {
                Console.WriteLine(failMessage);
            }
            return ReadInput(out result);
        }












        public static bool ReadInput(out int result)
        {
            string str = WriteWaitingInput();
            bool parsable = int.TryParse(str, out int num);

            if (parsable)
            {
                result = num;
                return true;
            }
            result = 0;
            return false;
        }

        public static bool ReadInput(out int result, int lowest, int highest)
        {
            string str = WriteWaitingInput();
            bool parsable = int.TryParse(str, out int num);
            if (parsable)
            {
                if (lowest <= num && num <= highest)
                {
                    result = num;
                    return true;
                }
            }
            result = 0;
            return false;
        }
    }
}
