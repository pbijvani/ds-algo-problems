using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Int
{
    class decimal_to_binary
    {
        public string ToBinary(int num)
        {
            string binary = string.Empty;
            int bitIndex = 1;
            if (num > 0)
            {
                while (bitIndex <= num)
                {
                    if ((num & bitIndex) > 0)
                    {
                        binary = "1" + binary;
                    }
                    else
                    {
                        binary = "0" + binary;
                    }
                    bitIndex = bitIndex << 1;
                }
            }
            return binary;
        }
    }
}
