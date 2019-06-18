using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Stack
{
    class sort_stack
    {
        public void SortStack()
        {
            Stack<int> stack = new Stack<int>();
            Stack<int> stackExtra = new Stack<int>();

            stack.Push(50);
            stack.Push(80);
            stack.Push(20);
            stack.Push(70);
            stack.Push(90);
            stack.Push(30);
            stack.Push(10);
            stack.Push(100);
            stack.Push(5);

            while (stack.Any())
            {
                int item = stack.Pop();

                if (!stackExtra.Any())
                {
                    stackExtra.Push(item);
                }
                else
                {
                    int i = 0;
                    while (stackExtra.Peek() > item)
                    {
                        stack.Push(stackExtra.Pop());
                        i++;
                    }
                    stackExtra.Push(item);
                    while (i > 0)
                    {
                        stackExtra.Push(stack.Pop());
                        i--;
                    }
                }
            }
        }
    }
}
