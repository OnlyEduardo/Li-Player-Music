using LiMusicPlayer.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace LiMusicPlayer
{
    public partial class MainForm : Form
    {
        public static MainForm INSTANCE;

        public int actualIndex = 0;
        public int actualVolume = 50;
        public Music actualMusic = null;

        private bool isPlaying = false;
        
        public MainForm()
        {
            if(INSTANCE == null)
                INSTANCE = this;

            InitializeComponent();
            InitializeMusicsList();
            PopulateListOfAllMusic();
            LoadAndSetData();

        }

        private List<Music> MusicsList { get; } = new List<Music>();
        private List<Panel> Panels { get; } = new List<Panel>();

        #region InitializeSystem
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

        private void LoadAndSetData()
        {
            Saver.LoadFile();
            trackBar.Value = actualVolume / 10;
            timer.Stop();
            labelActualMusic.Text = MusicsList[actualIndex].ToString();
        }

        private void ListPanels()
        {
            Panels.Add(panelAllMusics);
        }
        #endregion

        #region Side Panel Buttons
        private void ShowAllMusics(object sender, EventArgs e)
        {
            SetPanelsOfExcept(panelAllMusics, panelAllMusics.Visible);
        }


        private void OpenMySite(object sender, EventArgs e)
        {
            try
            {
                var myProcess = new Process();
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "https://www.eduardo-ribeiro-leal.com";
                myProcess.Start();
            }
            catch { }

        }
        #endregion

        #region Player Buttons
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

            isPlaying = !isPlaying;
            PlayStopButtonClick(sender, e);
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

            isPlaying = !isPlaying;
            PlayStopButtonClick(sender, e);
        }

        // Update volume
        private void TrackBarScrolling(object sender, EventArgs e)
        {
            actualVolume = trackBar.Value * 10;

            if (actualMusic != null)
                actualMusic.Volume(actualVolume);
        }
        #endregion

        // Panels configs
        private void SetPanelsOfExcept(Panel exceptedPanel, bool oldState)
        {
            foreach(var panel in Panels)
            {
                panel.Visible = false;
                panel.Enabled = false;
            }

            exceptedPanel.Visible = !oldState;
            exceptedPanel.Enabled = !oldState;
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

        // Select Music by listbox
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex <= -1)
                return;

            var selectedIndex = listBox.SelectedIndex;  
            var selectedMusic = (Music) listBox.Items[selectedIndex];

            if (selectedMusic == actualMusic)
                return;

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

        // When closing save data
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Saver.SaveFile();
        }

        
    }
}
