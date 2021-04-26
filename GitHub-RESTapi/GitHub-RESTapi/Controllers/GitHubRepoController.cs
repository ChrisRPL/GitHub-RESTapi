using System;
using System.Threading.Tasks;
using GitHub_RESTapi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GitHub_RESTapi.Controllers
{
    [ApiController]
    [Route("api/repositories")]
    public class GitHubRepoController : ControllerBase
    {
        private readonly IGitHubRepoService _gitHubRepoService;

        public GitHubRepoController(IGitHubRepoService gitHubRepoService)
        {
            _gitHubRepoService = gitHubRepoService;
        }
        
        [HttpGet]
        [Route("{owner}/{repositoryName}")]
        public async Task<IActionResult> GetGitHubRepoInfo([FromRoute] string owner, [FromRoute] string repositoryName)
        {
            try
            {
                var result = await _gitHubRepoService.GetGitHubRepoInfoAsync(owner, repositoryName);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound("Repository not found!");
            }
            
        }
    }
}