using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class HardestMateIn2Layout : Layout
    {
        private int[] hardestM2 = new int[]
        {
            000, 000, 103, 105, 105, 103, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            101, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 009,
            000, 101, 000, 110, 101, 001, 101, 000,
            000, 001, 000, 101, 002, 000, 001, 000,
            000, 000, 000, 010, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000
        };

        public override void Initialize()
        {
            TurnIntoLayout(hardestM2);
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
