using NUnit.Framework;
using PairingTest.Unit.Tests.Stubs;
using PairingTest.Web;
using System.Net;
using System.Net.Http;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class HttpClientWrapperTests
    {

        [Test]
        public void CallingGet()
        {
            // Arrange
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Response from API")
            };
            var responseHandler = new TestHttpMessageHandler(responseMessage);
            var httpClient = new HttpClient(responseHandler);

            var httpClientWrapper = new HttpClientWrapper(httpClient);

            //Act 
            var result = httpClientWrapper.Get("http://localhost/testAddress");

            // Assert
            Assert.That(result, Is.EqualTo(responseMessage.Content.ReadAsStringAsync().Result));
        }
    }
}
