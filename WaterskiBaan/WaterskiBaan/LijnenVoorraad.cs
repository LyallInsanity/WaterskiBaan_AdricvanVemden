using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    class LijnenVoorraad
    {
        private Queue<Lijn> _lijnen = new Queue<Lijn>();

        public void LijnToevoegenAanRij(Lijn lijn)
        {
            _lijnen.Enqueue(lijn);
        }

        public Lijn VerwijderEersteLijn()
        {
        return (GetAantalLijnen() > 0) ? _lijnen.Dequeue() : null;
            
        }

        public int GetAantalLijnen()
        {
            if (_lijnen != null)
            {
                return _lijnen.Count;
            }

            return 0;
        }

        public override string ToString()
        {
           
            return $"{_lijnen.Count} lijnen op voorraad";
        }
    }
}
