namespace GitlabProjectCreator;


using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

public class Program
{
    private static ILogger<Program> _logger;
    private static HttpClient _httpClient = new HttpClient();
    private static string _gitlabUrl;
    private static string _gitlabToken;

    static async Task Main(string[] args)
    {
        // Set up logging
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        _logger = loggerFactory.CreateLogger<Program>();

        // Load config
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        _gitlabUrl = config["GitLab:Url"];
        _gitlabToken = config["GitLab:Token"];
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _gitlabToken);

        // Parse command-line arguments
        if (args.Length < 2)
        {
            _logger.LogError("Usage: dotnet run <group-path> <project1> <project2> ...");
            return;
        }
        string path = args[0];
        string[] projects = args[1..];

        // Create group/subgroup and projects
        int groupId = await CreateGroupOrSubgroup(path);
        foreach (var project in projects)
        {
            int projectId = await CreateProject(groupId, project);
            await ConfigureProject(projectId);
        }
    }

    public static async Task<int> CreateGroupOrSubgroup(string path)
    {
        string[] parts = path.Split('/');
        int? parentId = null;
        foreach (var part in parts)
        {
            var url = $"{_gitlabUrl}/api/v4/groups";
            var payload = new { name = part, path = part, parent_id = parentId };
            var response = await _httpClient.PostAsync(url, new StringContent(JsonSerializer.Serialize(payload), System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json")));

            if (response.IsSuccessStatusCode)
            {
                var group = JsonSerializer.Deserialize<JsonElement>(await response.Content.ReadAsStringAsync());
                parentId = group.GetProperty("id").GetInt32();
                _logger.LogInformation($"Created group/subgroup: {part}", new { id = parentId });
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var searchResponse = await _httpClient.GetAsync($"{_gitlabUrl}/api/v4/groups?search={part}");
                var groups = JsonSerializer.Deserialize<JsonElement>(await searchResponse.Content.ReadAsStringAsync());
                parentId = groups[0].GetProperty("id").GetInt32();
                _logger.LogInformation($"Group/subgroup already exists: {part}", new { id = parentId });
            }
            else
            {
                throw new Exception($"Failed to create group/subgroup: {await response.Content.ReadAsStringAsync()}");
            }
        }
        return parentId ?? throw new Exception("Failed to create group/subgroup");
    }

    public static async Task<int> CreateProject(int groupId, string projectName)
    {
        var url = $"{_gitlabUrl}/api/v4/projects";
        var payload = new { name = projectName, namespace_id = groupId, initialize_with_readme = true };
        var response = await _httpClient.PostAsync(url, new StringContent(JsonSerializer.Serialize(payload), System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json")));

        if (response.IsSuccessStatusCode)
        {
            var project = JsonSerializer.Deserialize<JsonElement>(await response.Content.ReadAsStringAsync());
            int projectId = project.GetProperty("id").GetInt32();
            _logger.LogInformation($"Created project: {projectName}", new { id = projectId });
            return projectId;
        }
        else
        {
            throw new Exception($"Failed to create project: {await response.Content.ReadAsStringAsync()}");
        }
    }

    static async Task ConfigureProject(int projectId)
    {
        // Create develop branch
        await _httpClient.PostAsync($"{_gitlabUrl}/api/v4/projects/{projectId}/repository/branches?branch=develop&ref=main", null);

        // Set develop as default branch
        await _httpClient.PutAsync($"{_gitlabUrl}/api/v4/projects/{projectId}?default_branch=develop", null);

        // Protect branches
        var protections = new[] { ("main", "maintainers"), ("develop", "developers") };
        foreach (var (branch, accessLevel) in protections)
        {
            var payload = new { name = branch, push_access_level = "0", merge_access_level = accessLevel };
            await _httpClient.PostAsync($"{_gitlabUrl}/api/v4/projects/{projectId}/protected_branches", new StringContent(JsonSerializer.Serialize(payload), System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json")));
        }

        // Set CI/CD path
        await _httpClient.PutAsync($"{_gitlabUrl}/api/v4/projects/{projectId}?ci_config_path=ci/.gitlab-ci.yml", null);
    }
}