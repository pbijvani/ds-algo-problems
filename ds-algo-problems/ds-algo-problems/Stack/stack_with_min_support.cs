using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Stack
{
    class stack_with_min_support
    {
        public StackNode top { get; set; }

        public void Push(int data)
        {
            StackNode node = new StackNode(data);

            if (top == null)
            {
                top = node;
                top.minData = data;
            }
            else
            {
                var minData = System.Math.Min(top.minData, data);
                node.minData = minData;
                node.next = top;

                top = node;
            }
        }

        public int Pop()
        {
            var item = top;
            top = top.next;


            return item.data;
        }

        public int GetMinVal()
        {
            if (top == null) return -1;
            else return top.minData;
        }
    }
    public class StackNode
    {
        public StackNode(int data)
        {
            this.data = data;
        }

        public StackNode(int data, int min) : this(data)
        {
            this.minData = min;
        }

        public int data { get; set; }
        public int minData { get; set; }
        public StackNode next { get; set; }
    }
}
