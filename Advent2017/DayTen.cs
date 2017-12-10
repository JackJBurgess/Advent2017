using System.Linq;
using System.Collections.Generic;
using System;

namespace Advent2017
{
    class DayTen
    {
        public static int SolvePartOne(string input)
        {
            var skip = 0;
            var idx = 0;
            var lengths = input.Split(',').Select(int.Parse).ToArray();
            var arr = Enumerable.Range(0, 256).ToArray();
            for (int i = 0; i < lengths.Length; i++)
            {
                int j = 0;
                var copy = new int[lengths[i]];

                while (j < lengths[i])
                {
                    copy[j] = arr[(idx + j) % 256];
                    j++;
                }

                while (j > 0)
                {
                    arr[idx] = copy[j - 1];
                    j--;
                    idx++;
                    idx %= 256;
                }

                idx += skip;
                idx = idx % 256;

                skip++;
            }

            return arr[0] * arr[1];
        }

        public static string SolvePartTwo(string input)
        {
            var lengths = input.Select(x => (int)x).ToArray();
            lengths = lengths.Concat(new int[] { 17, 31, 73, 47, 23 }).ToArray();
            var arr = Enumerable.Range(0, 256).ToArray();

            var skip = 0;
            var idx = 0;

            for (int k = 0; k < 64; k++)
            {
                for (int i = 0; i < lengths.Length; i++)
                {
                    int j = 0;
                    var copy = new int[lengths[i]];

                    while (j < lengths[i])
                    {
                        copy[j] = arr[(idx + j) % 256];
                        j++;
                    }

                    while(j > 0)
                    {
                        arr[idx] = copy[j-1];
                        j--;
                        idx++;
                        idx %= 256;
                    }

                    idx += skip;
                    idx = idx % 256;

                    skip++;
                }
            }

            return DenseHash(arr);
        }

        private static string DenseHash(int[] array)
        {
            var dense = new int[16];
            int i = 0;
            var idx = 0;
            while (i < 256)
            {
                dense[idx] ^= array[i];
                i++;
                if (i % 16 == 0)
                {
                    idx++;
                }
            }

            return string.Concat(dense.ToArray().Select(a => a.ToString("X2")));
        }

        private void Iterate(int[] arr, int skip, int idx)
        {

        }
    }
}
