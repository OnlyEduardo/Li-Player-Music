using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LiMusicPlayer.Lib
{
    [Serializable]
    public class SaveData
    {
        public List<string> _additionalFolders;
        public int _indexOfLastMusic;
        public int _volumeOfLastMusic;
        public int _lastDuration;
        public int _currentPosition;
        public string _durationlabel;
        public FormWindowState _windowsState;
    }
}
