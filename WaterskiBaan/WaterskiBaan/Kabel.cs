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
            if (_lijnen.Count > 0)
            {
                if (_lijnen.First.Value.PositieOpDeKabel != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg() == true)
            {
                _lijnen.AddFirst(lijn);
            }
        }
        public void VerschuifLijnen()
        {
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpDeKabel != 9)
                {
                    lijn.PositieOpDeKabel += 1;
                }
                else
                {
                    lijn.PositieOpDeKabel = 0;
                }
            }
        }
        public Lijn VerwijderLijnVanKabel() {
            if(_lijnen.Last.Value.PositieOpDeKabel == 9)
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
            string value = "";

            if (_lijnen.Count > 0)
            {
                Lijn laatste = _lijnen.Last.Value;
                foreach (Lijn lijn in _lijnen)
                {
                    value += lijn.PositieOpDeKabel.ToString();
                    if (!lijn.Equals(laatste))
                    {
                        value += "|";
                    }
                }
            }

            return value;
        }
    }
}
