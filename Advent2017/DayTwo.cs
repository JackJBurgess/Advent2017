using System.Linq;

namespace Advent2017
{
    class DayTwo
    {
        public static int SolvePartOne(string[] input)
        {
            var res = 0;
            foreach(string line in input)
            {
                var ints = line.Split('\t').ToList().Select(int.Parse);
                res += ints.Max() - ints.Min();
            }

            return res;
        }

        public static int SolvePartTwo(string[] input)
        {
            var res = 0;
            foreach (string line in input)
            {
                var ints = line.Split('\t').ToList().Select(int.Parse).OrderByDescending(n => n).ToList();
                for(int i = 0; i < ints.Count; i++)
                {
                    for(int j = i+1; j < ints.Count; j++)
                    {
                        if(ints[i] % ints[j] == 0)
                        {
                            res += (ints[i] / ints[j]);
                        }
                    }
                }
            }

            return res;
        }

    }
}
