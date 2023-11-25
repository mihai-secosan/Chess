using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Pawn : APiece
    {
        private Bitmap bufferedImage;

        public Pawn(PieceColors color) : base(color)
        {
            this.Type = Pieces.Pawn;
        }

        //public Pieces type = Pieces.Pawn;

        public override Bitmap GetImage()
        {
            if (bufferedImage == null)
            {
                Bitmap image = new Bitmap(60, 60);
                Graphics imageGraphics = Graphics.FromImage(image);

                if (Color == PieceColors.White)
                {
                    Rectangle destinationRectangle = new Rectangle(0, 0, 60, 60);
                    Rectangle sourceRectangle = new Rectangle(300, 60, 60, 60); // Pionii albi //

                    imageGraphics.DrawImage(chessPiecesImage, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
                }
                else
                {
                    Rectangle destinationRectangle = new Rectangle(0, 0, 60, 60);
                    Rectangle sourceRectangle = new Rectangle(300, 0, 60, 60); // Pionii negrii //

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

            APiece pieceAtCoordinateWhiteFront = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(sourceCoordinate.X, sourceCoordinate.Y - 1));
            APiece pieceAtCoordinateWhiteFLeft = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(sourceCoordinate.X - 1, sourceCoordinate.Y - 1));
            APiece pieceAtCoordinateWhiteFRight = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(sourceCoordinate.X + 1, sourceCoordinate.Y - 1));
            APiece pieceAtCoordinateBlackFront = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(sourceCoordinate.X, sourceCoordinate.Y + 1));
            APiece pieceAtCoordinateBlackFLeft = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(sourceCoordinate.X - 1, sourceCoordinate.Y + 1));
            APiece pieceAtCoordinateBlackFRight = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(sourceCoordinate.X + 1, sourceCoordinate.Y + 1));
            APiece pieceAtCoordinateLeft = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(sourceCoordinate.X - 1, sourceCoordinate.Y));
            APiece pieceAtCoordinateRight = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(sourceCoordinate.X + 1, sourceCoordinate.Y));
            APiece pieceAtTargetCoordinate;


            if (pieceColor != context.CurrentColor)
            {
                return availableMoves;
            }

            if (pieceColor == PieceColors.White)
            {
                if (pieceAtCoordinateWhiteFront == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X, sourceCoordinate.Y - 1));
                    pieceAtTargetCoordinate = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(sourceCoordinate.X, sourceCoordinate.Y - 2));
                    if (sourceCoordinate.Y == 6 && pieceAtTargetCoordinate == null)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X, sourceCoordinate.Y - 2));
                    }
                }

                if (pieceAtCoordinateWhiteFLeft != null && pieceAtCoordinateWhiteFLeft.Color == PieceColors.Black)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X - 1, sourceCoordinate.Y - 1));
                }

                if (pieceAtCoordinateWhiteFRight != null && pieceAtCoordinateWhiteFRight.Color == PieceColors.Black)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X + 1, sourceCoordinate.Y - 1));
                }

                if (sourceCoordinate.Y == 3)
                {
                    if (pieceAtCoordinateLeft != null && pieceAtCoordinateLeft.Type == Pieces.Pawn && pieceAtCoordinateLeft.Color == PieceColors.Black 
                        && context.LastMovePlayed.Source.X == sourceCoordinate.X - 1
                        && context.LastMovePlayed.Source.Y == 1
                        && context.LastMovePlayed.Target.X == sourceCoordinate.X - 1
                        && context.LastMovePlayed.Target.Y == 3)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X - 1, sourceCoordinate.Y - 1));
                    }

                    if (pieceAtCoordinateRight != null && pieceAtCoordinateRight.Type == Pieces.Pawn && pieceAtCoordinateRight.Color == PieceColors.Black
                        && context.LastMovePlayed.Source.X == sourceCoordinate.X + 1
                        && context.LastMovePlayed.Source.Y == 1
                        && context.LastMovePlayed.Target.X == sourceCoordinate.X + 1
                        && context.LastMovePlayed.Target.Y == 3)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X + 1, sourceCoordinate.Y - 1));
                    }
                }
            }
            else
            {
                if (pieceAtCoordinateBlackFront == null)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X, sourceCoordinate.Y + 1));
                    pieceAtTargetCoordinate = context.CurrentLayout.GetPieceAtCoordinate(Coordinate.GetCoordinate(sourceCoordinate.X, sourceCoordinate.Y + 2));
                    if (sourceCoordinate.Y == 1 && pieceAtTargetCoordinate == null)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X, sourceCoordinate.Y + 2));
                    }
                }

                if (pieceAtCoordinateBlackFLeft != null && pieceAtCoordinateBlackFLeft.Color == PieceColors.White)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X - 1, sourceCoordinate.Y + 1));
                }

                if (pieceAtCoordinateBlackFRight != null && pieceAtCoordinateBlackFRight.Color == PieceColors.White)
                {
                    availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X + 1, sourceCoordinate.Y + 1));
                }

                if (sourceCoordinate.Y == 4)
                {
                    if (pieceAtCoordinateLeft != null && pieceAtCoordinateLeft.Type == Pieces.Pawn && pieceAtCoordinateLeft.Color == PieceColors.White
                        && context.LastMovePlayed.Source.X == sourceCoordinate.X - 1
                        && context.LastMovePlayed.Source.Y == 6
                        && context.LastMovePlayed.Target.X == sourceCoordinate.X - 1
                        && context.LastMovePlayed.Target.Y == 4)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X - 1, sourceCoordinate.Y + 1));
                    }

                    if (pieceAtCoordinateRight != null && pieceAtCoordinateRight.Type == Pieces.Pawn && pieceAtCoordinateRight.Color == PieceColors.White
                        && context.LastMovePlayed.Source.X == sourceCoordinate.X + 1
                        && context.LastMovePlayed.Source.Y == 6
                        && context.LastMovePlayed.Target.X == sourceCoordinate.X + 1
                        && context.LastMovePlayed.Target.Y == 4)
                    {
                        availableMoves.Add(Coordinate.GetCoordinate(sourceCoordinate.X + 1, sourceCoordinate.Y + 1));
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
