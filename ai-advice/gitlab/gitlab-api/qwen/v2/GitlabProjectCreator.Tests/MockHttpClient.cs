using System.Net.Http;
using System.Threading.Tasks;

public class MockHttpClient : HttpClient
{
    public bool WasCalled { get; private set; }
    public HttpResponseMessage LastResponse { get; private set; }

    public void SetupGet(string url, HttpResponseMessage response)
    {
        this.SendAsyncFunc = (request, _) =>
        {
            if (request.RequestUri.ToString() == url && request.Method == HttpMethod.Get)
            {
                WasCalled = true;
                LastResponse = response;
                return Task.FromResult(response);
            }
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound));
        };
    }

    public void SetupPost(string url, string requestBody, HttpResponseMessage response)
    {
        this.SendAsyncFunc = (request, _) =>
        {
            if (request.RequestUri.ToString() == url && request.Method == HttpMethod.Post &&
                request.Content.ReadAsStringAsync().Result == requestBody)
            {
                WasCalled = true;
                LastResponse = response;
                return Task.FromResult(response);
            }
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest));
        };
    }

    public Func<HttpRequestMessage, HttpCompletionOption, Task<HttpResponseMessage>> SendAsyncFunc;

    public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption)
    {
        return SendAsyncFunc(request, completionOption);
    }
}