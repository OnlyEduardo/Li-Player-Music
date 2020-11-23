using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiMusicPlayer.Lib
{
    public sealed class Playlist
    {
        public Playlist(string pName, List<Music> iMusics)
        {
            PName = pName;
            IMusics = iMusics;
        }

        public string PName { get; }
        public List<Music> IMusics { get; }
    }
}
