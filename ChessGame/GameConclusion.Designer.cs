namespace ChessGame
{
    partial class GameConclusion
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
            this.ConclusionText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConclusionText
            // 
            this.ConclusionText.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ConclusionText.Location = new System.Drawing.Point(0, 0);
            this.ConclusionText.Name = "ConclusionText";
            this.ConclusionText.Size = new System.Drawing.Size(384, 211);
            this.ConclusionText.TabIndex = 0;
            this.ConclusionText.Text = "Draw\r\nby stalemate";
            this.ConclusionText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameConclusion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.ConclusionText);
            this.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.MaximumSize = new System.Drawing.Size(400, 250);
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "GameConclusion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Conclusion";
            this.Load += new System.EventHandler(this.GameConclusion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ConclusionText;
    }
}