using RecipeSharingPlatform.Application.Common.Interfaces;
using RecipeSharingPlatform.Application.Services.Interfaces;
using RecipeSharingPlatform.Domain.Entities;

namespace RecipeSharingPlatform.Infrastructure.Implementations
{
    public class RecipeLabelService : IRecipeLabelService
    {
        // inject IUnitOfWork
        private readonly IUnitOfWork _unitOfWork;

        public RecipeLabelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Get Labels
        public async Task<IEnumerable<RecipeLabel>> GetAllLabelsAsync()
        {
            try
            {
                return _unitOfWork.RecipeLabel.GetAll(includeProperties: "Recipes");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Recipe>> GetLabelRecipesAsync(Guid labelId)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RecipeLabel> GetLabelByIdAsync(Guid labelId)
        {
            try
            {
                return _unitOfWork.RecipeLabel.Get(rl => rl.Id == labelId, includeProperties: "Recipes");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


        public async Task CreateLabelAsync(RecipeLabel recipeLabel)
        {
            try
            {
                var labelExist = _unitOfWork.RecipeLabel.Any(rl =>
                    rl.Name == recipeLabel.Name);

                if (labelExist)
                    throw new Exception($"Recipe {recipeLabel.Name} already exist!");

                // adding
                _unitOfWork.RecipeLabel.Add(recipeLabel);

                // save
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateLabelAsync(RecipeLabel recipeLabel)
        {
            try
            {
                // checking new name is exist
                var labelExist = _unitOfWork.RecipeLabel.Any(rl =>
                    rl.Name == recipeLabel.Name);

                if (labelExist)
                    throw new Exception($"Recipe {recipeLabel.Name} already exist!");

                var labelFromDb = _unitOfWork.RecipeLabel.Get(rl =>
                    rl.Id == recipeLabel.Id) ?? throw new Exception("Label not found!");
               
                // updating field(s)
                labelFromDb.Name = recipeLabel.Name;

                // updating
                _unitOfWork.RecipeLabel.Update(recipeLabel);

                // save
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteLabelAsync(Guid labelId)
        {
            try
            {
                var labelFromDb = _unitOfWork.RecipeLabel.Get(rl =>
                    rl.Id == labelId) ?? throw new Exception("Label not found!");

                // deleting
                _unitOfWork.RecipeLabel.Remove(labelFromDb);

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
