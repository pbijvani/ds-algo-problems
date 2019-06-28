using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Array
{
    class swap_element_to_get_equal_sum
    {
        /*
         * you are give 2 array
         * find a pair (one element from each array)
         * such that if you swap both, sum of both array will be same
         */


        // O(AB)
        public int[] SumSwap(int[] a, int[] b)
        {
            int sumA = a.Sum();
            int sumB = b.Sum();

            int diff = System.Math.Abs(sumA - sumB);

            for(int i = 0; i < a.Length; i++)
            {
                for(int j = 0; j < b.Length; j++)
                {
                    int eleA = a[i];
                    int eleB = b[i];

                    if (sumA - eleA + eleB == sumB - eleB + eleA) return new int[] { eleA, eleB };
                }
            }

            return new int[] { };
        }

        // O (A + B)
        public int[] SumSwapOptimal(int[] a, int[] b)
        {
            var hashSetOfA = PrepareHashSet(a);
            var target = GetTarget(a, b);

            if (!target.HasValue) return new int[] { };

            foreach(var two in b)
            {
                var one = two + target.Value;

                if (hashSetOfA.Contains(one)) return new[] { one, two };
            }
            return new int[] { };
        }

        private HashSet<int> PrepareHashSet(int[] array)
        {
            HashSet<int> set = new HashSet<int>();
            foreach(var num in array)
            {
                set.Add(num);
            }
            return set;
        }

        private int? GetTarget(int[] a, int[] b)
        {
            var sumA = a.Sum();
            var sumB = b.Sum();

            var diff = sumA - sumB;

            if (diff % 2 != 0) return null;
            return diff / 2;
        }

        // Solution 3:
        // if Array are sorted we can use two pointer (one for each array)
        // calc difference of two element at current point position
        // if difference (a-b) is more than target increase a
        // if difference (a -b) is smaller than target increment b
        // This avoids using extra space
        // Its also O (A + B)
    }
}
