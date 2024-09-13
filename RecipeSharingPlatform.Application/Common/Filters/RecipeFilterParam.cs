namespace RecipeSharingPlatform.Application.Common.Filters
{
    public class RecipeFilterParam
    {
        public string Keyword { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? ChefId { get; set; }
        public List<Guid> LabelIds { get; set; }
    }
}
