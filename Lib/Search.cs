using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace LiMusicPlayer.Lib
{
    internal sealed class Search
    {
        public static string UserName => Environment.UserName;
        public static string HDName => Environment.GetLogicalDrives()[0];
        public static List<string> additionalFolders = new List<string>();

        private static string DefaultPathRoot => $"{HDName}Users\\{UserName}\\";

        // Default Paths
        private static string Path1 => $"{DefaultPathRoot}Documents";
        private static string Path2 => $"{DefaultPathRoot}Downloads";
        private static string Path3 => $"{DefaultPathRoot}Music";
        private static string Path4 => $"{DefaultPathRoot}Videos";
        private static string Path5 => $"{DefaultPathRoot}OneDrive\\Documents";
        private static string Path6 => $"{DefaultPathRoot}OneDrive\\Music";
        private static string Path7 => $"{DefaultPathRoot}OneDrive\\Videos";
        
        public static List<string> GetMusicsPaths()
        {
            var directories = GetDirectories();
            var musicsPaths = new List<string>();

            for (var i = 0; i < directories.Count; i++)
            {
                var dir = directories[i];

                if (!Directory.Exists(dir)) 
                    continue;

                var filesInDir = Directory.EnumerateFiles(dir);
                
                for (var j = 0; j < filesInDir.Count(); j++)
                {
                    var file = filesInDir.ElementAt(j);
                   
                    if(file.EndsWith(".mp3") || file.EndsWith(".wav"))
                        musicsPaths.Add(file);
                }                
            }

            return musicsPaths;
        }

        private static List<string> GetDirectories() 
        {
            var directories = DefaultPaths;

            if(additionalFolders.Any())
                directories.AddRange(additionalFolders);

            return directories;
        }

        public static List<string> DefaultPaths => new List<string>()
        {
            Path1, Path2, Path3, Path4,
            Path5, Path6, Path7,
        };
    }
}
