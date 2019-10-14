using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WaterskiBaan;

namespace Visual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer DispatcherTimer;
        private readonly Game _Game;
        List<Sporter> wachtrij = new List<Sporter>();
        List<Sporter> InstructieGroep = new List<Sporter>();
        List<Sporter> startWachtrij = new List<Sporter>();
        List<Sporter> sporters = new List<Sporter>();

        public MainWindow()
        {
            InitializeComponent();

            _Game = new Game();

            DispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal)
            {
                Interval = TimeSpan.FromMilliseconds(200)
            };
            DispatcherTimer.Tick += TimerEvent;
            _Game.Initialize(DispatcherTimer);

            
        }
      
        private void TimerEvent(object sender, EventArgs e)
        {
            CanvasNewVisitor.Children.Clear();
            CanvasInstructieGroep.Children.Clear();
            CanvasWachtrijStarten.Children.Clear();
            CanvasWater.Children.Clear();


            wachtrij = _Game.wachtrijInstructie.GetAlleSporters();
            InstructieGroep = _Game.instructieGroep.GetAlleSporters();
            startWachtrij = _Game.wachtrijStarten.GetAlleSporters();

            
           DrawQueueNewVisitor(wachtrij, 1);
           DrawQueueInstructieGroep(InstructieGroep, 1);
           DrawQueueWachtrijStarten(startWachtrij, 1);
           DrawKabelbaan();
           DrawSporter();


           LabelVoorraad.Content = _Game.waterskibaan.lijnenvoorraad.ToString();
           LabelVisitor.Content = _Game.wachtrijInstructie.ToString();
           LabelInstructie.Content = _Game.instructieGroep.ToString();
            
        }

        private void DrawQueueNewVisitor(List<Sporter> queue , double offset)
        {
            int count = 0;
            Double HightOffset = offset;
            double WidthOffset =0;
            foreach (Sporter sporter in queue)
            {
                if(count == 25)
                {
                  count = 0;
                  HightOffset += 22.5;
                }
               
                WidthOffset = 22.5 * count;
                DrawVisitor(sporter, WidthOffset, HightOffset, "visitor");
                count++;
                }

            }

        private void DrawQueueInstructieGroep(List<Sporter> queue, double offset)
        {
            int count = 0;
            Double HightOffset = offset;
            double WidthOffset = 0;

            foreach (Sporter sporter in queue)
            {
                WidthOffset = 22.5 * count;
                DrawVisitor(sporter, WidthOffset, HightOffset, "instructie");
                count++;
            }

        }

        private void DrawQueueWachtrijStarten(List<Sporter> queue, double offset)
        {
            int count = 0;
            Double HightOffset = offset;
            double WidthOffset = 0;

            foreach (Sporter sporter in queue)
            {
                WidthOffset = 22.5 * count;
                DrawVisitor(sporter, WidthOffset, HightOffset, "starten");
                count++;
            }

        }

        private void DrawVisitor(Sporter sporter, double WidthOffset, double HightOffset, string  wachtrij)
        {
            // Making the visitor
            
            Rectangle visitor = new Rectangle();
            visitor.Height = 20;
            visitor.Width = 20;
            SolidColorBrush visotorColor = new SolidColorBrush(sporter.KledingKleur);
            visitor.Fill = visotorColor;


            // drawing the visitor
            Canvas.SetTop(visitor, HightOffset); // place where next visitor is drawn down
            Canvas.SetLeft(visitor, WidthOffset); // place where next visitor is drawn to the right

            if (wachtrij.Contains("visitor"))
            {
                CanvasNewVisitor.Children.Add(visitor);
            }
            if (wachtrij.Contains("instructie"))
            {
                CanvasInstructieGroep.Children.Add(visitor);
            }
            if (wachtrij.Contains("starten"))
            {
                CanvasWachtrijStarten.Children.Add(visitor);
            }
            if (wachtrij.Contains("sporters"))
            {
               CanvasWater.Children.Add(visitor);
            }

        }
        private void DrawKabelbaan()
        {
            CanvasWater.Children.Add(kabelbaan);
            CanvasWater.Children.Add(LabelPlace0);
            CanvasWater.Children.Add(LabelPlace1);
            CanvasWater.Children.Add(LabelPlace2);
            CanvasWater.Children.Add(LabelPlace3);
            CanvasWater.Children.Add(LabelPlace4);
            CanvasWater.Children.Add(LabelPlace5);
            CanvasWater.Children.Add(LabelPlace6);
            CanvasWater.Children.Add(LabelPlace7);
            CanvasWater.Children.Add(LabelPlace8);
            CanvasWater.Children.Add(LabelPlace9);
            CanvasWater.Children.Add(LabelMovePlace0);
            CanvasWater.Children.Add(LabelMovePlace1);
            CanvasWater.Children.Add(LabelMovePlace2);
            CanvasWater.Children.Add(LabelMovePlace3);
            CanvasWater.Children.Add(LabelMovePlace4);
            CanvasWater.Children.Add(LabelMovePlace5);
            CanvasWater.Children.Add(LabelMovePlace6);
            CanvasWater.Children.Add(LabelMovePlace7);
            CanvasWater.Children.Add(LabelMovePlace8);
            CanvasWater.Children.Add(LabelMovePlace9);
        }
       
        private void DrawSporter()
        {
            int positie = 0;
            int a =0;
          
            LinkedList<Lijn> lijnen = _Game.waterskibaan.kabel._lijnen;
            
                foreach (Lijn lijn in lijnen)
                {
                    positie = lijn.PositieOpDeKabel;
                    Sporter sp = lijn.Sporter;
 

                if (positie == 0)
                    {
                    LabelMovePlace0.Content = sp.HuidigeMove;
                    DrawVisitor(sp, 100, 250, "sporters");
                    }
                    if (positie == 1)
                    {
                    LabelMovePlace1.Content = sp.HuidigeMove;
                    DrawVisitor(sp, 100, 125, "sporters");
                    }
                    if (positie == 2)
                    {
                    LabelMovePlace2.Content = sp.HuidigeMove;
                    DrawVisitor(sp, 208, 15, "sporters");
                    }
                    if (positie == 3)
                    {
                    LabelMovePlace3.Content = sp.HuidigeMove;
                    DrawVisitor(sp, 332, 15, "sporters");
                    }
                    if (positie == 4)
                    {
                    LabelMovePlace4.Content = sp.HuidigeMove;
                    DrawVisitor(sp, 446, 125, "sporters");
                    }
                    if (positie == 5)
                    {
                    LabelMovePlace5.Content = sp.HuidigeMove;
                    DrawVisitor(sp, 446, 250, "sporters");
                    }
                    if (positie == 6)
                    {
                    LabelMovePlace6.Content = sp.HuidigeMove;
                    DrawVisitor(sp, 446, 375, "sporters");
                    }
                    if (positie == 7)
                    {
                    LabelMovePlace7.Content = sp.HuidigeMove;
                    DrawVisitor(sp, 332, 482, "sporters");
                    }
                    if (positie == 8)
                    {
                    LabelMovePlace8.Content = sp.HuidigeMove;
                    DrawVisitor(sp, 208, 482, "sporters");
                    }
                    if (positie == 9)
                    {
                    LabelMovePlace9.Content = sp.HuidigeMove;
                    DrawVisitor(sp, 100, 375, "sporters");
                    }
                }
  
 
               
               
            }
        

        private void bt_start_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer.Start();
        }

        private void bt_stop_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer.Stop();
        }
    }
}





