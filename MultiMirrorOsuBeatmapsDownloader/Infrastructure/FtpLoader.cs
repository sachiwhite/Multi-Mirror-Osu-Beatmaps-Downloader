using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CredLib;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    
    public class FtpLoader : IFtpLoader
    {

        public async Task<string> GetContent(string query)
        {
            var response = await LoadWebsite(query);
            var responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            return await reader.ReadToEndAsync();
        }

        public async Task<FtpWebResponse> LoadWebsite(string query)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://gildiagrzybiarzy.pl/osu!");
            request.Credentials = Credentials.ReturnCredentials();
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            var response = await request.GetResponseAsync();
            return response as FtpWebResponse;
            
            
        }
    }
}
