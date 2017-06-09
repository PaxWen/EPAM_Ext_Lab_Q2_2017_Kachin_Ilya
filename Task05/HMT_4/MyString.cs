using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_4
{
    class MyString
    {
        private char[] stringArr;
        public MyString(char[] arr)
        {
            this.stringArr = arr;
        }
        public MyString(string str)
        {
            stringArr = str.ToCharArray();
        }
        public MyString()
        {
        }
        public static MyString operator +(MyString a,MyString b)
        {
            return (new MyString(a.ToString() + b.ToString()));
        }
        public static bool operator ==(MyString a, MyString b)
        {
            return a.stringArr.Equals(b.stringArr);
        }
        public static bool operator !=(MyString a, MyString b)
        {
            return !a.stringArr.Equals(b.stringArr);
        }

        public new string ToString()
        {
            return new string(stringArr);
        }
    }
}
