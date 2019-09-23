using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; } = 0;
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KleudingKLeur { get; set; }
        public List<IMoves> Moves { get; set; }

        public Sporter(List<IMoves> moves)
        {

        }
    }
}
