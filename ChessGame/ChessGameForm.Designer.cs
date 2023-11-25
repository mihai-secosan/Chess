namespace ChessGame
{
    partial class ChessGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessGameForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kingRaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tinyChessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inYourFaceMateIn1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operaHouseGameMateIn2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enPassantMateIn4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enPassantMateIn4ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AIwhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AIblackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.hardestMateIn2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.aiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolStripMenuItem1,
            this.kingRaceToolStripMenuItem,
            this.tinyChessToolStripMenuItem,
            this.inYourFaceMateIn1ToolStripMenuItem,
            this.operaHouseGameMateIn2ToolStripMenuItem,
            this.enPassantMateIn4ToolStripMenuItem,
            this.enPassantMateIn4ToolStripMenuItem1,
            this.hardestMateIn2ToolStripMenuItem,
            this.customPositionToolStripMenuItem});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startToolStripMenuItem.Text = "&Begin";
            // 
            // standardToolStripMenuItem1
            // 
            this.standardToolStripMenuItem1.Name = "standardToolStripMenuItem1";
            this.standardToolStripMenuItem1.Size = new System.Drawing.Size(237, 22);
            this.standardToolStripMenuItem1.Text = "&Standard";
            this.standardToolStripMenuItem1.Click += new System.EventHandler(this.standardToolStripMenuItem1_Click);
            // 
            // kingRaceToolStripMenuItem
            // 
            this.kingRaceToolStripMenuItem.Name = "kingRaceToolStripMenuItem";
            this.kingRaceToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.kingRaceToolStripMenuItem.Text = "&KingRace";
            this.kingRaceToolStripMenuItem.Click += new System.EventHandler(this.kingRaceToolStripMenuItem_Click);
            // 
            // tinyChessToolStripMenuItem
            // 
            this.tinyChessToolStripMenuItem.Name = "tinyChessToolStripMenuItem";
            this.tinyChessToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.tinyChessToolStripMenuItem.Text = "&Tiny Chess";
            this.tinyChessToolStripMenuItem.Click += new System.EventHandler(this.tinyChessToolStripMenuItem_Click);
            // 
            // inYourFaceMateIn1ToolStripMenuItem
            // 
            this.inYourFaceMateIn1ToolStripMenuItem.Name = "inYourFaceMateIn1ToolStripMenuItem";
            this.inYourFaceMateIn1ToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.inYourFaceMateIn1ToolStripMenuItem.Text = "&In your face (Mate in 1)";
            this.inYourFaceMateIn1ToolStripMenuItem.Click += new System.EventHandler(this.inYourFaceMateIn1ToolStripMenuItem_Click);
            // 
            // operaHouseGameMateIn2ToolStripMenuItem
            // 
            this.operaHouseGameMateIn2ToolStripMenuItem.Name = "operaHouseGameMateIn2ToolStripMenuItem";
            this.operaHouseGameMateIn2ToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.operaHouseGameMateIn2ToolStripMenuItem.Text = "&Opera House Game (Mate in 2)";
            this.operaHouseGameMateIn2ToolStripMenuItem.Click += new System.EventHandler(this.operaHouseGameMateIn2ToolStripMenuItem_Click);
            // 
            // enPassantMateIn4ToolStripMenuItem
            // 
            this.enPassantMateIn4ToolStripMenuItem.Name = "enPassantMateIn4ToolStripMenuItem";
            this.enPassantMateIn4ToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.enPassantMateIn4ToolStripMenuItem.Text = "&Ladder (Mate in 2)";
            this.enPassantMateIn4ToolStripMenuItem.Click += new System.EventHandler(this.ladderMateIn3ToolStripMenuItem_Click);
            // 
            // enPassantMateIn4ToolStripMenuItem1
            // 
            this.enPassantMateIn4ToolStripMenuItem1.Name = "enPassantMateIn4ToolStripMenuItem1";
            this.enPassantMateIn4ToolStripMenuItem1.Size = new System.Drawing.Size(237, 22);
            this.enPassantMateIn4ToolStripMenuItem1.Text = "&En Passant (Mate in 2)";
            this.enPassantMateIn4ToolStripMenuItem1.Click += new System.EventHandler(this.enPassantMateIn4ToolStripMenuItem1_Click);
            // 
            // customPositionToolStripMenuItem
            // 
            this.customPositionToolStripMenuItem.Name = "customPositionToolStripMenuItem";
            this.customPositionToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.customPositionToolStripMenuItem.Text = "&Custom Position";
            this.customPositionToolStripMenuItem.Click += new System.EventHandler(this.customPositionToolStripMenuItem_Click);
            // 
            // aiToolStripMenuItem
            // 
            this.aiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AIwhiteToolStripMenuItem,
            this.AIblackToolStripMenuItem});
            this.aiToolStripMenuItem.Name = "aiToolStripMenuItem";
            this.aiToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aiToolStripMenuItem.Text = "Steve AI";
            // 
            // AIwhiteToolStripMenuItem
            // 
            this.AIwhiteToolStripMenuItem.CheckOnClick = true;
            this.AIwhiteToolStripMenuItem.Name = "AIwhiteToolStripMenuItem";
            this.AIwhiteToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.AIwhiteToolStripMenuItem.Text = "White";
            this.AIwhiteToolStripMenuItem.Click += new System.EventHandler(this.AIwhiteToolStripMenuItem_Click);
            // 
            // AIblackToolStripMenuItem
            // 
            this.AIblackToolStripMenuItem.CheckOnClick = true;
            this.AIblackToolStripMenuItem.Name = "AIblackToolStripMenuItem";
            this.AIblackToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.AIblackToolStripMenuItem.Text = "Black";
            this.AIblackToolStripMenuItem.Click += new System.EventHandler(this.AIblackToolStripMenuItem_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // hardestMateIn2ToolStripMenuItem
            // 
            this.hardestMateIn2ToolStripMenuItem.Name = "hardestMateIn2ToolStripMenuItem";
            this.hardestMateIn2ToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.hardestMateIn2ToolStripMenuItem.Text = "Hardest Mate in 2";
            this.hardestMateIn2ToolStripMenuItem.Click += new System.EventHandler(this.hardestMateIn2ToolStripMenuItem_Click);
            // 
            // ChessGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(784, 560);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChessGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess Game";
            this.Load += new System.EventHandler(this.ChessGameForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AIwhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AIblackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kingRaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inYourFaceMateIn1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operaHouseGameMateIn2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tinyChessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enPassantMateIn4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enPassantMateIn4ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customPositionToolStripMenuItem;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ToolStripMenuItem hardestMateIn2ToolStripMenuItem;
    }
}

