using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2017
{
    class DayOne
    { 
        public static int Solve(string input, int offset)
        {
            int res = 0;
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] == input[(i + offset) % input.Length])
                {
                    res += (input[i] - '0');
                }
            }
            
            return res;
        }
    }
}
