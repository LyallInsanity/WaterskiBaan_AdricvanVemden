using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WaterskiBaan
{
    class Game
    {
        private Timer timer;
        private int elapsed;

        private Waterskibaan waterskibaan;
        private InstructieGroep instructieGroep;
        private WachtrijInstructie wachtrijInstructie;
        private WachtrijStarten wachtrijStarten;
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        public void Initialize()
        {
            waterskibaan = new Waterskibaan();
            instructieGroep = new InstructieGroep();
            wachtrijInstructie = new WachtrijInstructie();
            wachtrijStarten = new WachtrijStarten();

            NieuweBezoeker += wachtrijInstructie.OnNieuweBezoeker;
            InstructieAfgelopen += instructieGroep.OnInstructieAfgelopen;
            InstructieAfgelopen += wachtrijStarten.OnInstructieAfgelopen;

            SetTimer();

            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();

            timer.Stop();
            timer.Dispose();
        }

        private void SetTimer()
        {
            timer = new Timer(300);
            timer.Elapsed += OnTimedEvent;
            timer.Elapsed += OnNieuweBezoeker;
            timer.Elapsed += OnInstructieAfgelopen;
            timer.Elapsed += OnLijnenVerplaats;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            elapsed++;

            Console.WriteLine(waterskibaan.ToString());
            Console.WriteLine(wachtrijInstructie.ToString());
            Console.WriteLine(instructieGroep.ToString());
            Console.WriteLine(wachtrijStarten.ToString());


        }
        private void OnNieuweBezoeker(object source, ElapsedEventArgs e)
        {
            if (elapsed % 3 == 0)
            {
                Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
                NieuweBezoekerArgs args = new NieuweBezoekerArgs();
                args.Sporter = sporter;

                NieuweBezoeker?.Invoke(args);
            }
        }
        private void OnInstructieAfgelopen(object source, ElapsedEventArgs e)
        {
            if (elapsed % 20 == 0)
            {
                InstructieAfgelopenArgs args = new InstructieAfgelopenArgs();
                args.SportersKlaar = instructieGroep.SportersVerlatenRij(5);
                args.SportersNieuw = wachtrijInstructie.SportersVerlatenRij(5);

                InstructieAfgelopen?.Invoke(args);
            }
        }
        private void OnLijnenVerplaats(object source, ElapsedEventArgs e)
        {
            if (elapsed % 4 == 0)
            {


                waterskibaan.VerplaatsKabel();
                if (wachtrijStarten.GetAlleSporters().Count > 0)
                {

                    Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
                    sporter = wachtrijStarten.SportersVerlatenRij(1)[0];
                    sporter.Skies = new Skies();
                    sporter.Zwemvest = new Zwemvest();

                    waterskibaan.SporterStart(sporter);
                }
            }
            
        }
    }
}
    
