using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_4
{
    abstract public class Unit
    {
        private int moveLogic;
        public ObjectCoor Core { get; set; }
        public int HP { get; set; }
        public bool Live { get; set; }
        public int MoveLogic {
            get { return moveLogic; }
            set
            {
                if ((value + 1 > 3) || (value < 0))//todo pn что за магические условия?
                {
                    moveLogic = value;
                }
            }
        }
        public Unit(int x,int y,char gist,string type,int HP)
        {
            Core = new ObjectCoor(x, y, gist, type);
            this.HP = HP;
            Live = true;//todo pn т.е. у тебя в игре на карте трупы будут валяться?)
        }
        public void Move(string MoveOption,string type)
        {
            switch (MoveOption)//todo pn enum
            {
                case "Up":
                    {
                        moveOrInteraction(0, 1, type);//todo pn хардкод, а если мы его решим прокачать и он начнет носиться по карте?
                        break;
                    }
                case "Left":
                    {
                        moveOrInteraction(-1, 0, type);
                        break;
                    }
                case "Down":
                    {
                        moveOrInteraction(0, -1, type);
                        break;
                    }
                case "Right":
                    {
                        moveOrInteraction(1, 0, type);
                        break;
                    }
            }
        }
        abstract public void moveOrInteraction(int biasX, int biasY, string type);//смещение по X,Y, встреченный объект
    }
}
