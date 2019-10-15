using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    public class OneHand : IMoves
    {

        public int Move()
        {
            return 10;
        }

        public override string ToString()
        {
            return "One hand";
        }
    }
}
