using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    class Kabel
    {
        private LinkedList<Lijn> _lijnen;

        public Boolean IsStartPositieLeeg()
        {
            if (_lijnen.First == null)
            {
                return true;
            }
            else
            {
                return false;
            }
         }
        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg() == true)
            {
                _lijnen.AddLast(lijn);
            }
        }
        public void VerschuifLijnen()
        {
            
        }
        public Lijn VerwijderLijnVanKabel() { }
        public override string ToString() { }
    }
}
