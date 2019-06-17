using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Math
{
    class fibonacci
    {

        /// <summary>
        /// fibonacci series
        /// </summary>
        /// <param name="len"></param>
        public void voidFibonacci_Iterative(int len)
        {
            int a = 0, b = 1, c = 0;
            Console.Write("{0} {1}", a, b);
            for (int i = 2; i < len; i++)
            {
                c = a + b;
                Console.Write(" {0}", c);
                a = b;
                b = c;
            }
        }

        public void Fibonacci_Recursive(int len)
        {
            this.Fibonacci_Rec_Temp(0, 1, 1, len);
        }



        public void Fibonacci_Rec_Temp(int a, int b, int counter, int len)
        {
            if (counter <= len)
            {
                Console.Write("{0} ", a);
                Fibonacci_Rec_Temp(b, a + b, counter + 1, len);
            }
        }
    }
}
