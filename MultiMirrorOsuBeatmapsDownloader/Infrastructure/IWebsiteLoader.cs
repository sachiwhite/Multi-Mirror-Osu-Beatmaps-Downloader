using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    public interface IWebsiteLoader
    {
        Task<HttpResponseMessage> LoadWebsite(string query);
    }
}
