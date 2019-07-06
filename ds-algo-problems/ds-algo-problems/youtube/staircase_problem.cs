using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class staircase_problem
    {
        public int NoOfWays(int n)
        {
            var mem = new int?[n+1];
            return noOfWayHelper(n, 0, mem);
        }

        public int noOfWayHelper(int n, int step, int?[] mem)
        {
            if (step == n) return 1;
            if (step > n) return 0;

            if(mem[step].HasValue)
            {
                return mem[step].Value;
            }
            else
            {
                var res = noOfWayHelper(n, step + 1, mem) + noOfWayHelper(n, step + 2, mem);

                mem[step] = res;

                return res;
            }            
        }

        public int NoOfWaysIterative(int n)
        {
            int[] arr = new int[n + 1];
            arr[0] = 0;
            arr[1] = 1;
            arr[2] = 2;

            for(int i = 3; i<= n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }

            return arr[n];
        }
    }
}
