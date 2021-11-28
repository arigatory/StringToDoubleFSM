using System;

namespace StringToDoubleLol
{

    public class Program
    {
        static void Main(string[] args)
        {
            string pattern = "-1323,5430";
            double result = ConvertToDouble(pattern);
            Console.WriteLine(result);
        }

        private static double ConvertToDouble(string pattern)
        {
            Process p = new Process();

            double result = 0;
            bool minus = false;
            double divider = 1;

            for (int i = 0; i < pattern.Length; i++)
            {
                char currentChar = pattern[i];
                Symbol symbol;
                symbol = GetSymbol(currentChar);
                var process = p.MoveNext(symbol);
                switch (process)
                {
                    case ProcessState.Start:
                        break;
                    case ProcessState.SignCheck:
                        if (currentChar == '-')
                            minus = true;
                        break;
                    case ProcessState.FirstPart:
                        result *= 10;
                        result += (currentChar - '0');
                        break;
                    case ProcessState.Point:
                        break;
                    case ProcessState.LastPart:
                        divider *= 10;
                        result += (currentChar - '0') / divider;
                        break;
                    case ProcessState.Error:
                        break;
                    case ProcessState.Finish:
                        break;
                    default:
                        break;
                }
            }
            return minus? -result : result;
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
