using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class ChessGame
    {
        public Referee TheReferee { get; set; }

        public Board TheBoard { get; set; }

        public GameContext InitialContext { get; set; }

        public SteveTheAI Steve { get; set; }

        public PieceColors? SteveTheAIColor { get; set; }
        
        public event GameEventHandler GameStarted;

        public delegate void GameEventHandler(object sender, GameEventArgs e);

        public void Initialize(Board board)
        {
            Layout defaultLayout = new StandardLayout();
            defaultLayout.Initialize();

            Initialize(board, defaultLayout);
        }

        public void Initialize(Board board, Layout initialLayout)
        {
            TheBoard = board;

            TheReferee = new Referee();
            TheReferee.Initialize(this, board);

            Steve = new SteveTheAI();
            Steve.Color = SteveTheAIColor;
            TheReferee.IsSteveTheAIPlaying = null;
            if (SteveTheAIColor != null)
            {
                TheReferee.IsSteveTheAIPlaying = SteveTheAIColor;
            }

            TheReferee.GameContextChanged += board.Referee_GameContextChanged;
            TheReferee.GameContextChanged += Steve.Referee_GameContextChanged;

            TheBoard.MoveProposed += TheReferee.Board_MoveProposed;
            Steve.MoveProposed += TheReferee.Board_MoveProposed;

            InitialContext = new GameContext();

            if (initialLayout == null)
            { 
                initialLayout = new StandardLayout();
                initialLayout.Initialize();
            }

            InitialContext.CurrentLayout = initialLayout;
            InitialContext.CurrentColor = PieceColors.White;
        }

        public void Start()
        {
            GameEventArgs e = new GameEventArgs();
            e.Context = InitialContext;

            if (GameStarted != null)
                GameStarted(this, e);
        }

    }
}
