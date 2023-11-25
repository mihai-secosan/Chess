using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class GameConclusion : Form
    {
        public GameConclusion()
        {
            InitializeComponent();
        }

        public string Message = "Draw by stalemate";

        private void GameConclusion_Load(object sender, EventArgs e)
        {
            ConclusionText.Text = Message;
        }
    }
}
