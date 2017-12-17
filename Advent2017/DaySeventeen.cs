using System.Linq;
using System.Collections.Generic;
using System;

namespace Advent2017
{
    class DaySeventeen
    {
        public static int SolvePartOne(int input)
        {
            var buf = spinLock(input, 2017);
            return buf[buf.IndexOf(2017) + 1];
        }

        public static List<int> spinLock(int input, int length)
        {
            List<int> buf = new List<int>() { 0 };
            var idx = 0;
            for (int i = 1; i < length + 1; i++)
            {
                idx = (idx + input) % buf.Count() + 1;
                buf.Insert(idx, i);
            }

            return buf;
        }

        public static int spinLock2(int input, int length)
        {
            var val = 0;
            var idx = 0;
            for (int i = 1; i < length + 1; i++)
            {
                idx = (idx + input) % i + 1;
                if(idx == 1) { val = i; }
                
            }

            return val;
        }

        public static int SolvePartTwo(int input)
        {
            var val = spinLock2(input, 50000000);
            return val;
        }

    }
}
