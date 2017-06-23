using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_4
{
    public class ObjectCoor//todo pn не очень хорошая реализация логики объект на карте - бонус - монстр - игрок. Лучше бы бонус и монстр тоже были отдельными классами. И в них вынести специфичные только им методы, а не городить всю логику в один moveOrInteraction
	{
        private int x;
        private int y;
        private char gist;
        private string type;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public char Gist { get { return gist; } }
        public string Type { get { return type; } }
        public void SetPosition(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        public ObjectCoor(int x,int y,char gist,string type)
        {
            this.x = x;
            this.y = y;
            this.gist = gist;
            this.type = type;
        }
    }
}
