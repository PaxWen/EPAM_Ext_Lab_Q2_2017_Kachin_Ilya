﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
    public class MyList<T>:List<T>
    {
        public delegate void ListEnventHandler(object sender,EventsArgsWorks e);
        public event ListEnventHandler OnAdd;
        public event ListEnventHandler OnDel;
        public new void Add(T item)
        {
            if (item is Person)
            {
                if (item != null)
                    {
                    Person bufPerson = ((object)item as Person);//todo pn у отдельного класса бизнес логики не должно быть зависимости от класса вывода данных.
					OnAdd?.Invoke(this, new EventsArgsWorks() {Name = bufPerson.Name,Time = bufPerson.TimeCome });
                    OnAdd += bufPerson.Greeting;
                    OnDel += bufPerson.Parting;
                    }
            }
            
            base.Add(item);
        }
        public new void Remove(T item)
        {
            if (item is Person)
            {
                if (item != null)
                {
                    Person bufPerson = ((object)item as Person);
                    Console.WriteLine();
                    Console.WriteLine("[{0} ушёл домой]", bufPerson.Name);
                    OnAdd -= bufPerson.Greeting;
                    OnDel -= bufPerson.Parting;
                    OnDel?.Invoke(this, new EventsArgsWorks() { Name = bufPerson.Name });
                }
            }
            base.Remove(item);
        }
    }
}
