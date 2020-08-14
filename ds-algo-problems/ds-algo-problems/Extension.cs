using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems
{
    public static class Extension
    {
        public static void Swap<T>(this T[] array, int indexA, int indexB)
        {
            T temp = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = temp;
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            System.Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static T[] SubArray1<T>(this T[] data, int index, int length)
        {
            return data.Skip(index).Take(length).ToArray();
        }

        public static T[] Slice<T>(this T[] source, int start, int end)
        {
            // Handles negative ends.
            //if (end < 0)
            //{
            //    end = source.Length + end;
            //}
            int len = end - (start == 0 ? -1 : start);

            T[] result = new T[len];

            System.Array.Copy(source, start, result, 0, len);
            return result;


            // Return new array.
            T[] res = new T[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }

        public static int GetOrDefault(this Dictionary<int, int> dict, int key, int defaultVal)
        {
            if (dict.ContainsKey(key)) return dict[key];
            else return defaultVal;
        }
    }
}
