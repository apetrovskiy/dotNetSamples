namespace GitlabProjectCreator.Tests;

using System.Net.Http;
using System.Threading.Tasks;
using TUnit;
using Moq;
using System.Threading;
using Moq.Protected;

public class GitLabTests
{
    [Test]
    [Fact]
    public async Task CreateGroupOrSubgroup_CreatesGroup_ReturnsGroupId()
    {
        // Arrange
        var mockHttp = new Mock<HttpMessageHandler>();
        mockHttp.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Content = new StringContent("{ \"id\": 1 }")
            });

        var httpClient = new HttpClient(mockHttp.Object);
        var program = new Program();

        // Act
        var groupId = await Program.CreateGroupOrSubgroup("projects001/tests/v2");

        // Assert
        await TUnit.Assertions.Assert.That(groupId).IsEqualTo(1);
    }

    [Test]
    [Fact]
    public async Task CreateGroupOrSubgroup_GroupAlreadyExists_ReturnsExistingGroupId()
    {
        // Arrange
        var mockHttp = new Mock<HttpMessageHandler>();
        mockHttp.Protected()
            .SetupSequence<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Content = new StringContent("Group already exists")
            })
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("[{ \"id\": 1 }]")
            });

        var httpClient = new HttpClient(mockHttp.Object);
        var program = new Program();

        // Act
        var groupId = await Program.CreateGroupOrSubgroup("projects001/tests/v2");

        // Assert
        await TUnit.Assertions.Assert.That(groupId).IsEqualTo(1);
    }

    [Test]
    [Fact]
    public async Task CreateProject_CreatesProject_ReturnsProjectId()
    {
        // Arrange
        var mockHttp = new Mock<HttpMessageHandler>();
        mockHttp.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Content = new StringContent("{ \"id\": 2 }")
            });

        var httpClient = new HttpClient(mockHttp.Object);
        var program = new Program();

        // Act
        var projectId = await Program.CreateProject(1, "project01");

        // Assert
        await TUnit.Assertions.Assert.That(projectId).IsEqualTo(2);
    }
}