using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace Advent2017
{
    class DayFourteen
    {
        public static int SolvePartOne(string input)
        {
            var used = 0;
            for (int i = 0; i < 128; i++)
            {
                var hash = DayTen.SolvePartTwo($"{input}-{i}");
                var binary = String.Concat(hash.Select(c => Convert.ToString(Convert.ToByte(c.ToString(), 16), 2).PadLeft(4, '0')));
                used += binary.Count(c => c == '1');
            }

            return used;
        }

        public static List<(int, int)> markedPoints = new List<(int, int)>();
        public static bool[,] grid = new bool[128, 128];

        public static int SolvePartTwo(string input)
        {
            var regions = 0;
            for (int i = 0; i < 128; i++)
            {
                var hash = DayTen.SolvePartTwo($"{input}-{i}");
                var binary = String.Concat(hash.Select(c => Convert.ToString(Convert.ToByte(c.ToString(), 16), 2).PadLeft(4, '0')));
                
                for(int j = 0;j < 128; j++)
                {
                    grid[i,j] = binary[j] == '1';
                }
            }

            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    if (grid[i, j] && !markedPoints.Contains((i,j)))
                    {
                        RemoveRegion(i, j);
                        regions++;
                    }
                }
            }

            return regions;
        }

        private static void RemoveRegion(int row, int col)
        {
            if (!markedPoints.Contains((row, col)))
            {
                markedPoints.Add((row, col));
                if (row > 0 && grid[row - 1, col])
                {
                    RemoveRegion(row - 1, col);
                }
                if (row < 127 && grid[row + 1, col])
                {
                    RemoveRegion(row + 1, col);
                }
                if (col > 0 && grid[row, col - 1])
                {
                    RemoveRegion(row, col - 1);
                }
                if (col < 127 && grid[row, col + 1])
                {
                    RemoveRegion(row, col + 1);
                }
            }
        }
    }
}
