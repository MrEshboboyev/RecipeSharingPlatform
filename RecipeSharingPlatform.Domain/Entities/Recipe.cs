namespace RecipeSharingPlatform.Domain.Entities
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ChefId { get; set; }
        public ApplicationUser Chef { get; set; }
        public ICollection<RecipeLabel> Labels { get; set; }
        public ICollection<RecipeImage> Images { get; set; }
    }
}
