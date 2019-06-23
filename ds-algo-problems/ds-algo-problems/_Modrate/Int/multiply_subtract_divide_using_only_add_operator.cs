using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems._Modrate.Int
{
    public class multiply_subtract_divide_using_only_add_operator
    {
        public int negate(int num)
        {
            int numCopy = num;
            int newSign = num > 0 ? -1 : 1;
            int delta = newSign;
            int neg = 0;
            while(num != 0)
            {
                bool isDiffSign = (num + delta) > 0 != num > 0;

                if(num + delta != 0 && isDiffSign)
                {
                    delta = newSign;
                }

                neg = neg + delta;
                num = num + delta;
                newSign = newSign << 1;
            }

            return neg;
        }

        public int Subtraction(int a, int b)
        {
            return a + negate(b);
        }

        public int Multiply(int a, int b)
        {
            int smallNumber = a > b ? b : a;
            int bigNumber = a > b ? a : b;

            if (smallNumber == 0) return 0;
            if (smallNumber == 1) return bigNumber;

            var s = smallNumber >> 1;

            var res = Multiply(s, bigNumber);

            if (smallNumber % 2 == 0) return res + res;
            else return res + res + bigNumber;
        }

        public int Divide(int a, int b)
        {
            if (a == b) return 1;

            int smallNumber = a > b ? b : a;
            int bigNumber = a > b ? a : b;
            int runningSum = smallNumber;
            int smallNumberCopy = smallNumber;
            int result = 1;
            while(bigNumber != runningSum)
            {
                if(runningSum + runningSum > bigNumber)
                {
                    smallNumber = smallNumberCopy;
                }
                
                runningSum = runningSum + smallNumber;
                result = result + smallNumber / smallNumberCopy;
                smallNumber = smallNumber + smallNumber;
            }

            return result;
        }


    }
}
