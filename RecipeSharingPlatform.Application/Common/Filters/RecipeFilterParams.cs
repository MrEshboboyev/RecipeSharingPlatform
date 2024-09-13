namespace RecipeSharingPlatform.Application.Common.Filters
{
    public class RecipeFilterParams
    {
        public string Keyword { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ChefId { get; set; }
        // Make LabelIds optional by setting it as nullable or initializing with an empty list
        public List<Guid> LabelIds { get; set; } = new List<Guid>(); // Default to empty list
    }
}
