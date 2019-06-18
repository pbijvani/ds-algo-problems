using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class Find_k_closest_elements_of_given_number_in_array
    {
        public int[] FindClosestELement(int[] input, int k, int x)
        {
            int len = input.Length;
            if (x <= input[0])
            {
                return input.SubArray(0, k);
            }
            else if (x >= input[len - 1])
            {
                return input.SubArray(len - k - 1, k);
            }
            else
            {
                var difference = new int[len];

                for (int j = 0; j < len; j++)
                {
                    difference[j] = System.Math.Abs(input[j] - x);
                }

                int i = 0;

                while (difference[i] > difference[i + 1])
                {
                    i++;
                }

                int left = i;
                int right = i;
                int count = 0;

                int[] result = new int[k];
                result[count] = input[i];

                while (count < k - 1)
                {
                    var option1 = right == len ? int.MaxValue : System.Math.Abs(difference[right] - difference[right + 1]);
                    var option2 = left == 0 ? int.MaxValue : System.Math.Abs(difference[left] - difference[left - 1]);

                    if (option1 < option2)
                    {
                        right++;
                        count++;
                        result[count] = input[right];
                    }
                    else
                    {
                        left--;
                        count++;
                        result[count] = input[left];
                    }
                }

                return result;
            }
        }
    }
}
