using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabEngine
{
    public partial class FrmGame : Form
    {

        public Game Game { get; set; }

        public FrmGame()
        {
            InitializeComponent();

            this.Game = new Game(this.pcbGame);
            this.Game.Start();
        }

        private void FrmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.Game != null)
            {
                lock (this.Game)
                {
                    this.Game.IsRunning = false;
                }
            }
        }

        private void pcbGame_Paint(object sender, PaintEventArgs e)
        {
            if(this.Game != null && this.Game.CurrentFrame != null)
                e.Graphics.DrawImage(this.Game.CurrentFrame, 0, 0, 690, 514);
        }
    }
}
