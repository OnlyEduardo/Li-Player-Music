namespace LiMusicPlayer
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxAllMusics = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(936, 69);
            this.label1.TabIndex = 6;
            this.label1.Text = "Todas as músicas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBoxAllMusics
            // 
            this.listBoxAllMusics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(5)))), ((int)(((byte)(32)))));
            this.listBoxAllMusics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxAllMusics.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBoxAllMusics.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAllMusics.ForeColor = System.Drawing.Color.White;
            this.listBoxAllMusics.FormattingEnabled = true;
            this.listBoxAllMusics.ItemHeight = 31;
            this.listBoxAllMusics.Location = new System.Drawing.Point(0, 117);
            this.listBoxAllMusics.Name = "listBoxAllMusics";
            this.listBoxAllMusics.Size = new System.Drawing.Size(936, 436);
            this.listBoxAllMusics.TabIndex = 5;
            // 
            // AllMusicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(936, 553);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxAllMusics);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(954, 600);
            this.Name = "AllMusicsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AllMusicsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxAllMusics;
    }
}