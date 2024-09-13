using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeSharingPlatform.Application.Common.Filters;
using RecipeSharingPlatform.Application.Common.Models;
using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Application.Services.Interfaces;
using System.Security.Claims;

namespace RecipeSharingPlatform.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        // inject Recipe Service
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        #region Private Methods
        private string GetChefId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
        #endregion

        #region Get Recipes
        [AllowAnonymous]
        [HttpGet("get-all-recipes")]
        public async Task<IActionResult> GetAllRecipes()
        {
            try
            {
                return Ok(await _recipeService.GetAllRecipesAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-chef-recipes")]
        public async Task<IActionResult> GetChefRecipes()
        {
            try
            {
                return Ok(await _recipeService.GetAllRecipesByChefAsync(GetChefId()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("get-filtered-recipes")]
        public async Task<IActionResult> GetFilteredRecipes([FromQuery] RecipeFilterParams filterParams)
        {
            try
            {
                return Ok(await _recipeService.GetFilteredRecipesAsync(filterParams));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        [HttpPost("create-recipe")]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeModel createRecipeModel)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            try
            {
                RecipeCreateDTO recipeCreateDTO = new()
                {
                    ChefId = GetChefId(),
                    Title = createRecipeModel.Title,
                    Description = createRecipeModel.Description,
                    Ingredients = createRecipeModel.Ingredients,
                    Instructions = createRecipeModel.Instructions
                };

                await _recipeService.CreateRecipeAsync(recipeCreateDTO);
                return Ok($"Recipe - {createRecipeModel.Title} : Created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-recipe")]
        public async Task<IActionResult> UpdateRecipe(Guid recipeId, [FromBody] UpdateRecipeModel updateRecipeModel)
        {
            if (!ModelState.IsValid || !recipeId.Equals(updateRecipeModel.RecipeId))
                return BadRequest("Error with entered values!");

            try
            {
                RecipeUpdateDTO recipeUpdateDTO = new()
                {
                    ChefId = GetChefId(),
                    RecipeId = updateRecipeModel.RecipeId,
                    Title = updateRecipeModel.Title,
                    Description = updateRecipeModel.Description,
                    Ingredients = updateRecipeModel.Ingredients,
                    Instructions = updateRecipeModel.Instructions
                };

                await _recipeService.UpdateRecipeAsync(recipeUpdateDTO);
                return Ok($"Recipe - {updateRecipeModel.Title} : Updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-recipe")]
        public async Task<IActionResult> DeleteRecipe(Guid recipeId)
        {
            try
            {
                RecipeDeleteDTO recipeDeleteDTO = new()
                {
                    ChefId = GetChefId(),
                    RecipeId = recipeId
                };

                await _recipeService.DeleteRecipeAsync(recipeDeleteDTO);
                return Ok("Recipe : Deleted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Attach label to Recipe
        [HttpPost("add-label-to-recipe")]
        public async Task<IActionResult> AddLabelToRecipe(Guid recipeId, Guid labelId)
        {
            try
            {
                RecipeAddLabelDTO recipeAddLabelDTO = new()
                {
                    ChefId = GetChefId(),
                    LabelId = labelId,
                    RecipeId = recipeId
                };

                await _recipeService.AddLabelToRecipeAsync(recipeAddLabelDTO);

                return Ok("Add Label to Recipe : Success!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
