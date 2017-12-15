using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class DayFifteen
    {
        public static int SolvePartOne(long aStart, long bStart)
        {
            var judge = 0;
            var aFactor = 16807;
            var bFactor = 48271;
            for (int i = 0; i < 40000000; i++)
            {
                aStart = (aStart * aFactor) % int.MaxValue;
                bStart = (bStart * bFactor) % int.MaxValue;

                if ((aStart & 0xFFFF) == (bStart & 0xFFFF))
                {
                    judge++;
                }
            }

            return judge;
        }

        public static int SolvePartTwo(long aStart, long bStart)
        {
            var judge = 0;
            var aFactor = 16807;
            var bFactor = 48271;

            for (int i = 0; i < 5000000; i++)
            {
                aStart = Generate(aStart, aFactor, 4);
                bStart = Generate(bStart, bFactor, 8);

                if ((aStart & 0xFFFF) == (bStart & 0xFFFF))
                {
                    judge++;
                }
            }

            return judge;
        }

        private static long Generate(long start, int factor, int mod)
        {
            do
            {
                start = (start * factor) % int.MaxValue;
            } while (start % mod != 0);

            return start;
        }
    }
}
