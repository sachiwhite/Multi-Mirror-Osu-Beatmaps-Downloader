using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using MultiMirrorOsuBeatmapsDownloader.Model;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    public class BloodcatParser : IParser
    {
        private readonly IWebsiteLoader websiteLoader;

        public List<SongsInfo> SongsList 
        {
            get;
            private set;
        }

        public BloodcatParser(IWebsiteLoader websiteLoader)
        {
            this.websiteLoader = websiteLoader as IWebsiteLoader;
            SongsList = new List<SongsInfo>();
        }
        public async Task Parse(string html)
        {
            
            var contentToParse = await websiteLoader.GetPageContent(html);
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(contentToParse);
            var node = htmlDoc.DocumentNode.SelectNodes("//a[@href]");
            foreach (var n in node)
            {
                if (n.Attributes.Count < 2) continue;
                else
                {
                    string address = n.Attributes[1].Value;
                    string name = n.InnerHtml;
                    Regex regex = new Regex(@"^s/\d");
                    Match match = regex.Match(address);

                    if (match.Success)
                    {
                        string mapNumber = new string(address.Skip(2).ToArray());
                        string thumbnailAddress = $"//b.ppy.sh/thumb/{mapNumber}l.jpg";
                        address = "https://bloodcat.com/osu/" + address;
                        SongsInfo infoToAdd = new SongsInfo(name, thumbnailAddress, address);
                        SongsList.Add(infoToAdd);
                    }
                }
            }
        }
        public List<SongsInfo> RetrieveSongsList()
        {
            return SongsList;
        }
    }
}
