using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class GameContext
    {
        public List<Move> MoveHistory = new List<Move>();

        public Layout CurrentLayout { get; set; }

        public PieceColors CurrentColor { get; set; }

        public int Value { get; set; }

        private Move _lastMovePlayed = null;

        public bool GameEnded = false;
        public bool WhiteWon = false;
        public bool BlackWon = false;
        public bool Draw = false;
        public bool DrawByRepetition = false;

        public Move LastMovePlayed
        {
            get
            { 
                return _lastMovePlayed; 
            }
            set
            {
                _lastMovePlayed = value;
            }
        }

        public GameContext Clone()
        {
            GameContext clone = new GameContext();
            clone.CurrentLayout = this.CurrentLayout.Clone();
            clone.CurrentColor = this.CurrentColor;
            clone.LastMovePlayed = this.LastMovePlayed;
            clone.MoveHistory = this.MoveHistory;

            clone.GameEnded = this.GameEnded;
            clone.WhiteWon = this.WhiteWon;
            clone.BlackWon = this.BlackWon;
            clone.Draw = this.Draw;
            clone.DrawByRepetition = this.DrawByRepetition;

            return clone;
        }

        public GameContext CloneContextWith(Move move)
        {
            GameContext clone = new GameContext();
            clone.MoveHistory = this.MoveHistory;
            clone.CurrentLayout = this.CurrentLayout.Clone();
            clone.CurrentLayout.Move(move);
            clone.LastMovePlayed = move;
            if (this.CurrentColor == PieceColors.White)
            {
                clone.CurrentColor = PieceColors.Black;
            }
            else
            {
                clone.CurrentColor = PieceColors.White;
            }

            return clone;
        }

        public GameContext OtherPlayersTurn()
        {
            GameContext clone = new GameContext();
            clone.CurrentLayout = this.CurrentLayout.Clone();
            clone.LastMovePlayed = this.LastMovePlayed;
            clone.MoveHistory = this.MoveHistory;
            if (this.CurrentColor == PieceColors.White)
            {
                clone.CurrentColor = PieceColors.Black;
            }
            else
            {
                clone.CurrentColor = PieceColors.White;
            }

            return clone;
        }

        public bool IsKingAttacked(PieceColors color)
        {
            foreach (Coordinate c in this.CurrentLayout.Keys)
            {
                if (this.CurrentLayout.ContainsKey(c))
                {
                    foreach (Coordinate coord in this.CurrentLayout[c].GetAvailableMovesWithoutKingCheck(c, this))
                    {
                        if (this.CurrentLayout.ContainsKey(coord) && this.CurrentLayout[coord].Type == Pieces.King && this.CurrentLayout[coord].Color == color)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public void IsGameEnded()
        {
            if (MoveHistory.Count >= 8)
            {
                DrawByRepetition = true;
                for (int i = 1; i <= 4; i++)
                {
                    if (!MoveHistory[MoveHistory.Count - i].Equals(MoveHistory[MoveHistory.Count - i - 4]))
                    {
                        DrawByRepetition = false;
                    }
                }
                if (DrawByRepetition)
                {
                    GameEnded = true;
                    return;
                }
            }

            GameEnded = true;
            foreach (Coordinate c in this.CurrentLayout.Keys)
            {
                if (this.CurrentLayout[c].GetAvailableMoves(c, this).Count > 0)
                {
                    GameEnded = false;
                    return;
                }
            }

            Draw = true;

            if (this.OtherPlayersTurn().IsKingAttacked(this.CurrentColor))
            {
                Draw = false;
                if (this.CurrentColor == PieceColors.Black)
                {
                    WhiteWon = true;
                }
                else
                {
                    BlackWon = true;
                }
            }
        }

        public void Evaluate()
        {
            IsGameEnded();
            if (GameEnded)
            {
                if (WhiteWon)
                {
                    Value = 10100;
                }
                else if (BlackWon)
                {
                    Value = -10100;
                }
                else if (Draw)
                {
                    Value = 0;
                }
                return;
            }

            int kingValue = 10000;
            int queenValue = 950;
            int rookValue = 500;
            int bishopValue = 310;
            int knightValue = 300;
            int pawnValue = 100;

            int controledSquareValue = 0;
            int enemyControledSquareValueBonus = 0;
            int doublePawnsPenalty = 15;
            int yourTurnBonus = 0;
            int safeKingBonus = 120;
            int pawnActivityBonus = 15;
            int knightActivityBonus = 7;
            int bishopActivityBonus = 10;
            int unactivePiecePenalty = 15;

            int unactivePieceCounter = 0;

            int[] whitePawnStructure = new int[] {0, 0, 0, 0, 0, 0, 0, 0};
            int[] blackPawnStructure = whitePawnStructure;

            //float avgDistanceFromTheWhiteKing;
            //float avgDistanceFromTheBlackKing;
            int nrOfWhitePieces = 0;
            int nrOfBlackPieces = 0;
            int totalDistanceFromTheWhiteKing = 0;
            int totalDistanceFromTheBlackKing = 0;
            int whiteKingX = 0;
            int whiteKingY = 0;
            int blackKingX = 0;
            int blackKingY = 0;
            int smallDistanceFromTheKingBonus = 1;
            int materialCount = 0;

            int eval = yourTurnBonus;
            if (this.CurrentColor == PieceColors.Black)
            {
                eval = - yourTurnBonus;
            }

            foreach (Coordinate coord in this.CurrentLayout.Keys)
            {
                if (this.CurrentLayout[coord].Color == PieceColors.White)
                {
                    unactivePieceCounter ++;

                    if (this.CurrentLayout[coord].Type == Pieces.King)
                    {
                        whiteKingX = coord.X;
                        whiteKingY = coord.Y;

                        eval += kingValue;
                        unactivePieceCounter --;
                        if (this.CurrentLayout.Keys.Count >= 12)
                        {
                            if (coord.Y == 7)
                            {
                                eval += safeKingBonus / 3;
                                if (coord.X == 0 || coord.X == 1 || coord.X == 2 || coord.X == 6 || coord.X == 7)
                                {
                                    eval += safeKingBonus;
                                    if (coord.X > 4)
                                    {
                                        eval += 5;
                                    }
                                }
                            }
                        }
                    }
                    else if (this.CurrentLayout[coord].Type == Pieces.Queen)
                    {
                        eval += queenValue;
                        unactivePieceCounter --;
                        materialCount += 9;
                    }
                    else if (this.CurrentLayout[coord].Type == Pieces.Rook)
                    {
                        eval += rookValue;
                        unactivePieceCounter--;
                        materialCount += 5;
                    }
                    else if (this.CurrentLayout[coord].Type == Pieces.Bishop)
                    {
                        eval += bishopValue;
                        if (this.MoveHistory.Count < 12 && coord.X != 0 && coord.X != 7 && coord.Y <= 6)
                        {
                            eval += bishopActivityBonus;
                        }
                        materialCount += 3;
                    }
                    else if (this.CurrentLayout[coord].Type == Pieces.Knight)
                    {
                        eval += knightValue;
                        if (this.MoveHistory.Count < 12 && coord.X != 0 && coord.X != 7 && coord.Y <= 6)
                        {
                            eval += knightActivityBonus;
                            if (coord.Y == 5)
                            {
                                eval += knightActivityBonus;
                            }
                        }
                        materialCount += 3;
                    }
                    else if (this.CurrentLayout[coord].Type == Pieces.Pawn)
                    {
                        eval += pawnValue;
                        if (this.MoveHistory.Count < 25 && coord.X >= 3 && coord.X <= 4)
                        {
                            eval += pawnActivityBonus;
                            if (coord.Y <= 4)
                            {
                                eval += pawnActivityBonus;
                            }
                        }
                        whitePawnStructure[coord.X] ++;
                    }

                    for (int i = 0; i < 8; i ++)
                    {
                        if (whitePawnStructure[i] > 1)
                        {
                            eval -= doublePawnsPenalty * (whitePawnStructure[i] - 1);
                        }
                    }

                    if (CurrentLayout.Keys.Count > 15)
                    {
                        foreach (Coordinate c in this.CurrentLayout[coord].GetAvailableMovesWithoutKingCheck(coord, this))
                        {
                            eval += controledSquareValue;
                            if (c.Y < 4)
                            {
                                eval += enemyControledSquareValueBonus;
                            }
                        }
                        foreach (Coordinate c in this.OtherPlayersTurn().CurrentLayout[coord].GetAvailableMovesWithoutKingCheck(coord, this))
                        {
                            eval += controledSquareValue;
                            if (c.Y < 4)
                            {
                                eval += enemyControledSquareValueBonus;
                            }
                        }
                    }
                }

                if (this.CurrentLayout[coord].Color == PieceColors.Black)
                {
                    unactivePieceCounter --;

                    if (this.CurrentLayout[coord].Type == Pieces.King)
                    {
                        blackKingX = coord.X;
                        blackKingY = coord.Y;

                        eval -= kingValue;
                        unactivePieceCounter++;
                        if (this.CurrentLayout.Keys.Count >= 12)
                        {
                            if (coord.Y == 0)
                            {
                                eval -= safeKingBonus / 3;
                                if (coord.X == 0 || coord.X == 1 || coord.X == 2 || coord.X == 6 || coord.X == 7)
                                {
                                    eval -= safeKingBonus;
                                    if (coord.X > 4)
                                    {
                                        eval -= 5;
                                    }
                                }
                            }
                        }
                    }
                    else if (this.CurrentLayout[coord].Type == Pieces.Queen)
                    {
                        eval -= queenValue;
                        unactivePieceCounter++;
                        materialCount -= 9;
                    }
                    else if (this.CurrentLayout[coord].Type == Pieces.Rook)
                    {
                        eval -= rookValue;
                        unactivePieceCounter++;
                        materialCount -= 5;
                    }
                    else if (this.CurrentLayout[coord].Type == Pieces.Bishop)
                    {
                        eval -= bishopValue;
                        if (this.MoveHistory.Count < 25 && coord.X != 0 && coord.X != 7 && coord.Y >= 1)
                        {
                            eval -= bishopActivityBonus;
                        }
                        materialCount -= 3;
                    }
                    else if (this.CurrentLayout[coord].Type == Pieces.Knight)
                    {
                        eval -= knightValue;
                        if (this.MoveHistory.Count < 25 && coord.X != 0 && coord.X != 7 && coord.Y >= 1)
                        {
                            eval -= knightActivityBonus;
                            if (coord.Y == 2)
                            {
                                eval -= knightActivityBonus;
                            }
                        }
                        materialCount -= 3;
                    }
                    else if (this.CurrentLayout[coord].Type == Pieces.Pawn)
                    {
                        eval -= pawnValue;
                        if (this.MoveHistory.Count < 25 && coord.X >= 3 && coord.X <= 4)
                        {
                            eval -= pawnActivityBonus;
                            if (coord.Y >= 2)
                            {
                                eval -= pawnActivityBonus;
                            }
                        }
                        blackPawnStructure[coord.X]++;
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        if (blackPawnStructure[i] > 1)
                        {
                            eval += doublePawnsPenalty * (blackPawnStructure[i] - 1);
                        }
                    }

                    if (CurrentLayout.Keys.Count > 10)
                    {
                        foreach (Coordinate c in this.CurrentLayout[coord].GetAvailableMovesWithoutKingCheck(coord, this))
                        {
                            eval -= controledSquareValue;
                            if (c.Y >= 4)
                            {
                                eval -= enemyControledSquareValueBonus;
                            }
                        }
                        foreach (Coordinate c in this.OtherPlayersTurn().CurrentLayout[coord].GetAvailableMovesWithoutKingCheck(coord, this))
                        {
                            eval -= controledSquareValue;
                            if (c.Y >= 4)
                            {
                                eval -= enemyControledSquareValueBonus;
                            }
                        }
                    }
                }
            }

            eval -= unactivePieceCounter * unactivePiecePenalty;

            foreach (Coordinate coord in this.CurrentLayout.Keys)
            {
                if (CurrentLayout[coord].Color == PieceColors.White)
                {
                    nrOfWhitePieces++;
                    totalDistanceFromTheBlackKing += Math.Abs(blackKingX - coord.X) + Math.Abs(blackKingY - coord.Y);
                }
                else
                {
                    nrOfBlackPieces++;
                    totalDistanceFromTheWhiteKing += Math.Abs(whiteKingX - coord.X) + Math.Abs(whiteKingY - coord.Y);
                }
            }
            //avgDistanceFromTheWhiteKing = totalDistanceFromTheWhiteKing / nrOfBlackPieces;
            //avgDistanceFromTheBlackKing = totalDistanceFromTheBlackKing / nrOfWhitePieces;

            if (materialCount > 0)
            {
                eval -= smallDistanceFromTheKingBonus * totalDistanceFromTheBlackKing / nrOfWhitePieces;
            }
            else
            {
                eval += smallDistanceFromTheKingBonus * totalDistanceFromTheWhiteKing / nrOfBlackPieces;
            }
            

            this.Value = eval;
        }

    }
}
