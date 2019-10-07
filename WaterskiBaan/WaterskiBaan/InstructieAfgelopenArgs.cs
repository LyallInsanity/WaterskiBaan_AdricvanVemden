using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
     class InstructieAfgelopenArgs : EventArgs
    {
        public List<Sporter> SportersKlaar { get; set; }
        public List<Sporter> SportersNieuw { get; set; }
    }
}
