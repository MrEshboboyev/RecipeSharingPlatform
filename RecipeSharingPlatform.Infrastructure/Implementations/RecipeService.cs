using AutoMapper;
using RecipeSharingPlatform.Application.Common.Filters;
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
        private readonly IMapper _mapper;

        public RecipeService(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #region Get Recipes
        public async Task<IEnumerable<RecipeDTO>> GetAllRecipesAsync()
        {
            try
            {
                return _mapper.Map<IEnumerable<RecipeDTO>>(_unitOfWork.Recipe.GetAll(includeProperties: "Labels"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllRecipesByChefAsync(string chefId)
        {
            try
            {
                return _mapper.Map<IEnumerable<RecipeDTO>>(_unitOfWork.Recipe.GetAll(r => r.ChefId == chefId, includeProperties: "Labels"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<RecipeDTO>> GetFilteredRecipesAsync(RecipeFilterParams filterParams)
        {
            try
            {
                return _mapper.Map<IEnumerable<RecipeDTO>>(_unitOfWork.Recipe.GetFilteredRecipesAsync(filterParams));
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

        // Add Label to Recipe
        public async Task AddLabelToRecipeAsync(RecipeAddLabelDTO addLabelDTO)
        {
            try
            {
                // found and check if this recipe belongs to this user
                var recipeFromDb = _unitOfWork.Recipe.Get(r =>
                    r.Id == addLabelDTO.RecipeId &&
                    r.ChefId == addLabelDTO.ChefId);

                // get label
                var labelFromDb = _unitOfWork.RecipeLabel.Get(rl =>
                    rl.Id == addLabelDTO.LabelId);

                if (recipeFromDb == null || labelFromDb == null)
                    throw new Exception("Recipe/Label not found");

                // attach label to recipe
                await _unitOfWork.Recipe.AddLabelToRecipeAsync(recipeFromDb.Id, 
                    labelFromDb.Id);

                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
