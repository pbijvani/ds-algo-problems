using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Stack
{
    /*
     * Need to maintain 3 stack using one array
     * 
     * Method 1 : We just devide array in 3 parts and use each part to maintain one stack.
     * issue with this approach is that one stack could be nearly empty and other is fully occupied
     * space is not used properly
     * 
     * to better manage stack we are deviding array into slots and assigning slots to stack as they need more space.
     * below is attempt to implement that. Not completed yet.
     */
    public class a_3_stack_in_one_array
    {
        private int[] _array;
        private int _capacityIncrement = 100;
        private int _totalCapacity = 100;
        private int _slotSize = 10;

        private List<List<int>> _stackSlots;
        private List<int> _emptySlots;

        private List<int> _stackTop;


        public a_3_stack_in_one_array()
        {
            _array = new int[_capacityIncrement];

            var stack1Slots = new List<int>() { 0 };
            var stack2Slots = new List<int>() { 1 };
            var stack3Slots = new List<int>() { 2 };

            _stackSlots = new List<List<int>>() { stack1Slots, stack2Slots, stack3Slots };

            _stackTop = new List<int>() { 0, 0, 0 };

            _emptySlots = new List<int>();

            _emptySlots.AddRange(new int[] { 3, 4, 5, 6, 7, 8, 9 });
        }

        private void EnsureCapacity(int stackIndex)
        {
            if(_stackTop[stackIndex] == 5) // slot is full
            {
                if(!_emptySlots.Any())
                {
                    // no empty slot
                    var newSlots = GetNewSlots(_totalCapacity, _totalCapacity + _capacityIncrement - 1);

                    _emptySlots.AddRange(newSlots);
                }

                var topSlot = _emptySlots[0];
                _emptySlots.RemoveAt(0);

                _stackSlots[stackIndex].Add(topSlot);
                _stackTop[stackIndex] = 0;
            }            
        }

        private void ReleaseSlot(int stackIndex)
        {
            var emptySlot = _stackSlots[stackIndex].Last();
            _stackSlots[stackIndex].RemoveAt(_stackSlots[stackIndex].Count - 1);

            _emptySlots.Insert(0, emptySlot);

            _stackTop[stackIndex] = 4;
        }

        private List<int> GetNewSlots(int startIndex, int endIndex)
        {
            var list = new List<int>();
            for(int i = startIndex; i <= endIndex; i = i + _slotSize)
            {
                list.Add(i / 10);
            }

            return list;
        }

        private int GetArrayIndex(int slot, int slotIndex)
        {
            return 0;
        }

        private void IncrementIndex(int stackIndex, int slot, int slotIndex)
        {

        }

        public void Push(int stack, int value)
        {
            var stackIndex = stack - 1;

            EnsureCapacity(stackIndex);

            var slot = _stackSlots[stackIndex].Last();
            var slotIndex = _stackTop[stackIndex];

            var arrayIndex = GetArrayIndex(slot, slotIndex);

            _array[arrayIndex] = value;

            slotIndex++;
        }

        public int Pop(int stack)
        {
            var stackIndex = stack - 1;

            var slot = _stackSlots[stackIndex].Last();
            var slotIndex = _stackTop[stackIndex];

            var arrayIndex = GetArrayIndex(slot, slotIndex);

            var item = _array[arrayIndex];

            _stackTop[stackIndex]--;

            if(_stackTop[stackIndex] == -1)
            {
                ReleaseSlot(stackIndex);
            }
            return item;
        }

    }
}
