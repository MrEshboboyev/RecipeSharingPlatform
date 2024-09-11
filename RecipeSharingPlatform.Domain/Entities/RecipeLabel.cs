namespace RecipeSharingPlatform.Domain.Entities
{
    public class RecipeLabel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
