namespace RecipeSharingPlatform.Domain.Entities
{
    public class RecipeLabel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //[JsonIgnore]
        public ICollection<Recipe> Recipes { get; set; }
    }
}
