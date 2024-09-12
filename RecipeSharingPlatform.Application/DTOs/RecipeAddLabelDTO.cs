namespace RecipeSharingPlatform.Application.DTOs
{
    public class RecipeAddLabelDTO
    {
        public Guid RecipeId { get; set; }
        public string ChefId { get; set; }
        public Guid LabelId { get; set; }
    }
}
