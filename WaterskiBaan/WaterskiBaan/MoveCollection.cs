using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterskiBaan
{
   public static class MoveCollection
    {
        private static List<IMoves> Moves = new List<IMoves>()
        {
            new Jump(),
            new Turn(),
            new OneHand(),
            new OneLeg(),
        };
        public static List<IMoves> GetWillekeurigeMoves()
        {
            List<IMoves> moves = new List<IMoves>();
            var rand = new Random();

            foreach(var move in Moves)
            {
                if (rand.Next(0, 4) == 1)
                {
                    moves.Add(move);
                }
            }

            return moves;
        }
    }
}
