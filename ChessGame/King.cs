using System.Collections.Generic;
using System.Drawing;

namespace ChessGame
{
    public class King : APiece
    {
        private Bitmap bufferedImage;

        public King(PieceColors color) : base(color)
        {
            this.Type = Pieces.King;
        }

        //public Pieces type = Pieces.King;

        public override Bitmap GetImage()
        {
            if (bufferedImage == null)
            {
                Bitmap image = new Bitmap(60, 60);
                Graphics imageGraphics = Graphics.FromImage(image);

                if (Color == PieceColors.White)
                {
                    Rectangle destinationRectangle = new Rectangle(0, 0, 60, 60);
                    Rectangle sourceRectangle = new Rectangle(60, 60, 60, 60); // Regele alb //

                    imageGraphics.DrawImage(chessPiecesImage, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
                }
                else
                {
                    Rectangle destinationRectangle = new Rectangle(0, 0, 60, 60);
                    Rectangle sourceRectangle = new Rectangle(60, 0, 60, 60); // Regele negru //

                    imageGraphics.DrawImage(chessPiecesImage, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
                }

                bufferedImage = image;
            }

            return bufferedImage;
        }

        public override List<Coordinate> GetAvailableMovesWithoutKingCheck(Coordinate sourceCoordinate, GameContext context)
        {
            PieceColors pieceColor = this.Color;

            List<Coordinate> availableMoves = new List<Coordinate>();

            if (pieceColor != context.CurrentColor)
            {
                return availableMoves;
            }

            APiece pieceAtTargetCoordinate = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(0, 0));
            int Xdif, Ydif;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Xdif = x - sourceCoordinate.X;
                    Ydif = y - sourceCoordinate.Y;
                    if (Xdif >= -1 && Xdif <= 1 && Ydif >= -1 && Ydif <= 1 && (Xdif != 0 || Ydif != 0))
                    {
                        pieceAtTargetCoordinate = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(x, y));
                        if (pieceAtTargetCoordinate == null ||
                            (pieceAtTargetCoordinate != null && pieceAtTargetCoordinate.Color != context.CurrentColor))
                        {
                            availableMoves.Add(Coordinate.GetCoordinate(x, y));
                        }
                    }
                }
            }

            return availableMoves;
        }

        public override List<Coordinate> GetAvailableMoves(Coordinate sourceCoordinate, GameContext context)
        {
            PieceColors pieceColor = this.Color;

            List<Coordinate> availableMoves = GetAvailableMovesWithoutKingCheck(sourceCoordinate, context);
            List<Coordinate> legalMoves = new List<Coordinate>();

            if (pieceColor != context.CurrentColor)
            {
                return legalMoves;
            }

            foreach (Coordinate c in availableMoves)
            {
                if (!context.CloneContextWith(new Move(sourceCoordinate, c)).IsKingAttacked(this.Color))
                {
                    legalMoves.Add(c);
                }
            }

            if (pieceColor == PieceColors.White && sourceCoordinate.Equals(Coordinate.GetCoordinate(4, 7)) && !context.OtherPlayersTurn().IsKingAttacked(pieceColor))
            {
                bool leftRookCanCastel = true;
                bool rightRookCanCastel = true;
                if (!context.CurrentLayout.ContainsKey(Coordinate.GetCoordinate(0, 7)))
                {
                    leftRookCanCastel = false;
                }
                if (!context.CurrentLayout.ContainsKey(Coordinate.GetCoordinate(7, 7)))
                {
                    rightRookCanCastel = false;
                }
                foreach (Move m in context.MoveHistory)
                {
                    if (m.Source.Equals(sourceCoordinate))
                    {
                        return legalMoves;
                    }
                    if (m.Source.Equals(Coordinate.GetCoordinate(0, 7)))
                    {
                        leftRookCanCastel = false;
                    }
                    if (m.Source.Equals(Coordinate.GetCoordinate(7, 7)))
                    {
                        rightRookCanCastel = false;
                    }
                }
                if (leftRookCanCastel)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        if (context.CurrentLayout.ContainsKey(Coordinate.GetCoordinate(i, 7)))
                        {
                            leftRookCanCastel = false;
                        }
                        if (i >= 2 && context.CloneContextWith(new Move(4, 7, i, 7)).IsKingAttacked(pieceColor))
                        {
                            leftRookCanCastel = false;
                        }
                    }
                }
                if (rightRookCanCastel)
                {
                    for (int i = 5; i <= 6; i++)
                    {
                        if (context.CurrentLayout.ContainsKey(Coordinate.GetCoordinate(i, 7)))
                        {
                            rightRookCanCastel = false;
                        }
                        if (context.CloneContextWith(new Move(4, 7, i, 7)).IsKingAttacked(pieceColor))
                        {
                            rightRookCanCastel = false;
                        }
                    }
                }
                if (leftRookCanCastel)
                {
                    legalMoves.Add(Coordinate.GetCoordinate(2, 7));
                }
                if (rightRookCanCastel)
                {
                    legalMoves.Add(Coordinate.GetCoordinate(6, 7));
                }
            }

            if (pieceColor == PieceColors.Black && sourceCoordinate.Equals(Coordinate.GetCoordinate(4, 0)) && !context.OtherPlayersTurn().IsKingAttacked(pieceColor))
            {
                bool leftRookCanCastel = true;
                bool rightRookCanCastel = true;
                if (!context.CurrentLayout.ContainsKey(Coordinate.GetCoordinate(0, 0)))
                {
                    leftRookCanCastel = false;
                }
                if (!context.CurrentLayout.ContainsKey(Coordinate.GetCoordinate(7, 0)))
                {
                    rightRookCanCastel = false;
                }
                foreach (Move m in context.MoveHistory)
                {
                    if (m.Source.Equals(sourceCoordinate))
                    {
                        return legalMoves;
                    }
                    if (m.Source.Equals(Coordinate.GetCoordinate(0, 0)))
                    {
                        leftRookCanCastel = false;
                    }
                    if (m.Source.Equals(Coordinate.GetCoordinate(7, 0)))
                    {
                        rightRookCanCastel = false;
                    }
                }
                if (leftRookCanCastel)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        if (context.CurrentLayout.ContainsKey(Coordinate.GetCoordinate(i, 0)))
                        {
                            leftRookCanCastel = false;
                        }
                        if (i >= 2 && context.CloneContextWith(new Move(4, 0, i, 0)).IsKingAttacked(pieceColor))
                        {
                            leftRookCanCastel = false;
                        }
                    }
                }
                if (rightRookCanCastel)
                {
                    for (int i = 5; i <= 6; i++)
                    {
                        if (context.CurrentLayout.ContainsKey(Coordinate.GetCoordinate(i, 0)))
                        {
                            rightRookCanCastel = false;
                        }
                        if (context.CloneContextWith(new Move(4, 0, i, 0)).IsKingAttacked(pieceColor))
                        {
                            rightRookCanCastel = false;
                        }
                    }
                }
                if (leftRookCanCastel)
                {
                    legalMoves.Add(Coordinate.GetCoordinate(2, 0));
                }
                if (rightRookCanCastel)
                {
                    legalMoves.Add(Coordinate.GetCoordinate(6, 0));
                }
            }

            return legalMoves;
        }
    }
}
