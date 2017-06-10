using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_1
{
    class Program
    {/*На основе класса User (см. задание 3 из предыдущей темы), 
        создать класс Employee, описывающий сотрудника фирмы. 
        В дополнение к полям пользователя добавить поля «стаж работы» и «должность». 
        Обеспечить нахождение класса в заведомо корректном состоянии.
        */
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            string InputString = "";
            bool ExitBool = true;
            Employee Employee1 = null;
            while (ExitBool)
            {
                Console.Clear();
                if (Employee1 != null)
                {
                    Console.WriteLine("Фамилия: {0}", Employee1.SecondName);
                    Console.WriteLine("Имя: {0}", Employee1.Name);
                    Console.WriteLine("Отчество: {0}", Employee1.Patronymic);
                    Console.WriteLine("Дата рождения: {0:dd/MM/yy}", Employee1.Birthday);
                    Console.WriteLine("Возраст: {0}", Employee1.Age);
                    Console.WriteLine("Стаж работы: {0:yy} года и {0:MM} месяца", Employee1.WorkExp);
                    Console.WriteLine("Должность: {0}", Employee1.Position);
                }
                else
                {
                    Console.WriteLine("Работник не задан");
                }

                Console.WriteLine("Введите нужную вам опцию");
                Console.WriteLine("1: Задать параметры Работника.");
                Console.WriteLine("2: Выход из программы.");
                InputString = Console.ReadLine();
                switch (InputString)
                {
                    case "1":
                        {
                            Employee1 = new Employee();
                            Console.WriteLine("Введите Фамилию: ");
                            Employee1.SecondName = Console.ReadLine();
                            Console.WriteLine("Введите Имя: ");
                            Employee1.Name = Console.ReadLine();
                            Console.WriteLine("Введите Отчество: ");
                            string buf;
                            Employee1.SecondName = Console.ReadLine();
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
                                        Employee1.Birthday = DateTime.Parse(buf);
                                        Employee1.Age = DateTime.Now.Year - Employee1.Birthday.Year;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Введена будущая дата рождения");
                                    }
                                }
                            }
                            Console.WriteLine("Введите стаж(Месяц.Год(ММ.ГГГГ)): ");
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
                                    if (DateTime.Parse(buf).Year < Employee1.Age - 18)
                                    {
                                        Employee1.WorkExp = DateTime.Parse(buf);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Стаж слишком велик");
                                    }
                                }
                            }
                            Console.WriteLine("Введите должность : ");
                            Employee1.Position = Console.ReadLine();
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
