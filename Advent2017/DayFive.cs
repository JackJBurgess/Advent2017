using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class DayFive
    {
        public static int SolvePartOne(string[] input)
        {
            var steps = input.Select(int.Parse).ToArray();
            var index = 0;
            var hops = 0;
            while(index >= 0 && index < steps.Length)
            {
                index += steps[index]++;
                hops++;
            }

            return hops;
        }

        public static int SolvePartTwo(string[] input)
        {
            var steps = input.Select(int.Parse).ToArray();
            var index = 0;
            var hops = 0;
            while (index >= 0 && index < steps.Length)
            {                
                if(steps[index] >= 3)
                {
                    index += steps[index]--;
                }
                else
                {
                    index += steps[index]++;
                }

                hops++;
            }

            return hops;
        }
    }
}
