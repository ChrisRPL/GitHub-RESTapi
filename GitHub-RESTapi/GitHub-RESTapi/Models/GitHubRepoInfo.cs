using System.ComponentModel.DataAnnotations;

namespace GitHub_RESTapi.Models
{
    public class GitHubRepoInfo
    {
        [Required(ErrorMessage = "FullName is required!")]
        public string FullName { get; set; }
        
        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }
        
        [Url]
        [Required(ErrorMessage = "CloneUrl is required!")]
        public string CloneUrl { get; set; }
        
        [Required(ErrorMessage = "Stars number is required!")]
        public int Stars { get; set; }
    }
}