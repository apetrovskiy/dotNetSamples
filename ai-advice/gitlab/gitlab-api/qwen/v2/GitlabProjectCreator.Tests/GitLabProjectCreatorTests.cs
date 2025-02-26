using System.Net.Http;
using System.Threading.Tasks;
using TUnit;

public class GitLabProjectCreatorTests
{
    [Test]
    [Fact]
    public async Task Test_CreateGroup_Success()
    {
        // Arrange
        var mockClient = new MockHttpClient();
        Program.client = mockClient;

        string groupName = "test-group";
        string expectedResponse = "{\"id\":1,\"name\":\"test-group\",\"path\":\"test-group\"}";

        mockClient.SetupPost($"{Program.Configuration["Gitlab:Url"]}/api/v4/groups",
            $"{{\"name\":\"{groupName}\",\"path\":\"{groupName}\"}}",
            new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Content = new StringContent(expectedResponse)
            });

        // Act
        await Program.CreateGroup(groupName);

        // Assert
        TUnit.Assert.IsTrue(mockClient.WasCalled);
        TUnit.Assert.AreEqual(System.Net.HttpStatusCode.Created, mockClient.LastResponse.StatusCode);
        TUnit.Assert.AreEqual(expectedResponse, await mockClient.LastResponse.Content.ReadAsStringAsync());
    }

    [Test]
    [Fact]
    public async Task Test_CreateProject_Success()
    {
        // Arrange
        var mockClient = new MockHttpClient();
        Program.client = mockClient;

        string groupPath = "test-group";
        string projectName = "test-project";

        // Mock GetGroupId
        mockClient.SetupGet($"{Program.Configuration["Gitlab:Url"]}/api/v4/groups/{groupPath}",
            new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent("{\"id\":1}")
            });

        // Mock CreateProject
        string projectResponse = "{\"id\":101,\"name\":\"test-project\",\"path_with_namespace\":\"test-group/test-project\"}";
        mockClient.SetupPost($"{Program.Configuration["Gitlab:Url"]}/api/v4/projects",
            $"{{\"name\":\"{projectName}\",\"namespace_id\":1,\"default_branch\":\"develop\",\"ci_config_path\":\"ci/.gitlab-ci.yml\"}}",
            new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Content = new StringContent(projectResponse)
            });

        // Act
        await Program.CreateProject(groupPath, projectName);

        // Assert
        TUnit.Assert.IsTrue(mockClient.WasCalled);
        TUnit.Assert.AreEqual(System.Net.HttpStatusCode.Created, mockClient.LastResponse.StatusCode);
        TUnit.Assert.AreEqual(projectResponse, await mockClient.LastResponse.Content.ReadAsStringAsync());
    }

    [Test]
    [Fact]
    public async Task Test_ProtectBranch_Success()
    {
        // Arrange
        var mockClient = new MockHttpClient();
        Program.client = mockClient;

        int projectId = 101;
        string branchName = "main";
        int mergeAccessLevel = 40;
        int pushAccessLevel = 0;

        mockClient.SetupPost($"{Program.Configuration["Gitlab:Url"]}/api/v4/projects/{projectId}/protected_branches",
            $"{{\"name\":\"{branchName}\",\"push_access_level\":{pushAccessLevel},\"merge_access_level\":{mergeAccessLevel}}}",
            new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.Created
            });

        // Act
        await Program.ProtectBranch(projectId, branchName, mergeAccessLevel, pushAccessLevel);

        // Assert
        TUnit.Assert.IsTrue(mockClient.WasCalled);
        TUnit.Assert.AreEqual(System.Net.HttpStatusCode.Created, mockClient.LastResponse.StatusCode);
    }
}