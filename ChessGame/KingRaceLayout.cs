using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class KingRaceLayout : Layout
    {
        private int[] kingRace = new int[]
        {
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            109, 105, 103, 102, 002, 003, 005, 009,
            110, 105, 103, 102, 002, 003, 005, 010
        };



        public override void Initialize()
        {
            TurnIntoLayout(kingRace);
        }

        public override Layout Clone()
        {
            CustomPosition clone = new CustomPosition();

            foreach (Coordinate k in this.Keys)
            {
                clone.Add(k, this[k]);
            }

            return clone;
        }

        public override string ToString()
        {
            string printedLayout = string.Empty;

            foreach (Coordinate c in this.Keys)
            {
                printedLayout += "Key: (" + c.X + ", " + c.Y + ") " + "Value: " + this[c] + ", " + this[c].Color + "\n";
            }

            return printedLayout;
        }

    }
}
