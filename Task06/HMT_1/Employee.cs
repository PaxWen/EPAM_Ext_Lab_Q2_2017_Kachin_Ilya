using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_1
{
    /*
     * На основе класса User (см. задание 3 из предыдущей темы), 
     * создать класс Employee, описывающий сотрудника фирмы. 
     * В дополнение к полям пользователя добавить поля «стаж работы» и «должность». 
     * Обеспечить нахождение класса в заведомо корректном состоянии.
     */
    public class Employee : User
    {
        public DateTime WorkExp { get; set; }
        public string Position { get; set; }
        public Employee (string N, string SN, string P, DateTime B,DateTime WE, string Pos):base(N,SN,P,B)
        {
            WorkExp = WE;//todo pn стаж не может быть больше возраста(обрабатывается при вводе)
            Position = Pos;
        }
        public Employee()
        {
        }
    }
}
