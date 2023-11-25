using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Node
    {
        private int MaxDepth { get; set; }

        public List<Node> Outcomes = new List<Node>();

        public GameContext Context { get; set; }

        public int Depth { get; set; }

        public int? Value = null;

        public bool EndOfLine = false;

        public Move TheMoveThatMadeThis { get; set; }

        public Move SugestedMove { get; set; }

        public Node(GameContext context, int maxDepth)
        {
            Context = context;
            Context.Evaluate();
            Depth = 0;
            MaxDepth = maxDepth;
            GetNextLevelOfDepth();
            GetEval();
        }

        public Node(GameContext context, Move move, int depth, int maxDepth)
        {
            Context = context.CloneContextWith(move);
            Context.IsGameEnded();
            Context.Evaluate();
            if (Context.GameEnded)
            {
                if (Context.WhiteWon)
                {
                    Value = 10100;
                }
                else if (Context.BlackWon)
                {
                    Value = -10100;
                }
                else
                {
                    Value = 0;
                }
                TheMoveThatMadeThis = move;
            }
            else
            {
                Depth = depth;
                MaxDepth = maxDepth;
                TheMoveThatMadeThis = move;
                if (depth <= MaxDepth)
                {
                    GetNextLevelOfDepth();
                }
            }
        }

        public void GetEval()
        {
            if (this.Value != null)
            {
                return;
            }
            if (this.Context.CurrentColor == PieceColors.White)
            {
                this.Value = int.MinValue;
                foreach (Node nod in Outcomes)
                {
                    if (nod.Value == null)
                    {
                        nod.GetEval();
                    }
                    if (nod.Value > this.Value || (nod.Value == this.Value && nod.Context.Value > this.Context.Value))
                    {
                        this.Value = nod.Value;
                        this.SugestedMove = nod.TheMoveThatMadeThis;
                    }
                }
                this.Value -= 20 * Depth; ;
            }
            else
            {
                this.Value = int.MaxValue;
                foreach (Node nod in Outcomes)
                {
                    if (nod.Value == null)
                    {
                        nod.GetEval();
                    }
                    if (nod.Value < this.Value || (nod.Value == this.Value && nod.Context.Value < this.Context.Value))
                    {
                        this.Value = nod.Value;
                        this.SugestedMove = nod.TheMoveThatMadeThis;
                    }
                }
                this.Value += 20 * Depth;
            }
        }

        public void GetNextLevelOfDepth()
        {
            if (EndOfLine)
            {
                return;
            }

            foreach (Coordinate source in this.Context.CurrentLayout.Keys)
            {
                foreach (Coordinate target in this.Context.CurrentLayout[source].GetAvailableMoves(source, this.Context))
                {
                    this.Outcomes.Add(new Node(this.Context, new Move(source, target), this.Depth + 1, this.MaxDepth));
                }
            }

            if (Outcomes.Count == 0)
            {
                this.Value = this.Context.Value;
                if (Context.CurrentColor == PieceColors.White)
                {
                    this.Value -= this.Depth * 20;
                }
                else
                {
                    this.Value += this.Depth * 20;
                }
            }

            if (this.Depth == MaxDepth)
            {
                foreach (Node nod in this.Outcomes)
                {
                    nod.Context.Evaluate();
                    nod.EndOfLine = true;
                    nod.Value = nod.Context.Value;
                    if (nod.Context.CurrentColor == PieceColors.White)
                    {
                        nod.Value -= nod.Depth * 20;
                    }
                    else
                    {
                        nod.Value += nod.Depth * 20;
                    }
                }
            }
        }

        public override string ToString()
        {
            string result = "";
            if (TheMoveThatMadeThis != null && Context.CurrentLayout.ContainsKey(TheMoveThatMadeThis.Target))
            {
                result += "" + TheMoveThatMadeThis + " - " + Context.CurrentLayout[TheMoveThatMadeThis.Target];
            }

            if (Value != null)
            {
                result += " V: " + Value;
            }

            if (Context != null)
            {
                Context.Evaluate();
                result += " CV: " + Context.Value;
            }

            return result;
        }
    }
}
