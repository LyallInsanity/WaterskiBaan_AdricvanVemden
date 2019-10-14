using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    public class WachtrijStarten : IWachtrij
    {
        public int MAX_LENGTE_RIJ { get { return 20; }}
        public Queue<Sporter> _wachtrijStarten = new Queue<Sporter>();

        public List<Sporter> GetAlleSporters()
        {
            return _wachtrijStarten.ToList();
        }


        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (_wachtrijStarten.Count < MAX_LENGTE_RIJ)
            {
                _wachtrijStarten.Enqueue(sporter);
            }
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            var verlatenRij = new List<Sporter>();
            while (aantal > 0 && _wachtrijStarten.Count > 0)
            {
                verlatenRij.Add(_wachtrijStarten.Dequeue());
                aantal--;
            }

            return verlatenRij;
        }



        public override string ToString()
        {
            return $"Wachtrij starten: {GetAlleSporters().Count} sporters";
        }
    }
}
