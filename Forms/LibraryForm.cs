using LiMusicPlayer.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiMusicPlayer.Forms
{
    public partial class LibraryForm : Form
    {
        public static LibraryForm INSTANCE;

        public LibraryForm()
        {
            if (INSTANCE == null)
                INSTANCE = this;

            InitializeComponent();
            listBox.SelectionMode = SelectionMode.MultiExtended;
        }

        public void PopulateListOfFolders()
        {           
            listBox.BeginUpdate();
            listBox.Items.AddRange(Search.additionalFolders.ToArray());
            listBox.EndUpdate();
        }

        // Add folder to library
        private void AddFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Pasta a ser adicionada a biblioteca";
            var dialog = folderBrowserDialog1.ShowDialog();

            if (dialog.Equals(DialogResult.OK))
            {
                var addDir = folderBrowserDialog1.SelectedPath;

                if (Search.additionalFolders.Contains(addDir) || Search.DefaultPaths.Contains(addDir))
                {
                    MessageBox.Show("Essa pasta já está existe na biblioteca",
                        "Pasta já existe");
                    return;
                }

                Search.additionalFolders.Add(addDir);
                listBox.Items.Add(addDir);
            }
        }

        // Remove folder from library
        private void RemoveFolderButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex <= -1)
                return;

            var folder = (string) listBox.Items[listBox.SelectedIndex];

            listBox.Items.Remove(folder);
            Search.additionalFolders.Remove(folder);

            listBox.SelectedIndex = -1;
            listBox.SelectedValue = null;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Util.Restart();
        }
    }
}
