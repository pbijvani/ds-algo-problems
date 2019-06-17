using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds_algo_problems.Problems
{
    class Excel_sheet_Column_title
    {
        /// <summary>
        /// Given a positive integer, return its corresponding column title as appear in an Excel sheet.
        /// Excel Sheet Column Title
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string ExcelSheetColumnTitle(int n)
        {
            var stringbuilder = new StringBuilder();
            while (n > 0)
            {
                stringbuilder.Insert(0, (char)((n - 1) % 26 + 'A'));
                n = (n - 1) / 26;
            }

            return stringbuilder.ToString();
        }
    }
}
