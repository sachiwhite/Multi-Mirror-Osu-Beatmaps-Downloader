using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiMirrorOsuBeatmapsDownloader.Infrastructure;
using Testing;
using Testing.HttpClient;
//using Testing.HttpClient.UnitTests;

namespace MultiMirrorOsuBeatmapsDownloader.Tests
{
    [TestClass]
    public class WebsiteLoaderTests
    {
        [TestMethod]
        public async Task CheckIfWebsiteLoaded()
        {
            IWebsiteLoader websiteLoader = new WebsiteLoader();
            var request = await websiteLoader.LoadWebsite("https://bloodcat.com/osu/?q=freedom%20dive&c=b&s=&m=&g=&l=");
            var toCompare = new HttpResponseMessage();
            toCompare.StatusCode = HttpStatusCode.OK;
            Assert.AreEqual(toCompare.StatusCode, request.StatusCode);
        }
        [TestMethod]
        public async Task CheckIfError()
        {
            IWebsiteLoader websiteLoader = new WebsiteLoader();
            var request = await websiteLoader.LoadWebsite("https://bloodcat.com/osu/?q=freedom%20dive&c=b&s=&m=&g=&l=");
            Assert.AreEqual(null, request);
        }
    }
}
