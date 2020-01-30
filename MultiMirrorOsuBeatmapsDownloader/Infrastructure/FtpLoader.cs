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
        private readonly string ftp_data_path = "ftpData";
        private async Task<bool> CheckIfFTPContentChanged()
        {
            if (!File.Exists(ftp_data_path)) 
                return true;

            var new_response = await GetFtpResponse(FtpRequestType.Timestamp);
            var former_response = File.ReadAllLines(ftp_data_path)[0];

            if (new_response.LastModified.ToString() == former_response) 
                return false;
            else
            {
                using (StreamWriter writer = new StreamWriter(ftp_data_path, false))
                {
                    writer.WriteLine(new_response.LastModified.ToString());
                }
                return true;
            }
        }
        private FtpWebRequest GetFtpRequest(FtpRequestType ftpRequestType )
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://gildiagrzybiarzy.pl/osu!");
            request.Credentials = Credentials.ReturnCredentials();
            switch (ftpRequestType)
            {
                case FtpRequestType.ListDirectory:
                    { request.Method = WebRequestMethods.Ftp.ListDirectory; }break;
                case FtpRequestType.Timestamp:
                    request.Method = WebRequestMethods.Ftp.GetDateTimestamp; break;
                default:
                    break;
            }
            return request;
        }
        public async Task<string> GetContent()
        {
            StreamReader reader;
            if(await CheckIfFTPContentChanged())
            {
                var response = await GetFtpResponse(FtpRequestType.ListDirectory);
                var responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream);
                using (StreamWriter writer = new StreamWriter(ftp_data_path,true))
                {
                    while (!reader.EndOfStream)
                    {
                        writer.WriteLine(reader.ReadLine());
                    }
                }

            }
            else
            {
                reader = new StreamReader(ftp_data_path);
            }
            return await reader.ReadToEndAsync();
        }

        private async Task<FtpWebResponse> GetFtpResponse(FtpRequestType ftpRequestType)
        {
            var request = GetFtpRequest(ftpRequestType);
            var response = await request.GetResponseAsync();
            return response as FtpWebResponse;
            
        }
    }
}
