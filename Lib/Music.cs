using WMPLib;

namespace LiMusicPlayer.Lib
{
    public sealed class Music
    {
        public Music(string path)
        {
            Path = path;
            Player.URL = Path;
            Player.controls.stop();
        }

        public string Path { get; }

        public WindowsMediaPlayer Player { get; } = new WindowsMediaPlayer();
        public double CurrentPosition { get; set; }
        public int Duration
        {
            get
            {
                var time = Player.currentMedia.durationString;

                var p1 = time.Split(':')[0];
                var p2 = time.Split(':')[1];

                return (int.Parse(p1) * 60) + int.Parse(p2);
            }
        }

        public void Play()
        {
            Player.PlayStateChange += PlayerPlayStateChange;
            Player.MediaError += PlayerMediaError;

            Player.controls.currentPosition = CurrentPosition;
            Player.controls.play();
        }

        public void Stop()
        {
            CurrentPosition = Player.controls.currentPosition;
            Player.controls.stop();
        }

        public void Volume(int vol)
        {
            if (vol > 100 || vol < 0 || Player == null)
                return;

            Player.settings.volume = vol;
        }

        public override string ToString()
        {
            var parts = Path.Split('\\');
            var name = parts[parts.Length - 1];

            if (name.EndsWith(".mp3"))
                return name.Replace(".mp3", "");
            else if (name.EndsWith(".wav"))
                return name.Replace(".wav", "");
            else
                return name;
        }

        // Modification States
        private void PlayerPlayStateChange(int NewState)
        {
            if ((WMPPlayState) NewState == WMPPlayState.wmppsStopped)
                Player.controls.stop();
        }
        private void PlayerMediaError(object pMediaObject)
        {
            Player.controls.stop();
        }
    }
}
