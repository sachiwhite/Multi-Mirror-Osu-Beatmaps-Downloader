using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiMirrorOsuBeatmapsDownloader.Infrastructure
{
    public class MockWebsiteLoader : IWebsiteLoader
    {
        public async Task<string> GetPageContent(string query)
        {
            var response = await LoadWebsite(query);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        /// <summary>
        /// Mock method for loading website. It provides mocked HttpResponseMessage (always OK), and the website is loaded from file
        /// </summary>
        /// <param name="query">Path to saved HTML file.</param>
        /// <returns>Mocked HttpResponseMessage</returns>
        public Task<HttpResponseMessage> LoadWebsite(string query)
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
                   Content = new StringContent(File.ReadAllText(query))
               })
               .Verifiable();
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };

            return httpClient.GetAsync("http://test.com/api/test/whatever");
        }
    }
}
