using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class cycle_in_a_array
    {
        /*
         * you are given an array
         * you need to traverse in a array with below rule
         * when you are at index i you jump to index arr[i].
         * 
         * find if there is any cycle in array
         */

        public bool HasCycle(int[] array)
        {
            int slow = 0;
            int fast = 0;
            int len = array.Length;

            while(slow >=0 && slow < len && fast >=0 && fast < len)
            {
                if (IsInRange(len, slow)) slow = array[slow];
                else return false;

                if (IsInRange(len, fast)) fast = array[fast];
                else return false;

                if (IsInRange(len, fast)) fast = array[fast];
                else return false;

                if (slow == fast) return true;
            }
            return false;
        }

        private bool IsInRange(int len, int index)
        {
            return index >= 0 && index < len;
        }

        public bool Test()
        {
            //int[] array = new int[] { 1, 2, 1, 3, 8 };
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };
            return HasCycle(array);
        }

        /*
         * Another version of similar kind of problem
         * 
         * You are given a circular array nums of positive and negative integers. If a number k at an index is positive, then move forward k steps. Conversely, if it's negative (-k), move backward k steps. Since the array is circular, 
         * you may assume that the last element's next element is the first element, and the first element's previous element is the last element.
            
            Determine if there is a loop (or a cycle) in nums. 
            A cycle must start and end at the same index and the cycle's length > 1. 
            Furthermore, movements in a cycle must all follow a single direction. 
            In other words, a cycle must not consist of both forward and backward movements

            Example 1:

            Input: [2,-1,1,2,2]
            Output: true
            Explanation: There is a cycle, from index 0 -> 2 -> 3 -> 0. The cycle's length is 3.
            Example 2:

            Input: [-1,2]
            Output: false
            Explanation: The movement from index 1 -> 1 -> 1 ... is not a cycle, because the cycle's length is 1. By definition the cycle's length must be greater than 1.
            Example 3:

            Input: [-2,1,-1,-2,-2]
            Output: false
            Explanation: The movement from index 1 -> 2 -> 1 -> ... is not a cycle, because movement from index 1 -> 2 is a forward movement, but movement from index 2 -> 1 is a backward movement. All movements in a cycle must follow a single direction.
         */


        public bool HasCycleDFS(int[] array)
        {
            int len = array.Length;
            int[] cycle = new int[len];
            bool[] inStack = new bool[len];

            for(int i = 0; i < len; i++)
            {
                inStack[i] = false;
                cycle[i] = -1;
            }

            for (int i = 0; i < len; i++)
            {
                if(cycle[i] == -1)
                {
                    if(DFSHelper(i, array, cycle, inStack, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool DFSHelper(int i, int[] array, int[] cycle, bool[] inStack, int currStackSize)
        {
            if(inStack[i])
            {
                return currStackSize > 1;
            }

            if(cycle[i] == -1)
            {
                inStack[i] = true;
                currStackSize++;

                int nextPos = (i + array[i]) % array.Length;

                if (nextPos < 0) nextPos = array.Length + nextPos;

                bool res;

                // (nums[i] * nums[nextPos] > 0) : this satifies the requirement of going in one direction
                // We should travere only positive or negitive numbers at a time
                if (i != nextPos && (array[i] * array[nextPos] > 0))
                {
                    res = DFSHelper(nextPos, array, cycle, inStack, currStackSize);
                }
                else
                {
                    res = false;
                }
                cycle[i] = res == true ? 1 : 0;
                inStack[i] = false;
            }

            return cycle[i] == 1;
        }


        public bool Test1()
        {
            int[] arr = new int[] { 2, -1, 1, 2, 2 };
            var a1 = HasCycleDFS(arr);

            int[] arr1 = new int[] { -1, 2 };
            return HasCycleDFS(arr1);


        }

    }
}
