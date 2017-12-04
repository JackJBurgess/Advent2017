using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class DayFour
    {
        public static int SolvePartOne(string[] input)
        {
            return input.Count(i => i.Split(' ').Distinct().Count() == i.Split(' ').Count());
        }

        public static int SolvePartTwo(string[] input)
        {
            return input.Count(i => i.Split(' ').Select(s => String.Concat(s.OrderBy(c => c))).Distinct().Count() == i.Split(' ').Count());
        }
    }
}
