using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_4
{
    public class Enemy : Unit
    {
        public override void moveOrInteraction(int biasX, int biasY, string type)
        {
            if (type == "Space")
            {
                Core.SetPosition(Core.X+biasX,Core.Y+biasY);
            }else
            {
                MoveLogic++;
            }
        }
        public Enemy(int x, int y, char gist, string type, int HP):base(x, y, gist, type, HP)
        {
        }
    }
}
