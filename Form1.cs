using System.Diagnostics;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace KosmiczniNajeźdźcy
{
    public partial class Form1 : Form
    {
        GameController gc = new GameController();
        bool gameStarted = false;

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
    IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();

        public Form1()
        {
            InitializeComponent();

            //load font from resources
            byte[] fontData = Properties.Resources.ARCADE_N;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.ARCADE_N.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.ARCADE_N.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logoBox.Visible = true;
     
            List<Label> labelsToChangeFont = new List<Label> {pressToStartLabel, scoreLabel1, scoreNr1Label, hiScoreLabel, HiScoreNrLabel, scoreLabel2 , scoreNr2Label, gameOverLabel, lifeLabel, creditLabel };

            foreach (var label in labelsToChangeFont)
            {
                label.Font = new Font(fonts.Families[0], label.Font.Size, FontStyle.Regular);
            }

            InitGame();
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
            scoreNr1Label.Text = gc.player1Score.ToString().PadLeft(4, '0');
            lifeLabel.Text = gc.PlayerLives.ToString();
            HiScoreNrLabel.Text = gc.HighScore.ToString().PadLeft(4, '0');

            if (gc.PlayerLives == 3)
            {
                lifePictureBox2.Visible = true;
                lifePictureBox1.Visible = true;
            }
            if (gc.PlayerLives < 3)
            {
                lifePictureBox2.Visible = false;
            }
            if (gc.PlayerLives < 2)
            {
                lifePictureBox1.Visible = false;
            }

            if (gc.GameOverHappened)
            {
                gameOverLabel.Visible = true;
                pressToStartLabel.Visible = true;
            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A || e.KeyData == Keys.Left) 
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0] - 1, gc.vectToMovePlayerBy[1]};
            if (e.KeyData == Keys.D || e.KeyData == Keys.Right)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0] + 1 , gc.vectToMovePlayerBy[1]};
            if (e.KeyData == Keys.W || e.KeyData == Keys.Up)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0], gc.vectToMovePlayerBy[1] - 1 };
            if (e.KeyData == Keys.S || e.KeyData == Keys.Down)
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
            if (e.KeyData == Keys.A || e.KeyData == Keys.Left)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0] + 1, gc.vectToMovePlayerBy[1] };
            if (e.KeyData == Keys.D || e.KeyData == Keys.Right)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0] - 1, gc.vectToMovePlayerBy[1] };
            if (e.KeyData == Keys.W || e.KeyData == Keys.Up)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0], gc.vectToMovePlayerBy[1] + 1 };
            if (e.KeyData == Keys.S || e.KeyData == Keys.Down)
                gc.vectToMovePlayerBy = new int[] { gc.vectToMovePlayerBy[0], gc.vectToMovePlayerBy[1] - 1 };

            if (gc.vectToMovePlayerBy[0] > 1) gc.vectToMovePlayerBy[0] = 1;
            if (gc.vectToMovePlayerBy[0] < -1) gc.vectToMovePlayerBy[0] = -1;
            if (gc.vectToMovePlayerBy[1] > 1) gc.vectToMovePlayerBy[1] = 1;
            if (gc.vectToMovePlayerBy[1] < -1) gc.vectToMovePlayerBy[1] = -1;

            if (e.KeyData == Keys.Space)
                gc.fireButtonHeld = false;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space) // wait for first space press to init game
            {
                if (gc.GameOverHappened)
                {
                    gc.SaveHighscore();
                    InitGame();
                    GC.Collect();
                }
                if (!gameStarted)
                {
                    StartGame();
                }
                
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gc.SaveHighscore(); // saves highscore when closing app
        }

        private void InitGame()
        {
            gc = new GameController();
            gameStarted = false;
            scorePanel.Visible = false;
            bottomPanel.Visible = false;
            pressToStartLabel.Visible = true;
            gameOverLabel.Visible = false;
        }
        private void StartGame()
        {
            gameOverLabel.Visible = false;
            logoBox.Visible = false;
            pressToStartLabel.Visible = false;
            gc.Start();
            gameStarted = true;
            scorePanel.Enabled = true;
            scorePanel.Visible = true;
            bottomPanel.Visible = true;
            bottomPanel.Enabled = true;
            gc.fireButtonHeld = false;
        }
    }
}