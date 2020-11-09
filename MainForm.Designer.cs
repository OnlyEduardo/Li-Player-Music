namespace LiMusicPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.ShuffleMusic = new System.Windows.Forms.Label();
            this.GoToNextMusic = new System.Windows.Forms.Label();
            this.PlayStopLabel = new System.Windows.Forms.Label();
            this.GoToStart = new System.Windows.Forms.Label();
            this.LoopMusic = new System.Windows.Forms.Label();
            this.totalDurationTime = new System.Windows.Forms.Label();
            this.timeProgressLabel = new System.Windows.Forms.Label();
            this.labelActualMusic = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.sidePanel = new System.Windows.Forms.Panel();
            this.buttonAllMusics = new System.Windows.Forms.Button();
            this.Logolabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAllMusics = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.panelBottom.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.sidePanel.SuspendLayout();
            this.panelAllMusics.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panelBottom.Controls.Add(this.panelButtons);
            this.panelBottom.Controls.Add(this.totalDurationTime);
            this.panelBottom.Controls.Add(this.timeProgressLabel);
            this.panelBottom.Controls.Add(this.labelActualMusic);
            this.panelBottom.Controls.Add(this.trackBar);
            this.panelBottom.Controls.Add(this.progressBar);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(250, 600);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1112, 173);
            this.panelBottom.TabIndex = 1;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelButtons.Controls.Add(this.ShuffleMusic);
            this.panelButtons.Controls.Add(this.GoToNextMusic);
            this.panelButtons.Controls.Add(this.PlayStopLabel);
            this.panelButtons.Controls.Add(this.GoToStart);
            this.panelButtons.Controls.Add(this.LoopMusic);
            this.panelButtons.Location = new System.Drawing.Point(167, 36);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(735, 100);
            this.panelButtons.TabIndex = 9;
            // 
            // ShuffleMusic
            // 
            this.ShuffleMusic.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ShuffleMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShuffleMusic.Image = global::LiMusicPlayer.Properties.Resources.shuffle_48px;
            this.ShuffleMusic.Location = new System.Drawing.Point(671, 20);
            this.ShuffleMusic.Name = "ShuffleMusic";
            this.ShuffleMusic.Size = new System.Drawing.Size(64, 64);
            this.ShuffleMusic.TabIndex = 5;
            // 
            // GoToNextMusic
            // 
            this.GoToNextMusic.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.GoToNextMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToNextMusic.Image = global::LiMusicPlayer.Properties.Resources.end_48px;
            this.GoToNextMusic.Location = new System.Drawing.Point(521, 20);
            this.GoToNextMusic.Name = "GoToNextMusic";
            this.GoToNextMusic.Size = new System.Drawing.Size(64, 64);
            this.GoToNextMusic.TabIndex = 2;
            this.GoToNextMusic.Click += new System.EventHandler(this.GoToNextMusic_Click);
            // 
            // PlayStopLabel
            // 
            this.PlayStopLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayStopLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayStopLabel.Image = global::LiMusicPlayer.Properties.Resources.play_64px;
            this.PlayStopLabel.Location = new System.Drawing.Point(300, 20);
            this.PlayStopLabel.Name = "PlayStopLabel";
            this.PlayStopLabel.Size = new System.Drawing.Size(135, 64);
            this.PlayStopLabel.TabIndex = 1;
            this.PlayStopLabel.Click += new System.EventHandler(this.PlayStopButtonClick);
            // 
            // GoToStart
            // 
            this.GoToStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GoToStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToStart.Image = global::LiMusicPlayer.Properties.Resources.skip_to_start_48px;
            this.GoToStart.Location = new System.Drawing.Point(150, 20);
            this.GoToStart.Name = "GoToStart";
            this.GoToStart.Size = new System.Drawing.Size(64, 64);
            this.GoToStart.TabIndex = 3;
            this.GoToStart.Click += new System.EventHandler(this.GoToStart_Click);
            // 
            // LoopMusic
            // 
            this.LoopMusic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LoopMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoopMusic.Image = global::LiMusicPlayer.Properties.Resources.repeat_48px;
            this.LoopMusic.Location = new System.Drawing.Point(0, 20);
            this.LoopMusic.Name = "LoopMusic";
            this.LoopMusic.Size = new System.Drawing.Size(64, 64);
            this.LoopMusic.TabIndex = 4;
            // 
            // totalDurationTime
            // 
            this.totalDurationTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalDurationTime.AutoSize = true;
            this.totalDurationTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDurationTime.ForeColor = System.Drawing.Color.White;
            this.totalDurationTime.Location = new System.Drawing.Point(987, 144);
            this.totalDurationTime.Name = "totalDurationTime";
            this.totalDurationTime.Size = new System.Drawing.Size(62, 25);
            this.totalDurationTime.TabIndex = 8;
            this.totalDurationTime.Text = "00:00";
            // 
            // timeProgressLabel
            // 
            this.timeProgressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeProgressLabel.AutoSize = true;
            this.timeProgressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeProgressLabel.ForeColor = System.Drawing.Color.White;
            this.timeProgressLabel.Location = new System.Drawing.Point(6, 144);
            this.timeProgressLabel.Name = "timeProgressLabel";
            this.timeProgressLabel.Size = new System.Drawing.Size(62, 25);
            this.timeProgressLabel.TabIndex = 7;
            this.timeProgressLabel.Text = "00:00";
            this.timeProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelActualMusic
            // 
            this.labelActualMusic.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActualMusic.ForeColor = System.Drawing.Color.White;
            this.labelActualMusic.Location = new System.Drawing.Point(3, 5);
            this.labelActualMusic.Name = "labelActualMusic";
            this.labelActualMusic.Size = new System.Drawing.Size(599, 28);
            this.labelActualMusic.TabIndex = 3;
            // 
            // trackBar
            // 
            this.trackBar.CausesValidation = false;
            this.trackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.trackBar.Location = new System.Drawing.Point(1056, 0);
            this.trackBar.Name = "trackBar";
            this.trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar.Size = new System.Drawing.Size(56, 173);
            this.trackBar.TabIndex = 6;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar.Value = 5;
            this.trackBar.Scroll += new System.EventHandler(this.TrackBarScrolling);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.progressBar.Location = new System.Drawing.Point(88, 147);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(893, 17);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.sidePanel.Controls.Add(this.buttonAbout);
            this.sidePanel.Controls.Add(this.buttonAllMusics);
            this.sidePanel.Controls.Add(this.Logolabel);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(250, 773);
            this.sidePanel.TabIndex = 2;
            // 
            // buttonAllMusics
            // 
            this.buttonAllMusics.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAllMusics.FlatAppearance.BorderSize = 0;
            this.buttonAllMusics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAllMusics.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAllMusics.ForeColor = System.Drawing.Color.White;
            this.buttonAllMusics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAllMusics.Location = new System.Drawing.Point(0, 161);
            this.buttonAllMusics.Name = "buttonAllMusics";
            this.buttonAllMusics.Size = new System.Drawing.Size(250, 50);
            this.buttonAllMusics.TabIndex = 2;
            this.buttonAllMusics.Text = "Músicas";
            this.buttonAllMusics.UseVisualStyleBackColor = true;
            this.buttonAllMusics.Click += new System.EventHandler(this.ShowAllMusics);
            // 
            // Logolabel
            // 
            this.Logolabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(5)))), ((int)(((byte)(17)))));
            this.Logolabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Logolabel.Image = global::LiMusicPlayer.Properties.Resources.LP_Logo_64px;
            this.Logolabel.Location = new System.Drawing.Point(0, 0);
            this.Logolabel.Name = "Logolabel";
            this.Logolabel.Size = new System.Drawing.Size(250, 161);
            this.Logolabel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(250, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(1112, 369);
            this.label1.TabIndex = 3;
            this.label1.Text = "Li Music Player\r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(250, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1112, 75);
            this.label2.TabIndex = 4;
            this.label2.Text = "Feito por: Eduardo Ribeiro Leal";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAllMusics
            // 
            this.panelAllMusics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAllMusics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelAllMusics.Controls.Add(this.label3);
            this.panelAllMusics.Controls.Add(this.listBox);
            this.panelAllMusics.Enabled = false;
            this.panelAllMusics.Location = new System.Drawing.Point(250, 0);
            this.panelAllMusics.Name = "panelAllMusics";
            this.panelAllMusics.Size = new System.Drawing.Size(1112, 602);
            this.panelAllMusics.TabIndex = 5;
            this.panelAllMusics.Visible = false;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1112, 64);
            this.label3.TabIndex = 8;
            this.label3.Text = "Todas as músicas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(5)))), ((int)(((byte)(32)))));
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox.CausesValidation = false;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.ForeColor = System.Drawing.Color.White;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 31;
            this.listBox.Location = new System.Drawing.Point(0, 166);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(1112, 436);
            this.listBox.TabIndex = 7;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAbout.FlatAppearance.BorderSize = 0;
            this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbout.ForeColor = System.Drawing.Color.White;
            this.buttonAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAbout.Location = new System.Drawing.Point(0, 723);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(250, 50);
            this.buttonAbout.TabIndex = 3;
            this.buttonAbout.Text = "Sobre";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.OpenMySite);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1362, 773);
            this.Controls.Add(this.panelAllMusics);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.sidePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1222, 820);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Li Music Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.sidePanel.ResumeLayout(false);
            this.panelAllMusics.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label PlayStopLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label GoToNextMusic;
        private System.Windows.Forms.Label GoToStart;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Label LoopMusic;
        private System.Windows.Forms.Label ShuffleMusic;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label labelActualMusic;
        private System.Windows.Forms.Label Logolabel;
        private System.Windows.Forms.Button buttonAllMusics;
        private System.Windows.Forms.Panel panelButtons;
        public System.Windows.Forms.Label timeProgressLabel;
        public System.Windows.Forms.Label totalDurationTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelAllMusics;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button buttonAbout;
    }
}

