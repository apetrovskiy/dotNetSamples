using Xunit;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;

public class GitLabProjectCreatorTests
{
    [Fact]
    public async Task Test_CreateGroup_Success()
    {
        // Arrange
        var mockClient = new Mock<HttpClient>();
        mockClient.Setup(client => client.PostAsync(It.IsAny<string>(), It.IsAny<StringContent>()))
                  .ReturnsAsync(new HttpResponseMessage
                  {
                      StatusCode = System.Net.HttpStatusCode.Created,
                      Content = new StringContent("{\"id\":1,\"name\":\"test-group\",\"path\":\"test-group\"}")
                  });

        Program.client = mockClient.Object;

        // Act
        await Program.CreateGroup("test-group");

        // Assert
        // Logging output should indicate success
    }

    [Fact]
    public async Task Test_CreateProject_Success()
    {
        // Arrange
        var mockClient = new Mock<HttpClient>();
        mockClient.SetupSequence(client => client.PostAsync(It.IsAny<string>(), It.IsAny<StringContent>()))
                  .ReturnsAsync(new HttpResponseMessage
                  {
                      StatusCode = System.Net.HttpStatusCode.OK,
                      Content = new StringContent("{\"id\":1}")
                  })
                  .ReturnsAsync(new HttpResponseMessage
                  {
                      StatusCode = System.Net.HttpStatusCode.Created,
                      Content = new StringContent("{\"id\":101,\"name\":\"test-project\",\"path_with_namespace\":\"test-group/test-project\"}")
                  });

        Program.client = mockClient.Object;

        // Act
        await Program.CreateProject("test-group", "test-project");

        // Assert
        // Logging output should indicate success
    }

    [Fact]
    public async Task Test_ProtectBranch_Success()
    {
        // Arrange
        var mockClient = new Mock<HttpClient>();
        mockClient.Setup(client => client.PostAsync(It.IsAny<string>(), It.IsAny<StringContent>()))
                  .ReturnsAsync(new HttpResponseMessage
                  {
                      StatusCode = System.Net.HttpStatusCode.Created
                  });

        Program.client = mockClient.Object;

        // Act
        await Program.ProtectBranch(101, "main", 40, 0);

        // Assert
        // Logging output should indicate success
    }
}