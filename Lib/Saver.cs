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

        public static void SaveFile()
        {
            var bf = new BinaryFormatter();

            if (!Directory.Exists(folderToData))
                Directory.CreateDirectory(folderToData);

            FileStream file;

            try
            {
                file = File.Create(Path.Combine(folderToData, "dataconfig.dat"));
            }
            catch { return; }
            
            var save = new SaveData
            {
                _additionalFolders = Search.additionalFolders,
                _indexOfLastMusic = MainForm.INSTANCE.actualIndex,
                _volumeOfLastMusic = MainForm.INSTANCE.actualVolume,
                _durationlabel = Util.FormatNumber(MainForm.INSTANCE.actualMusic == null ? 0 
                                                : (int)MainForm.INSTANCE.actualMusic.Player.currentMedia.duration),
            };

            bf.Serialize(file, save);
            file.Close();
        }

        public static void LoadFile()
        {
            if (!File.Exists(Path.Combine(folderToData, "dataconfig.dat")))
                return;

            var bf = new BinaryFormatter();
            var file = File.Open(Path.Combine(folderToData, "dataconfig.dat"), FileMode.Open);

            SaveData save;

            try
            {
                 save = (SaveData)bf.Deserialize(file);
            } catch { return; }
            
            file.Close();

            Search.additionalFolders = save._additionalFolders;
            MainForm.INSTANCE.actualIndex = save._indexOfLastMusic;
            MainForm.INSTANCE.actualVolume = save._volumeOfLastMusic;
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
