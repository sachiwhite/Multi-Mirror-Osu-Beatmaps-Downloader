using MultiMirrorOsuBeatmapsDownloader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    public class SongSearcher
    {
        private readonly IParser websiteParser;
        public SongSearcher(IParser websiteParser)
        {
            this.websiteParser = websiteParser;
        }
        public Task<List<SongsInfo>> ReturnListOfSongs()
        {
            throw new NotImplementedException();
          //  return websiteParser.ParseWebsite(query);
        }



    }
}
