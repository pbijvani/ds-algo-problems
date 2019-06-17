using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class NumberInArrayPlusOne
    {
        /// <summary>
        /// Input: [1,2,3]
        //Output: [1,2,4]
        //Explanation: The array represents the integer 123.

        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }

                digits[i] = 0;
            }

            var res = new int[digits.Length + 1];
            res[0] = 1;
            return res;
        }
    }
}
