

using System;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;

class GitLabProjectCreator
{
    private readonly HttpClient _client;

    public GitLabProjectCreator(string baseUrl, string privateToken)
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(baseUrl);
        _client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", privateToken);
    }

    public async Task<int> CreateGroupAsync(string groupName, int? parentId = null)
    {
        var data = new { name = groupName, path = groupName, parent_id = parentId };
        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/groups", content);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Group '{groupName}' created.");
            var result = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
            return Convert.ToInt32(result["id"]);
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest && response.Content.ReadAsStringAsync().Result.Contains("has already been taken"))
        {
            Console.WriteLine($"Group '{groupName}' already exists.");
            return GetGroupIdAsync(groupName).Result;
        }
        else
        {
            throw new Exception($"Failed to create group: {await response.Content.ReadAsStringAsync()}");
        }
    }

    public async Task<int> GetGroupIdAsync(string groupName)
    {
        var response = await _client.GetAsync($"/groups/{groupName}");
        var result = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
        return Convert.ToInt32(result["id"]);
    }

    // Similar methods for CreateProject, GetProjectId, ProtectBranch, and SetupProjects...

    static async Task Main(string[] args)
    {
var path=args[0];


        var baseUrl = "https://gitlab.com/api/v4";
        var privateToken = "your_private_token";

        var creator = new GitLabProjectCreator(baseUrl, privateToken);
        await creator.SetupProjectsAsync("projects001/tests/v2", new[] { "project01", "project02", "project03" });
    }
}