using System.Linq;
using System.Collections.Generic;
using System;

namespace Advent2017
{
    class DaySixteen
    {
        private static char[] chars = new char[16] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };

        public static string SolvePartOne(string input)
        {
            var instructions = input.Split(',');

            dance(instructions);

            return string.Concat(chars);
        }

        private static void dance(string[] instructions)
        {
            var c1 = '\0';
            var c2 = '\0';
            var i1 = 0;
            var i2 = 0;

            foreach (string instruction in instructions)
            {
                char op = instruction[0];
                switch (op)
                {
                    case 's':
                        var num = int.Parse(instruction.Substring(1));
                        chars = chars.Skip(16 - num).Concat(chars.Take(16 - num)).ToArray();
                        break;
                    case 'x':
                        i1 = int.Parse(instruction.Substring(1).Split('/')[0]);
                        i2 = int.Parse(instruction.Substring(1).Split('/')[1]);
                        c1 = chars[i1];
                        chars[i1] = chars[i2];
                        chars[i2] = c1;
                        break;
                    case 'p':
                        c1 = instruction[1];
                        c2 = instruction[3];
                        i1 = Array.IndexOf(chars, c1);
                        i2 = Array.IndexOf(chars, c2);
                        chars[i1] = c2;
                        chars[i2] = c1;
                        break;
                }
            }
        }

        public static string SolvePartTwo(string input)
        {
            var order = new char[16];
            chars.CopyTo(order, 0);
            var instructions = input.Split(',');

            var loop = 0;
            do
            {
                dance(instructions);
                loop++;

            } while (!order.SequenceEqual(chars));

            loop = 999999999 % loop;

            for(int i = 0; i < loop; i++)
            {
                dance(instructions);
            }

            return string.Concat(chars);
        }

    }
}
