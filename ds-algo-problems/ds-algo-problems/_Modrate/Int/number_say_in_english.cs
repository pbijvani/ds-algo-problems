using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Int
{
    public class number_say_in_english
    {
        // 1234: one thousand thirty four

        Dictionary<string, int> dict = new Dictionary<string, int>();
        
        
        public string SayNumber(int n)
        {
            string[] ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tens = { "" };

            List<int> digits = new List<int>();
            int modVal = 10;
            int i = 0;
            while (n > 0)
            {                
                modVal = i >= 3 ? modVal * 1000 : modVal;

                var mod = n % modVal;

                digits.Add(mod);
                
                n = n / modVal;

                i++;
            }

            

            return string.Empty;
        }
        
    }
}
