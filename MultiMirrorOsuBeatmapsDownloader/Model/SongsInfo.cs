using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiMirrorOsuBeatmapsDownloader.Model
{
    public class SongsInfo
    {
        public SongsInfo(string title, string linkToThumbnail, string downloadLink) 
        {
            Title = title;
            LinkToThumbnail = linkToThumbnail;
            DownloadLink = downloadLink;
        }

        public string Title { get; private set; }
        public string LinkToThumbnail { get; private set; }
        public string DownloadLink { get; private set; }
        //public int BeatmapNumber { get; private set; }
    }
}
