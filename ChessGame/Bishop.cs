using System.Collections.Generic;
using System.Drawing;

namespace ChessGame
{
    public class Bishop : APiece
    {
        private Bitmap bufferedImage;

        public Bishop(PieceColors color) : base(color)
        {
            this.Type = Pieces.Bishop;
        }

        //public Pieces type = Pieces.Bishop;

        public override Bitmap GetImage()
        {
            if (bufferedImage == null)
            {
                Bitmap image = new Bitmap(60, 60);
                Graphics imageGraphics = Graphics.FromImage(image);

                if (Color == PieceColors.White)
                {
                    Rectangle destinationRectangle = new Rectangle(0, 0, 60, 60);
                    Rectangle sourceRectangle = new Rectangle(240, 60, 60, 60); // Nebunul alb //

                    imageGraphics.DrawImage(chessPiecesImage, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
                }
                else
                {
                    Rectangle destinationRectangle = new Rectangle(0, 0, 60, 60);
                    Rectangle sourceRectangle = new Rectangle(240, 0, 60, 60); // Nebunul negru //

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

            for (int i = sourceCoordinate.X - 1; i >= 0; i--)
            {
                var tx = i;
                var ty = sourceCoordinate.Y - (sourceCoordinate.X - i);

                if (tx < 0 || tx > 7 || ty < 0 || ty > 7)
                {
                    break;
                }

                APiece pieceAtCoordinateFrontLeft = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(tx, ty));
                if (pieceAtCoordinateFrontLeft == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(tx, ty));
                }
                else
                {
                    if (pieceAtCoordinateFrontLeft.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(tx, ty));
                    }
                    break;
                }
            }

            for (int i = sourceCoordinate.X + 1; i <= 7; i++)
            {
                var tx = i;
                var ty = sourceCoordinate.Y - (i - sourceCoordinate.X);

                if (tx < 0 || tx > 7 || ty < 0 || ty > 7)
                {
                    break;
                }

                APiece pieceAtCoordinateFrontRight = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(tx, ty));
                if (pieceAtCoordinateFrontRight == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(tx, ty));
                }
                else
                {
                    if (pieceAtCoordinateFrontRight.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(tx, ty));
                    }
                    break;
                }
            }

            for (int i = sourceCoordinate.X - 1; i >= 0; i--)
            {
                var tx = i;
                var ty = sourceCoordinate.Y - (i - sourceCoordinate.X);

                if (tx < 0 || tx > 7 || ty < 0 || ty > 7)
                {
                    break;
                }

                APiece pieceAtCoordinateBackLeft = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(tx, ty));
                if (pieceAtCoordinateBackLeft == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(tx, ty));
                }
                else
                {
                    if (pieceAtCoordinateBackLeft.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(tx, ty));
                    }
                    break;
                }
            }

            for (int i = sourceCoordinate.X + 1; i <= 7; i++)
            {
                var tx = i;
                var ty = sourceCoordinate.Y - (sourceCoordinate.X - i);

                if (tx < 0 || tx > 7 || ty < 0 || ty > 7)
                {
                    break;
                }

                APiece pieceAtCoordinateBackRight = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(tx, ty));
                if (pieceAtCoordinateBackRight == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(tx, ty));
                }
                else
                {
                    if (pieceAtCoordinateBackRight.Color != context.CurrentColor)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(tx, ty));
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
