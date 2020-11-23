using LiMusicPlayer.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace LiMusicPlayer.Lib
{
    public sealed class Saver
    {
        private static readonly string folderToData = $"{Search.HDName}Users\\Public\\LMPlayer";
        private static readonly string archiveName = "dataconfig.dat";

        public static void SaveFile()
        {
            var bf = new BinaryFormatter();

            if (!Directory.Exists(folderToData))
                Directory.CreateDirectory(folderToData);

            FileStream file;

            try
            {
                file = File.Create(Path.Combine(folderToData, archiveName));
            }
            catch { return; }
            
            var save = new SaveData
            {
                _additionalFolders = Search.additionalFolders,
                _indexOfLastMusic = MainForm.INSTANCE._actualIndex,
                _volumeOfLastMusic = MainForm.INSTANCE._actualVolume,
                _durationlabel = Util.FormatNumber(MainForm.INSTANCE._actualMusic == null ? 0 
                                                : (int)MainForm.INSTANCE._actualMusic.Player.currentMedia.duration),
            };

            bf.Serialize(file, save);
            file.Close();
        }

        public static void LoadFile()
        {
            if (!File.Exists(Path.Combine(folderToData, archiveName)))
                return;

            var bf = new BinaryFormatter();
            var file = File.Open(Path.Combine(folderToData, archiveName), FileMode.Open);

            SaveData save;

            try
            {
                 save = (SaveData)bf.Deserialize(file);
            } catch { return; }
            
            file.Close();

            Search.additionalFolders = save._additionalFolders;
            MainForm.INSTANCE._actualIndex = save._indexOfLastMusic;
            MainForm.INSTANCE._actualVolume = save._volumeOfLastMusic;
            MainForm.INSTANCE.totalDurationTime.Text = save._durationlabel;
        }
    }

    [Serializable]
    public class SaveData
    {
        public List<string> _additionalFolders;
        public int _indexOfLastMusic;
        public int _volumeOfLastMusic;

        public string _durationlabel;
    }
}
