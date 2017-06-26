using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
	/*
     * Задан английский текст. 
     * Выделить отдельные слова и для каждого посчитать частоту встречаемости. 
     * Слова, отличающиеся регистром, считать одинаковыми. 
     * В качестве разделителей считать пробел и точку.
     */
	public class Program
    {
        public static void Main(string[] args)//todo pn "Слова, отличающиеся регистром, считать одинаковыми" переделай, сейчас для проги AS as As - разные слова.
		{
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            int sumWords = 0;
            Console.Write("Введите текст: ");
            string sentence = Console.ReadLine();
            sentence += " ";
            string word = "";
            List<WordAndAmound> lWords = new List<WordAndAmound>();
            foreach (var item in sentence)
            {
                if ((item!=' ') && (item != '.'))
                {
                    word += item;
                }
                else
                {
                    if (word != "")
                        {
                            sumWords++;
                            word.ToLower();
                            bool toBreak = false;
                            for (int i = 0; i < lWords.Count; i++)
                            {
                                if (lWords[i].Word == word)
                                {
                                    lWords[i].incAmout();
                                    toBreak = true;
                                    break;
                                }
                            }
                            if (!toBreak)
                            {
                                lWords.Add(new WordAndAmound(word));
                            }
                            word = "";
                        }    
                }
            }
            Console.WriteLine("Всего слов: {0}", lWords.Count);
            foreach (var item in lWords)
            {
                Console.WriteLine("Слово {0} встречалось {1} раз - {2,3:N0}%", item.Word, item.Amout, ((double)item.Amout / sumWords) * 100);
            }
            Console.ReadKey();
        }
    }
    public class WordAndAmound
    {
        private string word;
        private int amout;
        public string Word
        {
            get { return word; }
        }
        public int Amout
        {
            get { return amout; }
        }
        public void incAmout()
        {
            amout++;
        }
        public WordAndAmound(string word)
        {
            this.word = word;
            amout = 1;
        }
    }
}
