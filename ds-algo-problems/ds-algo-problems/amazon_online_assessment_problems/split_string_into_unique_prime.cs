using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.amazon_online_assessment_problems
{
    /*
        https://aonecode.com/amazon-online-assessment-split-string-into-unique-primes
        https://www.geeksforgeeks.org/find-all-possible-ways-to-split-the-given-string-into-primes/

        Amazon's operations team needs an algorithm that can break out a list of products for a given order. The products in the order are listed as a string and the order items are represented as prime numbers. Given a string consisting of digits [0-9], count the number of ways the given string can be split into prime numbers, which represent unique items in the order. The digits must remain in the order given and the entire string must be used.

        Write an algorithm to find the number of ways the given string can be split into unique prime numbers using the entire string.

        Input

        The input to the function/method consists of an argument:

        inputString, a string representing the input string.

        Output

        Return an integer representing the number of ways the given string can be split into unique primes using the entire string.

        Note

        The inputString does not contain leading zeros.

        Each number split of the given number must be in the range 2 to 10 inclusive.

        Since the answer can be large, return the answer modulo (1000000007)

        Constraints

        1 <= length of inputStrings <= 10^5

        Example

        Input:

        inputstring = 11373

        Output:

        6

        Explanation:

        This string can be split into prime numbers in 6 different ways: [11,3,7,3], [113, 7,3], [11,3,73], [11, 37, 3], [113,73] and [11, 373]. So the output is 6.




     */

    public class split_string_into_unique_prime
    {
        public List<List<int>> UniquePrime(string input)
        {
            var splits = GetPossibleSplit(input);

            var notPrime = PreparePrimeNumberList(Convert.ToInt32(input));

            var res = new List<List<int>>();
            foreach(var split in splits)
            {
                bool isAllPrime = true;
                foreach(var num in split)
                {
                    if(notPrime[num])
                    {
                        isAllPrime = false;
                        break;
                    }
                }
                if(isAllPrime)
                {
                    res.Add(split);
                }
            }

            return res;
        }

        private bool[] PreparePrimeNumberList(int n)
        {
            var notPrime = new bool[n + 1];
            notPrime[1] = true;
            for(int i = 2; i <= n; i++)
            {
                if (notPrime[i] == true) continue;

                var start = i + i;
               
                while(start <= n)
                {
                    notPrime[start] = true;
                    start = start + i;
                }
            }
            return notPrime;
        }

        private List<List<int>> GetPossibleSplit(string input)
        {
            var len = input.Length;

            var possibleSplitCount = System.Math.Pow(2, len - 1);

            var res = new List<List<int>>();

            for(int i = 0; i < possibleSplitCount; i++)
            {
                var mask = 1;

                var currSplit = new List<int>();
                var endIndex = len - 1;
                var startIndex = len - 1;
                for(int j = 0; j < len - 1; j++)
                {
                    if((mask & i) > 0)
                    {
                        startIndex = len - j - 1;// j + 1;
                        var split = input.Substring(startIndex, endIndex - startIndex + 1);
                        currSplit.Add(Convert.ToInt32(split));
                        endIndex = startIndex - 1;
                    }

                    mask = mask << 1;
                }

                var finalSplit = input.Substring(0, endIndex + 1);
                currSplit.Add(Convert.ToInt32(finalSplit));

                res.Add(currSplit);
            }

            return res;
        }

        public void test()
        {
            var res = UniquePrime("3175");
        }
    }
}
