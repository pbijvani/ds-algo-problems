using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    public class Array_of_Integer_Every_Elem_appear_twice_except_one_find_one
    {
        /// <summary>
        /// Single Number
        /// Given a non-empty array of integers, every element appears twice except for one. Find that single one
        /// Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
        /// Input: [2,2,1]      Output: 1
        /// This can be solved using hashtable
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        /// 1. Solve using brute force with each elem compare to other
        /// 2. User hash
        /// 3. XOR
        /// 
        public int SingleNumber(int[] A)
        {
            return A.Aggregate(0, (current, i) =>
            {
                var ret = current ^ i;
                return ret;
            });

        }

        public int FindSingleNumber(int[] arr)
        {
            var res = arr[0] ^ arr[1];

            for (int i = 2; i < arr.Length; i++)
            {
                res = res ^ arr[i];
            }

            return res;
        }
    }
}
