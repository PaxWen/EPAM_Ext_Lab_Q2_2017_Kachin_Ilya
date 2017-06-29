using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_4
{
    public class Enemy : Unit
    {
        public override void moveOrInteraction(int biasX, int biasY, TypeObect type,int damage=0)
        {
            if (type == TypeObect.Space)
            {
                Core.SetPosition(Core.X+biasX,Core.Y+biasY);
            }else
            {
                MoveLogic++;
            }
        }
        public Enemy(int x, int y, char gist, TypeObect type,int atk, int HP):base(x, y, gist, type,atk, HP)
        {
        }
    }
}
