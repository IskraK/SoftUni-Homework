using System.ComponentModel.DataAnnotations;

namespace Git.Models.Repositories
{
    public class RepositoryCreateViewModel
    {
        [StringLength(10, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }
        public string RepositoryType { get; set; }
    }
}