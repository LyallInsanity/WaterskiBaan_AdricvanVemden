using System;
using System.Collections.Generic;
using System.Windows.Media;


namespace WaterskiBaan
{
    public class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }
        public int BehaaldePunten { get; set; }
        public IMoves HuidigeMove { get; set; }
        Random rand= new Random();
        public Sporter(List<IMoves> moves)
        {
            BehaaldePunten = 0;
            Moves = moves;
            Color clothes = new Color();
            clothes = Color.FromRgb((byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256));
            KledingKleur = clothes;
            AantalRondenNogTeGaan = rand.Next(1, 3);
        }

        public void SetHuidigeMove()
        {
           
            if (rand.Next(0, 4) == 0 && Moves.Count > 0)
            {
                int number = rand.Next(Moves.Count);
                HuidigeMove = Moves[number];
                BehaaldePunten += HuidigeMove.Move();
                return;
            }
            HuidigeMove = null;
        }



        public override string ToString()
        {
            return $"Behaalde punten:{BehaaldePunten}, move: {HuidigeMove}, Kleur:{KledingKleur}";
        }
    }
}
