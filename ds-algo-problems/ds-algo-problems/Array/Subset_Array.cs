using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class Subset_Array
    {
        /// <summary>
        /// no of subset : 2 Powrer(n)
        /// </summary>
        /// <param name="input"></param>
        public void ArraySubset(char[] input)
        {
            var count = System.Math.Pow(2, input.Length);

            for (int i = 0; i < count; i++)
            {
                int bitIndex = 1;

                string str = string.Empty;

                for (int j = 0; j < input.Length; j++)
                {
                    if ((bitIndex & i) > 0)
                    {
                        str = input[j] + str;
                    }
                    bitIndex = bitIndex << 1;
                }
                Console.WriteLine(str);
            }
        }

        List<List<char>> output = new List<List<char>>();
        public void ArraySubset11(List<char> input, List<char> prefix, int n)
        {
            if (n == input.Count)
            {
                output.Add(prefix);
            }
            else
            {
                var option1 = prefix;
                List<char> option2 = new List<char>();
                option2.AddRange(prefix);
                option2.Add(input[n]);

                ArraySubset11(input, option1, n + 1);
                ArraySubset11(input, option2, n + 1);
            }

        }
        ///string instead of array
        public void ArraySubSet1(string prefix, string input, int i)
        {
            if (input.Length == i)
            {
                Console.WriteLine(prefix);
            }
            else
            {
                var option1 = prefix;
                ArraySubSet1(option1, input, i + 1);

                var option2 = prefix + input[i];
                ArraySubSet1(option2, input, i + 1);
            }

        }
    }
}
