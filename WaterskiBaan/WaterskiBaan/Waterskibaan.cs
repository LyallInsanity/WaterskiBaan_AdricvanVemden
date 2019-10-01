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
        LijnenVoorraad lijnenvoorraad = new LijnenVoorraad();
        Kabel kabel = new Kabel();
        
        public Waterskibaan()
        {
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
                    kabel.NeemLijnInGebruik(lijnenvoorraad.VerwijderEersteLijn());
                    sp.AantalRondenNogTeGaan = rand.Next(1, 3);
                    sp.KledingKleur = (Color.Blue);
                }
            }
        }
        public void VerplaatsKabel()
        {
            kabel.VerschuifLijnen();
            lijnenvoorraad.LijnToevoegenAanRij(kabel.VerwijderLijnVanKabel());
        }

        public override string ToString()
        {
            return $"{lijnenvoorraad.ToString()} + {kabel.ToString()} ";
        }
    }
}
