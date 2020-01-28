using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using MultiMirrorOsuBeatmapsDownloader.Infrastructure;
using MultiMirrorOsuBeatmapsDownloader.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiMirrorOsuBeatmapsDownloader.Tests
{
    [TestClass]
    public class BloodcatParserTests
    {
        [TestMethod]
        public async Task ParserReturnsFourBeatmaps()
        {
            string path = "mocksite";
            IWebsiteLoader loader = new MockWebsiteLoader();
            BloodcatParser parser = new BloodcatParser(loader);
            await parser.Parse(path);
            var parsedSongs = parser.RetrieveSongsList();
            var songsToCompare = parsedSongs.Select(data =>
            new
            {
                data.Title,
                data.LinkToThumbnail,
                data.DownloadLink
            }).ToArray();
            var actualSongs = new[]
            {
                new {Title = "Carly Rae Jepsen - Call Me Maybe (Nightcore Mix)", LinkToThumbnail="//b.ppy.sh/thumb/60927l.jpg",DownloadLink="https://bloodcat.com/osu/s/60927" },
                new {Title = "Freda - Maybe (Tronix DJ Remix) (Nightcore Mix)", LinkToThumbnail="//b.ppy.sh/thumb/289235l.jpg", DownloadLink="https://bloodcat.com/osu/s/289235" },
                new {Title = "Various Artists - Nightcore Mix Compilation", LinkToThumbnail="//b.ppy.sh/thumb/89289l.jpg", DownloadLink="https://bloodcat.com/osu/s/89289" },
                new {Title = "Carly Rae Jepsen - Call Me Maybe (Nightcore Mix)", LinkToThumbnail="//b.ppy.sh/thumb/56071l.jpg", DownloadLink="https://bloodcat.com/osu/s/56071"}
            };
            //var test1 = actualSongs[0];
            //var test2 = songsToCompare[0];
            //var test3 = new SongsInfo("a","a","a");
            //var test4 = new SongsInfo("a","a","a");
            //Assert.(test3, test4);
            CollectionAssert.AreEquivalent(actualSongs, songsToCompare);

        }
    }
}
