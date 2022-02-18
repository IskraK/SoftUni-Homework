namespace CarShop.ViewModels.Issues
{
    public class IssueListViewModel
    {
        public string Id { get; init; }
        public string Description { get; init; }
        public bool IsFixed { get; init; }
        public string FixedInformation { get; init; }
    }
}
