using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class DaySix
    {
        public static int SolvePartOne(string input)
        {
            var blocks = input.Split('\t').Select(int.Parse).ToArray();
            var history = new List<string>();
            var cycles = 0;

            while(!history.Contains(String.Join(",", blocks)))
            {
                history.Add(String.Join(",",blocks));
                var max = blocks.Max();
                var idx = Array.IndexOf(blocks, max);

                blocks[idx] = 0;
                
                for(int i = 0; i < max; i++)
                {
                    if(idx == 15)
                    {
                        idx = 0;
                    }
                    else
                    {
                        idx += 1;
                    }

                    blocks[idx]++;
                }

                cycles++;
            }

            return cycles;
        }

        public static int SolvePartTwo(string input)
        {
            var blocks = input.Split('\t').Select(int.Parse).ToArray();
            var history = new List<string>();
            var cycles = 0;

            while (!history.Contains(String.Join(",", blocks)))
            {
                history.Add(String.Join(",", blocks));
                var max = blocks.Max();
                var idx = Array.IndexOf(blocks, max);

                blocks[idx] = 0;

                for (int i = 0; i < max; i++)
                {
                    if (idx == 15)
                    {
                        idx = 0;
                    }
                    else
                    {
                        idx += 1;
                    }

                    blocks[idx]++;
                }

                cycles++;
            }

            cycles = 0;
            history = new List<string>();

            while (!history.Contains(String.Join(",", blocks)))
            {
                history.Add(String.Join(",", blocks));
                var max = blocks.Max();
                var idx = Array.IndexOf(blocks, max);

                blocks[idx] = 0;

                for (int i = 0; i < max; i++)
                {
                    if (idx == 15)
                    {
                        idx = 0;
                    }
                    else
                    {
                        idx += 1;
                    }

                    blocks[idx]++;
                }

                cycles++;
            }

            return cycles;
        }
    }
}
