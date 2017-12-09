using System.Linq;

namespace Advent2017
{
    class DayNine
    {
        public static int SolvePartOne(string input)
        {
            var res = 0;

            var currentDepth = 0;
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
                    if(input[i] == '!')
                    {
                        i++;
                    }
                    else if(input[i] == '>')
                    {
                        garbage = false;
                    }
                }
            }

            return res;
        }

        public static int SolvePartTwo(string input)
        {
            var res = 0;

            var currentDepth = 0;
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
                    if (input[i] == '!')
                    {
                        i++;
                        continue;
                    }
                    else if (input[i] == '>')
                    {
                        garbage = false;
                        continue;
                    }
                    garbageCount++;
                    
                }
            }

            return garbageCount;
        }

    }
}
