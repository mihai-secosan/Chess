using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class TinyChessLayout : Layout
    {
        private int[] tinyChess = new int[]
        {
            009, 009, 009, 009, 009, 009, 009, 009,
            001, 001, 001, 001, 001, 001, 001, 001,
            105, 102, 103, 109, 110, 103, 102, 105,
            101, 101, 101, 101, 101, 101, 101, 101,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            001, 001, 001, 001, 001, 001, 001, 001,
            005, 002, 003, 009, 010, 003, 002, 005
        };



        public override void Initialize()
        {
            TurnIntoLayout(tinyChess);
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
