using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    public class overlaping_rectangles
    {
        public int CalculateOverlapArea(Rectangle r1, Rectangle r2)
        {
            int xOverlapSize = 0;
            int yOverlapSize = 0;

            if(r1.Left <= r2.Left)
            {
                xOverlapSize = getAxisOverlaping(r1.Left, r1.Right, r2.Left, r2.Right);
            }
            else
            {
                xOverlapSize = getAxisOverlaping(r2.Left, r2.Right, r1.Left, r1.Right);
            }

            if (r1.Bottom <= r2.Bottom)
            {
                yOverlapSize = getAxisOverlaping(r1.Bottom, r1.Top, r2.Bottom, r2.Top);
            }
            else
            {
                yOverlapSize = getAxisOverlaping(r2.Bottom, r2.Top, r1.Bottom, r1.Top);
            }

            return xOverlapSize * yOverlapSize;
        }

        public int getAxisOverlaping(int r1Left, int r1Right, int r2Left, int r2Right)
        {
            if(r1Right <= r2Left)
            {
                return 0;
            }
            else if (r1Left <= r2Left && r2Right <= r1Right)
            {
                return r2Right - r2Left;
            }
            else
            {
                return r1Right - r2Left;
            }
        }

        public int Test()
        {
            var r1 = new Rectangle(4, 1, 1, 5);
            var r2 = new Rectangle(6, 2, 1, 6);

            var res = CalculateOverlapArea(r2, r1);

            return res; 
        }
    }

    public class Rectangle
    {
        public int Top { get; set; }
        public int Left { get; set; }

        public int Bottom { get; set; }
        public int Right { get; set; }

        public Rectangle(int top, int left, int bottom, int right)
        {
            this.Top = top;
            this.Left = left;
            this.Bottom = bottom;
            this.Right = right;
        }
    }
}
