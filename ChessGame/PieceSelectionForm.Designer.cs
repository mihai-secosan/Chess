namespace ChessGame
{
    partial class PieceSelectionForm
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
            this.Queen = new System.Windows.Forms.Button();
            this.Rook = new System.Windows.Forms.Button();
            this.Bishop = new System.Windows.Forms.Button();
            this.Knight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Queen
            // 
            this.Queen.Location = new System.Drawing.Point(0, 0);
            this.Queen.Name = "Queen";
            this.Queen.Size = new System.Drawing.Size(100, 100);
            this.Queen.TabIndex = 0;
            this.Queen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Queen.UseVisualStyleBackColor = true;
            this.Queen.Click += new System.EventHandler(this.Queen_Click);
            // 
            // Rook
            // 
            this.Rook.Location = new System.Drawing.Point(100, 0);
            this.Rook.Name = "Rook";
            this.Rook.Size = new System.Drawing.Size(100, 100);
            this.Rook.TabIndex = 1;
            this.Rook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Rook.UseVisualStyleBackColor = true;
            this.Rook.Click += new System.EventHandler(this.Rook_Click);
            // 
            // Bishop
            // 
            this.Bishop.Location = new System.Drawing.Point(200, 0);
            this.Bishop.Name = "Bishop";
            this.Bishop.Size = new System.Drawing.Size(100, 100);
            this.Bishop.TabIndex = 2;
            this.Bishop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Bishop.UseVisualStyleBackColor = true;
            this.Bishop.Click += new System.EventHandler(this.Bishop_Click);
            // 
            // Knight
            // 
            this.Knight.Location = new System.Drawing.Point(300, 0);
            this.Knight.Name = "Knight";
            this.Knight.Size = new System.Drawing.Size(100, 100);
            this.Knight.TabIndex = 3;
            this.Knight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Knight.UseVisualStyleBackColor = true;
            this.Knight.Click += new System.EventHandler(this.Knight_Click);
            // 
            // PieceSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 100);
            this.Controls.Add(this.Queen);
            this.Controls.Add(this.Knight);
            this.Controls.Add(this.Bishop);
            this.Controls.Add(this.Rook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "PieceSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.PieceSelectionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Queen;
        private System.Windows.Forms.Button Rook;
        private System.Windows.Forms.Button Bishop;
        private System.Windows.Forms.Button Knight;
    }
}