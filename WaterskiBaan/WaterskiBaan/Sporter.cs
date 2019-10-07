using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }
        public int BehaaldePunten { get; set; }

        public Sporter(List<IMoves> moves)
        {
            BehaaldePunten = 0;
           Moves = moves;
         
            foreach(var move in Moves)
            {
                BehaaldePunten += move.Move();
            }
        }
    }
}
