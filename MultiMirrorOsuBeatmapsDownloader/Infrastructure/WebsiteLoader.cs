using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    public class WebsiteLoader : IWebsiteLoader
    {
        public async Task<HttpResponseMessage> LoadWebsite(string query)
        {
            HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetAsync(query);
                return response;
            }
            catch(InvalidOperationException)
            {
                Messaging.Report("Podany adres jest nieprawidłowy!", "Błąd");
            }
            catch (HttpRequestException ex)
            {
                if(ex.InnerException is WebException w) 
                Messaging.Report($"Błąd połączenia ze stroną WWW: {w.Message}", $"Błąd {w.Status}");
            }
           
            return null;
        }
        private string PrepareLink(string query)
        {
            throw new NotImplementedException();
        }
        public async Task<string> GetPageContent(string query)
        {
            var addressToLoadFrom = PrepareLink(query);
            var response = await LoadWebsite(addressToLoadFrom);
            var content = await response.Content.ReadAsStringAsync();
            return content;

        }
    }
}
