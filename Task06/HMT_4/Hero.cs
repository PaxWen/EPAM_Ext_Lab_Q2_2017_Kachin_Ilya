
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_4
{
    public class Hero:Unit
    {
        public Hero(int x, int y, char gist, TypeObect type,int atk, int HP):base(x, y, gist, type,atk, HP)
        {
        }
        public override void moveOrInteraction(int biasX, int biasY, TypeObect type,int damage = 0)
        {
           switch (type)//todo pn type должен быть enum в этом случае
            {
                case TypeObect.Space:
                    {
                        Core.SetPosition(Core.X + biasX, Core.Y + biasY);
                        break;
                    }
                case TypeObect.Enemy:
                    {
                        Live = false;
                        break;
                    }
                case TypeObect.Bonus:
                    {
                        Core.SetPosition(Core.X + biasX, Core.Y + biasY);
                        HP++;
                        break;
                    }
            }
            
        }
    }
}
