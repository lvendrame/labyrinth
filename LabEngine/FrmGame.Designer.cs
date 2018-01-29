namespace LabEngine
{
    partial class FrmGame
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
            this.pcbGame = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGame)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbGame
            // 
            this.pcbGame.BackColor = System.Drawing.Color.Transparent;
            this.pcbGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbGame.Location = new System.Drawing.Point(0, 0);
            this.pcbGame.Name = "pcbGame";
            this.pcbGame.Size = new System.Drawing.Size(690, 514);
            this.pcbGame.TabIndex = 0;
            this.pcbGame.TabStop = false;
            this.pcbGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pcbGame_Paint);
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LabEngine.Properties.Resources.labyrinth;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(690, 514);
            this.Controls.Add(this.pcbGame);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Labirinto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmGame_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pcbGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbGame;

    }
}

