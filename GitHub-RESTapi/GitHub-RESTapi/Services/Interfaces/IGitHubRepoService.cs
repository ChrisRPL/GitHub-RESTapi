using System.Threading.Tasks;
using GitHub_RESTapi.Models;

namespace GitHub_RESTapi.Services.Interfaces
{
    public interface IGitHubRepoService
    {
        public Task<GitHubRepoInfo> GetGitHubRepoInfoAsync(string owner, string repositoryName);
    }
}