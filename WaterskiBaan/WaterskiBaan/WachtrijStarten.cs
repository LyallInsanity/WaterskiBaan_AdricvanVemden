using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    class WachtrijStarten : Wachtrij
    {
        public override int MAX_LENGTE_RIJ { get { return 20; }}
        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            foreach (Sporter sporter in args.SportersKlaar)
            {
                SporterNeemPlaatsInRij(sporter);
            }
        }
        public override string ToString()
        {
            return $"Er staan {base.ToString()}  in de start wachtrij";
        }
    }
}
