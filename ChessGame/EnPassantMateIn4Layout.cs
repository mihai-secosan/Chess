using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class EnPassantMateIn4Layout : Layout
    {
        private int[] enPassantMateIn1 = new int[]
        {
            000, 000, 000, 000, 003, 000, 110, 105,
            101, 000, 000, 000, 000, 101, 000, 000,
            000, 000, 000, 000, 000, 000, 101, 103,
            000, 000, 003, 101, 000, 000, 000, 000,
            000, 000, 101, 001, 109, 000, 101, 000,
            000, 001, 001, 000, 000, 000, 001, 000,
            001, 000, 000, 010, 000, 001, 000, 000,
            005, 002, 000, 009, 000, 000, 000, 000
        };

        private int[] enPassantMateIn2 = new int[]
        {
            000, 000, 000, 000, 003, 000, 110, 105,
            101, 000, 000, 000, 000, 101, 103, 000,
            000, 000, 000, 000, 000, 000, 101, 000,
            000, 000, 003, 101, 000, 000, 000, 000,
            000, 000, 101, 001, 109, 000, 101, 000,
            000, 001, 001, 000, 000, 000, 001, 000,
            001, 000, 000, 000, 010, 001, 000, 000,
            005, 002, 000, 009, 000, 000, 000, 000
        };

        private int[] enPassantMateIn3 = new int[]
        {
            000, 000, 000, 000, 003, 000, 110, 105,
            101, 000, 000, 000, 000, 101, 103, 000,
            000, 000, 000, 000, 000, 000, 101, 000,
            000, 000, 003, 101, 000, 000, 000, 000,
            000, 000, 101, 001, 000, 000, 101, 000,
            000, 001, 001, 000, 000, 000, 001, 000,
            001, 000, 000, 000, 000, 001, 000, 000,
            005, 002, 000, 009, 000, 010, 000, 109
        };

        private int[] enPassantMateIn4 = new int[]
        {
            000, 000, 000, 000, 003, 000, 110, 105,
            101, 000, 000, 000, 000, 101, 103, 000,
            000, 000, 000, 000, 000, 000, 101, 000,
            000, 000, 003, 101, 000, 000, 000, 109,
            000, 000, 101, 001, 000, 000, 101, 000,
            000, 001, 001, 000, 000, 000, 001, 000,
            001, 000, 000, 000, 000, 001, 000, 000,
            005, 002, 000, 009, 000, 000, 010, 000
        };

        private int[] enPassantMateIn5 = new int[]
        {
            000, 000, 000, 000, 102, 000, 110, 105,
            101, 000, 000, 000, 000, 101, 103, 000,
            000, 000, 003, 000, 000, 000, 101, 000,
            000, 000, 003, 101, 000, 000, 109, 000,
            000, 000, 101, 001, 000, 000, 101, 000,
            000, 001, 001, 000, 000, 000, 001, 000,
            001, 000, 000, 000, 000, 001, 000, 000,
            005, 002, 000, 009, 000, 000, 010, 000
        };

        public override void Initialize()
        {
            TurnIntoLayout(enPassantMateIn2);
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
