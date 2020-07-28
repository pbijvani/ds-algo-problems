using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.LeetCodeTop.Stack
{
    public class valid_parentheses
    {
        /*
         * Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

            An input string is valid if:

            Open brackets must be closed by the same type of brackets.
            Open brackets must be closed in the correct order.
            Note that an empty string is also considered valid.
            
                     
         */
        public bool IsValid(string s)
        {
            var stack1 = new Stack<char>();           

            foreach(var ch in s)
            {
                if(ch == '(' || ch == '{' || ch == '[')
                {
                    stack1.Push(ch);
                }
                else
                {
                    if(ch == ')' && stack1.Any() && stack1.Peek() == '(')
                    {
                        stack1.Pop();
                    }
                    else if (ch == '}' && stack1.Any() && stack1.Peek() == '{')
                    {
                        stack1.Pop();
                    }
                    else if (ch == ']' && stack1.Any() && stack1.Peek() == '[')
                    {
                        stack1.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return !stack1.Any();

            
        }
    }
}
