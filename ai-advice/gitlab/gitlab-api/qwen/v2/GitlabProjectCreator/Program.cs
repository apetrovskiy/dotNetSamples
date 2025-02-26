using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

class Program
{
    private static readonly HttpClient client = new();
    private static IConfiguration Configuration;
    private static ILogger Logger;

    static async Task Main(string[] args)
    {
        // Load configuration from appsettings.json
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json"); //, optional: false, reloadOnChange: true);
        Configuration = builder.Build();

        // Configure logging
        var factory = LoggerFactory.Create(builder => builder.AddConsole());
        Logger = factory.CreateLogger<Program>();

        // Validate arguments
        if (args.Length < 2)
        {
            Logger.LogError("Usage: dotnet run <group_path> <project_name_1> <project_name_2> ...");
            return;
        }

        string gitlabUrl = Configuration["Gitlab:Url"];
        string privateToken = Configuration["Gitlab:Token"];

        client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", privateToken);

        string groupPath = args[0];
        string[] projectNames = args[1..];

        // Split the group path into parts
        string[] parts = groupPath.Split('/');
        foreach (var part in parts)
        {
            await CreateGroup(part);
        }

        // Create projects under the specified group/subgroup
        foreach (var projectName in projectNames)
        {
            await CreateProject(groupPath, projectName);
        }
    }

    static async Task<int> GetGroupId(string groupPath)
    {
        try
    }

    static async Task CreateGroup(string groupName)
        {
            try
            {
                var url = $"{Configuration["Gitlab:Url"]}/api/v4/groups";
                var content = new StringContent(
                    $"{{\"name\":\"{groupName}\",\"path\":\"{groupName}\"}}",
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Logger.LogInformation($"Group {groupName} created.");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    Logger.LogWarning($"Group {groupName} already exists.");
                }
                else
                {
                    Logger.LogError($"Failed to create group {groupName}: {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error creating group: {ex.Message}");
            }

        }

        static async Task<int> GetGroupId(string groupPath)
        {
            try
            {
                var url = $"{Configuration["Gitlab:Url"]}/api/v4/groups/{groupPath}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    JObject groupResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
                    return (int)groupResponse["id"];
                }
                else
                {
                    Logger.LogError($"Failed to get group ID for {groupPath}: {await response.Content.ReadAsStringAsync()}");
                    throw new Exception("Group not found or inaccessible.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error getting group ID: {ex.Message}");
                throw;
            }
        }

        static async Task ProtectBranch(int projectId, string branchName, int mergeAccessLevel, int pushAccessLevel)
        {
            try
            {
                var url = $"{Configuration["Gitlab:Url"]}/api/v4/projects/{projectId}/protected_branches";
                var content = new StringContent(
                    $"{{" +
                    $"\"name\":\"{branchName}\"," +
                    $"\"push_access_level\":{pushAccessLevel}," +
                    $"\"merge_access_level\":{mergeAccessLevel}" +
                    "}",
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Logger.LogInformation($"Protected branch {branchName} for project {projectId}.");
                }
                else
                {
                    Logger.LogError($"Failed to protect branch {branchName}: {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error protecting branch: {ex.Message}");
            }
        }
    }