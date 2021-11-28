using System;

namespace StringToDoubleLol
{

    public class Program
    {
        static void Main(string[] args)
        {
            string pattern = "1323.543";
            double result = ConvertToDouble(pattern);
            Console.WriteLine(result);
        }

        private static double ConvertToDouble(string pattern)
        {
            Process p = new Process();

            double result = 0;
            bool minus = false;

            for (int i = 0; i < pattern.Length; i++)
            {
                Symbol symbol;
                symbol = GetSymbol(pattern[i]);
                p.MoveNext(symbol);
            }
            return result;
        }

        public static Symbol GetSymbol(char c)
        {
            Symbol result;
            switch (c)
            {
                case '-':
                case '+':
                    result = Symbol.Sign;
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    result = Symbol.Digit;
                    break;
                case '.':
                case ',':
                    result = Symbol.Point;
                    break;
                default:
                    result = Symbol.Other;
                    break;
            }

            return result;
        }
    }
}
