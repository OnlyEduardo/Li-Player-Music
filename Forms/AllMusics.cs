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
    public partial class AllMusics : Form
    {
        public static AllMusics INSTANCE;

        public AllMusics()
        {
            if (INSTANCE == null)
                INSTANCE = this;

            InitializeComponent();
        }

        public void PopulateListOfAllMusic()
        {
            listBox.SelectionMode = SelectionMode.MultiExtended;
            listBox.BeginUpdate();

            for (int x = 0; x < MainForm.INSTANCE.MusicsList.Count; x++)
            {
                listBox.Items.Add(MainForm.INSTANCE.MusicsList[x]);
            }

            listBox.EndUpdate();
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex <= -1)
                return;

            var selectedIndex = listBox.SelectedIndex;
            var selectedMusic = (Music)listBox.Items[selectedIndex];

            if (selectedMusic == MainForm.INSTANCE.actualMusic)
                return;

            if (MainForm.INSTANCE.actualMusic != null)
            {
                if (MainForm.INSTANCE.isPlaying)
                {
                    MainForm.INSTANCE.timer.Stop();
                    MainForm.INSTANCE.actualMusic.Stop();
                }

                MainForm.INSTANCE.actualMusic.CurrentPosition = 0;
                MainForm.INSTANCE.progressBar.Value = 0;
            }

            MainForm.INSTANCE.actualIndex = selectedIndex;
            MainForm.INSTANCE.actualMusic = selectedMusic;

            if (MainForm.INSTANCE.isPlaying)
                MainForm.INSTANCE.isPlaying = false;

            MainForm.INSTANCE.PlayStopButtonClick(sender, e);
        }
    }
}
