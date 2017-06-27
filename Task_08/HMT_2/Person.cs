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
        public DateTime TimeCome { get; }
        public Person(string name)
        {
            this.name = name;
            TimeCome = DateTime.Now;
        }
        public Person(string name,DateTime time)
        {
            this.name = name;
            TimeCome = time;
        }
        public Person(Person p)
        {
            this.name = p.name;
            this.TimeCome = p.TimeCome;
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
