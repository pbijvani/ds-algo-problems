using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class array_minimize_max_distance_to_gas_station
    {
        /*
         * you are given an array. e.g. [1, 5, 10]
         * each element represents an gas station at perticular point
         * so now we have distance btween 1st and 2nd gas station is 4
         * distance between 2nd and 3rd gas station si 5.
         * max distance is 5.
         * 
         * now you are given a int k. you need to add k more gas station in between
         * in a way that max distance between gas station gets minimized.
         * 
         * for example if k = 1, you can add that at element 7.5, which will make max distance to 4
         */

        public double MinimizeMaxDistance(int[] input, int k)
        {
            List<Interval> distanceArray = new List<Interval>();

            int lastElement = -1;
            foreach (var elem in input)
            {
                if(lastElement != -1)
                {
                    distanceArray.Add(new Interval(elem - lastElement));
                }
                lastElement = elem;
            }

            while(k >= 0)
            {
                var top = GetTopElementFromList(distanceArray);

                while(k >= 0 && (top.Distance >= PeekTopElementFromList(distanceArray).Distance))
                {
                    top.AddGasStation();
                    k--;
                }
                AddElementToList(distanceArray, top);
            }

            return PeekTopElementFromList(distanceArray).Distance;
        }

        private void AddElementToList(List<Interval> lsit, Interval element)
        {
            lsit.Add(element);
        }

        private Interval GetTopElementFromList(List<Interval> list)
        {
            var orderedList = list.OrderByDescending(x => x.Distance).ToList();
            var item = orderedList.First();
            orderedList = orderedList.Skip(1).ToList();
            return item;
        }

        private Interval PeekTopElementFromList(List<Interval> list)
        {
            var orderedList = list.OrderByDescending(x => x.Distance).ToList();
            var item = orderedList.First();            
            return item;
        }

        public double Test(int k)
        {
            var array = new int[] { 1, 25, 51 };

            var res = MinimizeMaxDistance(array, k);

            return res;
        }
    }

    public class Interval
    {
        public Interval(double d)
        {
            TotalDistance = d;
            NoOfGasStations = 1;            
        }

        public double Distance
        {
            get
            {
                return TotalDistance / NoOfGasStations;
            }
        }
        public int NoOfGasStations { get; set; }
        public double TotalDistance { get; set; }

        public void AddGasStation()
        {
            NoOfGasStations++;
        }

        public void RemoveGasStation()
        {
            NoOfGasStations--;
        }
    }
}
