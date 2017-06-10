using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_4
{
    class Program
    {/*
        Создайте иерархию классов и пропишите ключевые методы для компьютерной игры (без реализации функционала). Суть игры:
1. Игрок может передвигаться по прямоугольному полю размером Width на Height.
2. На поле располагаются бонусы (яблоко, вишня и т.д.), которые игрок может подобрать для поднятия каких-либо характеристик.
3. За игроком охотятся монстры (волки, медведи и т.д.), которые могут передвигаться по карте по какому-либо алгоритму.
4. На поле располагаются препятствия разных типов (камни, деревья и т.д.), которые игрок и монстры должны обходить.
Цель игры – собрать все бонусы и не быть «съеденным» монстрами.
    Иерархия сделана 
    ObjectCore - коориднаты и тип объекта
    Unit - Основа для передвигающихся обхектов (Hero,Enemy)
    Hero - наследуется от Unit реализуеn moveOrInteraction
    Enemy - наследуется от Unit реализуеn moveOrInteraction
        */

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            char[][] Area = new char[][] {"############".ToCharArray(),
                                          "#    b     #".ToCharArray(),
                                          "# h       e#".ToCharArray(),
                                          "# e       e#".ToCharArray(),
                                          "############".ToCharArray()
                                         };
            List<Enemy> Enemys = new List<Enemy>();
            Hero Hero1;
            for (int i = 0; i < Area.Length; i++)
            {
                for (int j = 0; j < Area[i].Length; j++)
                {
                    if (Area[i][j] == 'h')
                    {
                        Hero1 = new Hero(i,j,Area[i][j],"Hero",15);
                    }
                    if (Area[i][j] == 'h')
                    {
                        Enemys.Add(new Enemy(i, j, Area[i][j], "Enemy", 15));
                    }
                }
            }
        }
    }
}
