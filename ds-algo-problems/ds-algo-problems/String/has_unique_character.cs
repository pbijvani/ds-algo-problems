using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    class has_unique_character
    {
        // If its ASCII : create bool array of 256 char

        // there loop through string char, and enable respective flag

        // WE can reduce space usage by using bit vector

        public bool HasUniqueChar(string input)
        {            
            int status = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int val = input[i] - 'a';

                if ((status & (1 << val)) > 0)
                {
                    return false;
                }

                status = status | (1 << val);
            }
            return true;
        }

    }
}
