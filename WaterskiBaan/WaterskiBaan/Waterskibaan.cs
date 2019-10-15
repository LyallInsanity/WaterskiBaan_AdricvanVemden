using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    public class Waterskibaan
    {

        public LijnenVoorraad lijnenvoorraad;
        public Kabel kabel;


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

                    Lijn _lijn = lijnenvoorraad.VerwijderEersteLijn();
                    kabel.NeemLijnInGebruik(_lijn);
                    _lijn.Sporter = sp;
                    
                }
            }
        }
        public void VerplaatsKabel()
        {
            foreach (Lijn lijn in kabel._lijnen)
            {
                lijn.Sporter.SetHuidigeMove();
            }

           kabel.VerschuifLijnen();

           Lijn _lijn = kabel.VerwijderLijnVanKabel();
            if (_lijn != null)
            {
                lijnenvoorraad.LijnToevoegenAanRij(_lijn);
           }
            
        }

        public override string ToString()
        {
            return $"{lijnenvoorraad.ToString()}";
        }
    }
}
