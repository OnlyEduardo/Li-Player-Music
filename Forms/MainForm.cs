using LiMusicPlayer.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

        // Private vars
        private int _mousePos = 0;

        // Colors
        private readonly Color _normalButtonColor = Color.FromArgb(17, 5, 17);
        private readonly Color _selectedButtonColor = Color.Indigo;

        // Declaration of external forms
        private readonly AllMusicsForm _allMusicsForm = new AllMusicsForm();
        private readonly LibraryForm _libraryForm = new LibraryForm();
        private readonly PlaylistForm _playlistForm = new PlaylistForm();

        public MainForm()
        {
            if(INSTANCE == null)
                INSTANCE = this;

            InitializeComponent();
            AddToolTipsForLabels();
            PopulateButtonsList();

            Saver.LoadFile();

            PopulateFormsList();
            HideAllExternalForms();
            InitializeMusicsList();
            SetLoadedData();

            // Load Form Initializators
            AllMusicsForm.INSTANCE.PopulateListOfAllMusic();
            LibraryForm.INSTANCE.PopulateListOfFolders();
        }

        public List<Playlist> Playlists { get; } = new List<Playlist>();
        public List<Music> MusicsList { get; } = new List<Music>();
        public List<Form> Forms { get; } = new List<Form>();
        public List<Button> Buttons { get; } = new List<Button>();

        #region InitializeSystem
        // Set tooltips for player buttons
        private void AddToolTipsForLabels()
        {
            ToolTip toolTip = new ToolTip
            {
                InitialDelay = 1500
            };

            toolTip.SetToolTip(LoopMusic, "Ativa/Desativa o looping da música atual.");
            toolTip.SetToolTip(GoBack, "Volta 10 segundos na música atual.");
            toolTip.SetToolTip(GoToStart, "Volta ao inicio da música, caso esteja no inicio, volta para a música anterior.");
            toolTip.SetToolTip(PlayStopLabel, "Inicia/Pausa música atual.");
            toolTip.SetToolTip(GoToNextMusic, "Vai para a próxima música.");
            toolTip.SetToolTip(Advance, "Avança 10 segundo na música atual.");
            toolTip.SetToolTip(ShuffleMusic, "Toca as músicas em ordem aleatória");
            toolTip.SetToolTip(SpeedoMeter, "Acelera música até 4 vezes.");
        }

        // Populate the buttons list
        private void PopulateButtonsList()
        {
            Buttons.Add(buttonAllMusics);
            Buttons.Add(buttonPlaylists);
            Buttons.Add(buttonLibrary);
        }

        // Add external forms to list
        private void PopulateFormsList()
        {
            Forms.Add(_allMusicsForm);
            Forms.Add(_libraryForm);
            Forms.Add(_playlistForm);
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
            timer.Stop();

            if(MusicsList.Count <= 0)
            {
                labelActualMusic.Text = "";
                progressBar.Value = 0;
                progressBar.Maximum = 100;
                timeProgressLabel.Text = Util.FormatNumber(0);
                return;
            }

            try
            {
                labelActualMusic.Text = MusicsList[_actualIndex].ToString();
                progressBar.Maximum = _lastDuration;
                progressBar.Value = _currentPosition;
                timeProgressLabel.Text = Util.FormatNumber(_currentPosition);            
            } catch (ArgumentOutOfRangeException) {
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
            TurnOffAllForms();
        }

        // Show main Playlist, all musics
        private void ShowAllMusics_Click(object sender, EventArgs e)
        {
            Util.ActiveDeactivePanelAndForm(mainPanel, _allMusicsForm);
            ButtonStyle(buttonAllMusics);
        }

        // Show playlists
        private void ButtonPlaylists_Click(object sender, EventArgs e)
        {
            Util.ActiveDeactivePanelAndForm(mainPanel, _playlistForm);
            ButtonStyle(buttonPlaylists);
        }

        // Open/Close library panel
        private void ButtonLibrary_Click(object sender, EventArgs e)
        {
            Util.ActiveDeactivePanelAndForm(mainPanel, _libraryForm);
            ButtonStyle(buttonLibrary);
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

        #region Player Buttons
        // Play Stop actual music
        public void PlayStopButtonClick(object sender, EventArgs e)
        {
            if (IsMusicListVoided()) return;
           
            _isPlaying = !_isPlaying;

            PlayStopLabel.Image = _isPlaying ? Properties.Resources.pause_64px : Properties.Resources.play_64px;

            try
            {
                _actualMusic = MusicsList[_actualIndex];
            }
            catch
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

            for (var i = 0; i < AllMusicsForm.INSTANCE.listBox.Items.Count; i++)
                AllMusicsForm.INSTANCE.listBox.SetSelected(i, false);

            labelActualMusic.Text = _actualMusic.ToString();
        }

        // Return 10 seconds
        private void GoBack_Click(object sender, EventArgs e)
        {
            if (IsMusicListVoided()) return;

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
            if (IsMusicListVoided()) return;

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
            if (IsMusicListVoided()) return;

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
            if (IsMusicListVoided()) return;

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
            if (IsMusicListVoided()) return;

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
        public void TurnOffAllForms()
        {
            foreach (var form in Forms)
            {
                form.Visible = false;
                form.Enabled = false;
            }
        }

        // Turn off all forms and activate the excepted Form
        public void TurnOnFormAndCloseOthers(Form exceptedForm)
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

        // When closing save data
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Saver.SaveFile();
        }

        // Set button color
        private void ButtonStyle(Button button)
        {
            foreach (var btn in Buttons)
            {
                if (button.Equals(btn))
                {
                    button.BackColor = button.BackColor.Equals(_selectedButtonColor)
                           ? _normalButtonColor
                           : _selectedButtonColor;
                }
                else
                {
                    btn.BackColor = _normalButtonColor;
                }
            }
        }

        // When Mouse click in progress bar
        private void ClickedInProgressBar(object sender, EventArgs e)
        {
            var isP = _isPlaying;

            if (isP)
                PlayStopButtonClick(sender, e);

            var pos = GetMouseConverted();

            _currentPosition = pos;
            progressBar.Value = pos;
            timeProgressLabel.Text = Util.FormatNumber(pos);

            if (isP)
                PlayStopButtonClick(sender, e);
        }

        // Update mouse position
        private void UpdateMousePosition_MouseMove(object sender, MouseEventArgs e)
        {
            _mousePos = e.X;
        }

        // Get mouse position converted to progress bar units
        private int GetMouseConverted()
        {
            var maxVal = progressBar.Maximum;

            var relativePos = (100 * progressBar.Width) / maxVal;
            var result = (100 * _mousePos) / relativePos;

            if (result >= maxVal)
                result = maxVal - 1;
            else if (result <= progressBar.Minimum)
                result = progressBar.Minimum + 1;

            return result;
        }

        // Verifica se a lista de músicas está vazia
        private bool IsMusicListVoided()
        {
            if (MusicsList.Count <= 0)
            {
                MessageBox.Show("Nenhuma música foi encontrada, tente adicionar em bibliotecas",
                    "Nenhuma música encontrada");
                return true;
            }

            return false;
        }
    }
}
