using LiMusicPlayer.Lib;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using WMPLib;

namespace LiMusicPlayer
{
    public partial class MainForm : Form
    {
        private List<Music> MusicsList { get; } = new List<Music>();
        public static int actualIndex = 0;

        private Music actualMusic = null;
        private bool isPlaying = false;
        private int actualVolume = 50;

        public MainForm()
        {
            InitializeComponent();
            InitializeMusicsList();
            PopulateListOfAllMusic();
            timer.Stop();     
        }

        private void InitializeMusicsList()
        {
            var musicsPaths = Search.GetMusicsPaths();

            foreach (var mpath in musicsPaths)
                MusicsList.Add(new Music(mpath));
        }

        private void PopulateListOfAllMusic()
        {
            listBox.SelectionMode = SelectionMode.MultiExtended;
            listBox.BeginUpdate();

            for (int x = 0; x < MusicsList.Count; x++)
            {
                listBox.Items.Add(MusicsList[x]);
            }

            listBox.EndUpdate();
        }

        // Play Stop actual music
        private void PlayStopButtonClick(object sender, EventArgs e)
        {
            isPlaying = !isPlaying;

            PlayStopLabel.Image = isPlaying ? Properties.Resources.pause_64px : Properties.Resources.play_64px;

            actualMusic = MusicsList[actualIndex];
            actualMusic.Volume(actualVolume);
            
            if (isPlaying)
            {
                actualMusic.Play();
                timer.Start();
            }           
            else
            {
                actualMusic.Stop();
                timer.Stop();
            }

            labelActualMusic.Text = actualMusic.ToString();
        }

        // Go to start or go to previous 
        private void GoToStart_Click(object sender, EventArgs e)
        {
            timer.Stop();

            if(progressBar.Value <= 3)
            {
                progressBar.Value = 0;
                if (isPlaying)
                    actualMusic.Stop();

                actualMusic.CurrentPosition = 0;

                actualIndex = actualIndex - 1 < 0 ? (MusicsList.Count - 1) : actualIndex - 1;               
                actualMusic = MusicsList[actualIndex];
            }
            else
            {
                progressBar.Value = 0;

                if (isPlaying)
                    actualMusic.Stop();

                actualMusic.CurrentPosition = 0;
            }

            if (isPlaying)
            {
                timer.Start();
                actualMusic.Play();
            }

            PlayStopLabel.Image = isPlaying ? Properties.Resources.pause_64px : Properties.Resources.play_64px;

            actualMusic.Volume(actualVolume);
            labelActualMusic.Text = actualMusic.ToString();
        }

        // Go to next music
        private void GoToNextMusic_Click(object sender, EventArgs e)
        {
            // Stop timer and reset progressBar
            timer.Stop();
            progressBar.Value = 0;

            // Adjust actual Index
            actualIndex = actualIndex + 1 >= MusicsList.Count ? 0 : ++actualIndex;

            // Stop music if is playing
            if (isPlaying)
                actualMusic.Stop();

            if(actualMusic != null)
                actualMusic.CurrentPosition = 0;                    
            
            actualMusic = MusicsList[actualIndex];

            if (isPlaying)
            {
                timer.Start();
                actualMusic.Play();
            }

            PlayStopLabel.Image = isPlaying ? Properties.Resources.pause_64px : Properties.Resources.play_64px;

            actualMusic.Volume(actualVolume);
            labelActualMusic.Text = actualMusic.ToString();
        }

        // Update progressBar
        private void TimerTick(object sender, EventArgs e)
        {
            if (actualMusic == null)
                return;

            if (progressBar.Value + 1 > progressBar.Maximum)
            {
                GoToNextMusic_Click(sender, e);
                return;
            }
                
            progressBar.Value += 1;
            timeProgressLabel.Text = Util.FormatNumber(progressBar.Value);

            if (progressBar.Maximum != actualMusic.Duration)
            {
                progressBar.Maximum = actualMusic.Duration;
                totalDurationTime.Text = Util.FormatNumber((int)actualMusic.Player.currentMedia.duration);
            }

            progressBar.Refresh();
            progressBar.Update();
        }

        // Update volume
        private void TrackBarScrolling(object sender, EventArgs e)
        {
            actualVolume = trackBar.Value * 10;

            if (actualMusic != null)
                actualMusic.Volume(actualVolume);
        }

        // Select Music by listbox
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {  
            var selectedIndex = listBox.SelectedIndex <= -1 ? 0 : listBox.SelectedIndex;  
            var selectedMusic = (Music) listBox.Items[selectedIndex];

            Console.WriteLine(selectedMusic);

            if (actualMusic != null)
            {
                if (isPlaying)
                {
                    timer.Stop();
                    actualMusic.Stop();
                }

                actualMusic.CurrentPosition = 0;
                progressBar.Value = 0;
            }

            actualIndex = selectedIndex;
            actualMusic = selectedMusic;

            if (isPlaying)
                isPlaying = false;

            PlayStopButtonClick(sender, e);
        }

        private void ButtonAllMusics_Click(object sender, EventArgs e)
        {
            panelAllMusics.Visible = !panelAllMusics.Visible;
            panelAllMusics.Enabled = panelAllMusics.Visible;
        }
    }
}
