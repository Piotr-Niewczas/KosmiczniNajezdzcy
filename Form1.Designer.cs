namespace KosmiczniNajeźdźcy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.frameTimer = new System.Windows.Forms.Timer(this.components);
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.pressToStartLabel = new System.Windows.Forms.Label();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.scorePanel = new System.Windows.Forms.Panel();
            this.scoreNr2Label = new System.Windows.Forms.Label();
            this.HiScoreNrLabel = new System.Windows.Forms.Label();
            this.scoreNr1Label = new System.Windows.Forms.Label();
            this.hiScoreLabel = new System.Windows.Forms.Label();
            this.scoreLabel2 = new System.Windows.Forms.Label();
            this.scoreLabel1 = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.greenBottomThingy = new System.Windows.Forms.PictureBox();
            this.lifePictureBox2 = new System.Windows.Forms.PictureBox();
            this.lifePictureBox1 = new System.Windows.Forms.PictureBox();
            this.lifeLabel = new System.Windows.Forms.Label();
            this.creditLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.scorePanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greenBottomThingy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // frameTimer
            // 
            this.frameTimer.Enabled = true;
            this.frameTimer.Interval = 5;
            this.frameTimer.Tick += new System.EventHandler(this.frameTimer_Tick);
            // 
            // logoBox
            // 
            this.logoBox.BackColor = System.Drawing.Color.Black;
            this.logoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoBox.Image = ((System.Drawing.Image)(resources.GetObject("logoBox.Image")));
            this.logoBox.Location = new System.Drawing.Point(0, 76);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(694, 247);
            this.logoBox.TabIndex = 0;
            this.logoBox.TabStop = false;
            // 
            // pressToStartLabel
            // 
            this.pressToStartLabel.BackColor = System.Drawing.Color.Transparent;
            this.pressToStartLabel.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pressToStartLabel.ForeColor = System.Drawing.Color.White;
            this.pressToStartLabel.Location = new System.Drawing.Point(0, 418);
            this.pressToStartLabel.Name = "pressToStartLabel";
            this.pressToStartLabel.Size = new System.Drawing.Size(698, 18);
            this.pressToStartLabel.TabIndex = 1;
            this.pressToStartLabel.Text = "Nacisnij SPACE aby rozpoczac!\r\n";
            this.pressToStartLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameOverLabel.Font = new System.Drawing.Font("Arcade Normal", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameOverLabel.ForeColor = System.Drawing.Color.White;
            this.gameOverLabel.Location = new System.Drawing.Point(0, 326);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(700, 75);
            this.gameOverLabel.TabIndex = 1;
            this.gameOverLabel.Text = "GAME OVER!";
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.gameOverLabel.Visible = false;
            // 
            // scorePanel
            // 
            this.scorePanel.BackColor = System.Drawing.Color.Black;
            this.scorePanel.Controls.Add(this.scoreNr2Label);
            this.scorePanel.Controls.Add(this.HiScoreNrLabel);
            this.scorePanel.Controls.Add(this.scoreNr1Label);
            this.scorePanel.Controls.Add(this.hiScoreLabel);
            this.scorePanel.Controls.Add(this.scoreLabel2);
            this.scorePanel.Controls.Add(this.scoreLabel1);
            this.scorePanel.ForeColor = System.Drawing.Color.Transparent;
            this.scorePanel.Location = new System.Drawing.Point(0, 0);
            this.scorePanel.Name = "scorePanel";
            this.scorePanel.Size = new System.Drawing.Size(700, 70);
            this.scorePanel.TabIndex = 3;
            // 
            // scoreNr2Label
            // 
            this.scoreNr2Label.AutoSize = true;
            this.scoreNr2Label.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreNr2Label.Location = new System.Drawing.Point(551, 45);
            this.scoreNr2Label.Name = "scoreNr2Label";
            this.scoreNr2Label.Size = new System.Drawing.Size(92, 18);
            this.scoreNr2Label.TabIndex = 5;
            this.scoreNr2Label.Text = "0000";
            // 
            // HiScoreNrLabel
            // 
            this.HiScoreNrLabel.AutoSize = true;
            this.HiScoreNrLabel.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HiScoreNrLabel.Location = new System.Drawing.Point(306, 45);
            this.HiScoreNrLabel.Name = "HiScoreNrLabel";
            this.HiScoreNrLabel.Size = new System.Drawing.Size(92, 18);
            this.HiScoreNrLabel.TabIndex = 4;
            this.HiScoreNrLabel.Text = "0000";
            // 
            // scoreNr1Label
            // 
            this.scoreNr1Label.AutoSize = true;
            this.scoreNr1Label.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreNr1Label.Location = new System.Drawing.Point(54, 45);
            this.scoreNr1Label.Name = "scoreNr1Label";
            this.scoreNr1Label.Size = new System.Drawing.Size(92, 18);
            this.scoreNr1Label.TabIndex = 3;
            this.scoreNr1Label.Text = "0000";
            // 
            // hiScoreLabel
            // 
            this.hiScoreLabel.AutoSize = true;
            this.hiScoreLabel.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hiScoreLabel.Location = new System.Drawing.Point(262, 13);
            this.hiScoreLabel.Name = "hiScoreLabel";
            this.hiScoreLabel.Size = new System.Drawing.Size(176, 18);
            this.hiScoreLabel.TabIndex = 2;
            this.hiScoreLabel.Text = "HI-SCORE";
            // 
            // scoreLabel2
            // 
            this.scoreLabel2.AutoSize = true;
            this.scoreLabel2.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel2.Location = new System.Drawing.Point(509, 13);
            this.scoreLabel2.Name = "scoreLabel2";
            this.scoreLabel2.Size = new System.Drawing.Size(176, 18);
            this.scoreLabel2.TabIndex = 1;
            this.scoreLabel2.Text = "SCORE<2>";
            // 
            // scoreLabel1
            // 
            this.scoreLabel1.AutoSize = true;
            this.scoreLabel1.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel1.Location = new System.Drawing.Point(12, 13);
            this.scoreLabel1.Name = "scoreLabel1";
            this.scoreLabel1.Size = new System.Drawing.Size(176, 18);
            this.scoreLabel1.TabIndex = 0;
            this.scoreLabel1.Text = "SCORE<1>";
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.greenBottomThingy);
            this.bottomPanel.Controls.Add(this.lifePictureBox2);
            this.bottomPanel.Controls.Add(this.lifePictureBox1);
            this.bottomPanel.Controls.Add(this.lifeLabel);
            this.bottomPanel.Controls.Add(this.creditLabel);
            this.bottomPanel.Location = new System.Drawing.Point(0, 750);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(700, 50);
            this.bottomPanel.TabIndex = 4;
            // 
            // greenBottomThingy
            // 
            this.greenBottomThingy.BackColor = System.Drawing.Color.Lime;
            this.greenBottomThingy.Location = new System.Drawing.Point(0, 3);
            this.greenBottomThingy.Name = "greenBottomThingy";
            this.greenBottomThingy.Size = new System.Drawing.Size(698, 3);
            this.greenBottomThingy.TabIndex = 0;
            this.greenBottomThingy.TabStop = false;
            // 
            // lifePictureBox2
            // 
            this.lifePictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("lifePictureBox2.Image")));
            this.lifePictureBox2.Location = new System.Drawing.Point(125, 9);
            this.lifePictureBox2.Name = "lifePictureBox2";
            this.lifePictureBox2.Size = new System.Drawing.Size(44, 28);
            this.lifePictureBox2.TabIndex = 3;
            this.lifePictureBox2.TabStop = false;
            // 
            // lifePictureBox1
            // 
            this.lifePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("lifePictureBox1.Image")));
            this.lifePictureBox1.Location = new System.Drawing.Point(75, 9);
            this.lifePictureBox1.Name = "lifePictureBox1";
            this.lifePictureBox1.Size = new System.Drawing.Size(44, 28);
            this.lifePictureBox1.TabIndex = 3;
            this.lifePictureBox1.TabStop = false;
            // 
            // lifeLabel
            // 
            this.lifeLabel.AutoSize = true;
            this.lifeLabel.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lifeLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.lifeLabel.Location = new System.Drawing.Point(27, 17);
            this.lifeLabel.Name = "lifeLabel";
            this.lifeLabel.Size = new System.Drawing.Size(29, 18);
            this.lifeLabel.TabIndex = 2;
            this.lifeLabel.Text = "3";
            // 
            // creditLabel
            // 
            this.creditLabel.AutoSize = true;
            this.creditLabel.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.creditLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.creditLabel.Location = new System.Drawing.Point(456, 17);
            this.creditLabel.Name = "creditLabel";
            this.creditLabel.Size = new System.Drawing.Size(197, 18);
            this.creditLabel.TabIndex = 1;
            this.creditLabel.Text = "CREDIT 00";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(697, 799);
            this.Controls.Add(this.logoBox);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.pressToStartLabel);
            this.Controls.Add(this.scorePanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Kosmiczni Najeźdźcy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.scorePanel.ResumeLayout(false);
            this.scorePanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greenBottomThingy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer frameTimer;
        private PictureBox logoBox;
        private Label pressToStartLabel;
        private Panel scorePanel;
        private Label scoreNr2Label;
        private Label HiScoreNrLabel;
        private Label scoreNr1Label;
        private Label hiScoreLabel;
        private Label scoreLabel2;
        private Label scoreLabel1;
        private Panel bottomPanel;
        private PictureBox greenBottomThingy;
        private Label lifeLabel;
        private Label creditLabel;
        private PictureBox lifePictureBox2;
        private PictureBox lifePictureBox1;
        private Label gameOverLabel;
    }
}