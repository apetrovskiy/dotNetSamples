using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using dotenv.net;
using System.Net.Http.Headers;
// using System.Text.Json;
using System.Text;
using System.Net.Http.Json;

class Program
{
    private static readonly HttpClient client = new HttpClient();
    private const string GITLAB_URL = "https://gitlab.com";
    private const string PRIVATE_TOKEN = "your-personal-access-token";

    static async Task Main(string[] args)
    {
        DotEnv.Load();
        var envVars = DotEnv.Read();

        client.DefaultRequestHeaders.Add("PRIVATE-TOKEN", envVars["PRIVATE_TOKEN"]);
        // client.DefaultRequestHeaders.Add("Content-Type", "application/json");
        /*
        HttpContent httpContent = new StringContent(Json, Encoding.UTF8, "application/json");
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        */
        string groupName, int? parentId = null;
        var data = new { name = groupName, path = groupName, parent_id = parentId };
        var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        // client.DefaultRequestHeaders.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        /*
HttpClient client = new HttpClient();
client.BaseAddress = new Uri("http://example.com/");
client.DefaultRequestHeaders
      .Accept
      .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
request.Content = new StringContent("{\"name\":\"John Doe\",\"age\":33}",
                                    Encoding.UTF8, 
                                    "application/json");//CONTENT-TYPE header

client.SendAsync(request)
      .ContinueWith(responseTask =>
      {
          Console.WriteLine("Response: {0}", responseTask.Result);
      });
        */

        string groupPath = "projects001/tests/v2";
        List<string> projectNames = new List<string> { "project01", "project02", "project03" };
        string ciPath = "ci/.gitlab-ci.yml";  // Optional: Set custom CI/CD path

        await CreateProjects(groupPath, projectNames, ciPath);
    }

    private static async Task CreateProjects(string groupPath, List<string> projectNames, string ciPath)
    {
        var parts = groupPath.Split('/');
        var group = await CreateOrGetGroup(parts[0]);

        // Traverse or create subgroups
        var currentGroup = group;
        for (int i = 1; i < parts.Length; i++)
        {
            currentGroup = await CreateOrGetSubgroup(currentGroup.Id, parts[i]);
        }

        // Create projects
        foreach (var projectName in projectNames)
        {
            await CreateProject(currentGroup.Id, projectName, ciPath);
            Console.WriteLine($"Created project: {currentGroup.FullPath}/{projectName}");
        }
    }

    private static async Task<Group> CreateOrGetGroup(string groupName)
    {
        var response = await client.GetAsync($"{GITLAB_URL}/api/v4/groups/{groupName}");
        if (!response.IsSuccessStatusCode)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new { name = groupName, path = groupName }), Encoding.UTF8, "application/json");
            response = await client.PostAsync($"{GITLAB_URL}/api/v4/groups", content);
        }
        return JsonConvert.DeserializeObject<Group>(await response.Content.ReadAsStringAsync());
    }

    private static async Task<Group> CreateOrGetSubgroup(int parentId, string subgroupName)
    {
        var response = await client.GetAsync($"{GITLAB_URL}/api/v4/groups?search={subgroupName}");
        var subgroups = JsonConvert.DeserializeObject<List<Group>>(await response.Content.ReadAsStringAsync());
        var subgroup = subgroups.Find(g => g.ParentId == parentId);
        if (subgroup == null)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new { name = subgroupName, path = subgroupName, parent_id = parentId }), Encoding.UTF8, "application/json");
            response = await client.PostAsync($"{GITLAB_URL}/api/v4/groups", content);
            subgroup = JsonConvert.DeserializeObject<Group>(await response.Content.ReadAsStringAsync());
        }
        return subgroup;
    }

    private static async Task CreateProject(int groupId, string projectName, string ciPath)
    {
        var content = new StringContent(JsonConvert.SerializeObject(new { name = projectName, namespace_id = groupId }), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{GITLAB_URL}/api/v4/projects", content);
        var project = JsonConvert.DeserializeObject<Project>(await response.Content.ReadAsStringAsync());

        // Create 'develop' branch
        content = new StringContent(JsonConvert.SerializeObject(new { branch = "develop", @ref = "main" }), Encoding.UTF8, "application/json");
        await client.PostAsync($"{GITLAB_URL}/api/v4/projects/{project.Id}/repository/branches", content);

        // Set 'develop' as default branch
        content = new StringContent(JsonConvert.SerializeObject(new { default_branch = "develop" }), Encoding.UTF8, "application/json");
        await client.PutAsync($"{GITLAB_URL}/api/v4/projects/{project.Id}", content);

        // Protect branches
        content = new StringContent(JsonConvert.SerializeObject(new { name = "main", push_access_level = 0, merge_access_level = 40 }), Encoding.UTF8, "application/json");
        await client.PostAsync($"{GITLAB_URL}/api/v4/projects/{project.Id}/protected_branches", content);
        content = new StringContent(JsonConvert.SerializeObject(new { name = "develop", push_access_level = 0, merge_access_level = 30 }), Encoding.UTF8, "application/json");
        await client.PostAsync($"{GITLAB_URL}/api/v4/projects/{project.Id}/protected_branches", content);

        // Set custom CI/CD path
        if (!string.IsNullOrEmpty(ciPath))
        {
            content = new StringContent(JsonConvert.SerializeObject(new { ci_config_path = ciPath }), Encoding.UTF8, "application/json");
            await client.PutAsync($"{GITLAB_URL}/api/v4/projects/{project.Id}", content);
        }
    }

    private class Group
    {
        public int Id { get; set; }
        public string FullPath { get; set; }
        public int ParentId { get; set; }
    }

    private class Project
    {
        public int Id { get; set; }
    }
}