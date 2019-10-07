using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    class WachtrijInstructie : Wachtrij
    {
        public override int MAX_LENGTE_RIJ { get { return 100; } }
        public void OnNieuweBezoeker(NieuweBezoekerArgs args)
        {
            SporterNeemPlaatsInRij(args.Sporter);
        }
        public override string ToString()
        {
            return $"Er staan {base.ToString()} in de instructie wachtrij";
        }
    }
}
