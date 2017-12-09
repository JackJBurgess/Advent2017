using System.Linq;

namespace Advent2017
{
    class DayNine
    {
        public static int SolvePartOne(string input)
        {
            var res = 0;

            var currentDepth = 0;
            var negate = false;
            var garbage = false;

            for(int i = 0; i < input.Length; i++)
            {
                if(!garbage)
                {
                    switch(input[i])
                    {
                        case '{':
                            currentDepth++;
                            break;
                        case '}':
                            res += currentDepth;
                            currentDepth--;
                            break;
                        case '<':
                            garbage = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (!negate)
                    {
                        if (input[i] == '>')
                        {
                            garbage = false;
                        }
                        else if (input[i] == '!')
                        {
                            negate = true;
                        }
                    }
                    else
                    {
                        negate = false;
                    }
                }
            }

            return res;
        }

        public static int SolvePartTwo(string input)
        {
            var res = 0;

            var currentDepth = 0;
            var negate = false;
            var garbage = false;
            var garbageCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (!garbage)
                {
                    switch (input[i])
                    {
                        case '{':
                            currentDepth++;
                            break;
                        case '}':
                            res += currentDepth;
                            currentDepth--;
                            break;
                        case '<':
                            garbage = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (!negate)
                    {
                        if (input[i] == '>')
                        {
                            garbage = false;
                        }
                        else if (input[i] == '!')
                        {
                            negate = true;
                        }
                        else
                        {
                            garbageCount++;
                        }
                    }
                    else
                    {
                        negate = false;
                    }
                }
            }

            return garbageCount;
        }

    }
}
