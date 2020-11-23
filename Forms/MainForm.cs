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

        public int _actualIndex = 0;
        public int _actualVolume = 50;
        public int _rate = 1;
        public Music _actualMusic = null;
        public bool _isPlaying = false;

        private readonly AllMusics _allMusicsForm = new AllMusics();

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

        public List<Playlist> Playlists { get; } = new List<Playlist>();
        public List<Music> MusicsList { get; } = new List<Music>();
        public List<Form> Forms { get; } = new List<Form>();
       
        #region InitializeSystem
        private void PopulateFormsList()
        {
            Forms.Add(_allMusicsForm);
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
            trackBar.Value = _actualVolume / 10;
            timer.Stop();
            labelActualMusic.Text = MusicsList[_actualIndex].ToString();
        }
        #endregion

        #region Side Panel Buttons
        private void ButtonPlaylists_Click(object sender, EventArgs e)
        {
            panelPlaylists.Visible = !panelPlaylists.Visible;
            panelPlaylists.Height = panelPlaylists.Controls.Count * 50;
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = !panelEdit.Visible;
            panelEdit.Height = panelEdit.Controls.Count * 50;
        }

        private void AddFolderButton_Click(object sender, EventArgs e)
        {
            var dialog = folderBrowserDialog1.ShowDialog();

            if (dialog.Equals(DialogResult.OK))
            {
                var addDir = folderBrowserDialog1.SelectedPath;
                Search.additionalFolders.Remove(addDir);
                MessageBox.Show("Essa ação só terá efeito após a reinicialização do programa");
            }
        }

        private void RemoveFolderButton_Click(object sender, EventArgs e)
        {
            var removedDir = "";
            Search.additionalFolders.Remove(removedDir);
            MessageBox.Show("Essa ação só terá efeito após a reinicialização do programa");
        }

        private void ShowAllMusics(object sender, EventArgs e)
        {

            if (!mainPanel.Visible)
            {
                mainPanel.Visible = true;
                mainPanel.Enabled = true;
                TurnOnFormAndCloseOthers(_allMusicsForm);
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
            _isPlaying = !_isPlaying;

            PlayStopLabel.Image = _isPlaying ? Properties.Resources.pause_64px : Properties.Resources.play_64px;

            _actualMusic = MusicsList[_actualIndex];
            _actualMusic.Volume(_actualVolume);
            _actualMusic.Rate(_rate);
            
            if (_isPlaying)
            {
                _actualMusic.Play();
                timer.Start();
            }           
            else
            {
                _actualMusic.Stop();
                timer.Stop();
            }

            for(var i = 0; i < AllMusics.INSTANCE.listBox.Items.Count; i++)
                AllMusics.INSTANCE.listBox.SetSelected(i, false);

            labelActualMusic.Text = _actualMusic.ToString();
        }

        // Go to start or go to previous 
        private void GoToStart_Click(object sender, EventArgs e)
        {
            timer.Stop();

            if(progressBar.Value <= 3)
            {
                progressBar.Value = 0;
                if (_isPlaying)
                    _actualMusic.Stop();

                _actualMusic.CurrentPosition = 0;

                _actualIndex = _actualIndex - 1 < 0 ? (MusicsList.Count - 1) : _actualIndex - 1;               
                _actualMusic = MusicsList[_actualIndex];
            }
            else
            {
                progressBar.Value = 0;

                if (_isPlaying)
                    _actualMusic.Stop();

                _actualMusic.CurrentPosition = 0;
            }

            _isPlaying = !_isPlaying;
            PlayStopButtonClick(sender, e);
        }

        // Go to next music
        private void GoToNextMusic_Click(object sender, EventArgs e)
        {
            // Stop timer and reset progressBar
            timer.Stop();
            progressBar.Value = 0;

            // Adjust actual Index
            _actualIndex = _actualIndex + 1 >= MusicsList.Count ? 0 : ++_actualIndex;

            // Stop music if is playing
            if (_isPlaying)
                _actualMusic.Stop();

            if(_actualMusic != null)
                _actualMusic.CurrentPosition = 0;                    
            
            _actualMusic = MusicsList[_actualIndex];

            _isPlaying = !_isPlaying;
            PlayStopButtonClick(sender, e);
        }

        // Update volume
        private void TrackBarScrolling(object sender, EventArgs e)
        {
            _actualVolume = trackBar.Value * 10;

            if (_actualMusic != null)
                _actualMusic.Volume(_actualVolume);
        }

        // Update Music Speed
        private void Speedometer_Click(object sender, EventArgs e)
        {
            bool wasEn = timer.Enabled;

            if (wasEn) timer.Stop();

            _rate = _rate + 1 > 4 ? 1 : ++_rate;
            if (_actualMusic != null) _actualMusic.Rate(_rate);
            speedometer.Text = $"{_rate}x";

            if(wasEn) timer.Start();
        }
        #endregion

        // Update progressBar
        private void TimerTick(object sender, EventArgs e)
        {
            if (_actualMusic == null)
                return;

            if (progressBar.Value + 1 > progressBar.Maximum)
            {
                GoToNextMusic_Click(sender, e);
                return;
            }
                
            progressBar.Value += _rate;
            timeProgressLabel.Text = Util.FormatNumber(progressBar.Value);

            if (progressBar.Maximum != _actualMusic.Duration)
            {
                progressBar.Maximum = _actualMusic.Duration;
                totalDurationTime.Text = Util.FormatNumber((int)_actualMusic.Player.currentMedia.duration);
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
