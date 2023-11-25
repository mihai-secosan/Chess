using System;
using System.Threading;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class ChessGameForm : Form
    {
        private Board board;
        private ChessGame game;
        private Layout startingLayout;
        private PieceColors? SteveTheAIColor;

        public ChessGameForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (board != null)
            {
                board.RescaleBoard(this.Width, this.Height, this.menuStrip1.Height);
            }
        }

        private void AIwhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AIwhiteToolStripMenuItem.Checked)
            {
                AIblackToolStripMenuItem.Checked = false;
                SteveTheAIColor = PieceColors.White;
                if (game != null)
                {
                    game.Steve.Color = PieceColors.White;
                    game.TheReferee.IsSteveTheAIPlaying = PieceColors.White;
                }
            }
            else
            {
                SteveTheAIColor = null;
                if (game != null)
                {
                    game.Steve.Color = null;
                    game.TheReferee.IsSteveTheAIPlaying = null;
                }
            }
        }

        private void AIblackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AIblackToolStripMenuItem.Checked)
            {
                AIwhiteToolStripMenuItem.Checked = false;
                SteveTheAIColor = PieceColors.Black;
                if (game != null)
                {
                    game.Steve.Color = PieceColors.Black;
                    game.TheReferee.IsSteveTheAIPlaying = PieceColors.Black;
                }
            }
            else
            {
                SteveTheAIColor = null;
                if (game != null)
                {
                    game.Steve.Color = null;
                    game.TheReferee.IsSteveTheAIPlaying = null;
                }
            }
        }

        private void StartANewMatch()
        {
            if (board != null)
            {
                this.Controls.Remove(board);
            }

            startingLayout.Initialize();

            board = new Board();
            this.Controls.Add(board);

            board.RescaleBoard(this.Width, this.Height, this.menuStrip1.Height);

            game = new ChessGame();
            game.SteveTheAIColor = this.SteveTheAIColor;
            game.Initialize(board, startingLayout);
            game.Start();
        }

        private void standardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            startingLayout = new StandardLayout();
            StartANewMatch();
        }

        private void kingRaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startingLayout = new KingRaceLayout();
            StartANewMatch();
        }

        private void tinyChessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startingLayout = new TinyChessLayout();
            StartANewMatch();
        }

        private void inYourFaceMateIn1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startingLayout = new InYourFaceMateIn1Layout();
            StartANewMatch();
        }

        private void operaHouseGameMateIn2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startingLayout = new OperaHauseMateIn2Layout();
            StartANewMatch();
        }

        private void ladderMateIn3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startingLayout = new LadderMateIn3Layout();
            StartANewMatch();
        }

        private void enPassantMateIn4ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            startingLayout = new EnPassantMateIn4Layout();
            StartANewMatch();
        }

        private void hardestMateIn2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startingLayout = new HardestMateIn2Layout();
            StartANewMatch();
        }


        private void customPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startingLayout = new CustomPosition();
            StartANewMatch();
        }

        private void ChessGameForm_Load(object sender, EventArgs e)
        {
            // ACESTA NU ESTE UN EASTER EGG
        }
    }
}
