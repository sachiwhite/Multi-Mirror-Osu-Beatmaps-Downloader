using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiMirrorOsuBeatmapsDownloader.Model;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    class BeatConnectParser : IWebsiteParser
    {
        private List<SongsInfo> songsParsed;
        private readonly IWebsiteLoader websiteLoader;
        public Task ParseWebsite(string html)
        {

            throw new NotImplementedException();
        }

        public List<SongsInfo> RetrieveSongsList()
        {
            return songsParsed;
        }
    }
}
