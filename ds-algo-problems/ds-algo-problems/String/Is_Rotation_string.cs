using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    class Is_Rotation_string
    {
        public bool IsRotationsString(string s1, string s2)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < s2.Length; i++)
            {
                if (s2[i] == s1[0])
                {
                    indexes.Add(i);
                }
            }

            foreach (var index in indexes)
            {
                var part1 = s2.Substring(0, index);
                var part2 = s2.Substring(index, s2.Length - index);

                if (s1 == string.Concat(part2, part1))
                    return true;
            }

            return false;
        }

        public bool IsRotationString1(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            else
            {
                var s1s1 = string.Concat(s1, s1);

                return s1s1.Contains(s2);
            }
        }

        
    }
}
