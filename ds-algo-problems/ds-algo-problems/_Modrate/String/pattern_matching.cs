using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.String
{
    public class pattern_matching
    {
        public bool MatchPattern(string input, string pattern)
        {
            int len = input.Length;
            int noOfA = 0;
            int noOfB = 0;

            int lenOfA = 1;
            int lenOfB = -1;
            foreach(var ch in pattern)
            {
                noOfA = ch == 'a' ? noOfA + 1 : noOfA;
                noOfB = ch == 'b' ? noOfB + 1 : noOfB;
            }

            
            while(true)
            {
                lenOfB = GetVal(noOfA, noOfB, len, lenOfA);

                if(lenOfB == -1)
                {
                    lenOfA++;
                    continue;
                }
                if(lenOfB == -2)
                {
                    break;
                }

                var res = Match(input, pattern, lenOfA, lenOfB);

                if (res) return true;

                lenOfA++;                
            }

            return false;
        }

        public bool Match(string input, string pattern, int lenOfA, int lenOfB)
        {
            string aVal = "";
            string bVal = "";

            int startIndexOfCurrentBucket = 0;

            for(int i = 0; i < pattern.Length; i++)
            {
                char ch = pattern[i];

                if (ch == 'a')
                {
                    if(aVal == "")
                    {
                        aVal = input.Substring(startIndexOfCurrentBucket, lenOfA);
                    }
                    else
                    {
                        var currAVal = input.Substring(startIndexOfCurrentBucket, lenOfA);
                        if (currAVal != aVal) return false;
                    }
                }

                if (ch == 'b')
                {
                    if (bVal == "")
                    {
                        bVal = input.Substring(startIndexOfCurrentBucket, lenOfB);
                    }
                    else
                    {
                        var currBVal = input.Substring(startIndexOfCurrentBucket, lenOfB);
                        if (currBVal != bVal) return false;
                    }
                }

                startIndexOfCurrentBucket += ch == 'a' ? lenOfA : lenOfB;
            }
            return true;
        }

        public int GetVal(int noOfA, int noOfB, int len, int lenOfA)
        {
            int topVal = (len - (noOfA * lenOfA));

            if(topVal % noOfB == 0)
            {
                int lenOfB = topVal / noOfB;
                if (lenOfB > 1 && lenOfB < len)
                    return lenOfB;
                else
                    return -2;
            }
            else
            {
                return -1;
            }
        }
    }
}
