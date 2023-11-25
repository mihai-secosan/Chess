using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace ChessGame
{
    public abstract class APiece
    {
        public Pieces       Type { get; set; }
        public PieceColors  Color { get; set; }

        protected Bitmap chessPiecesImage = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("ChessGame.Resources.ChessPiecesArray.png"));

        public APiece(PieceColors color)
        {
            this.Color = color;
        }

        public abstract Bitmap GetImage();

        public abstract List<Coordinate> GetAvailableMoves(Coordinate sourceCoordinate, GameContext context);

        public abstract List<Coordinate> GetAvailableMovesWithoutKingCheck(Coordinate sourceCoordinate, GameContext context);

        public override string ToString()
        {
            return "" + Type + ":" + Color;
        }
    }
}
