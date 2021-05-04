using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GitHub_RESTapi.Models;
using GitHub_RESTapi.Services.Interfaces;

namespace GitHub_RESTapi.Services.Implementations
{
    public class GitHubRepoService : IGitHubRepoService
    {
        public async Task<GitHubRepoInfo> GetGitHubRepoInfoAsync(string owner, string repositoryName)
        {
            using var handler = new HttpClientHandler {UseDefaultCredentials = true};

            using var httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            
            var url = $"https://api.github.com/repos/{owner}/{repositoryName}";
            
            HttpResponseMessage responseMessage =
                await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                Dictionary<string, object> jsonResponse =
                    JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);

                string fullName = (string) jsonResponse["full_name"].ToString();
                string description = (string) jsonResponse["description"].ToString();
                string cloneUrl = (string) jsonResponse["clone_url"].ToString();
                int stargazers = int.Parse(jsonResponse["stargazers_count"].ToString());

                return new GitHubRepoInfo()
                {
                    FullName = fullName,
                    Description = description,
                    CloneUrl = cloneUrl,
                    Stars = stargazers
                };
            }

            throw new ArgumentException("Repository not found or repository is private!");
        }
    }
}