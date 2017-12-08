using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class DayEight
    {
        public static int SolvePartOne(string[] input)
        {
            Dictionary<string, int> registers = new Dictionary<string, int>();
            foreach(string s in input)
            {
                var parts = s.Split(' ');
                if(!registers.ContainsKey(parts[0]))
                {
                    registers.Add(parts[0], 0);
                }

                if(!registers.ContainsKey(parts[4]))
                {
                    registers.Add(parts[4], 0);
                }

                if(checkCondition(registers[parts[4]], int.Parse(parts[6]), parts[5]))
                {
                    registers[parts[0]] = parts[1] == "inc" ? registers[parts[0]] += int.Parse(parts[2]) : registers[parts[0]] -= int.Parse(parts[2]);
                }
            }

            return registers.Values.Max();
        }

        public static int SolvePartTwo(string[] input)
        {
            var max = 0;
            Dictionary<string, int> registers = new Dictionary<string, int>();
            foreach (string s in input)
            {
                var parts = s.Split(' ');
                if (!registers.ContainsKey(parts[0]))
                {
                    registers.Add(parts[0], 0);
                }

                if (!registers.ContainsKey(parts[4]))
                {
                    registers.Add(parts[4], 0);
                }

                if (checkCondition(registers[parts[4]], int.Parse(parts[6]), parts[5]))
                {
                    registers[parts[0]] = parts[1] == "inc" ? registers[parts[0]] += int.Parse(parts[2]) : registers[parts[0]] -= int.Parse(parts[2]);
                }

                if(registers[parts[0]] > max)
                {
                    max = registers[parts[0]];
                }
            }

            return max;
        }

        private static bool checkCondition(int a, int b, string op)
        {
            switch(op)
            {
                case "==":
                    return a == b;
                case "!=":
                    return a != b;
                case ">":
                    return a > b;
                case "<":
                    return a < b;
                case ">=":
                    return a >= b;
                case "<=":
                    return a <= b;
            }
            return true;
        }
    }
}
