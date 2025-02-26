namespace GitlabProjectCreator.Tests;

using Xunit;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using Moq.Protected;
using GitlabProjectCreator;

public class GitLabTests1
{
    [Fact]
    public async Task TestCreateGroupOrSubgroup()
    {
        var mockHttp = new Mock<HttpMessageHandler>();
        mockHttp.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.OK, Content = new StringContent("{ \"id\": 1 }") });

        var httpClient = new HttpClient(mockHttp.Object);
        var program = new Program();
        var groupId = await Program.CreateGroupOrSubgroup("projects001/tests/v2");
        Assert.Equal(1, groupId);
    }
}