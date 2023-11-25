using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class PieceFactory
    {
        public static APiece GetPiece(Pieces type, PieceColors color)
        {
            switch (type)
            {
                case Pieces.Bishop:
                    return new Bishop(color);
                case Pieces.King:
                    return new King(color);
                case Pieces.Knight:
                    return new Knight(color);
                case Pieces.Pawn:
                    return new Pawn(color);
                case Pieces.Queen:
                    return new Queen(color);
                case Pieces.Rook:
                    return new Rook(color);
                default:
                    throw new Exception("Unsupported piece type.");
            }
        }
    }
}
