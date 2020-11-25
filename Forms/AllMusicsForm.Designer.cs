namespace LiMusicPlayer.Forms
{
    partial class AllMusicsForm
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelAllMusics.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAllMusics
            // 
            this.panelAllMusics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelAllMusics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelAllMusics.Controls.Add(this.listBox);
            this.panelAllMusics.Controls.Add(this.panel1);
            this.panelAllMusics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAllMusics.Location = new System.Drawing.Point(0, 0);
            this.panelAllMusics.Name = "panelAllMusics";
            this.panelAllMusics.Size = new System.Drawing.Size(1112, 600);
            this.panelAllMusics.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1112, 112);
            this.label3.TabIndex = 8;
            this.label3.Text = "Todas as músicas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(5)))), ((int)(((byte)(32)))));
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox.CausesValidation = false;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.ForeColor = System.Drawing.Color.White;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 32;
            this.listBox.Location = new System.Drawing.Point(0, 112);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(1112, 488);
            this.listBox.TabIndex = 7;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 112);
            this.panel1.TabIndex = 9;
            // 
            // AllMusicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1112, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panelAllMusics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AllMusicsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panelAllMusics.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAllMusics;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Panel panel1;
    }
}