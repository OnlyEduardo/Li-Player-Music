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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.totalDurationTime = new System.Windows.Forms.Label();
            this.timeProgressLabel = new System.Windows.Forms.Label();
            this.labelActualMusic = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.ShuffleMusic = new System.Windows.Forms.Label();
            this.LoopMusic = new System.Windows.Forms.Label();
            this.GoToStart = new System.Windows.Forms.Label();
            this.GoToNextMusic = new System.Windows.Forms.Label();
            this.PlayStopLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Logolabel = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.panelBottom.Controls.Add(this.totalDurationTime);
            this.panelBottom.Controls.Add(this.timeProgressLabel);
            this.panelBottom.Controls.Add(this.labelActualMusic);
            this.panelBottom.Controls.Add(this.LoopMusic);
            this.panelBottom.Controls.Add(this.trackBar);
            this.panelBottom.Controls.Add(this.ShuffleMusic);
            this.panelBottom.Controls.Add(this.progressBar);
            this.panelBottom.Controls.Add(this.GoToStart);
            this.panelBottom.Controls.Add(this.GoToNextMusic);
            this.panelBottom.Controls.Add(this.PlayStopLabel);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(266, 600);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(938, 173);
            this.panelBottom.TabIndex = 1;
            // 
            // totalDurationTime
            // 
            this.totalDurationTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalDurationTime.AutoSize = true;
            this.totalDurationTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDurationTime.ForeColor = System.Drawing.Color.White;
            this.totalDurationTime.Location = new System.Drawing.Point(813, 144);
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
            this.trackBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.trackBar.Location = new System.Drawing.Point(882, 0);
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
            this.progressBar.Size = new System.Drawing.Size(719, 17);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // ShuffleMusic
            // 
            this.ShuffleMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ShuffleMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShuffleMusic.Image = global::LiMusicPlayer.Properties.Resources.shuffle_48px;
            this.ShuffleMusic.Location = new System.Drawing.Point(743, 48);
            this.ShuffleMusic.Name = "ShuffleMusic";
            this.ShuffleMusic.Size = new System.Drawing.Size(64, 64);
            this.ShuffleMusic.TabIndex = 5;
            // 
            // LoopMusic
            // 
            this.LoopMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoopMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoopMusic.Image = global::LiMusicPlayer.Properties.Resources.repeat_48px;
            this.LoopMusic.Location = new System.Drawing.Point(85, 48);
            this.LoopMusic.Name = "LoopMusic";
            this.LoopMusic.Size = new System.Drawing.Size(64, 64);
            this.LoopMusic.TabIndex = 4;
            // 
            // GoToStart
            // 
            this.GoToStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GoToStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToStart.Image = global::LiMusicPlayer.Properties.Resources.skip_to_start_48px;
            this.GoToStart.Location = new System.Drawing.Point(258, 48);
            this.GoToStart.Name = "GoToStart";
            this.GoToStart.Size = new System.Drawing.Size(64, 64);
            this.GoToStart.TabIndex = 3;
            this.GoToStart.Click += new System.EventHandler(this.GoToStart_Click);
            // 
            // GoToNextMusic
            // 
            this.GoToNextMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GoToNextMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GoToNextMusic.Image = global::LiMusicPlayer.Properties.Resources.end_48px;
            this.GoToNextMusic.Location = new System.Drawing.Point(538, 48);
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
            this.PlayStopLabel.Location = new System.Drawing.Point(404, 48);
            this.PlayStopLabel.Name = "PlayStopLabel";
            this.PlayStopLabel.Size = new System.Drawing.Size(64, 64);
            this.PlayStopLabel.TabIndex = 1;
            this.PlayStopLabel.Click += new System.EventHandler(this.PlayStopButtonClick);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(0)))), ((int)(((byte)(12)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Logolabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 773);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Logolabel
            // 
            this.Logolabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Logolabel.Location = new System.Drawing.Point(0, 0);
            this.Logolabel.Name = "Logolabel";
            this.Logolabel.Size = new System.Drawing.Size(266, 129);
            this.Logolabel.TabIndex = 1;
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(5)))), ((int)(((byte)(32)))));
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.ForeColor = System.Drawing.Color.White;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 31;
            this.listBox.Location = new System.Drawing.Point(266, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(938, 467);
            this.listBox.TabIndex = 3;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1204, 773);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Li Music Player";
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label PlayStopLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label GoToNextMusic;
        private System.Windows.Forms.Label GoToStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LoopMusic;
        private System.Windows.Forms.Label ShuffleMusic;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label labelActualMusic;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Logolabel;
        private System.Windows.Forms.Label timeProgressLabel;
        private System.Windows.Forms.Label totalDurationTime;
    }
}

