using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using Microsoft.Win32;

namespace Advent2017
{
    class DayThirteen
    {
        public static int SolvePartOne(string[] input)
        {
            var walls = new List<(int depth,int max)>();
            foreach (string s in input)
            {
                var parts = s.Split(':').Select(int.Parse).ToArray();
                walls.Add((parts[0],parts[1]));
            }

            var sev = 0;
            foreach ((int depth, int max) wall in walls)
            {
                if (wall.depth % ((wall.max - 1) * 2) == 0)
                {
                    sev += wall.depth * wall.max;
                }
            }

            return sev;
        }

        public static int SolvePartTwo(string[] input)
        {
            var walls = new List<(int depth, int max)>();
            foreach (string s in input)
            {
                var parts = s.Split(':').Select(int.Parse).ToArray();
                walls.Add((parts[0], parts[1]));
            }

            var wait = 0;
            var seen = false;

            do
            {
                seen = false;
                var sev = 0;
                foreach ((int depth, int max) wall in walls)
                {
                    if ((wall.depth + wait) % ((wall.max - 1) * 2) == 0)
                    {
                        sev += (wall.depth + wait) * wall.max;
                    }
                }

                if (sev > 0)
                {
                    seen = true;
                    wait++;
                }

            } while (seen);

            return wait;
        }

    }
}
