using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    public class Jewels_and_Stones
    {
        /*
         * You're given strings J representing the types of stones that are jewels, and S representing the stones you have.  Each character in S is a type of stone you have.  You want to know how many of the stones you have are also jewels.

The letters in J are guaranteed distinct, and all characters in J and S are letters. Letters are case sensitive, so "a" is considered a different type of stone from "A".

Example 1:

Input: J = "aA", S = "aAAbbbb"
Output: 3
Example 2:

Input: J = "z", S = "ZZ"
Output: 0

         */

        public int NumOfJewelsInStore(string j, string s)
        {
            HashSet<char> hashSet = new HashSet<char>();
            foreach(var ch in j)
            {
                hashSet.Add(ch);
            }

            int count = 0;
            foreach(var ch in s)
            {
                if(hashSet.Contains(ch))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
