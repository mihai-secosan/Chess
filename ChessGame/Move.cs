using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Move
    {
        public Move()
        {

        }

        public Move(Coordinate source, Coordinate target)
        {
            Source = source;
            Target = target;
        }
        
        public Move(int sx, int sy, int tx, int ty)
        {
            Source = Coordinate.GetCoordinate(sx, sy);
            Target = Coordinate.GetCoordinate(tx, ty);
        }

        public Move(string move)
        {
            Source = Coordinate.GetCoordinate(move[0] - 'a', 8 - (move[1] - '0'));
            Target = Coordinate.GetCoordinate(move[3] - 'a', 8 - (move[4] - '0'));
        }

        public bool Equals(string move)
        {
            if (Source == Coordinate.GetCoordinate(move[0] - 'a', 8 - (move[1] - '0')) && Target == Coordinate.GetCoordinate(move[3] - 'a', 8 - (move[4] - '0')))
            {
                return true;
            }
            return false;
        }

        public bool Equals(Move move)
        {
            if (Source == move.Source && Target == move.Target)
            {
                return true;
            }
            return false;
        }

        public Coordinate Source { get; set; }

        public Coordinate Target { get; set; }

        public override string ToString()
        {
            return "[" + Source + " - " + Target + "]"; 
        }

    }
}
