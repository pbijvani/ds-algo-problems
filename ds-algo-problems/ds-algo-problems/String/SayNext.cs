using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    class SayNext1
    {
        /// <summary>
        /// ///////////////////////////
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        private string SayNext(string start)
        {
            var res = new StringBuilder();

            var pre = 0;

            for (var i = 0; i < start.Length; i++)
            {
                if (start[i] != start[pre])
                {
                    res.Append(i - pre).Append(start[pre]);
                    pre = i;
                }
            }
            res.Append(start.Length - pre).Append(start[pre]);

            return res.ToString();

        }

        public string CountAndSay(int n)
        {
            //1.     1
            //2.     11
            //3.     21
            //4.     1211
            //5.     111221

            if (n == 1) return "1";

            var pre = CountAndSay(n - 1);

            Console.WriteLine(pre);

            return SayNext(pre);
        }
    }
}
