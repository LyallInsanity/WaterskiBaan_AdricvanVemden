using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
   public abstract class Wachtrij
    {
       public abstract int MAX_LENGTE_RIJ { get; }
        private Queue<Sporter> wachtrijSporters = new Queue<Sporter>();

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (wachtrijSporters.Count < MAX_LENGTE_RIJ)
            {
                wachtrijSporters.Enqueue(sporter);
            }

        }
            public List<Sporter> GetAlleSporters()
            {
                return wachtrijSporters.ToList();
            }

            public List<Sporter> SportersVerlatenRij(int aantal)
            {
                List<Sporter> verlatenRij = new List<Sporter>();
                while (aantal > 0 && wachtrijSporters.Count > 0)
                {
                verlatenRij.Add(wachtrijSporters.Dequeue());
                    aantal--;
                }

                return verlatenRij;
            }

        public override string ToString()
        {
            return $"{GetAlleSporters().Count} sporters";
        }
    }
}
