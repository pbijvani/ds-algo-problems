using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    public class product_of_all_number_except_i
    {
        public int[] Product(int[] input)
        {
            int totalProduct = 1;
            int zeroCount = 0;
            int firstZeroIndex = -1;
            int[] result = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] != 0)
                {
                    totalProduct = totalProduct * input[i];
                }
                else
                {
                    zeroCount++;
                    if (firstZeroIndex == -1) firstZeroIndex = i;

                    if(zeroCount > 1)
                    {
                        return result;
                    }
                }
            }

            if(zeroCount == 1)
            {
                result[firstZeroIndex] = totalProduct;
                return result;
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    result[i] = totalProduct / input[i];
                }
                return result;
            }            

        }
    }
}
