using LiMusicPlayer.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

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
                _lastDuration = MainForm.INSTANCE._lastDuration,
                _currentPosition = MainForm.INSTANCE._currentPosition,

                _durationlabel = Util.FormatNumber(MainForm.INSTANCE._actualMusic == null 
                ? 0
                : (int)MainForm.INSTANCE._actualMusic.Player.currentMedia.duration),

                _windowsState = MainForm.INSTANCE.WindowState,
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
            } catch {
                MessageBox.Show("Ocorreu um erro grave, não foi possivel acessar as informações salvas",
                    "Erro grave");
                return; 
            }
            
            file.Close();

            // Apply saved infos
            Search.additionalFolders = save._additionalFolders;
            MainForm.INSTANCE._actualIndex = save._indexOfLastMusic;
            MainForm.INSTANCE._actualVolume = save._volumeOfLastMusic;
            MainForm.INSTANCE._lastDuration = save._lastDuration;
            MainForm.INSTANCE._currentPosition = save._currentPosition;
            MainForm.INSTANCE.totalDurationTime.Text = save._durationlabel;
            MainForm.INSTANCE.WindowState = save._windowsState;
        }
    }
}
