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
                        var firstIndex = int.Parse(instruction.Substring(1).Split('/')[0]);
                        var secondIndex = int.Parse(instruction.Substring(1).Split('/')[1]);
                        var firstChar = chars[firstIndex];
                        var secondChar = chars[secondIndex];
                        chars[firstIndex] = secondChar;
                        chars[secondIndex] = firstChar;
                        break;
                    case 'p':
                        var charA = instruction[1];
                        var charB = instruction[3];
                        var i1 = Array.IndexOf(chars, charA);
                        var i2 = Array.IndexOf(chars, charB);
                        chars[i1] = charB;
                        chars[i2] = charA;
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

            } while (string.Concat(order) != string.Concat(chars));

            loop = 999999999 % loop;

            for(int i = 0; i < loop; i++)
            {
                dance(instructions);
            }

            return string.Concat(chars);
        }

    }
}
