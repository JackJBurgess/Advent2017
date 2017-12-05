using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class DayThree
    {
        public static int SolvePartOne(int input)
        {
            // Done by hand. Find the closest corner square number,
            // use the width of square + difference from input to calculate
            // steps.
            return 0;
        }

        public static int SolvePartTwo(int input)
        {
            var vpos = 0;
            var hpos = 0;
            double steps = 0;
            var sum = 0;
            var direction = 0;
            var currentDirectionMaxSteps = 1;
            var grid = new Dictionary<string, int>() { { "0,0", 1 } };

            while(sum < input)
            {
                for(int i = 0; i < currentDirectionMaxSteps; i++)
                {
                    switch (direction)
                    {
                        case 0:
                            hpos += 1;
                            break;
                        case 1:
                            vpos += 1;
                            break;
                        case 2:
                            hpos -= 1;
                            break;

                        case 3:
                            vpos -= 1;
                            break;
                        default:
                            break;
                    }

                    sum = 0;
                    if (grid.TryGetValue(string.Format("{0},{1}", vpos + 1, hpos), out var val)) sum += val;
                    if (grid.TryGetValue(string.Format("{0},{1}", vpos + 1, hpos + 1), out val)) sum += val;
                    if (grid.TryGetValue(string.Format("{0},{1}", vpos, hpos + 1), out val)) sum += val;
                    if (grid.TryGetValue(string.Format("{0},{1}", vpos - 1, hpos + 1), out val)) sum += val;
                    if (grid.TryGetValue(string.Format("{0},{1}", vpos - 1, hpos), out val)) sum += val;
                    if (grid.TryGetValue(string.Format("{0},{1}", vpos - 1, hpos - 1), out val)) sum += val;
                    if (grid.TryGetValue(string.Format("{0},{1}", vpos, hpos - 1), out val)) sum += val;
                    if (grid.TryGetValue(string.Format("{0},{1}", vpos + 1, hpos - 1), out val)) sum += val;

                    grid[string.Format("{0},{1}", vpos, hpos)] = sum;
                    steps++;

                    if (Math.Floor(Math.Sqrt(steps)) + (Math.Floor(Math.Sqrt(steps)) * Math.Floor(Math.Sqrt(steps))) == steps && steps > 1)
                    {
                        currentDirectionMaxSteps++;
                    }
                }

                direction = (direction + 1) % 4;
            }

            return sum;
        }
    }
}
