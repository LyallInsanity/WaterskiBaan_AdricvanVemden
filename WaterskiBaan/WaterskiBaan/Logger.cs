using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WaterskiBaan
{

    public class Logger
    {
        public List<Sporter> _sporters = new List<Sporter>();
        public Kabel _kabel = new Kabel();
        public int Rodekleding = 0;

        public void VoegToeAanLogger(Sporter sporter)
        {
            _sporters.Add(sporter);
            if (ColorsAreClose(sporter.KledingKleur, Colors.Red))
            {
                Rodekleding++;
            }
        }

        public int TotaalBezoekers()
        {
            return _sporters.Count;
        }

        public int Highscore()
        {
            int hs = 0;
            if (_sporters.Count > 0)
            {
             hs = _sporters.Max(sp => sp.BehaaldePunten);
            }
            return hs;
        }

        public string LichsteKleding()
        {
            List<Sporter> Top10LichsteSporters = new List<Sporter>();
            string top10 = "";
            var lichsteSporters = (from sporter in _sporters orderby LichsteKleur(sporter.KledingKleur) descending select sporter).Take(10);
            Top10LichsteSporters = lichsteSporters.ToList();

            foreach (Sporter sp in Top10LichsteSporters)
            {
                string kleur = sp.KledingKleur.ToString();
                top10 += "\n" + kleur;
            }
            return top10;
        }
        

        public int TotaalRondjes()
        {
            int aantalRondjes = _sporters.Sum(sp => sp.AantalRondenNogTeGaan);
            return aantalRondjes;

        }

        //KRIJG HET NIET WERKEND MET MOVES ALLEEN MET HUIDIGE MOVES
        public string getMoves()
        {
            List<string> HudigeMoves = new List<string>();
            var HuidigeMovesLijst = (from sporter in _sporters where sporter.HuidigeMove != null select sporter.HuidigeMove.ToString()).Distinct();

            HudigeMoves = HuidigeMovesLijst.ToList();
            string moves = String.Join(", ", HudigeMoves);

            return moves;


        }
  
        private bool ColorsAreClose(Color a, Color z, int threshold = 100)
        {
            int r = (int)a.R - z.R,
                g = (int)a.G - z.G,
                b = (int)a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }
        public int LichsteKleur(Color kleur)
        {
            int lichsteKleur = (kleur.R * kleur.R) +(kleur.G * kleur.G) + (kleur.B * kleur.B);
            return lichsteKleur;
        }
    }
}
   

