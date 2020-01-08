using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiMirrorOsuBeatmapsDownloader
{
    public static class Messaging
    {
        public static async Task Report(string message, string title)
        {
            MessageBox.Show(message, title);
        }

    }
}
