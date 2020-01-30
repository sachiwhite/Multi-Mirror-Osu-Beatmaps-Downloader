using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MultiMirrorOsuBeatmapsDownloader.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiMirrorOsuBeatmapsDownloader.Tests
{
    [TestClass]
    public class FtpParserTests
    {
        [TestMethod]
        public void ReturnsNothingWhenPassedNull()
        {
            Mock<IFtpLoader> mock = new Mock<IFtpLoader>();
            mock.Setup(m => m.GetContent()).Returns(Task.FromResult(File.ReadAllText("ftpData")));
            FtpParser ftpParser = new FtpParser(mock.Object);
            ftpParser.Parse(null);
            var expected = new List<Model.SongsInfo>();
            var actual = ftpParser.RetrieveSongsList();
            CollectionAssert.AreEquivalent(expected, actual);
        }
       
        [TestMethod]
        public void ReturnTwoParticularSongs()
        {
            Mock<IFtpLoader> mock = new Mock<IFtpLoader>();
            mock.Setup(m => m.GetContent()).Returns(Task.FromResult(File.ReadAllText("ftpData")));
            FtpParser ftpParser = new FtpParser(mock.Object);
            ftpParser.Parse("DISCO");
            var expected = new[]
            {
                new {
                    Title="Kenji Ninuma - DISCO★PRINCE.osz",
                    LinkToThumbnail = "//b.ppy.sh/thumb/1l.jpg",
                    DownloadLink = "ftp//gildiagrzybiarzy.pl/osu!/1 Kenji Ninuma - DISCO★PRINCE.osz.osz"
                    },
                 new {
                     Title="Pastel-Palettes - DISCOTHEQUE.osz",
                     LinkToThumbnail = "//b.ppy.sh/thumb/919813l.jpg",
                    DownloadLink ="ftp//gildiagrzybiarzy.pl/osu!/919813 Pastel-Palettes - DISCOTHEQUE.osz.osz"
                 }
 
            };
        var parsedSongs = ftpParser.RetrieveSongsList();
        var songsToCompare = parsedSongs.Select(data =>
        new
        {
            data.Title,
            data.LinkToThumbnail,
            data.DownloadLink
        }).ToArray();
       CollectionAssert.AreEquivalent(expected, songsToCompare) ;


        }
}
}
