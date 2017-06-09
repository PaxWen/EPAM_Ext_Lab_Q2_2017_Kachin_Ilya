using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_3
{
    class Program
    {
        /*Написать класс User, описывающий человека(Фамилия, Имя, Отчество, Дата рождения, Возраст). 
         * Написать программу, демонстрирующую использование этого класса.
         */
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string InputString = "";
            bool ExitBool = true;
            User User1 = null;
            while (ExitBool)
            {
                Console.Clear();
                if (User1 != null)
                {
                    Console.WriteLine("Фамилия: {0}",User1.SecondName);
                    Console.WriteLine("Имя: {0}", User1.Name);
                    Console.WriteLine("Отчество: {0}", User1.Patronymic);
                    Console.WriteLine("Дата рождения: {0}", User1.Birthday);
                    Console.WriteLine("Возраст: {0}", User1.Age);
                }else
                {
                    Console.WriteLine("User не задан");
                }
                
                Console.WriteLine("Введите нужную вам опцию");
                Console.WriteLine("1: Задать параметры User.");
                Console.WriteLine("2: Выход из программы.");
                InputString = Console.ReadLine();
                switch (InputString)
                {
                    case "1":
                        {
                            User1 = new User();
                            Console.WriteLine("Введите Фамилию: ");
                            User1.SecondName=Console.ReadLine();
                            Console.WriteLine("Введите Имя: ");
                            User1.Name = Console.ReadLine();
                            Console.WriteLine("Введите Отчество: ");
                            string buf;
                            User1.SecondName = Console.ReadLine();
                            Console.WriteLine("Введите дату рождения(День.Месяц.Год): ");
                            for (;;)
                            {
                                buf = Console.ReadLine();
                                DateTime bufAge;
                                if (!DateTime.TryParse(buf, out bufAge))
                                {
                                    Console.WriteLine("Значение введено не правильно");
                                }
                                else
                                {
                                    if (DateTime.Parse(buf) < DateTime.Now)
                                    {
                                        User1.Birthday = DateTime.Parse(buf);
                                        User1.Age = DateTime.Now.Year - User1.Birthday.Year;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Введена будущая дата рождения");
                                    }
                                }
                            }
                            break;
                        }
                    case "2":
                        {
                            ExitBool = false;
                            break;
                        }
                }
            }
        }
    }
}
