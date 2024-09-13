namespace RecipeSharingPlatform.Application.Common.Filters
{
    public class RecipeFilterParams
    {
        public string Keyword { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ChefId { get; set; }
        public List<Guid> LabelIds { get; set; }
    }
}
