using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    class tower_of_hanoi
    {
        /*
 * T(1) = 1
 * T(2) = 3
 * T(3) = 7
 * T(n) = T(n-1) + 1 + t(n-1)
 * T(n) = 2 T(n-1) + 1
 * T(n) = 2 (Pow n) - 1
 */
        public class Tower
        {
            private readonly Stack<int> stack;
            public Tower()
            {
                stack = new Stack<int>();
            }

            public void Add(int disk)
            {
                if (stack.Any() && stack.Peek() <= disk)
                    throw new Exception("Operation not allowed.");
                else
                    stack.Push(disk);
            }

            public void MoveTopDiscToTower(Tower dest)
            {
                dest.Add(stack.Pop());
            }

            public void MoveDisks(int qty, Tower dest, Tower buffer)
            {
                if (qty == 0) return;

                MoveDisks(qty - 1, buffer, dest);
                MoveTopDiscToTower(dest);
                buffer.MoveDisks(qty - 1, dest, this);
            }
        }

        public class TowerOfHanoi
        {
            public void TestTowerOfHanoi()
            {
                Tower source = new Tower();
                source.Add(4);
                source.Add(3);
                source.Add(2);
                source.Add(1);

                Tower dest = new Tower();
                Tower buffer = new Tower();

                source.MoveDisks(4, dest, buffer);

                Console.ReadKey();
            }
        }
    }
}
