using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class SteveTheAI
    {

        private GameContext CurrentContext { get; set; }

        public PieceColors? Color { get; set; }

        public event MoveProposedHandler MoveProposed;

        public delegate void MoveProposedHandler(object sender, MoveProposedEventArgs e);

        private Move ProposedMove { get; set; }

        public void Referee_GameContextChanged(object sender, GameEventArgs e)
        {
            this.CurrentContext = e.Context.Clone();
            CurrentContext.IsGameEnded();

            if (!CurrentContext.GameEnded && CurrentContext.CurrentColor == this.Color)
            {
                int depth = 1;

                if (this.CurrentContext.CurrentLayout.Keys.Count <= 22)
                {
                    depth++;
                }
                if (this.CurrentContext.CurrentLayout.Keys.Count <= 4)
                {
                    depth ++;
                }
                if (this.CurrentContext.CurrentLayout.Keys.Count <= 3)
                {
                    //depth++;
                }

                Node node = new Node(this.CurrentContext, depth);
                ProposedMove = node.SugestedMove;

                MoveProposedEventArgs me = new MoveProposedEventArgs();
                me.ProposedMove = ProposedMove;

                if (MoveProposed != null)
                {
                    MoveProposed(this, me);
                }
            }
        }
    }
}
