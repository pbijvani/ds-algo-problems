using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class Convert_number_to_array
    {
        /// <summary>
        /// 123 => {1, 2, 3}
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public int[] ConvertToArray(int number)
        {
            var retVal = new List<int>();

            do
            {
                retVal.Add(number % 10);
                number = number / 10;
            }
            while (number > 0);

            return retVal.ToArray();
        }
    }
}
