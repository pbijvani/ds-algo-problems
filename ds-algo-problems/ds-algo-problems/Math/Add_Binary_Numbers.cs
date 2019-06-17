using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Math
{
    class AddBinaryNumbers
    {
        /// <summary>
        /// Binary addition
        /// Input: a = "1010", b = "1011"
        ///Output: "10101"
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string addBinary(string a, string b)
        {

            // Initialize result 
            string result = "";

            // Initialize digit sum 
            int s = 0;

            // Travers both strings starting  
            // from last characters 
            int i = a.Length - 1, j = b.Length - 1;
            while (i >= 0 || j >= 0 || s == 1)
            {

                // Comput sum of last  
                // digits and carry 
                s += ((i >= 0) ? a[i] - '0' : 0);
                s += ((j >= 0) ? b[j] - '0' : 0);

                // If current digit sum is  
                // 1 or 3, add 1 to result 
                result = (char)(s % 2 + '0') + result;

                // Compute carry 
                s /= 2;

                // Move to next digits 
                i--; j--;
            }
            return result;
        }
    }
}
