using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Sort
{
    /*
     * you are reading a stream of int
     * periodically you wish to see the ran of int x (number of value less than or equal to x)
     * implement the data structire and algo to support this operation.
     * 
     * Sol 1 : store numbers in array in sorted mannger. Insertion will be expension because you need to shift element.
     * but fetch would fast you can apply binary search
     * 
     * Sol2 : maintain has table, for each unique number maintain count. Instertion is expensive but fetch will be better
     * 
     * Sol3: maintain BS tree. insertion and fetch both will be lon (n) as per below.
     */
    public class rank_from_stream_of_int
    {
        private RankNode root;

        public void track(int num)
        {
            if (root == null)
            {
                root = new RankNode(num);
            }
            else
            {
                root.Insert(num);
            }
        }

        public int GetRank(int num)
        {
            return root.GetRank(num);
        }

        public void Test()
        {
            this.track(5);
            this.track(1);
            this.track(4);
            this.track(4);
            this.track(5);
            this.track(9);
            this.track(7);
            this.track(12);
            this.track(3);
        }
    }

    public class RankNode
    {
        public int Data { get; set; }
        public int LeftSize { get; set; }

        public RankNode Left { get; set; }
        public RankNode Right { get; set; }

        public RankNode(int d)
        {
            this.Data = d;
        }

        public int GetRank(int d)
        {
            if (d == Data)
            {
                return LeftSize;
            }
            else
            {
                if(d < Data)
                {
                    if (Left == null) return -1;
                    else return Left.GetRank(d);
                }
                else
                {
                    int rightRank = Right == null ? -1 : Right.GetRank(d);
                    if (rightRank == -1) return -1;
                    else return rightRank + LeftSize + 1;
                }
            }
        }

        public void Insert(int d)
        {
            if(d <= Data)
            {
                if(Left == null)
                {
                    Left = new RankNode(d);
                }
                else
                {
                    Left.Insert(d);
                }
                LeftSize++;
            }
            else
            {
                if(Right == null)
                {
                    Right = new RankNode(d);
                }
                else
                {
                    Right.Insert(d);
                }
            }
        }

    }
}
