using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    class Program
    {
        static void Main(string[] args)
        {

            TestOpdracht11();
        }
        private static void TestOpdracht2()
        {
            Kabel kabel = new Kabel();
            Lijn lijn1 = new Lijn();
            Lijn lijn2 = new Lijn();
            Lijn lijn3 = new Lijn();
            kabel.NeemLijnInGebruik(lijn1);
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn2);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            kabel.NeemLijnInGebruik(lijn3);
            kabel.VerschuifLijnen();


            kabel.VerwijderLijnVanKabel();
            Console.WriteLine(kabel);

            kabel.VerschuifLijnen();
            Console.WriteLine(kabel);
            kabel.VerschuifLijnen();
            kabel.VerschuifLijnen();
            Console.WriteLine(kabel);
            kabel.VerschuifLijnen();
            Console.WriteLine(kabel);
            kabel.VerwijderLijnVanKabel();
            Console.WriteLine(kabel);
        }

        private static void TestOpdracht3()
        {
            LijnenVoorraad lijnenvoorraad = new LijnenVoorraad();
            lijnenvoorraad.LijnToevoegenAanRij(new Lijn());
            lijnenvoorraad.LijnToevoegenAanRij(new Lijn());
            lijnenvoorraad.LijnToevoegenAanRij(new Lijn());
            lijnenvoorraad.LijnToevoegenAanRij(new Lijn());
            lijnenvoorraad.LijnToevoegenAanRij(new Lijn());
            lijnenvoorraad.LijnToevoegenAanRij(new Lijn());
            lijnenvoorraad.LijnToevoegenAanRij(new Lijn());
            Console.WriteLine(lijnenvoorraad);
            lijnenvoorraad.VerwijderEersteLijn();
            Console.WriteLine(lijnenvoorraad);
        }

        private static void TestOpdracht8()
        {
            //sporter start zonder skies en zwemvest
            Sporter sp1 = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Waterskibaan waterskib = new Waterskibaan();
            Skies ski = new Skies();
            Zwemvest zwemv = new Zwemvest();
            // Geen zwemvest & skies
            //wski.SporterStart(sp1);
            sp1.Zwemvest = zwemv;
            // Geen skies
            //waterskib.SporterStart(sp1);
            sp1.Skies = ski;
            // Wel zwemvest en skies
            waterskib.SporterStart(sp1);
        }
        private static void TestOpdracht10()
        {
            WachtrijInstructie w = new WachtrijInstructie();
            WachtrijStarten ws = new WachtrijStarten();
            InstructieGroep ig = new InstructieGroep();
            w.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            w.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            w.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            ws.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            ws.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            ws.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            ig.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            ig.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));
            ig.SporterNeemPlaatsInRij(new Sporter(MoveCollection.GetWillekeurigeMoves()));

            Console.WriteLine(w.ToString());
            Console.WriteLine(ws.ToString());
            Console.WriteLine(ig.ToString());

        }
        private static void TestOpdracht11()
        {
            Game game = new Game();
           // game.Initialize();
        }
    }
}
