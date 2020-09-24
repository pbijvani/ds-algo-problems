using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.amazon_online_assessment_problems
{
    /*
     https://aonecode.com/amazon-online-assessment-questions#dl
     https://blog.csdn.net/qq_35175413/article/details/98751076

Given N dices each face ranging from 1 to 6, return the minimum number of rotations necessary for each dice show the same face.
Notice in one rotation you can rotate the dice to the adjacent face. For example you can rotate the dice shows 1 to show 2, 3, 4, or 5. But to make it show 6, you need two rotations.

Example:
Input: [6, 5, 4]
Output: 2
Rotate 6 to 4, then rotate 5 to 4.

Input: [6, 6, 1]
Output: 2
Rotate 1 to 6, which needs two rotations.

Input: [6, 1, 5, 4]
Output: 3
Rotate 6 to 5, rotate 1 to 5, then rotate 4 to 5


     */
    public class roll_dice_same_face
    {
        public int  RollDice(int[] faces)
        {
            var dict = new Dictionary<int, int>();

            foreach(var face in faces)
            {
                if(dict.ContainsKey(face))
                {
                    dict[face] = dict[face] + 1;
                }
                else
                {
                    dict.Add(face, 1);
                }
            }

            var minCount = int.MaxValue;

            // In dic sum of two opposit face in 7
            // When sum is 7 you need to roll dice twice.
            for (int i = 1; i <= 6; i++)
            {
                var tempCount = 0;

                foreach(var face in dict)
                {
                    if(face.Key == i)
                    {
                        tempCount = tempCount + 0; // alredy on same face
                    }
                    else if(face.Key + i == 7)
                    {
                        tempCount = tempCount + 2; // opposit face
                    }
                    else
                    {
                        tempCount = tempCount + 1;
                    }
                }

                minCount = System.Math.Min(minCount, tempCount);
            }



            return minCount;

        }
    }
}
