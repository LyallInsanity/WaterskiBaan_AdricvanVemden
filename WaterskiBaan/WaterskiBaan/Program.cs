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

            TestOpdracht2();
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
            kabel.VerschuifLijnen();
            Console.WriteLine(kabel);
            kabel.VerwijderLijnVanKabel();
            Console.WriteLine(kabel);
        }
    }
}
