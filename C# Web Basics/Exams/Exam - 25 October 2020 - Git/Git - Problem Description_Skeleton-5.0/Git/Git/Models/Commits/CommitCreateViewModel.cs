using System.ComponentModel.DataAnnotations;

namespace Git.Models.Commits
{
    public class CommitCreateViewModel
    {
        public string Id { get; set; }

        [MinLength(5, ErrorMessage = "{0} must be at least {1} characters")]
        public string Description { get; set; }
    }
}
