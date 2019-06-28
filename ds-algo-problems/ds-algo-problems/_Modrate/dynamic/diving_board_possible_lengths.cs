using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.dynamic
{
    public class diving_board_possible_lengths
    {
        /*
         * you are given bunch of planks of woods.
         * there are two types of planks. Long and short
         * you need to use k planks
         * write a method to return all possible lengths
         */
        public HashSet<int> PossibleLengths(int k, int shorter, int longegr)
        {
            var lengths = new HashSet<int>();
            generatePossibleLengths(k, 0, 0, shorter, longegr, lengths);
            return lengths;
        }

        // O(2 pow k)
        public void generatePossibleLengths(int k, int runningSum, int length, int shorter, int longer, HashSet<int> possibleLengths)
        {
            if(length == k)
            {
                possibleLengths.Add(runningSum);
                return;
            }

            generatePossibleLengths(k, runningSum + shorter, length + 1, shorter, longer, possibleLengths);
            generatePossibleLengths(k, runningSum + longer, length + 1, shorter, longer, possibleLengths);
        }

        // Optionmization using memorization
        public void generatePossibleLengthsOptimized(int k, int runningSum, int length, int shorter, int longer, HashSet<int> possibleLengths, HashSet<string> visited)
        {
            if (length == k)
            {
                possibleLengths.Add(runningSum);
                return;
            }

            var key = $"{length}-{runningSum}";

            if (visited.Contains(key)) return;

            generatePossibleLengthsOptimized(k, runningSum + shorter, length + 1, shorter, longer, possibleLengths, visited);
            generatePossibleLengthsOptimized(k, runningSum + longer, length + 1, shorter, longer, possibleLengths, visited);

            visited.Add(key);
        }

        public List<int> generatePOssibleLengthsIterative(int k, int shorter, int longer)
        {
            var possibleLengths = new List<int>();
            for(int i = 0; i <= shorter; i++)
            {
                int nOfLonger = k - i;
                int length = i * shorter + nOfLonger * longer;
                possibleLengths.Add(length);
            }
            return possibleLengths;
        }
    }
}
