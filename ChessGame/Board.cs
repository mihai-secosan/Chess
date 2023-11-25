using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public class Board : Panel
    {
        private int _cellSize = 80;
        private int _mouseOverCellX = 8;
        private int _mouseOverCellY = 8;

        private const int _highlightTickness = 6;

        public int CellSize
        {
            get
            {
                return _cellSize;
            }

            set
            {
                _cellSize = value;
            }
        }

        public int MouseOverCellX
        {
            get
            {
                return _mouseOverCellX;
            }

            private set
            {
                _mouseOverCellX = value;
            }
        }
        public int MouseOverCellY
        {
            get
            {
                return _mouseOverCellY;
            }

            private set
            {
                _mouseOverCellY = value;
            }
        }

        public Coordinate DraggedCoordinate { get; set; }

        public Coordinate TargetCoordinate { get; set; }

        private GameContext CurrentContext { get; set; }

        public event MoveProposedHandler MoveProposed;

        public delegate void MoveProposedHandler(object sender, MoveProposedEventArgs e);

        public Board()
        {
            DoubleBuffered = true;
        }

        public void Referee_GameContextChanged(object sender, GameEventArgs e)
        {
            this.CurrentContext = e.Context.Clone();
            this.Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                var clickedX = e.X / CellSize;
                var clickedY = e.Y / CellSize;

                DraggedCoordinate = Coordinate.GetCoordinate(clickedX, clickedY);
                if (CurrentContext.CurrentLayout.ContainsKey(DraggedCoordinate))
                {

                    APiece selectedPiece = CurrentContext.CurrentLayout[DraggedCoordinate];

                    Bitmap cursorBitmap = new Bitmap(CellSize, CellSize);

                    Graphics cursorGraphics = Graphics.FromImage(cursorBitmap);
                    cursorGraphics.DrawImage(selectedPiece.GetImage(), 0, 0, CellSize, CellSize);

                    Cursor.Current = new Cursor(cursorBitmap.GetHicon());

                    this.CurrentContext.CurrentLayout.Remove(DraggedCoordinate);

                    this.Refresh();
                }
                else
                {
                    DraggedCoordinate = null;
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left && DraggedCoordinate != null)
            {
                var clickedX = e.X / CellSize;
                var clickedY = e.Y / CellSize;

                TargetCoordinate = Coordinate.GetCoordinate(clickedX, clickedY);

                Cursor.Current = Cursors.Default;

                Move proposedMove = new Move();
                proposedMove.Source = DraggedCoordinate;
                proposedMove.Target = TargetCoordinate;

                MoveProposedEventArgs me = new MoveProposedEventArgs();
                me.ProposedMove = proposedMove;

                if (MoveProposed != null)
                {
                    MoveProposed(this, me);
                }

                DraggedCoordinate = null;
                TargetCoordinate = null;

                this.Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap doubleBufferingImage = new Bitmap(CellSize * 8, CellSize * 8);
            Graphics doubleBufferingGraphics = Graphics.FromImage(doubleBufferingImage);

            DrawSquares(doubleBufferingGraphics);

            if (CurrentContext != null && CurrentContext.CurrentLayout != null)
            {
                DrawLayout(doubleBufferingGraphics);
                HeighlightHoveredOverCell(doubleBufferingGraphics);
                DrawAvailableMoves(doubleBufferingGraphics);
            }

            e.Graphics.DrawImage(doubleBufferingImage, 0, 0);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var newX = e.X / CellSize;
            var newY = e.Y / CellSize;

            if ((newX != MouseOverCellX || newY != MouseOverCellY) && CurrentContext != null)
            {
                MouseOverCellX = newX;
                MouseOverCellY = newY;

                if (CurrentContext.CurrentLayout.ContainsKey(Coordinate.GetCoordinate(MouseOverCellX, MouseOverCellY)))
                {
                    this.Refresh();
                }
            }
        }

        private void DrawSquares(Graphics g)
        {
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        g.FillRectangle(System.Drawing.Brushes.LightYellow, CellSize * j, CellSize * i, CellSize, CellSize);
                    }
                    else
                    {
                        g.FillRectangle(System.Drawing.Brushes.SaddleBrown, CellSize * j, CellSize * i, CellSize, CellSize);
                    }
                }
            }
            if (CurrentContext != null && CurrentContext.LastMovePlayed != null)
            {
                int sx = CurrentContext.LastMovePlayed.Source.X;
                int sy = CurrentContext.LastMovePlayed.Source.Y;
                int tx = CurrentContext.LastMovePlayed.Target.X;
                int ty = CurrentContext.LastMovePlayed.Target.Y;
                if ((sx + sy) % 2 == 0)
                {
                    g.FillRectangle(System.Drawing.Brushes.Orchid, CellSize * sx, CellSize * sy, CellSize, CellSize);
                }
                else
                {
                    g.FillRectangle(System.Drawing.Brushes.DarkOrchid, CellSize * sx, CellSize * sy, CellSize, CellSize);
                }

                if ((tx + ty) % 2 == 0)
                {
                    g.FillRectangle(System.Drawing.Brushes.Orchid, CellSize * tx, CellSize * ty, CellSize, CellSize);
                }
                else
                {
                    g.FillRectangle(System.Drawing.Brushes.DarkOrchid, CellSize * tx, CellSize * ty, CellSize, CellSize);
                }
            }
        }

        private void DrawLayout(Graphics g)
        {
            foreach (Coordinate c in CurrentContext.CurrentLayout.Keys)
            {
                g.DrawImage(CurrentContext.CurrentLayout[c].GetImage(), c.X * CellSize, c.Y * CellSize, CellSize, CellSize);
            }
        }

        private void HeighlightHoveredOverCell(Graphics g)
        {
            if (MouseOverCellX >= 0 && MouseOverCellX <= 7 && MouseOverCellY >= 0 && MouseOverCellY <= 7)
            {
                Pen higlightPen = new Pen(Brushes.Red, _highlightTickness);

                g.DrawRectangle(higlightPen, MouseOverCellX * CellSize, MouseOverCellY * CellSize, CellSize, CellSize);
            }
        }

        private void DrawAvailableMoves(Graphics g)
        {
            if (DraggedCoordinate != null)
            {
                return;
            }

            Coordinate sourceCoordinate = Coordinate.GetCoordinate(MouseOverCellX, MouseOverCellY);

            if (CurrentContext.CurrentLayout.ContainsKey(sourceCoordinate))
            {
                APiece piece = CurrentContext.CurrentLayout[sourceCoordinate];

                if (piece != null)
                {
                    List<Coordinate> availableMoves = piece.GetAvailableMoves(sourceCoordinate, CurrentContext);

                    foreach (Coordinate c in availableMoves)
                    {
                        Pen higlightPen = new Pen(Brushes.OrangeRed, _highlightTickness);
                        g.DrawRectangle(higlightPen, c.X * CellSize, c.Y * CellSize, CellSize, CellSize);

                        higlightPen = new Pen(Brushes.Yellow, _highlightTickness - 2);
                        g.DrawRectangle(higlightPen, c.X * CellSize, c.Y * CellSize, CellSize, CellSize);
                    }
                }
            }
        }

        public void RescaleBoard(int windowWidth, int windowHeight, int menuHeight)
        {
            int width = windowWidth - 16;
            int height = windowHeight - menuHeight - 39;

            CellSize = Math.Min(width, height) / 8;

            if (width < height)
            {
                this.SetBounds(0, (height - width) / 2 + menuHeight, CellSize * 8, CellSize * 8);
            }
            else
            {
                this.SetBounds((width - height) / 2, menuHeight, CellSize * 8, CellSize * 8);
            }

            this.Refresh();
        }

    }
}
