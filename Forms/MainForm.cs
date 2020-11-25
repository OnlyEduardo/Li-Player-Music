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

        public Music _actualMusic = null;

        public int _currentPosition = 0;
        public int _lastDuration = 100;
        public int _actualIndex = 0;
        public int _actualVolume = 50;
        public int _rate = 1;
        
        public bool _isPlaying = false;
        
        // Declaration of external forms
        private readonly AllMusicsForm _allMusicsForm = new AllMusicsForm();

        public MainForm()
        {
            if(INSTANCE == null)
                INSTANCE = this;

            InitializeComponent();
            AddToolTipsForLabels();

            Saver.LoadFile();

            PopulateFormsList();
            HideAllExternalForms();
            InitializeMusicsList();
            SetLoadedData();         

            // Load Form Initializators
            AllMusicsForm.INSTANCE.PopulateListOfAllMusic();
        }

        public List<Playlist> Playlists { get; } = new List<Playlist>();
        public List<Music> MusicsList { get; } = new List<Music>();
        public List<Form> Forms { get; } = new List<Form>();
       
        #region InitializeSystem
        private void AddToolTipsForLabels()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.InitialDelay = 1500;

            toolTip.SetToolTip(LoopMusic, "Ativa/Desativa o looping da música atual.");
            toolTip.SetToolTip(GoBack, "Volta 10 segundos na música atual.");
            toolTip.SetToolTip(GoToStart, "Volta ao inicio da música, caso esteja no inicio, volta para a música anterior.");
            toolTip.SetToolTip(PlayStopLabel, "Inicia/Pausa música atual.");
            toolTip.SetToolTip(GoToNextMusic, "Vai para a próxima música.");
            toolTip.SetToolTip(Advance, "Avança 10 segundo na música atual.");
            toolTip.SetToolTip(ShuffleMusic, "Toca as músicas em ordem aleatória");
            toolTip.SetToolTip(SpeedoMeter, "Acelera música até 4 vezes.");
        }

        // Add external forms to list
        private void PopulateFormsList()
        {
            Forms.Add(_allMusicsForm);
        }

        // Set visible and enable to false, for all External Forms
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

        // Populate Main Playlist(allmusics) with musics
        private void InitializeMusicsList()
        {
            var musicsPaths = Search.GetMusicsPaths();

            foreach (var mpath in musicsPaths)
                MusicsList.Add(new Music(mpath));
        }     

        // Apply the track bar last value, stop the timer and set actual music name in label
        private void SetLoadedData()
        {      
            trackBar.Value = _actualVolume / 10;

            progressBar.Maximum = _lastDuration;
            progressBar.Value = _currentPosition;
            timeProgressLabel.Text = Util.FormatNumber(_currentPosition);

            timer.Stop();

            try
            {
                labelActualMusic.Text = MusicsList[_actualIndex].ToString();
            } catch (ArgumentOutOfRangeException)
            {
                labelActualMusic.Text = MusicsList[0].ToString();
            }
        }
        #endregion

        #region Side Panel Buttons
        // Clicking in Logo
        private void Logolabel_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            mainPanel.Enabled = false;
        }

        // Open/Close playlistPanel
        private void ButtonPlaylists_Click(object sender, EventArgs e)
        {
            panelPlaylists.Visible = !panelPlaylists.Visible;
            panelPlaylists.Height = (panelPlaylists.Controls.Count * 50) + 1;
        }

        // Open/Close editPanel
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = !panelEdit.Visible;
            panelEdit.Height = (panelEdit.Controls.Count * 50) + 1;
        }
        
        // Open in default browser the link of my site
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

        #region SubPanel Buttons
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
                MessageBox.Show("O programa vai reiniciar agora", "Reinicialização necessária");
                Restart();
            }
        }

        // Remove folder from library
        private void RemoveFolderButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Pasta a ser removida da biblioteca";
            var dialog = folderBrowserDialog1.ShowDialog();

            if (dialog.Equals(DialogResult.OK))
            {
                var removedDir = folderBrowserDialog1.SelectedPath;

                if (!Search.additionalFolders.Contains(removedDir) && !Search.DefaultPaths.Contains(removedDir))
                {
                    MessageBox.Show("Essa pasta não está na biblioteca para ser removida",
                        "Pasta não existe");
                    return;
                }

                Search.additionalFolders.Remove(removedDir);
                MessageBox.Show("O programa vai reiniciar agora", "Reinicialização necessária");
                Restart();
            }
        }

        // Show main Playlist, all musics
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
        #endregion

        #region Player Buttons
        // Play Stop actual music
        public void PlayStopButtonClick(object sender, EventArgs e)
        {
            _isPlaying = !_isPlaying;

            PlayStopLabel.Image = _isPlaying ? Properties.Resources.pause_64px : Properties.Resources.play_64px;

            try
            {
                _actualMusic = MusicsList[_actualIndex];
            } catch
            {
                _actualIndex = 0;
                _actualMusic = MusicsList[0];
                _currentPosition = 0;
            }

            _actualMusic.Volume(_actualVolume);
            _actualMusic.Rate(_rate);
            _actualMusic.CurrentPosition = _currentPosition;
            
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

            for(var i = 0; i < AllMusicsForm.INSTANCE.listBox.Items.Count; i++)
                AllMusicsForm.INSTANCE.listBox.SetSelected(i, false);

            labelActualMusic.Text = _actualMusic.ToString();
        }

        // Return 10 seconds
        private void GoBack_Click(object sender, EventArgs e)
        {
            var isP = _isPlaying;

            if(_currentPosition <= 10)
            {
                _currentPosition = 0;
                progressBar.Value = 0;

                if (isP)
                    PlayStopButtonClick(sender, e);

            } else {
                _currentPosition -= 10;
                progressBar.Value -= 10;

                if (isP)
                    PlayStopButtonClick(sender, e);
            }

            if (isP)
                PlayStopButtonClick(sender, e);

            timeProgressLabel.Text = Util.FormatNumber(_currentPosition);
        }

        // Go to start or go to previous 
        private void GoToStart_Click(object sender, EventArgs e)
        {
            timer.Stop();
            _currentPosition = 0;

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
            _currentPosition = 0;

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

        // Advance 10 seconds
        private void Advance_Click(object sender, EventArgs e)
        {
            var isP = _isPlaying;

            if (_currentPosition + 10 >= _lastDuration)
            {
                _currentPosition = _lastDuration - 1;
                progressBar.Value = _lastDuration - 1;

                if (isP)
                    PlayStopButtonClick(sender, e);
                return;
            } else
            {
                _currentPosition += 10;
                progressBar.Value += 10;

                if (isP)
                    PlayStopButtonClick(sender, e);
            }

            if (isP)
                PlayStopButtonClick(sender, e);

            timeProgressLabel.Text = Util.FormatNumber(_currentPosition);
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
            SpeedoMeter.Text = $"{_rate}x";

            if(wasEn) timer.Start();
        }
        #endregion

        #region Derive methods
        // Update progressBar
        private void TimerTick(object sender, EventArgs e)
        {
            if (_actualMusic == null)
                return;

            if (progressBar.Value + _rate > progressBar.Maximum)
            {
                GoToNextMusic_Click(sender, e);
                return;
            }
                
            progressBar.Value += _rate;
            _currentPosition = progressBar.Value;
            timeProgressLabel.Text = Util.FormatNumber(progressBar.Value);

            if (progressBar.Maximum != _actualMusic.Duration)
            {
                _lastDuration = _actualMusic.Duration;
                progressBar.Maximum = _actualMusic.Duration;
                totalDurationTime.Text = Util.FormatNumber((int)_actualMusic.Player.currentMedia.duration);

                Console.Write($"Música: {_actualMusic}, ");
                Console.WriteLine($"duração total: {_actualMusic.Player.currentMedia.durationString}");
                Console.WriteLine($"Volume: {_actualVolume}");
            }

            progressBar.Refresh();
            progressBar.Update();
        }
        
        // Turn off all forms
        private void TurnOffAllForms()
        {
            foreach (var form in Forms)
            {
                form.Visible = false;
                form.Enabled = false;
            }
        }

        // Turn off all forms and activate the excepted Form
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
        #endregion

        #region In Class methods
        // Restart Application
        private void Restart()
        {
            Application.Restart();
        }

        // When closing save data
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Saver.SaveFile();
        }
        #endregion   
    }
}
