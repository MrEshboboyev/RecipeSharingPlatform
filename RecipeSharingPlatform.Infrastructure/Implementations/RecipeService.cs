using RecipeSharingPlatform.Application.Common.Interfaces;
using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Application.Services.Interfaces;
using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Infrastructure.Implementations
{
    public class RecipeService : IRecipeService
    {
        // inject IUnitOfWork
        private readonly IUnitOfWork _unitOfWork;

        public RecipeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Get Recipes
        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            try
            {
                return _unitOfWork.Recipe.GetAll(includeProperties: "Labels");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesByChefAsync(string chefId)
        {
            try
            {
                return _unitOfWork.Recipe.GetAll(r => r.ChefId == chefId, includeProperties: "Labels");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        public async Task CreateRecipeAsync(RecipeCreateDTO recipeCreateDTO)
        {
            try
            {
                Recipe recipeForDb = new()
                {
                    ChefId = recipeCreateDTO.ChefId,
                    Description = recipeCreateDTO.Description,
                    Ingredients = recipeCreateDTO.Ingredients,
                    Instructions = recipeCreateDTO.Instructions,
                    PublicationDate = DateTime.UtcNow,
                    Title = recipeCreateDTO.Title
                };

                // adding
                _unitOfWork.Recipe.Add(recipeForDb);

                // save
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateRecipeAsync(RecipeUpdateDTO recipeUpdateDTO)
        {
            try
            {
                var recipeFromDb = _unitOfWork.Recipe.Get(r =>
                    r.ChefId == recipeUpdateDTO.ChefId && 
                    r.Id == recipeUpdateDTO.RecipeId);

                // not found, throw exception
                if (recipeFromDb is null)
                    throw new Exception("Recipe not found!");

                recipeFromDb.ChefId = recipeUpdateDTO.ChefId;
                recipeFromDb.Description = recipeUpdateDTO.Description;
                recipeFromDb.Ingredients = recipeUpdateDTO.Ingredients;
                recipeFromDb.Instructions = recipeUpdateDTO.Instructions;
                recipeFromDb.Title = recipeUpdateDTO.Title;

                // updating
                _unitOfWork.Recipe.Update(recipeFromDb);

                // save
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteRecipeAsync(RecipeDeleteDTO recipeDeleteDTO)
        {
            try
            {
                var recipeFromDb = _unitOfWork.Recipe.Get(r =>
                    r.ChefId == recipeDeleteDTO.ChefId &&
                    r.Id == recipeDeleteDTO.RecipeId);

                // not found, throw exception
                if (recipeFromDb is null)
                    throw new Exception("Recipe not found!");

                // deleting
                _unitOfWork.Recipe.Remove(recipeFromDb);

                // save
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
