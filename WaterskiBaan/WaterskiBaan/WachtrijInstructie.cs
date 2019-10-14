using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    public class WachtrijInstructie : IWachtrij
    {
        public int MAX_LENGTE_RIJ { get { return 100; } }
        public Queue<Sporter> _wachtrijInstructie = new Queue<Sporter>();

        public List<Sporter> GetAlleSporters()
        {
            return _wachtrijInstructie.ToList();
        }


        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (_wachtrijInstructie.Count < MAX_LENGTE_RIJ)
            {
                _wachtrijInstructie.Enqueue(sporter);
            }
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> verlatenRij = new List<Sporter>();
            while (aantal > 0 && _wachtrijInstructie.Count > 0)
            {
                verlatenRij.Add(_wachtrijInstructie.Dequeue());
                aantal--;
            }

            return verlatenRij;
        }
        public override string ToString()
        {
            return $"Wachtrij insctructie: {GetAlleSporters().Count} sporters";
        }
    }
}
