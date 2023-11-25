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
    public partial class PieceSelectionForm : Form
    {
        public PieceSelectionForm()
        {
            InitializeComponent();
        }

        public Pieces Outcome;
        public PieceColors Color;

        private void PieceSelectionForm_Load(object sender, EventArgs e)
        {
            Queen.Image = new Queen(Color).GetImage();
            Rook.Image = new Rook(Color).GetImage();
            Bishop.Image = new Bishop(Color).GetImage();
            Knight.Image = new Knight(Color).GetImage();
        }

        private void Queen_Click(object sender, EventArgs e)
        {
            this.Outcome = Pieces.Queen;
            this.DialogResult = DialogResult.OK;
        }

        private void Rook_Click(object sender, EventArgs e)
        {
            this.Outcome = Pieces.Rook;
            this.DialogResult = DialogResult.OK;
        }

        private void Bishop_Click(object sender, EventArgs e)
        {
            this.Outcome = Pieces.Bishop;
            this.DialogResult = DialogResult.OK;
        }

        private void Knight_Click(object sender, EventArgs e)
        {
            this.Outcome = Pieces.Knight;
            this.DialogResult = DialogResult.OK;
        }

        public void RescaleForm(int windowWidth, int windowHeight, int menuHeight)
        {
            int width = windowWidth - 16;
            int height = windowHeight - menuHeight - 39;
            int cellSizeMultiplier = 4;
            int cellSizeDevider = 3;

            int CellSize = Math.Min(width, height) / 8;
            int MenuCellSize = CellSize * cellSizeMultiplier / cellSizeDevider;

            int Xoffset = 4 * CellSize - 2 * MenuCellSize;
            int Yoffset = 3 * CellSize - MenuCellSize / 2;

            if (width < height)
            {
                this.SetBounds(Xoffset, (height - width) / 2 + menuHeight + Yoffset, MenuCellSize * 4, MenuCellSize);
            }
            else
            {
                this.SetBounds((width - height) / 2 + Xoffset, menuHeight + Yoffset, MenuCellSize * 4, MenuCellSize);
            }

            this.Refresh();
        }
    }
}
