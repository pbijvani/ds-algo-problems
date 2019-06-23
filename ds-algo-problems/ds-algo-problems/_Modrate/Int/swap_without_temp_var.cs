using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Int
{
    public class swap_without_temp_var
    {
        public void swap(int a, int b)
        {
            a = 5;
            b = 9;

            b = b - a;
            a = a + b;
            b = a - b;

            a = a ^ b;
            b = a ^ b;
            a = a ^ b;

        }
    }
}
