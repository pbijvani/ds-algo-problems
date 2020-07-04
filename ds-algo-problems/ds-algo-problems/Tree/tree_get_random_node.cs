using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Tree
{
    // Runs O (lon N) for balanced tree.
    public class TreeNodeWithRandomOption
    {
        public int data { get; set; }
        public int size { get; set; }
        public TreeNodeWithRandomOption Left { get; set; }
        public TreeNodeWithRandomOption Right { get; set; }

        public TreeNodeWithRandomOption(int _data)
        {
            data = _data;
            size = 0;
        }

        public void InsertInOrder(int d)
        {
            if(d <= data)
            {
                if(Left == null)
                {
                    Left = new TreeNodeWithRandomOption(d);
                }
                else
                {
                    Left.InsertInOrder(d);
                }
            }
            else
            {
                if(Right == null)
                {
                    Right = new TreeNodeWithRandomOption(d);
                }
                else
                {
                    Right.InsertInOrder(d);
                }
            }
            size++;
        }

        public TreeNodeWithRandomOption find(int d)
        {
            if(d == data)
            {
                return this;
            }
            else if(d <= data)
            {
                return Left?.find(d);
            }
            else if(d > data)
            {
                return Right?.find(d);
            }
            else
            {
                return null;
            }
        }

        public TreeNodeWithRandomOption GetRandomNode()
        {
            var leftSize = Left == null ? 0 : Left.size;

            var randomNum = GetRandomNumber(size);

            if(randomNum == leftSize)
            {
                return this;
            }
            else if(randomNum < leftSize)
            {
                return Left.GetRandomNode();
            }
            else
            {
                return Right.GetRandomNode();
            }
        }

        // another version. No need to get new random num everytime
        public TreeNodeWithRandomOption GetRandomNode1()
        {
            var randomNum = GetRandomNumber(size);

            return GetRandomNode1(randomNum);
        }
        public TreeNodeWithRandomOption GetRandomNode1(int randomNum)
        {
            var leftSize = Left == null ? 0 : Left.size;

            if(randomNum < leftSize)
            {
                return Left.GetRandomNode1(randomNum);
            }
            else if(randomNum == leftSize)
            {
                return this;
            }
            else
            {
                return Right.GetRandomNode1(randomNum - (leftSize + 1));
            }
        }

        private int GetRandomNumber(int max)
        {
            Random r = new Random();
            int rInt = r.Next(0, max);
            return rInt;
        }

    }
}
