using System.Runtime.CompilerServices;
using System.Text;

namespace TestProj
{
    internal class Parser
    {
        static string[] errors = { "NAME", "WEIGHT", "HEIGHT", "AGE", "VISION", "SMOKING" };
        static int error_pntr = 0;
        static int index = 0;

        public static bool bool_error;

        public Parser()
        {
            index = 0;
            error_pntr = 0;

            bool_error = false;
        }

        public Candidate ParseCandidate(string general)
        {
            Candidate result = new Candidate();

            result.name = ParseName(general);
            result.weight = ParseIntField(general);
            result.height = ParseIntField(general);
            result.age = ParseIntField(general);
            result.vision = ParseDoubleField(general);
            result.smoking = ParseBoolField(general);
            result.diseases = ParseStringList(general);

            return result;
        }

        private static HashSet<string> ParseStringList(string str)
        {
            HashSet<string> res = new HashSet<string>();

            StringBuilder sb = new StringBuilder();
            while (index < str.Length)
            {
                if (str[index] == ' ')
                {
                    res.Add(sb.ToString());
                    index += 1;
                    sb.Clear();
                }
                else
                {
                    sb.Append(str[index]);
                    index += 1;
                }
            }

            res.Add(sb.ToString());
            index += 1;
            return res;
        }

        private static bool ParseBoolField(string str)
        {
            bool res = false;

            StringBuilder sb = new StringBuilder();
            while (index < str.Length && str[index] != ' ')
            {
                sb.Append(str[index]);
                index += 1;
            }

            string temp = sb.ToString();
            if (!bool.TryParse(temp, out res))
            {
                Console.WriteLine($"{errors[error_pntr]}. Ошибка: надо ввести true/false");
                bool_error = true;
                return false;
            }

            index += 1;
            error_pntr += 1;
            return res;
        }

        private static double ParseDoubleField(string str)
        {
            double res = 0.0;

            StringBuilder sb = new StringBuilder();
            while (index < str.Length && str[index] != ' ')
            {
                if (str[index] == ',' || str[index] == '.')
                {
                    sb.Append(',');
                }
                else
                {
                    sb.Append(str[index]);
                }
                index += 1;
            }

            string temp = sb.ToString();
            if (!double.TryParse(temp, out res) || (double.Parse(temp) < 0 || double.Parse(temp) > 1))
            {
                Console.WriteLine($"{errors[error_pntr]}. Ошибка: необходимо дробное число от 0 до 1");
                index += 1;
                error_pntr += 1;
                return -1;
            }

            index += 1;
            error_pntr += 1;
            return res;
        }

        private static int ParseIntField(string str)
        {
            int res = 0;

            StringBuilder sb = new StringBuilder();
            while (index < str.Length && str[index] != ' ')
            {
                sb.Append(str[index]);
                index += 1;
            }

            string temp = sb.ToString();
            if (!int.TryParse(temp, out res) || int.Parse(temp) <= 0)
            {
                Console.WriteLine($"{errors[error_pntr]}. Ошибка: необходимо целое положительное число");
                index += 1;
                error_pntr += 1;
                return -1;
            }

            index += 1;
            error_pntr += 1;
            return res;
        }

        private static string ParseName(string str)
        {
            string res = "";

            int space_cntr = 0;
            StringBuilder sb = new StringBuilder();
            while (index < str.Length && space_cntr < 2)
            {
                if (str[index] == ' ')
                {
                    space_cntr += 1;
                }

                sb.Append(str[index]);
                index += 1;
            }

            if (sb.Length > 0)
            {
                res = sb.ToString()[..^1];
            }
            else
            {
                Console.WriteLine($"{errors[error_pntr]}. Ошибка: строка не должна быть пустой");
                error_pntr += 1;
                return "";
            }

            error_pntr += 1;
            return res;
        }
    }
}
