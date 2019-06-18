using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Sort
{
    class QuickSort
    {
        public int[] QuickSortMethod(int[] array)
        {
            QuickSortMethod(array, 0, array.Length - 1);

            return array;
        }

        public void QuickSortMethod(int[] array, int left, int right)
        {
            if (left >= right)
                return;

            int pivot = array[(left + right) / 2];
            int index = Partition(array, left, right, pivot);

            QuickSortMethod(array, left, index - 1);
            QuickSortMethod(array, index, right);

        }

        public int Partition(int[] array, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (array[left] < pivot)
                {
                    left++;
                }

                while (array[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    array.Swap<int>(left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }
    }
}
