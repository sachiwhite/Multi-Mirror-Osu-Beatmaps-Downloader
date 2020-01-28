using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    public interface IFtpLoader
    {
        Task<FtpWebResponse> LoadWebsite(string query);
        Task<string> GetContent(string query);
    }
}
