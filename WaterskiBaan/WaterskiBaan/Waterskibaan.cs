using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    class Waterskibaan
    {

        LijnenVoorraad lijnenvoorraad;
        Kabel kabel;
        
        public Waterskibaan()
        {
            lijnenvoorraad = new LijnenVoorraad();
            kabel = new Kabel();

            for (int i = 0; i < 15; i++)
            {
                
                lijnenvoorraad.LijnToevoegenAanRij(new Lijn());
            }
        }
            public void SporterStart(Sporter sp)
        {
            if (sp.Skies == null || sp.Zwemvest == null)
            {
                throw new ArgumentException("Skies en zwemvest verplicht!");
            }
            else
            {          
                if (kabel.IsStartPositieLeeg())
                {

                    Random rand = new Random();
                    Lijn _lijn = lijnenvoorraad.VerwijderEersteLijn();
                    kabel.NeemLijnInGebruik(_lijn);
                    _lijn.Sporter = sp;
                    sp.AantalRondenNogTeGaan = rand.Next(1, 3);
                    sp.KledingKleur = (Color.Blue);
                }
            }
        }
        public void VerplaatsKabel()
        {
            kabel.VerschuifLijnen();
        }

        public override string ToString()
        {
            return $"{lijnenvoorraad.ToString()}  {kabel.ToString()} ";
        }
    }
}
