using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class OperaHauseMateIn2Layout : Layout
    {
        private int[] operaHauseMateIn2 = new int[]
        {
            000, 000, 000, 000, 110, 103, 000, 105,
            101, 000, 000, 102, 000, 101, 101, 101,
            000, 000, 000, 000, 109, 000, 000, 000,
            000, 000, 000, 000, 101, 000, 003, 000,
            000, 000, 000, 000, 001, 000, 000, 000,
            000, 009, 000, 000, 000, 000, 000, 000,
            001, 001, 001, 000, 000, 001, 001, 001,
            000, 000, 010, 005, 000, 000, 000, 000
        };



        public override void Initialize()
        {
            TurnIntoLayout(operaHauseMateIn2);
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
