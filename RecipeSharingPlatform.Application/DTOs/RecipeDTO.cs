﻿namespace RecipeSharingPlatform.Application.DTOs
{
    public class RecipeDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ChefId { get; set; }
        public List<LabelDto> Labels { get; set; }
    }
}
