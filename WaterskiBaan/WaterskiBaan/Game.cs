using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace WaterskiBaan
{
    public class Game
    {
   
        private int counter;
        

        public Waterskibaan waterskibaan;
        public InstructieGroep instructieGroep; //5 per keer 
        public WachtrijInstructie wachtrijInstructie; // voor de nieuwe bezoekers
        public WachtrijStarten wachtrijStarten; // voordat ze gaan skien
        public Logger logger;

        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs e);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs e);
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        public delegate void LijnenVerplaatstHandler();
        public event LijnenVerplaatstHandler LijnenVerplaatst;




        public void Initialize(DispatcherTimer timer)
        {
            waterskibaan = new Waterskibaan();
            instructieGroep = new InstructieGroep();
            wachtrijInstructie = new WachtrijInstructie();
            wachtrijStarten = new WachtrijStarten();
            logger = new Logger();

            NieuweBezoeker += OnNieuweBezoeker;
            InstructieAfgelopen += OnInstructieAfgelopen;
            LijnenVerplaatst += OnLijnenVerplaatst;

            timer.Tick += OnTimedEvent;

        }

        private void OnTimedEvent(Object source, EventArgs e)
        {
            counter++;
            Console.WriteLine(waterskibaan.ToString());
            Console.WriteLine(wachtrijInstructie.ToString());
            Console.WriteLine(instructieGroep.ToString());
            Console.WriteLine(wachtrijStarten.ToString());

            if (counter %3 == 0)
            {
                Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());
                NieuweBezoeker?.Invoke(new NieuweBezoekerArgs(sporter));
            }

            if(counter % 20 == 0)
            {
                List<Sporter> sporters = instructieGroep.SportersVerlatenRij(wachtrijInstructie.GetAlleSporters().Count);
                InstructieAfgelopen?.Invoke(new InstructieAfgelopenArgs(sporters));
            }
            if(counter % 4 == 0)
            {
                LijnenVerplaatst?.Invoke();
            }
 

        }
        private void OnNieuweBezoeker(NieuweBezoekerArgs e)
        {
            wachtrijInstructie.SporterNeemPlaatsInRij(e.Sporter);
            logger.VoegToeAanLogger(e.Sporter);

            
        }

        private void OnInstructieAfgelopen(InstructieAfgelopenArgs e)
        {
            if (wachtrijStarten.GetAlleSporters().Count <= 15)
            {
                foreach (Sporter sporter in e.Sporters)
                {
                    wachtrijStarten.SporterNeemPlaatsInRij(sporter);
                }
            }
            if (instructieGroep.GetAlleSporters().Count == 0)
            {
                List<Sporter> sporters = wachtrijInstructie.SportersVerlatenRij(Math.Min(wachtrijInstructie.GetAlleSporters().Count, 5));
                foreach (Sporter sporter in sporters)
                {
                    instructieGroep.SporterNeemPlaatsInRij(sporter);
                }
            }
        }
        private void OnLijnenVerplaatst()
        {
            
            if (waterskibaan.kabel.IsStartPositieLeeg())
            {
                List<Sporter> sporters = wachtrijStarten.SportersVerlatenRij(1);
                if (sporters.Count > 0)
                {
                    Sporter sporter = sporters[0];
                    sporter.Zwemvest = new Zwemvest();
                    sporter.Skies = new Skies();
                    counter++;
                    

                    waterskibaan.SporterStart(sporter);
                }
            }

            waterskibaan.VerplaatsKabel();
            
        }

        public override string ToString()
        {
            return $"{waterskibaan.ToString()}";
        }
    }
}
    
