using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Coordinate
    {
        
        private int _x = 8;
        private int _y = 8;

        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        private static Dictionary<int, Dictionary<int, Coordinate>> coordinatePool;

        public Coordinate()
        {

        }

        private Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinate GetCoordinate(int x, int y)
        {
            if (coordinatePool is null)
            {
                coordinatePool = new Dictionary<int, Dictionary<int, Coordinate>>();
            }

            if (!coordinatePool.Keys.Contains(x))
            {
                coordinatePool.Add(x, new Dictionary<int, Coordinate>());
            }

            if (!coordinatePool[x].Keys.Contains(y))
            {
                coordinatePool[x].Add(y, new Coordinate(x, y));
            }

            return coordinatePool[x][y];
        }

        public override string ToString()
        {
            return "(" + X + ":" + Y + ")";
        }
    }
}
