using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PairingTest.Unit.Tests.Stubs
{
    public class TestHttpMessageHandler : HttpMessageHandler
    {
        readonly HttpResponseMessage responseMessage;

        public TestHttpMessageHandler(HttpResponseMessage responseMessage)
        {
            this.responseMessage = responseMessage;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(responseMessage);
        }
    }
}
