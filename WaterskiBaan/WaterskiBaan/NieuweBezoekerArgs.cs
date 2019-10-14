using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    public class NieuweBezoekerArgs : EventArgs
    {
        public Sporter Sporter { get;}
        public NieuweBezoekerArgs(Sporter sporter)
        {
            Sporter = sporter;
        }
    }
}
