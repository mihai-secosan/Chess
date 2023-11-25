using System.Collections.Generic;
using System.Drawing;

namespace ChessGame
{
    public class Knight : APiece
    {
        private Bitmap bufferedImage;

        public Knight(PieceColors color) : base(color)
        {
            this.Type = Pieces.Knight;
        }

        //public Pieces type = Pieces.Knight;

        public override Bitmap GetImage()
        {
            if (bufferedImage == null)
            {
                Bitmap image = new Bitmap(60, 60);
                Graphics imageGraphics = Graphics.FromImage(image);

                if (Color == PieceColors.White)
                {
                    Rectangle destinationRectangle = new Rectangle(0, 0, 60, 60);
                    Rectangle sourceRectangle = new Rectangle(180, 60, 60, 60); // Calul alb //

                    imageGraphics.DrawImage(chessPiecesImage, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
                }
                else
                {
                    Rectangle destinationRectangle = new Rectangle(0, 0, 60, 60);
                    Rectangle sourceRectangle = new Rectangle(180, 0, 60, 60); // Calul negru //

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

            int x = sourceCoordinate.X - 1; int y = sourceCoordinate.Y - 2;
            APiece pieceAtCoordinateFL = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(x, y));
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                if (pieceAtCoordinateFL == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(x, y));
                }
                else
                {
                    if (pieceAtCoordinateFL.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(x, y));
                    }
                }
            }

            x = sourceCoordinate.X + 1; y = sourceCoordinate.Y - 2;
            APiece pieceAtCoordinateFR = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(x, y));
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                if (pieceAtCoordinateFR == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(x, y));
                }
                else
                {
                    if (pieceAtCoordinateFR.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(x, y));
                    }
                }
            }

            x = sourceCoordinate.X + 2; y = sourceCoordinate.Y - 1;
            APiece pieceAtCoordinateRF = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(x, y));
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                if (pieceAtCoordinateRF == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(x, y));
                }
                else
                {
                    if (pieceAtCoordinateRF.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(x, y));
                    }
                }
            }

            x = sourceCoordinate.X + 2; y = sourceCoordinate.Y + 1;
            APiece pieceAtCoordinateRB = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(x, y));
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                if (pieceAtCoordinateRB == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(x, y));
                }
                else
                {
                    if (pieceAtCoordinateRB.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(x, y));
                    }
                }
            }

            x = sourceCoordinate.X + 1; y = sourceCoordinate.Y + 2;
            APiece pieceAtCoordinateBR = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(x, y));
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                if (pieceAtCoordinateBR == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(x, y));
                }
                else
                {
                    if (pieceAtCoordinateBR.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(x, y));
                    }
                }
            }

            x = sourceCoordinate.X - 1; y = sourceCoordinate.Y + 2;
            APiece pieceAtCoordinateBL = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(x, y));
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                if (pieceAtCoordinateBL == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(x, y));
                }
                else
                {
                    if (pieceAtCoordinateBL.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(x, y));
                    }
                }
            }

            x = sourceCoordinate.X - 2; y = sourceCoordinate.Y + 1;
            APiece pieceAtCoordinateLB = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(x, y));
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                if (pieceAtCoordinateLB == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(x, y));
                }
                else
                {
                    if (pieceAtCoordinateLB.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(x, y));
                    }
                }
            }

            x = sourceCoordinate.X - 2; y = sourceCoordinate.Y - 1;
            APiece pieceAtCoordinateLF = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(x, y));
            if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            {
                if (pieceAtCoordinateLF == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(x, y));
                }
                else
                {
                    if (pieceAtCoordinateLF.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(x, y));
                    }
                }
            }


            return availableMoves;
        }

        public override List<Coordinate> GetAvailableMoves(Coordinate sourceCoordinate, GameContext context)
        {
            List<Coordinate> availableMoves = GetAvailableMovesWithoutKingCheck(sourceCoordinate, context);
            List<Coordinate> legalMoves = new List<Coordinate>();

            foreach (Coordinate c in availableMoves)
            {
                if (!context.CloneContextWith(new Move(sourceCoordinate, c)).IsKingAttacked(this.Color))
                {
                    legalMoves.Add(c);
                }
            }

            return legalMoves;
        }
    }
}
