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
            this.startLabel = new System.Windows.Forms.Label();
            this.startPanel = new System.Windows.Forms.Panel();
            this.scorePanel = new System.Windows.Forms.Panel();
            this.scoreNr2Label = new System.Windows.Forms.Label();
            this.HiScoreNrLabel = new System.Windows.Forms.Label();
            this.scoreNr1Label = new System.Windows.Forms.Label();
            this.hiScoreLabel = new System.Windows.Forms.Label();
            this.scoreLabel2 = new System.Windows.Forms.Label();
            this.scoreLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.startPanel.SuspendLayout();
            this.scorePanel.SuspendLayout();
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
            this.logoBox.Location = new System.Drawing.Point(3, 3);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(694, 305);
            this.logoBox.TabIndex = 0;
            this.logoBox.TabStop = false;
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.BackColor = System.Drawing.Color.Transparent;
            this.startLabel.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startLabel.ForeColor = System.Drawing.Color.White;
            this.startLabel.Location = new System.Drawing.Point(46, 330);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(617, 18);
            this.startLabel.TabIndex = 1;
            this.startLabel.Text = "Nacisnij SPACE aby rozpoczac!\r\n";
            // 
            // startPanel
            // 
            this.startPanel.Controls.Add(this.startLabel);
            this.startPanel.Controls.Add(this.logoBox);
            this.startPanel.Location = new System.Drawing.Point(0, 76);
            this.startPanel.Name = "startPanel";
            this.startPanel.Size = new System.Drawing.Size(700, 631);
            this.startPanel.TabIndex = 2;
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
            this.scoreNr2Label.Location = new System.Drawing.Point(509, 41);
            this.scoreNr2Label.Name = "scoreNr2Label";
            this.scoreNr2Label.Size = new System.Drawing.Size(92, 18);
            this.scoreNr2Label.TabIndex = 5;
            this.scoreNr2Label.Text = "0000";
            // 
            // HiScoreNrLabel
            // 
            this.HiScoreNrLabel.AutoSize = true;
            this.HiScoreNrLabel.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HiScoreNrLabel.Location = new System.Drawing.Point(264, 41);
            this.HiScoreNrLabel.Name = "HiScoreNrLabel";
            this.HiScoreNrLabel.Size = new System.Drawing.Size(92, 18);
            this.HiScoreNrLabel.TabIndex = 4;
            this.HiScoreNrLabel.Text = "0000";
            // 
            // scoreNr1Label
            // 
            this.scoreNr1Label.AutoSize = true;
            this.scoreNr1Label.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreNr1Label.Location = new System.Drawing.Point(12, 41);
            this.scoreNr1Label.Name = "scoreNr1Label";
            this.scoreNr1Label.Size = new System.Drawing.Size(92, 18);
            this.scoreNr1Label.TabIndex = 3;
            this.scoreNr1Label.Text = "0000";
            // 
            // hiScoreLabel
            // 
            this.hiScoreLabel.AutoSize = true;
            this.hiScoreLabel.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hiScoreLabel.Location = new System.Drawing.Point(264, 9);
            this.hiScoreLabel.Name = "hiScoreLabel";
            this.hiScoreLabel.Size = new System.Drawing.Size(176, 18);
            this.hiScoreLabel.TabIndex = 2;
            this.hiScoreLabel.Text = "HI-SCORE";
            // 
            // scoreLabel2
            // 
            this.scoreLabel2.AutoSize = true;
            this.scoreLabel2.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel2.Location = new System.Drawing.Point(509, 9);
            this.scoreLabel2.Name = "scoreLabel2";
            this.scoreLabel2.Size = new System.Drawing.Size(176, 18);
            this.scoreLabel2.TabIndex = 1;
            this.scoreLabel2.Text = "SCORE<2>";
            // 
            // scoreLabel1
            // 
            this.scoreLabel1.AutoSize = true;
            this.scoreLabel1.Font = new System.Drawing.Font("Arcade Normal", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel1.Location = new System.Drawing.Point(12, 9);
            this.scoreLabel1.Name = "scoreLabel1";
            this.scoreLabel1.Size = new System.Drawing.Size(176, 18);
            this.scoreLabel1.TabIndex = 0;
            this.scoreLabel1.Text = "SCORE<1>";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(697, 799);
            this.Controls.Add(this.startPanel);
            this.Controls.Add(this.scorePanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Kosmiczni Najeźdźcy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.startPanel.ResumeLayout(false);
            this.startPanel.PerformLayout();
            this.scorePanel.ResumeLayout(false);
            this.scorePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer frameTimer;
        private PictureBox logoBox;
        private Label startLabel;
        private Panel startPanel;
        private Panel scorePanel;
        private Label scoreNr2Label;
        private Label HiScoreNrLabel;
        private Label scoreNr1Label;
        private Label hiScoreLabel;
        private Label scoreLabel2;
        private Label scoreLabel1;
    }
}