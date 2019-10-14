using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    public class Kabel
    {

        public LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();

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
            if (_lijnen.Count != 0)
            {
                foreach (Lijn lijn in _lijnen)
                {
                    lijn.PositieOpDeKabel++;
                }
            }
        }
        
        public Lijn VerwijderLijnVanKabel()
        {
          
            if (_lijnen.Count != 0)
            {
                
                Lijn _lijn = _lijnen.Last.Value;
                if (_lijn.PositieOpDeKabel == 10)
                {
                    _lijnen.Remove(_lijn);

                    if (_lijn.Sporter.AantalRondenNogTeGaan > 1)
                    {
                        _lijn.Sporter.AantalRondenNogTeGaan--;
                        _lijn.PositieOpDeKabel = 0;
                        _lijnen.AddFirst(_lijn);
                        return null;
                    }
                    return _lijn;
                }
            }
            
            return null;
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
