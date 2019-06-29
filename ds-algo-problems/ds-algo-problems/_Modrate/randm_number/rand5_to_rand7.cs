using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.randm_number
{
    public class rand5_to_rand7
    {
        public int Rand7()
        {
            var val = new int[,] {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 1, 2, 3 },
                { 4, 5, 6, 7, 1 },
                { 2, 3, 4, 5, 6 },
                { 7, 0, 0, 0, 0 }
            };

            int result = 0;
            while (result == 0)
            {
                int i = Rand5();
                int j = Rand5();
                result = val[i - 1,j - 1];
            }
            return result;
        }

        private int Rand5()
        {
            Random random = new Random();
            return random.Next(1, 5);
        }


        // Solution 2: User base-5 number

        public int rand7_another()
        {
            while(true)
            {
                int num = 5 * Rand5() + Rand5();

                if(num < 21)
                {
                    return num % 7;
                }
            }
        }

    }

}
