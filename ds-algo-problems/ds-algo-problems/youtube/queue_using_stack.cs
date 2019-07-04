using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.youtube
{
    public class queue_using_stack
    {
        /*
         * Queue using only 1 stack
         */

        public void Test()
        {
            QueueUsingTwoStack queue1 = new QueueUsingTwoStack();
            queue1.Enqueue(1);
            queue1.Enqueue(2);
            queue1.Enqueue(3);
            queue1.Enqueue(4);

            var data1 = queue1.Dequeue();
            data1 = queue1.Dequeue();

            QueueUsingOneStack queue = new QueueUsingOneStack();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            var data = queue.Dequeue();
            data = queue.Dequeue();

        }
    }

    public class QueueUsingTwoStack
    {
        public readonly Stack<int> _enqueueStack;
        public readonly Stack<int> _dequeueStack;

        public QueueUsingTwoStack()
        {
            _enqueueStack = new Stack<int>();
            _dequeueStack = new Stack<int>();
        }

        public void Enqueue(int data)
        {
            _enqueueStack.Push(data);
        }

        public int Dequeue()
        {
            if(!_dequeueStack.Any())
            {
                while (_enqueueStack.Any())
                {
                    _dequeueStack.Push(_enqueueStack.Pop());
                }
            }

            if (_dequeueStack.Any())
            {
                return _dequeueStack.Pop();
            }
            else
            {
                return -1;
            }            
        }
    }

    public class QueueUsingOneStack
    {
        private readonly Stack<int> _stack;

        public QueueUsingOneStack()
        {
            _stack = new Stack<int>();
        }

        public void Enqueue(int data)
        {
            _stack.Push(data);
        }

        public int Dequeue()
        {
            if (_stack.Any())
            {
                var data = DequeueHelper();
                return data;
            }
            else
                return -1;
            
        }

        private int DequeueHelper()
        {
            if(_stack.Count > 1)
            {
                var data = _stack.Pop();
                var retVal = DequeueHelper();
                _stack.Push(data);
                return retVal;
            }
            else
            {
                return _stack.Pop(); ;
            }
        }
    }
}
