using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    public class InstructieGroep : IWachtrij
    {
        public int MAX_LENGTE_RIJ { get { return 5; } }
        public Queue<Sporter> _wachtrijInstructieGroep = new Queue<Sporter>();
        private WachtrijStarten ws = new WachtrijStarten();

        public List<Sporter> GetAlleSporters()
        {
            return _wachtrijInstructieGroep.ToList();
        }

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (_wachtrijInstructieGroep.Count < MAX_LENGTE_RIJ)
            {
                _wachtrijInstructieGroep.Enqueue(sporter);
            }
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> verlatenRij = new List<Sporter>();
            while (aantal > 0 && _wachtrijInstructieGroep.Count > 0 && ws.GetAlleSporters().Count <= 15)
            {
                verlatenRij.Add(_wachtrijInstructieGroep.Dequeue());
                aantal--;
            }

            return verlatenRij;
        }
            public override string ToString() {

            return $"Instructie groep: {GetAlleSporters().Count} sporters";
        }
    }
}
