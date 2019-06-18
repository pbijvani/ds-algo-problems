using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    class tower_hop_problem
    {
        public bool TestIsHopable1(int[] tower)
        {
            var current = 0;

            while (true)
            {
                if (current >= tower.Length) return true;
                if (tower[current] == 0) return false;
                current = nextStpe(tower, current);
            }

        }
        public int nextStpe(int[] tower, int curent)
        {
            int i = 1;
            int max = tower[curent];
            int maxNextMove = tower[curent];
            int optimalIndex = curent + 1;
            while (i <= tower[curent])
            {
                var outOfIndex = i + curent >= tower.Length;
                if (maxNextMove <= i + (outOfIndex ? 0 : tower[curent + i]))
                {
                    maxNextMove = i + (outOfIndex ? 0 : tower[curent + i]);
                    optimalIndex = curent + i;
                }
                i++;
            }
            return optimalIndex;
        }
        public bool TestIsHopable(int[] tower)
        {
            var arr = new int[] { 1, 0 };

            var len = tower.Length;


            bool[] status = new bool[len];

            for (int i = len - 1; i >= 0; i--)
            {
                if (i == len - 1)
                {
                    if (tower[i] > 0)
                    {
                        status[i] = true;
                    }
                }
                else
                {
                    if (tower[i] >= len - i)
                    {
                        status[i] = true;
                        continue;
                    }
                    else
                    {
                        int j = len - 1;
                        while (j > i)
                        {
                            if (status[j] == true && tower[i] >= j - i)
                            {
                                status[i] = true;
                                break;
                            }
                            j--;
                        }
                    }
                }
            }


            return status[0] == true;
        }
    }
}
