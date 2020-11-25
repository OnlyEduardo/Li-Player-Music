namespace LiMusicPlayer.Forms
{
    partial class LibraryForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateButton = new System.Windows.Forms.Label();
            this.removeFolderButton = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.addFolderButton = new System.Windows.Forms.Label();
            this.panelAllMusics.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAllMusics
            // 
            this.panelAllMusics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelAllMusics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelAllMusics.Controls.Add(this.panel1);
            this.panelAllMusics.Controls.Add(this.listBox);
            this.panelAllMusics.Controls.Add(this.label3);
            this.panelAllMusics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAllMusics.Location = new System.Drawing.Point(0, 0);
            this.panelAllMusics.Name = "panelAllMusics";
            this.panelAllMusics.Size = new System.Drawing.Size(1112, 600);
            this.panelAllMusics.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.updateButton);
            this.panel1.Controls.Add(this.addFolderButton);
            this.panel1.Controls.Add(this.removeFolderButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 547);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 53);
            this.panel1.TabIndex = 7;
            // 
            // updateButton
            // 
            this.updateButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.updateButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.updateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.ForeColor = System.Drawing.Color.White;
            this.updateButton.Location = new System.Drawing.Point(0, 4);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(148, 45);
            this.updateButton.TabIndex = 12;
            this.updateButton.Text = "Atualizar";
            this.updateButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // removeFolderButton
            // 
            this.removeFolderButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeFolderButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.removeFolderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeFolderButton.Font = new System.Drawing.Font("Mongolian Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeFolderButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.removeFolderButton.Image = global::LiMusicPlayer.Properties.Resources.subtract_32px;
            this.removeFolderButton.Location = new System.Drawing.Point(1064, 4);
            this.removeFolderButton.Name = "removeFolderButton";
            this.removeFolderButton.Size = new System.Drawing.Size(45, 45);
            this.removeFolderButton.TabIndex = 11;
            this.removeFolderButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.removeFolderButton.Click += new System.EventHandler(this.RemoveFolderButton_Click);
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
            this.listBox.Location = new System.Drawing.Point(0, 88);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(1112, 512);
            this.listBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1112, 88);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sua Biblioteca de pastas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addFolderButton
            // 
            this.addFolderButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.addFolderButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addFolderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addFolderButton.Font = new System.Drawing.Font("Mongolian Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFolderButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.addFolderButton.Image = global::LiMusicPlayer.Properties.Resources.plus_math_32px;
            this.addFolderButton.Location = new System.Drawing.Point(1010, 4);
            this.addFolderButton.Name = "addFolderButton";
            this.addFolderButton.Size = new System.Drawing.Size(48, 45);
            this.addFolderButton.TabIndex = 10;
            this.addFolderButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addFolderButton.Click += new System.EventHandler(this.AddFolderButton_Click);
            // 
            // LibraryForm
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
            this.Name = "LibraryForm";
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label addFolderButton;
        private System.Windows.Forms.Label removeFolderButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label updateButton;
    }
}