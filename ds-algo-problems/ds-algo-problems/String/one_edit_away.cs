using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    class one_edit_away
    {
        public bool StringWithOneEditAway(string input, string edit)
        {
            if (System.Math.Abs(input.Length - edit.Length) > 1) return false;

            int indexA = 0;
            int indexB = 0;

            bool sameLength = input.Length == edit.Length;
            bool newSringIsShort = input.Length > edit.Length;

            int diffCount = 0;
            while (indexA < input.Length && indexB < edit.Length)
            {
                if (input[indexA] == edit[indexB])
                {
                    indexA++;
                    indexB++;
                    continue;
                }
                else
                {
                    diffCount++;
                    if (sameLength)
                    {
                        indexA++;
                        indexB++;
                    }
                    else
                    {
                        if (newSringIsShort) indexB++;
                        else indexA++;
                    }
                }
                if (diffCount > 1) return false;
            }
            return true;
        }
    }
}
