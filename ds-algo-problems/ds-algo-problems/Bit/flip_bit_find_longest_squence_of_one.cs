using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Bit
{
    public class flip_bit_find_longest_squence_of_one
    {
        /*
         * you are given an integer and you can flip one bit from zero to one in a way to find longest subsequence of one
         * this runs in O(b) where b is the element in sequence and O(b) space`
         */

        public  int LongestSequence(int num)
        {
            var binaryNum = GetBinary(num);

            var sequence = PrepareSeq(binaryNum);
            var seqLen = sequence.Count;

            var index = 0;
            var isZero = false;
            var longSeq = int.MinValue;
            var currentLen = 0;

            while(index < sequence.Count)
            {
                if(index == 0 && sequence[index] == 0)
                {
                    index++;
                    continue;
                }
                isZero = index % 2 == 0;

                if(isZero && sequence[index] == 1)
                {
                    if(index == 0)
                    {
                        currentLen = seqLen > 1 ? sequence[index + 1] + 1 : 1;  
                    }
                    else if(index == seqLen - 1)
                    {
                        currentLen = sequence[index - 1] + 1;
                    }
                    else
                    {
                        currentLen = sequence[index - 1] + sequence[index + 1] + 1;
                    }
                }
                else if(isZero && sequence[index] > 1)
                {
                    if(index == 0)
                    {
                        currentLen = sequence[index + 1] + 1;
                    }
                    else if (index == seqLen - 1)
                    {
                        currentLen = sequence[index - 1] + 1;
                    }
                    else
                    {
                        currentLen = System.Math.Max(sequence[index - 1] + 1, sequence[index + 1] + 1);
                    }
                }
                else
                {
                    currentLen = sequence[index];
                }

                if(currentLen > longSeq)
                {
                    longSeq = currentLen;
                }
                index++;
            }

            return longSeq;
        }

        public List<int> PrepareSeq(string binaryNum)
        {
            var len = binaryNum.Length;
            var index = 0;
            var res = new List<int>();

            if(binaryNum[index] == '1')
            {
                res.Add(0);
            }
            int runningCount = 0;
            var currentChar = binaryNum[index];
            var prevChar = currentChar;
            while(index < len)
            {
                currentChar = binaryNum[index];

                if(currentChar != prevChar)
                {
                    res.Add(runningCount);
                    prevChar = currentChar;
                    runningCount = 0;                    
                }

                runningCount++;                

                index++;
            }

            res.Add(runningCount);

            return res;
        }

        private string GetBinary(int num)
        {
            var mask = 1;
            var sb = new StringBuilder();

            while(mask <= num)
            {
                var res = mask & num;
                sb.Insert(0, res == 0 ? "0" : "1");

                mask = mask << 1;
            }

            return sb.ToString();
        }

        /*
         * We can improve space by not storing sequence and counting longest seq as you generate binary
         * 
         * not fullt tested yet
         */

        public int LongerstSequence1(int num)
        {
            int bestLen = int.MinValue;
            int runningLen = 0;
            bool? moreThanOneZero = null;

            int lastBit = -1;

            var mask = 1;
            var sb = new StringBuilder();

            while (mask <= num)
            {
                var res = mask & num;
                sb.Insert(0, res == 0 ? "0" : "1");

                mask = mask << 1;

                var currBit = res == 0 ? 0 : 1;

                if(currBit == 0)
                {
                    if(lastBit == -1)
                    {
                        runningLen = 1;
                    }
                    else if(lastBit == 0)
                    {
                        moreThanOneZero = true;
                        runningLen = 0;
                    }
                    else //if(lastBit == 1)
                    {
                        moreThanOneZero = false;
                        runningLen++;
                    }
                }
                else // currBit == 1
                {
                    if (lastBit == -1)
                    {
                        runningLen = 1;
                    }
                    else if (lastBit == 0)
                    {
                        if (moreThanOneZero != true)
                        {
                            runningLen++;
                        }
                        else
                        {
                            runningLen = 2;
                        }
                    }
                    else //if(lastBit == 1)
                    {
                        runningLen++;
                    }
                }


                if(runningLen > bestLen)
                {
                    bestLen = runningLen;
                }

                lastBit = currBit;
            }

            return bestLen;
        }
    }
}
