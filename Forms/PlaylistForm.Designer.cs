namespace LiMusicPlayer.Forms
{
    partial class PlaylistForm
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
            this.panelAllMusics = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelAllMusics.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAllMusics
            // 
            this.panelAllMusics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelAllMusics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelAllMusics.Controls.Add(this.label3);
            this.panelAllMusics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAllMusics.Location = new System.Drawing.Point(0, 0);
            this.panelAllMusics.Name = "panelAllMusics";
            this.panelAllMusics.Size = new System.Drawing.Size(1094, 553);
            this.panelAllMusics.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1094, 88);
            this.label3.TabIndex = 8;
            this.label3.Text = "Playlists";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1094, 553);
            this.ControlBox = false;
            this.Controls.Add(this.panelAllMusics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlaylistForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PlaylistForm";
            this.panelAllMusics.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAllMusics;
        private System.Windows.Forms.Label label3;
    }
}