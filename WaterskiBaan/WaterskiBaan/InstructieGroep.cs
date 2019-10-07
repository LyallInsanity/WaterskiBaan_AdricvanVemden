using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    class InstructieGroep : Wachtrij
    {
        public override int MAX_LENGTE_RIJ { get { return 5; } }
        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            foreach (Sporter sporter in args.SportersNieuw)
            {
                SporterNeemPlaatsInRij(sporter);
            }
        }
        public override string ToString()
        {
            return $"Er zitten {base.ToString()}  in de instructie groep";
        }
    }
}
