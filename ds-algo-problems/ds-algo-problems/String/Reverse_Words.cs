using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.String
{
    class Reverse_Words
    {
        /// <summary>
        /// Reverse word from string
        /// "Hellow How are you" should return "you are how hello"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ReverseWord(string input)
        {
            var n = input.Length;

            var stack = new Stack<string>();

            int left = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == n - 1 || (input[i] == ' '))
                {
                    if (!string.IsNullOrWhiteSpace(input.Substring(left, (i - left))))
                    {
                        stack.Push(input.Substring(left, (i - left)));
                    }
                    left = i + 1;
                }

                if (i == n - 1)
                {
                    if (!string.IsNullOrWhiteSpace(input.Substring(left, (n - left))))
                    {
                        stack.Push(input.Substring(left, (n - left)));
                    }
                }
            }
            return string.Join(" ", stack.ToList());
        }
    }
}
