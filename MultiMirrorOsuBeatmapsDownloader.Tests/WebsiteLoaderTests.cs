using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
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
        [TestMethod]
        public async Task CheckEmptyString()
        {
            IWebsiteLoader websiteLoader = new WebsiteLoader();
            var request = await websiteLoader.LoadWebsite(string.Empty);
            Assert.AreEqual(null, request);
        }
        [TestMethod]
        public async Task CheckNonsenseString()
        {
            IWebsiteLoader websiteLoader = new WebsiteLoader();
            var request = await websiteLoader.LoadWebsite("a3rni3r");
            Assert.AreEqual(null, request);
        }
        [TestMethod]
        public async Task CheckNullString()
        {
            IWebsiteLoader websiteLoader = new WebsiteLoader();
            var request = await websiteLoader.LoadWebsite(null);
            Assert.AreEqual(null, request);
        }
        [TestMethod]
        public async Task CompareMockAndRealValue()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(File.ReadAllText("mocksite.html")),
               })
               .Verifiable();

        }
        public async Task MockingTest()
        {
           
        }
    }
}
