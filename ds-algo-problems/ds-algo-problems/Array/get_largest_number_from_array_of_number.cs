using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Array
{
    class get_largest_number_from_array_of_number
    {
        public string GetLargestNumber(List<int> input)
        {
            var inputStr = input.Select(x => x.ToString()).ToList();
            inputStr.Sort(new LargerNumComparer());

            return string.Join("", inputStr);
        }
    }
    public class LargerNumComparer : IComparer<string>
    {


        public int Compare(string x, string y)
        {
            var option1 = Convert.ToInt32($"{x}{y}");
            var option2 = Convert.ToInt32($"{y}{x}");

            return option1 > option2 ? -1 : 1;
        }

    }
}
