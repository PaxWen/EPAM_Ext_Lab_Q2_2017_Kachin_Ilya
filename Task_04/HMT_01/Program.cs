using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_01
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Написать программу, которая определяет среднюю длину слова во введенной текстовой строке.
             *  Учесть, что символы пунктуации на длину слов влиять не должны. 
             *  Регулярные выражения не использовать. И не пытайтесь прописать все ручками.
             *   Используйте стандартные методы класса String. 
             */
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string sentence;
            string text;
            int sum;
            int k;//счётчик слов
            while (true)
            {
                Console.Clear();
                text = "";
                sum = 0;
                k = 0;
                Console.Write("Введите текст: ");
                sentence = Console.ReadLine();
                sentence += " ";
                sentence.ToLower();
                for (int i=0;i<sentence.Length;i++)
                {
                    if ((!char.IsPunctuation(sentence[i]))&& (!char.IsSeparator(sentence[i])))
                    {
                        text += sentence[i];
                    }else
                    {
                        if (text != "")
                        {
                            k++;
                            sum += text.Length;
                            text = "";
                        }  
                    }
                    
                }
                Console.WriteLine("Сумма длинн: {0}",sum);
                Console.WriteLine("Кол-во слов: {0}",k);
                Console.WriteLine("Средняя длинна слова: {0,6:N1}",sum/k);
                Console.WriteLine("Для выхода нажмите \'Enter\'...");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }
    }
}
