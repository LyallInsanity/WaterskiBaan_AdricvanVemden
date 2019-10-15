using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    public class Turn : IMoves
    {

        public int Move()
        {
            return 20;
        }

        public override string ToString()
        {
            return "Turn";
        }

    }
}
