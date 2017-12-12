using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Advent2017
{
    class DayEleven
    {
        public static int SolvePartOne(string input)
        {
            var moves = input.Split(',');
            var childLocation = new Tuple<int, int>(0, 0);

            foreach (string move in moves)
            {
                childLocation = Move(move, childLocation);
            }

            var myLocation = new Tuple<int, int>(0, 0);
            var stepcount = 0;
            while (!myLocation.Equals(childLocation))
            {
                myLocation = Move(ChooseStep(myLocation, childLocation), myLocation);
                stepcount++;
            }

            return stepcount;
        }

        private static Tuple<int, int> Move(string dir, Tuple<int, int> startPos)
        {
            switch (dir)
            {
                case "n":
                    return new Tuple<int, int>(startPos.Item1 + 1, startPos.Item2);                
                case "nw":
                    return new Tuple<int, int>(startPos.Item2 % 2 == 0 ? startPos.Item1 + 1: startPos.Item1, startPos.Item2 - 1);
                case "ne":
                    return new Tuple<int, int>(startPos.Item2 % 2 == 0 ? startPos.Item1 + 1 : startPos.Item1, startPos.Item2 + 1);
                case "s":
                    return new Tuple<int, int>(startPos.Item1 - 1, startPos.Item2);
                case "sw":
                    return new Tuple<int, int>(startPos.Item2 % 2 == 0 ? startPos.Item1: startPos.Item1 - 1, startPos.Item2 - 1);
                case "se":
                    return new Tuple<int, int>(startPos.Item2 % 2 == 0 ? startPos.Item1 : startPos.Item1 - 1, startPos.Item2 + 1);
                default:
                    return startPos;                
            }
        }

        private static string ChooseStep(Tuple<int, int> me, Tuple<int, int> target)
        {
            if (me.Item1 < target.Item1 && me.Item2 < target.Item2)
            {
                return "ne";
            }
            else if (me.Item1 < target.Item1 && me.Item2 == target.Item2)
            {
                return "n";
            }
            else if (me.Item1 == target.Item1 && me.Item2 < target.Item2)
            {
                return "se";
            }
            else if (me.Item1 == target.Item1 && me.Item1 > target.Item2)
            {
                return "sw";
            }
            else if (me.Item1 > target.Item1 && me.Item2 == target.Item2)
            {
                return "s";
            }
            else if (me.Item1 > target.Item1 && me.Item2 > target.Item2)
            {
                return "sw";
            }
            else if (me.Item1 < target.Item1 && me.Item2 > target.Item2)
            {
                return "nw";
            }
            else if (me.Item1 > target.Item1 && me.Item2 < target.Item2)
            {
                return "se";
            }
            else return "";
        }

        public static int SolvePartTwo(string input)
        {
            var moves = input.Split(',');
            var childLocation = new Tuple<int, int>(0, 0);

            var maxsteps = 0;

            foreach (string move in moves)
            {
                childLocation = Move(move, childLocation);

                var myLocation = new Tuple<int, int>(0, 0);
                var stepcount = 0;
                while (!myLocation.Equals(childLocation))
                {
                    myLocation = Move(ChooseStep(myLocation, childLocation), myLocation);
                    stepcount++;
                }

                if (stepcount > maxsteps)
                {
                    maxsteps = stepcount;
                }

            }

            return maxsteps;
        }

    }
}
