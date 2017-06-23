﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_3
{
    /*На базе обычного массива (коллекции .NET не использовать) 
     * реализовать свой собственный класс DynamicArray, представляющий собой массив с запасом.
     *  Класс должен содержать:
    $1. Конструктор без параметров (создается массив емкостью 8 элементов).
    $2. Конструктор с 1 целочисленным параметром (создается массив заданной емкости).
    $3. Конструктор, который в качестве параметра принимает коллекцию, реализующую интерфейс IEnumerable,
    создает массив нужного размера и копирует в него все элементы из коллекции.
    $4. Метод Add, добавляющий в конец массива один элемент.
    При нехватке места для добавления элемента емкость массива должна расширяться в 2 раза.
    $5. Метод AddRange, добавляющий в конец массива содержимое коллекции, реализующей интерфейс IEnumerable.
    Обратите внимание, метод должен корректно учитывать число элементов в коллекции с тем,
    чтобы при необходимости расширения массива делать это только один раз вне зависимости 
    от числа элементов в добавляемой коллекции.
    $6. Метод Remove, удаляющий из коллекции указанный элемент. 
    Метод должен возвращать true, если удаление прошло успешно и false в противном случае.
    При удалении элементов реальная емкость массива не должна уменьшаться.
    $7. Метод Insert, позволяющий добавить элемент в произвольную позицию массива
    (обратите внимание, может потребоваться расширить массив).
    Метод должен возвращать true, если добавление прошло успешно и false в противном случае. 
    При выходе за границу массива должно генерироваться исключение ArgumentOutOfRangeException.
    $8. Свойство Length – получение длины массива.
    $9. Свойство Capacity – получение реальной длины массива.
    $10. Методы, реализующие интерфейсы IEnumerable и IEnumerator.
    $11. Индексатор, позволяющий работать с элементом с указанным номером. 
    При выходе за границу массива должно генерироваться исключение ArgumentOutOfRangeException.
    */
    public class DynamicArray<T>: IEnumerable, IEnumerator
    {
        private T[] arr;
        private int possition;
        private int capacity;
        public DynamicArray()
        {
            arr = new T[8];
            capacity = 0;
            possition = -1;
        }
        public DynamicArray(int n)
        {
            arr = new T[n];
            capacity = 0;
            possition = -1;
        }
        public DynamicArray(T[] arr)
        {
            this.arr = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                this.arr[i] = arr[i];
            }
            capacity = arr.Length;
            possition = -1;
        }
        public int Length
        {
            get { return arr.Length; }
        }
        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }
        public void Add(T item)
        {

            if (capacity<Length)
            {
                arr[capacity] = item;
                capacity++;
                return;
            }
            int buf = arr.Length;
            multArray(1);
            capacity++;
            arr[buf] = item;
        }
        public bool Insert(T item,int index)
        {
            if (Length - capacity == 0)
            {
                return false;
            }
            for (int i = capacity-1; i > index; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[index] = item;
            return true;

        }
        public T this[int index]
        {
            get
            {
                if ((index > Length-1)||(index < 0))
                {
                    throw new System.ArgumentOutOfRangeException("OutRangeArray");
                }
                return arr[index];
                
            }
            set {
                if ((index > Length - 1) || (index < 0))
                {
                    throw new System.ArgumentOutOfRangeException("OutRangeArray");
                }
                arr[index] = value;
            }
        }
        public void AddRange(T[] arrItems)
        {
            if (arr.Length - capacity >= arrItems.Length)
            {
                for (int j = capacity; j < arrItems.Length + capacity; j++)
                {
                    arr[j] = arrItems[j - capacity];
                }
                capacity += arrItems.Length;
                return;
            }
            int multSegments = 1;
            while ((arr.Length * multSegments*2) - capacity <= arrItems.Length)
            {
                multSegments++;
            }
            multArray(multSegments);
            for (int i = 0; i < arrItems.Length; i++)
            {
                arr[i + capacity] = arrItems[i];
            }
            capacity += arrItems.Length;

        }
        public bool Remove(T item)
        {
            int removeIndex=0;
            bool exitBool = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(item))
                {
                    removeIndex = i;
                    exitBool = true;
                    capacity--;
                }
            }
            for (int i = removeIndex; i < arr.Length-1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[arr.Length - 1] = default(T);
            return exitBool;
        }

        private void multArray(int multiplier)
        {
            T[] arrbuf = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arrbuf[i] = arr[i];
            }
            arr = new T[arr.Length * multiplier*2];
            for (int i = 0; i < arrbuf.Length; i++)
            {
                arr[i] = arrbuf[i];
            }
        }
        public void Reset()
        {
            possition = -1;
        }

        public bool MoveNext()
        {
            if (possition == arr.Length - 1)
            {
                Reset();
                return false;
            }

            possition++;
            return true;
        }
        public object Current
        {
            get
            {
                return arr[possition];
            }
        }
    
        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
}
