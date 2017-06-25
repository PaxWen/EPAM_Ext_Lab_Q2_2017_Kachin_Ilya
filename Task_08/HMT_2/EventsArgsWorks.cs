using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMT_2
{
    public class EventsArgsWorks:EventArgs
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
}
