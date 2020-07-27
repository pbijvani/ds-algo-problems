using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.DataStructure
{
    public class MinHeap
    {
        private int _capacity;
        private int _size;
        private int[] _items;
        public MinHeap()
        {
            _capacity = 10;
            _size = 0;
            _items = new int[_capacity];
        }

        private int getLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int getRightChildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        private int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }

        private bool hasLeftChild(int index) { return getLeftChildIndex(index) < _size; }
        private bool hasRightChild(int index) { return getRightChildIndex(index) < _size; }
        private bool hasParent(int index) { if (index == 0) return false; else return getParentIndex(index) < _size; }


        private int getLeftChild(int parentIndex) { return _items[getLeftChildIndex(parentIndex)]; }
        private int getRightChild(int parentIndex) { return _items[getRightChildIndex(parentIndex)]; }
        private int getParent(int childIndex) { return _items[getParentIndex(childIndex)]; }


        private void swap(int index1, int index2)
        {
            var temp = _items[index1];
            _items[index1] = _items[index2];
            _items[index2] = temp;
        }

        private void ensureExtraCapacity()
        {
            if(_size == _capacity)
            {
                System.Array.Resize(ref _items, _capacity * 2);
                _capacity = _capacity * 2;
            }
        }

        private void heapifyyDown()
        {
            var index = 0;
            while(hasLeftChild(index))
            {
                var minValChildIndex = getLeftChildIndex(index);
                if(hasRightChild(index) && getRightChild(index) < getLeftChild(index))
                {
                    minValChildIndex = getRightChildIndex(index);
                }

                if(_items[index] < _items[minValChildIndex])
                {
                    break;
                }
                else
                {
                    swap(index, minValChildIndex);
                    index = minValChildIndex;
                }
            }
        }

        private void heapifyUp()
        {
            var index = _size - 1;
            while(hasParent(index) && getParent(index) > _items[index])
            {
                swap(index, getParentIndex(index));
                index = getParentIndex(index);
            }
        }

        public int Peek()
        {
            if (_size == 0) throw new Exception("");

            return _items[0];
        }


        public int Poll()
        {
            if (_size == 0) throw new Exception("");
            var item = _items[0];
            _items[0] = _items[_size - 1];
            heapifyyDown();
            _size = _size - 1;
            return item;
        }

        public void Insert(int data)
        {
            ensureExtraCapacity();
            _items[_size] = data;
            _size++;
            heapifyUp();
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }
    }
}
