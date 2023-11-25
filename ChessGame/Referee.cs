using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ChessGame
{
    public class Referee
    {
        public GameContext CurrentContext { get; set; }

        public event GameEventHandler GameContextChanged;

        public delegate void GameEventHandler(object sender, GameEventArgs e);

        private PieceSelectionForm pieceSelectionForm = new PieceSelectionForm();

        private GameConclusion gameConclusion = new GameConclusion();

        public PieceColors? IsSteveTheAIPlaying { get; set; }

        public Referee()
        {
        }

        public void Initialize(ChessGame game, Board board)
        {
            game.GameStarted += Game_GameStarted;
        }

        private void Game_GameStarted(object sender, GameEventArgs e)
        {
            this.CurrentContext = e.Context;

            if (GameContextChanged != null)
                GameContextChanged(this, e);
        }

        public void Board_MoveProposed(object sender, MoveProposedEventArgs e)
        {
            if (IsValid(e.ProposedMove))
            {
                this.CurrentContext.LastMovePlayed = e.ProposedMove;
                this.CurrentContext.MoveHistory.Add(e.ProposedMove);

                Pieces movedPieceType = this.CurrentContext.CurrentLayout[e.ProposedMove.Source].Type;

                this.CurrentContext.CurrentLayout.Move(e.ProposedMove);

                if (IsSteveTheAIPlaying != CurrentContext.CurrentColor && movedPieceType == Pieces.Pawn && (e.ProposedMove.Target.Y == 0 || e.ProposedMove.Target.Y == 7))
                {
                    this.CurrentContext.CurrentLayout.Remove(e.ProposedMove.Target);

                    pieceSelectionForm.SetBounds(0, 0, 400, 100);
                    pieceSelectionForm.Color = this.CurrentContext.CurrentColor;
                    pieceSelectionForm.ShowDialog();

                    this.CurrentContext.CurrentLayout.Add(e.ProposedMove.Target, PieceFactory.GetPiece(pieceSelectionForm.Outcome, this.CurrentContext.CurrentColor));
                }
                
                ChangePlayerTurn();

                this.CurrentContext.IsGameEnded();
                if (this.CurrentContext.GameEnded == true)
                {
                    this.CurrentContext.MoveHistory.Add(e.ProposedMove);

                    if (this.CurrentContext.WhiteWon)
                    {
                        this.gameConclusion.Message = "White won\nby checkmate";
                    }
                    if (this.CurrentContext.BlackWon)
                    {
                        this.gameConclusion.Message = "Black won\nby Checkmate";
                    }
                    if (this.CurrentContext.DrawByRepetition)
                    {
                        this.gameConclusion.Message = "Draw\nby Repetition";
                    }
                    //Thread.Sleep(TimeSpan.FromMilliseconds(1500));
                    gameConclusion.Show();
                }
            }

            GameEventArgs ge = new GameEventArgs();
            ge.Context = CurrentContext.Clone();

            if (GameContextChanged != null)
                GameContextChanged(this, ge);
        }

        public void ChangePlayerTurn()
        {
            if (CurrentContext.CurrentColor == PieceColors.Black)
            {
                CurrentContext.CurrentColor = PieceColors.White;
            }
            else
            {
                CurrentContext.CurrentColor = PieceColors.Black;
            }
        }

        public bool IsValid(Move move)
        {
            if (!this.CurrentContext.CurrentLayout[move.Source].GetAvailableMoves(move.Source, this.CurrentContext).Contains(move.Target))
            {
                return false;
            }

            return true;
        }

    }
}
