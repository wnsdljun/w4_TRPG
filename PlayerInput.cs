namespace w4_TRPG
{
    internal class PlayerInput
    {
        private static string WriteWaitingInput()
        {
            Console.Write(">>>");
            return Console.ReadLine() ?? ""; //Null-Coalescing Operator: 좌항이 null 이면 우항을 반환. 이거 개꿀이자너...!
        }
        /// <summary>
        /// 사용자 입력을 받는 메서드.
        /// </summary>
        /// <returns>입력이 비어있거나 null이라면 false</returns>
        public static bool ReadInput(out string result)
        {
            string str = WriteWaitingInput();
            if (string.IsNullOrWhiteSpace(str)) //null: ctrl+z 입력시, 비어있거나 빈칸만 존재하는경우.
            {
                result = "";
                return false;
            }
            result = str;
            return true;
        }
        /// <summary>
        /// 사용자 입력을 받는 메서드.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="tip">tip을 출력하고 입력을 기다립니다.</param>
        /// <returns>입력이 비어있거나 null이라면 false</returns>
        public static bool ReadInput(out string result, string tip)
        {
            Console.WriteLine(tip);
            return ReadInput(out result);
        }
        /// <summary>
        /// 사용자 입력을 받는 메서드.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="failMessage">이전 실행 결과</param>
        /// <param name="previousResult"></param>
        /// <returns></returns>
        public static bool ReadInput(out string result, string failMessage, bool previousResult)
        {
            if (!previousResult)
            {
                Console.WriteLine(failMessage);
            }
            return ReadInput(out result);
        }

        /// <summary>
        /// 사용자 입력을 받는 메서드.
        /// </summary>
        /// <param name="result"></param>
        /// <returns>입력이 숫자가 아니라면 false</returns>
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
        /// <summary>
        /// 사용자 입력을 받는 메서드.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="lowest">입력받을 수 있는 숫자 중 가장 낮은 번호</param>
        /// <param name="highest">입력받을 수 있는 숫자 중 가장 높은 번호</param>
        /// <returns>입력받은 값이 숫자이고, lowest<= 입력 <= highest 라면 true, 아니면 false</returns>
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
