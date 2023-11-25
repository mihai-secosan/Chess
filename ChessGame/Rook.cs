using System.Collections.Generic;
using System.Drawing;

namespace ChessGame
{
    public class Rook : APiece
    {
        private Bitmap bufferedImage;

        public Rook(PieceColors color) : base(color)
        {
            this.Type = Pieces.Rook;
        }

        //public Pieces type = Pieces.Rook;

        public override Bitmap GetImage()
        {
            if (bufferedImage == null)
            {
                Bitmap image = new Bitmap(60, 60);
                Graphics imageGraphics = Graphics.FromImage(image);

                if (Color == PieceColors.White)
                {
                    Rectangle destinationRectangle = new Rectangle(0, 0, 60, 60);
                    Rectangle sourceRectangle = new Rectangle(120, 60, 60, 60); // Tura alba //

                    imageGraphics.DrawImage(chessPiecesImage, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
                }
                else
                {
                    Rectangle destinationRectangle = new Rectangle(0, 0, 60, 60);
                    Rectangle sourceRectangle = new Rectangle(120, 0, 60, 60); // Tura neagra //

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

            for (int i = sourceCoordinate.Y - 1; i >= 0; i --)
            {
                APiece pieceAtCoordinateFront = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(sourceCoordinate.X, i));
                if (pieceAtCoordinateFront == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X, i));
                }
                else
                {
                    if (pieceAtCoordinateFront.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X, i));
                    }
                    break;
                }

            }

            for (int i = sourceCoordinate.Y + 1; i <= 7; i++)
            {
                APiece pieceAtCoordinateBack = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(sourceCoordinate.X, i));
                if (pieceAtCoordinateBack == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X, i));
                }
                else
                {
                    if (pieceAtCoordinateBack.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X, i));
                    }
                    break;
                }

            }

            for (int i = sourceCoordinate.X - 1; i >= 0; i--)
            {
                APiece pieceAtCoordinateLeft = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(i, sourceCoordinate.Y));
                if (pieceAtCoordinateLeft == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(i, sourceCoordinate.Y));
                }
                else
                {
                    if (pieceAtCoordinateLeft.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(i, sourceCoordinate.Y));
                    }
                    break;
                }

            }

            for (int i = sourceCoordinate.X + 1; i <= 7; i++)
            {
                APiece pieceAtCoordinateRight = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(i, sourceCoordinate.Y));
                if (pieceAtCoordinateRight == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(i, sourceCoordinate.Y));
                }
                else
                {
                    if (pieceAtCoordinateRight.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(i, sourceCoordinate.Y));
                    }
                    break;
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
