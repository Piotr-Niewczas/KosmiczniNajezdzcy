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
            scoreNr1Label.Text = gc.player1Score.ToString().PadLeft(4, '0');
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.A) 
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0] - 1, gc.vectToMovePlayerBy[1]};
            if (e.KeyData == Keys.D)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0] + 1 , gc.vectToMovePlayerBy[1]};
            if (e.KeyData == Keys.W)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0], gc.vectToMovePlayerBy[1] - 1 };
            if (e.KeyData == Keys.S)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0], gc.vectToMovePlayerBy[1] + 1 };

            if (gc.vectToMovePlayerBy[0] > 1) gc.vectToMovePlayerBy[0] = 1;
            if (gc.vectToMovePlayerBy[0] < -1) gc.vectToMovePlayerBy[0] = -1;
            if (gc.vectToMovePlayerBy[1] > 1) gc.vectToMovePlayerBy[1] = 1;
            if (gc.vectToMovePlayerBy[1] < -1) gc.vectToMovePlayerBy[1] = -1;

            if (e.KeyData == Keys.Space)
                gc.fireButtonHeld = true;

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0] + 1, gc.vectToMovePlayerBy[1] };
            if (e.KeyData == Keys.D)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0] - 1, gc.vectToMovePlayerBy[1] };
            if (e.KeyData == Keys.W)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0], gc.vectToMovePlayerBy[1] + 1 };
            if (e.KeyData == Keys.S)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0], gc.vectToMovePlayerBy[1] - 1 };

            if (gc.vectToMovePlayerBy[0] > 1) gc.vectToMovePlayerBy[0] = 1;
            if (gc.vectToMovePlayerBy[0] < -1) gc.vectToMovePlayerBy[0] = -1;
            if (gc.vectToMovePlayerBy[1] > 1) gc.vectToMovePlayerBy[1] = 1;
            if (gc.vectToMovePlayerBy[1] < -1) gc.vectToMovePlayerBy[1] = -1;

            if (e.KeyData == Keys.Space)
                gc.fireButtonHeld = false;
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