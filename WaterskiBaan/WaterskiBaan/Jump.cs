using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
    public class Jump : IMoves
    {
        public int Move()
        {
            return 25;
        }
        
        public override string ToString()
        {
            return "Jump";
        }
    }
}
