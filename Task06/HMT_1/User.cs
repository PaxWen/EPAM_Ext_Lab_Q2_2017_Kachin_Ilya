using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_1
{
    public class User
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get;  set; }
        public User(string N,string SN,string P,DateTime B)
        {
            Name = N;
            SecondName = SN;
            Patronymic = P;
            Age = DateTime.Now.Year-B.Year;
        }
        public User()
        {

        }

    }
}
