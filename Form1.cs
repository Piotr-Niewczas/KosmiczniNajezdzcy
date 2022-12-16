using System.Diagnostics;

namespace KosmiczniNajeźdźcy
{
    public partial class Form1 : Form
    {
        GameController gc = new GameController();
        bool gameStarted = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startPanel.Visible = true;
            startPanel.Enabled = true;
            scorePanel.Visible = false;
            scorePanel.Enabled = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if(gameStarted )
            {
                gc.Update(e);
            }
           

        }

        private void frameTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.A) 
                gc.vectToMoveBy = new int[] { gc.vectToMoveBy[0] - 1, gc.vectToMoveBy[1]};
            if (e.KeyData == Keys.D)
                gc.vectToMoveBy = new int[] { gc.vectToMoveBy[0] + 1 , gc.vectToMoveBy[1]};
            if (e.KeyData == Keys.W)
                gc.vectToMoveBy = new int[] { gc.vectToMoveBy[0], gc.vectToMoveBy[1] - 1 };
            if (e.KeyData == Keys.S)
                gc.vectToMoveBy = new int[] { gc.vectToMoveBy[0], gc.vectToMoveBy[1] + 1 };

            if (gc.vectToMoveBy[0] > 1) gc.vectToMoveBy[0] = 1;
            if (gc.vectToMoveBy[0] < -1) gc.vectToMoveBy[0] = -1;
            if (gc.vectToMoveBy[1] > 1) gc.vectToMoveBy[1] = 1;
            if (gc.vectToMoveBy[1] < -1) gc.vectToMoveBy[1] = -1;

            if (e.KeyData == Keys.Space)
                gc.isFiring = true;

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
                gc.vectToMoveBy = new int[] { gc.vectToMoveBy[0] + 1, gc.vectToMoveBy[1] };
            if (e.KeyData == Keys.D)
                gc.vectToMoveBy = new int[] { gc.vectToMoveBy[0] - 1, gc.vectToMoveBy[1] };
            if (e.KeyData == Keys.W)
                gc.vectToMoveBy = new int[] { gc.vectToMoveBy[0], gc.vectToMoveBy[1] + 1 };
            if (e.KeyData == Keys.S)
                gc.vectToMoveBy = new int[] { gc.vectToMoveBy[0], gc.vectToMoveBy[1] - 1 };

            if (gc.vectToMoveBy[0] > 1) gc.vectToMoveBy[0] = 1;
            if (gc.vectToMoveBy[0] < -1) gc.vectToMoveBy[0] = -1;
            if (gc.vectToMoveBy[1] > 1) gc.vectToMoveBy[1] = 1;
            if (gc.vectToMoveBy[1] < -1) gc.vectToMoveBy[1] = -1;

            if (e.KeyData == Keys.Space)
                gc.isFiring = false;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space && !gameStarted)
            {
                startPanel.Visible= false;
                startPanel.Enabled = false;
                gc.Start();
                gameStarted = true;
                scorePanel.Enabled = true;
                scorePanel.Visible = true;
                
            }
        }
    }
}