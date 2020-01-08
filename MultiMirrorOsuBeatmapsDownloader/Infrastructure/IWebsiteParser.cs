using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiMirrorOsuBeatmapsDownloader.Model;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    public interface IWebsiteParser
    {

       List<SongsInfo> RetrieveSongsList(string query);
    }
}
