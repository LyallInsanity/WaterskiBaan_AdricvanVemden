using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    class Kabel
    {

        private LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg()
        {
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpDeKabel == 0)
                {
                    return false;
                }
            }

            return true;
        }
        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                _lijnen.AddFirst(lijn);
                lijn.PositieOpDeKabel = 0;
            }
        }
        public void VerschuifLijnen()
        {
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpDeKabel != 9)
                {
                    lijn.PositieOpDeKabel++;
                }
                else
                {

                    lijn.PositieOpDeKabel = 0;
                    lijn.Sporter.AantalRondenNogTeGaan--;

                }
            }
        }
        public Lijn VerwijderLijnVanKabel() {
            if(_lijnen.Last.Value.PositieOpDeKabel == 9 &&  _lijnen.Last.Value.Sporter.AantalRondenNogTeGaan == 1)
            {
                _lijnen.RemoveLast();
                return _lijnen.Last.Value;
            }
            else
            {
                return null;
            }
        }
        public override string ToString()
        {
            string lijnRes = "";
            foreach (Lijn lijn in _lijnen)
            {
                lijnRes += lijn.PositieOpDeKabel + "| ";

            }
            return lijnRes;
        }
    }
}
