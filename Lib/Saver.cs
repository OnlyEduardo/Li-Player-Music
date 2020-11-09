using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LiMusicPlayer.Lib
{
    public sealed class Saver
    {
        private static readonly string folderToData = $"{Search.HDName}Users\\Public\\LMPlayer";

        public static void SaveFile()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Path.Combine(folderToData, "dataconfig.dat"));

            SaveData save = new SaveData
            {
                additionalFolders = Search.additionalFolders,
                indexOfLastMusic = MainForm.actualIndex,
                VolumeOfLastMusic = Music._volume
            };

            bf.Serialize(file, save);
            file.Close();
        }

        public static void LoadFile()
        {
            if (!File.Exists(Path.Combine(folderToData, "dataconfig.dat")))
                return;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Path.Combine(folderToData, "dataconfig.dat"), FileMode.Open);

            SaveData save = (SaveData) bf.Deserialize(file);
            file.Close();

            Search.additionalFolders = save.additionalFolders;
            MainForm.actualIndex = save.indexOfLastMusic;
            Music._volume = save.VolumeOfLastMusic;
        }
    }

    [Serializable]
    public class SaveData
    {
        public List<string> additionalFolders;
        public int indexOfLastMusic;
        public int VolumeOfLastMusic;
    }
}
