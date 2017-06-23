using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_4
{
    public class Hero:Unit
    {
        public Hero(int x, int y, char gist, string type, int HP):base(x, y, gist, type, HP)
        {
        }
        public override void moveOrInteraction(int biasX, int biasY, string type)
        {
           switch (type)//todo pn type должен быть enum в этом случае
            {
                case "Space":
                    {
                        Core.SetPosition(Core.X + biasX, Core.Y + biasY);
                        break;
                    }
                case "Enemy":
                    {
                        Live = false;
                        break;
                    }
                case "Bonus":
                    {
                        Core.SetPosition(Core.X + biasX, Core.Y + biasY);
                        HP++;
                        break;
                    }
            }
            
        }
    }
}
