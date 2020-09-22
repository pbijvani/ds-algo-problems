using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.amazon_online_assessment_problems
{
    /*
     * https://aonecode.com/amazon-online-assessment-secret-fruits
     * https://leetcode.com/discuss/interview-question/762546/
     */
    public class secret_fruit_list
    {
        public static bool GetResult(List<List<string>> codeList, string[] shoppingCart)
        {
            bool isMatched = false;
            int j = 0;
            for (int i = 0; i < codeList.Count; i++)
            {
                for (int m = 0; m < shoppingCart.Length; m++)
                {
                    if (codeList[i].Count == j && isMatched)
                    {
                        return isMatched;
                    }
                    else if (codeList[i][j].Equals(shoppingCart[m]) || codeList[i][j].Equals("anything"))
                    {
                        isMatched = true;
                        j++;
                    }
                    else
                    {
                        isMatched = false;
                        j = 0;
                    }
                }
            }
            return isMatched;
        }

        public void test()
        {
            var list = new List<List<string>>()
            {
                new List<string>(){ "apple", "apple" },
                new List<string>(){ "banana", "anything", "banana" }
            };

            var card = new string[] { "banana", "orange", "banana", "apple", "apple" };

            var res = GetResult(list, card);
        }
    }
}
