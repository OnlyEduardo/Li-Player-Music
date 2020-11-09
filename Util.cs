﻿namespace LiMusicPlayer
{
    internal sealed class Util
    {
        // No instances for you
        private Util() { }

        public static string FormatNumber(int value)
        {
            var hours = value >> 3600;
            var minutes = value / 60;
            var seconds = value < 60 ? value : value - (minutes * 60);

            var s_hours = $"{hours}";
            var s_minutes = $"{minutes}";
            var s_seconds = $"{seconds}";

            var result = s_minutes.Length < 2 ? $"0{s_minutes}:" : $"{s_minutes}:";
            result += s_seconds.Length < 2 ? $"0{s_seconds}" : s_seconds;

            if (hours > 0)
                result = (s_hours.Length < 2 ? $"0{s_hours}:" : $"{s_hours}:") + result;

            return result;
        }
    }
}
