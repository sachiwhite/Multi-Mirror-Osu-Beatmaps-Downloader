using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiMirrorOsuBeatmapsDownloader.Model;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    public interface IParser
    {
        List<SongsInfo> SongsList { get;}
        Task Parse(string query);
       List<SongsInfo> RetrieveSongsList();
    }
}
