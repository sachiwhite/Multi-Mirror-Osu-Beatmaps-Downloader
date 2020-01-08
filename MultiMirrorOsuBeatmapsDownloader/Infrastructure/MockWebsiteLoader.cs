using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    class MockWebsiteLoader : IWebsiteLoader
    {
        public Task<HttpResponseMessage> LoadWebsite(string query)
        {
            throw new NotImplementedException();
        }
    }
}
