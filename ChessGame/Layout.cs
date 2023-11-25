using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public abstract class Layout : Dictionary<Coordinate, APiece>
    {
        public abstract void Initialize();

        public APiece GetPieceAtCoordinate(Coordinate targetCoordinate)
        {
            if (this.ContainsKey(targetCoordinate))
            {
                return this[targetCoordinate];
            }
            
            return null;
        }

        public abstract Layout Clone();


        public void Move(Move move)
        {
            if (!this.ContainsKey(move.Source))
            {
                return;
            }

            APiece movedPiece = this[move.Source];

            if (movedPiece.Type == Pieces.Pawn && move.Source.X != move.Target.X && !this.ContainsKey(move.Target)) // EN PASSANT
            {
                this.Remove(Coordinate.GetCoordinate(move.Target.X, move.Source.Y));
                this.Remove(move.Source);
                this.Add(move.Target, movedPiece);
                return;
            }

            if (movedPiece.Type == Pieces.King) // ROCADA
            {
                if (move.Source.X - move.Target.X == 2) // SPRE STANGA
                {
                    this.Remove(move.Source);
                    this.Remove(move.Target);
                    this.Add(move.Target, movedPiece);
                    this.Remove(Coordinate.GetCoordinate(3, move.Source.Y));
                    this.Add(Coordinate.GetCoordinate(3, move.Source.Y), this[Coordinate.GetCoordinate(0, move.Source.Y)]);
                    this.Remove(Coordinate.GetCoordinate(0, move.Source.Y));
                    return;
                }
                if (move.Target.X - move.Source.X == 2) // SPRE DREAPTA
                {
                    this.Remove(move.Source);
                    this.Remove(move.Target);
                    this.Add(move.Target, movedPiece);
                    this.Remove(Coordinate.GetCoordinate(5, move.Source.Y));
                    this.Add(Coordinate.GetCoordinate(5, move.Source.Y), this[Coordinate.GetCoordinate(7, move.Source.Y)]);
                    this.Remove(Coordinate.GetCoordinate(7, move.Source.Y));
                    return;
                }
            }

            this.Remove(move.Source);
            this.Remove(move.Target);

            if (movedPiece.Type == Pieces.Pawn && (move.Target.Y == 0 || move.Target.Y == 7))
            {
                this.Add(move.Target, PieceFactory.GetPiece(Pieces.Queen, movedPiece.Color));
            }
            else
            {
                this.Add(move.Target, movedPiece);
            }
        }

        public void TurnIntoLayout(int[] vector)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (vector[i * 8 + j] != 0)
                    {
                        this.Add(Coordinate.GetCoordinate(j, i), TurnCoordinateIntoPiece(i, j, vector));
                    }
                }
            }
        }

        private APiece TurnCoordinateIntoPiece(int i, int j, int[] vector)
        {
            Pieces type = Pieces.King;
            PieceColors color = PieceColors.White;
            int k = i * 8 + j;

            if (vector[k] > 100)
            {
                color = PieceColors.Black;
            }

            k = vector[k] % 100;

            if (k == 1)
            {
                type = Pieces.Pawn;
            }
            else if (k == 2)
            {
                type = Pieces.Knight;
            }
            else if (k == 3)
            {
                type = Pieces.Bishop;
            }
            else if (k == 5)
            {
                type = Pieces.Rook;
            }
            else if (k == 9)
            {
                type = Pieces.Queen;
            }

            return PieceFactory.GetPiece(type, color);
        }
    }
}
