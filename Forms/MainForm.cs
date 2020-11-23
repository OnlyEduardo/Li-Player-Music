using LiMusicPlayer.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace LiMusicPlayer.Forms
{
    public partial class MainForm : Form
    {
        public static MainForm INSTANCE;

        public int actualIndex = 0;
        public int actualVolume = 50;
        public Music actualMusic = null;
        public bool isPlaying = false;

        private readonly AllMusics allMusicsForm = new AllMusics();

        public MainForm()
        {
            if(INSTANCE == null)
                INSTANCE = this;

            InitializeComponent();
            Saver.LoadFile();

            PopulateFormsList();
            HideAllExternalForms();
            InitializeMusicsList();
            SetLoadedData();         

            // Load Form Initializators
            AllMusics.INSTANCE.PopulateListOfAllMusic();
        }

        public List<Music> MusicsList { get; } = new List<Music>();
        public List<Form> Forms { get; } = new List<Form>();
       
        #region InitializeSystem
        private void PopulateFormsList()
        {
            Forms.Add(allMusicsForm);
        }

        private void HideAllExternalForms()
        {
            foreach(var form in Forms)
            {
                form.Visible = false;
                form.Enabled = false;
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(form);     
            }
        }

        private void InitializeMusicsList()
        {
            var musicsPaths = Search.GetMusicsPaths();

            foreach (var mpath in musicsPaths)
                MusicsList.Add(new Music(mpath));
        }     

        private void SetLoadedData()
        {      
            trackBar.Value = actualVolume / 10;
            timer.Stop();
            labelActualMusic.Text = MusicsList[actualIndex].ToString();
        }
        #endregion

        #region Side Panel Buttons
        private void ShowAllMusics(object sender, EventArgs e)
        {

            if (!mainPanel.Visible)
            {
                mainPanel.Visible = true;
                mainPanel.Enabled = true;
                TurnOnFormAndCloseOthers(allMusicsForm);
            }         
            else
            {
                mainPanel.Visible = false;
                mainPanel.Enabled = false;
                TurnOffAllForms();
            }        
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
        public void PlayStopButtonClick(object sender, EventArgs e)
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

            for(var i = 0; i < AllMusics.INSTANCE.listBox.Items.Count; i++)
                AllMusics.INSTANCE.listBox.SetSelected(i, false);

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

        // When closing save data
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Saver.SaveFile();
        }

        // Clicking in Logo
        private void Logolabel_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            mainPanel.Enabled = false;
        }

        private void TurnOffAllForms()
        {
            foreach (var form in Forms)
            {
                form.Visible = false;
                form.Enabled = false;
            }
        }

        private void TurnOnFormAndCloseOthers(Form exceptedForm)
        {
            foreach(var form in Forms)
            {
                if(form == exceptedForm)
                {
                    form.Visible = true;
                    form.Enabled = true;
                    continue;
                }

                form.Visible = false;
                form.Enabled = false;
            }
        }
    }
}
