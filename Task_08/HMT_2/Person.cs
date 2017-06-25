using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
    public class Person
    {
        private string name;
        public string Name { get { return name; } }
        public Person(string name)
        {
            this.name = name;
        }
        public Person(Person p)
        {
            this.name = p.name;
        }
        public void Greeting(object sender, EventsArgsWorks e)
        {
            if (e.Time.Hour < 12)
            {
                Console.WriteLine("\'Доброе утро,{0}!\' - сказал {1}", e.Name,Name);
                return;
            }
            if ((e.Time.Hour >= 12)&&((e.Time.Hour < 16)))
            {
                Console.WriteLine("\'Добрый день,{0}!\' - сказал {1}", e.Name, Name);
                return;
            }
            if (e.Time.Hour >= 16)
            {
                Console.WriteLine("\'Добрый вечер,{0}!\' - сказал {1}", e.Name, Name);
                return;
            }
        }
        public void Parting(object sender, EventsArgsWorks e)
        {
            Console.WriteLine("\'До свидания, {0}!\' - сказал {1}",e.Name,this.name);
        }
    }
}
