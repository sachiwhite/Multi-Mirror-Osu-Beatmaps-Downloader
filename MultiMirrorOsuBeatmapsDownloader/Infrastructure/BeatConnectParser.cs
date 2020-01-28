using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiMirrorOsuBeatmapsDownloader.Model;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    class BeatConnectParser : IParser
    {
        private List<SongsInfo> songsParsed;
        private readonly IWebsiteLoader websiteLoader;

        public List<SongsInfo> SongsList => throw new NotImplementedException();

        public Task Parse(string html)
        {

            throw new NotImplementedException();
        }

        public List<SongsInfo> RetrieveSongsList()
        {
            return songsParsed;
        }
    }
}
