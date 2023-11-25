using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class StandardLayout : Layout
    {
        public override void Initialize()
        {
            this.Add(Coordinate.GetCoordinate(3, 0), PieceFactory.GetPiece(Pieces.Queen, PieceColors.Black));
            this.Add(Coordinate.GetCoordinate(3, 7), PieceFactory.GetPiece(Pieces.Queen, PieceColors.White));

            this.Add(Coordinate.GetCoordinate(6, 0), PieceFactory.GetPiece(Pieces.Knight, PieceColors.Black));
            this.Add(Coordinate.GetCoordinate(6, 7), PieceFactory.GetPiece(Pieces.Knight, PieceColors.White));
            this.Add(Coordinate.GetCoordinate(1, 0), PieceFactory.GetPiece(Pieces.Knight, PieceColors.Black));
            this.Add(Coordinate.GetCoordinate(1, 7), PieceFactory.GetPiece(Pieces.Knight, PieceColors.White));

            this.Add(Coordinate.GetCoordinate(7, 0), PieceFactory.GetPiece(Pieces.Rook, PieceColors.Black));
            this.Add(Coordinate.GetCoordinate(7, 7), PieceFactory.GetPiece(Pieces.Rook, PieceColors.White));
            this.Add(Coordinate.GetCoordinate(0, 0), PieceFactory.GetPiece(Pieces.Rook, PieceColors.Black));
            this.Add(Coordinate.GetCoordinate(0, 7), PieceFactory.GetPiece(Pieces.Rook, PieceColors.White));

            this.Add(Coordinate.GetCoordinate(5, 0), PieceFactory.GetPiece(Pieces.Bishop, PieceColors.Black));
            this.Add(Coordinate.GetCoordinate(5, 7), PieceFactory.GetPiece(Pieces.Bishop, PieceColors.White));
            this.Add(Coordinate.GetCoordinate(2, 0), PieceFactory.GetPiece(Pieces.Bishop, PieceColors.Black));
            this.Add(Coordinate.GetCoordinate(2, 7), PieceFactory.GetPiece(Pieces.Bishop, PieceColors.White));

            for (int i = 0; i <= 7; i++)
            {
                this.Add(Coordinate.GetCoordinate(i, 1), PieceFactory.GetPiece(Pieces.Pawn, PieceColors.Black));
                this.Add(Coordinate.GetCoordinate(i, 6), PieceFactory.GetPiece(Pieces.Pawn, PieceColors.White));
            }

            this.Add(Coordinate.GetCoordinate(4, 0), PieceFactory.GetPiece(Pieces.King, PieceColors.Black));
            this.Add(Coordinate.GetCoordinate(4, 7), PieceFactory.GetPiece(Pieces.King, PieceColors.White));
        }

        public override Layout Clone()
        {
            StandardLayout clone = new StandardLayout();

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
