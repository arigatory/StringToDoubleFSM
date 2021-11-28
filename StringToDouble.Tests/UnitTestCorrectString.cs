using StringToDoubleLol;
using System;
using Xunit;

namespace StringToDouble.Tests
{
    public class UnitTestCorrectString
    {
        [Fact]
        public void CanDetectWrongStrings()
        {
            var p = new Process();
            var strings = new string[] { ".34", "d2k2", "132.232d", "12k32.343", "d324.343", "23+4.324", "234.23-4", "234.234.343"};

            var exeption = Record.Exception(() =>
            {
                foreach (var s in strings)
                {
                    p = new Process();
                    for (int i = 0; i < s.Length; i++)
                    {
                        p.MoveNext(Program.GetSymbol(s[i]));
                    }
                }
            });

            Assert.NotNull(exeption);
        }


        [Fact]
        public void CanDetectCorrectStrings()
        {
            var p = new Process();
            var strings = new string[] { "1.34", "22", "132.232", "-343", "00324.33", "234,324", "+234.234", "-34234.343" };

            var exeption = Record.Exception(() =>
            {
                foreach (var s in strings)
                {
                    p = new Process();
                    for (int i = 0; i < s.Length; i++)
                    {
                        p.MoveNext(Program.GetSymbol(s[i]));
                    }
                }
            });

            Assert.Null(exeption);
        }
    }
}
