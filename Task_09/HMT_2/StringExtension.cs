using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
    public static class StringExtension
    {
        public static bool StringTest(this string word)
        {
            foreach (var item in word)
            {
                if (!char.IsDigit(item))//todo pn некорректно. А если 0 введут?
                {
                    return false;
                }
            }
            return true;
        }
    }
}
