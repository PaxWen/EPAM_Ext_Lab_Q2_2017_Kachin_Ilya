using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_4
{
    public enum MoveSet {Right,Up,Left,Down }
    abstract public class Unit
    {
        private MoveSet moveLogic;
        public ObjectCoor Core { get; set; }
        public int Attack { get; set; }
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public bool Live { get; set; }
        public MoveSet MoveLogic {
            get { return moveLogic; }
            set
            {
                 moveLogic = (MoveSet)((int)value % 4);
            }
        }
        public Unit(int x,int y,char gist,TypeObect type,int attack,int maxHP)
        {
            Core = new ObjectCoor(x, y, gist, type);
            MaxHP = maxHP;
            this.HP = maxHP;
            Attack=attack;
            Live = true;//todo pn т.е. у тебя в игре на карте трупы будут валяться?)(будет отчистка по этому критерию )
        }
        public void Move(string MoveOption,TypeObect type)
        {
            const int step = 1;
            switch (MoveOption)//todo pn enum
            {
                case "Up":
                    {
                        moveOrInteraction(0, step, type);//todo pn хардкод, а если мы его решим прокачать и он начнет носиться по карте?
                        break;
                    }
                case "Left":
                    {
                        moveOrInteraction(-step, 0, type);
                        break;
                    }
                case "Down":
                    {
                        moveOrInteraction(0, -step, type);
                        break;
                    }
                case "Right":
                    {
                        moveOrInteraction(step, 0, type);
                        break;
                    }
            }
        }
        abstract public void moveOrInteraction(int biasX, int biasY, TypeObect type,int damage = 0);//смещение по X,Y, встреченный объект
        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP <= 0)
            {
                Live = false;
            }
        }
        public void Heal(int healPoint)
        {
            HP += healPoint;
            if (HP > MaxHP)
            {
                HP = MaxHP;
            }
        }
    }
}
