﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class CustomPosition : Layout
    {
        private int[] emptyBoard = new int[]
        {
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000
        };

        private int[] QueenEndgame = new int[]
        {
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 110, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 009, 010
        };

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

        private int[] buggedMatch = new int[]
       {
            105, 000, 103, 105, 000, 000, 110, 000,
            101, 101, 000, 000, 000, 000, 101, 101,
            000, 000, 000, 003, 000, 000, 000, 000,
            000, 000, 000, 109, 101, 000, 000, 000,
            000, 000, 000, 000, 002, 000, 000, 000,
            000, 001, 000, 001, 000, 000, 000, 001,
            001, 000, 009, 000, 000, 000, 001, 010,
            005, 000, 000, 000, 000, 000, 000, 005
       };

        private int[] promoteTesting = new int[]
        {
            000, 000, 000, 000, 110, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 001,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            101, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 010, 000, 000, 000
        };

        private int[] operaGame = new int[]
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

        private int[] castels = new int[]
        {
            105, 000, 000, 000, 110, 000, 000, 105,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            001, 000, 000, 000, 000, 000, 000, 001,
            005, 000, 000, 000, 010, 000, 000, 005
        };

        private int[] queenTrap = new int[]
        {
            000, 110, 105, 000, 000, 000, 000, 105,
            000, 101, 101, 102, 109, 101, 101, 000,
            101, 000, 000, 101, 103, 102, 000, 000,
            000, 000, 103, 000, 101, 000, 000, 101,
            000, 000, 000, 000, 001, 000, 000, 000,
            000, 000, 002, 001, 000, 001, 009, 000,
            001, 001, 001, 003, 002, 000, 001, 001,
            000, 010, 000, 005, 000, 003, 000, 005
        };

        private int[] blackHasToPromote = new int[]
        {
            000, 000, 000, 000, 000, 000, 000, 110,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 000,
            101, 105, 000, 000, 000, 000, 000, 000,
            000, 000, 000, 000, 000, 000, 000, 010
        };

        public override void Initialize()
        {
            TurnIntoLayout(QueenEndgame);
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