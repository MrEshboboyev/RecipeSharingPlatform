using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeSharingPlatform.Application.Common.Models;
using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Application.Services.Interfaces;
using RecipeSharingPlatform.Domain.Entities;
using RecipeSharingPlatform.Infrastructure.Implementations;

namespace RecipeSharingPlatform.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeLabelController : ControllerBase
    {
        // inject IRecipeLabelService
        private readonly IRecipeLabelService _recipeLabelService;

        public RecipeLabelController(IRecipeLabelService recipeLabelService)
        {
            _recipeLabelService = recipeLabelService;
        }

        #region Get Recipe Labels
        [HttpGet("get-all-labels")]
        public async Task<IActionResult> GetAllLabels()
        {
            try
            {
                return Ok(await _recipeLabelService.GetAllLabelsAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-label-by-id")]
        public async Task<IActionResult> GetLabelById(Guid labelId)
        {
            try
            {
                return Ok(await _recipeLabelService.GetLabelByIdAsync(labelId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        [HttpPost("create-label")]
        public async Task<IActionResult> CreateLabel([FromBody] RecipeLabel recipeLabel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _recipeLabelService.CreateLabelAsync(recipeLabel);
                return Ok($"Recipe Label - {recipeLabel.Name} : Created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-label")]
        public async Task<IActionResult> UpdateLabel(Guid labelId, [FromBody] RecipeLabel recipeLabel)
        {
            if (!ModelState.IsValid || !labelId.Equals(recipeLabel.Id))
                return BadRequest("Error with entered values!");

            try
            {
                await _recipeLabelService.UpdateLabelAsync(recipeLabel);
                return Ok($"Recipe Label - {recipeLabel.Name} : Updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-label")]
        public async Task<IActionResult> DeleteLabel(Guid labelId)
        {
            try
            {
                await _recipeLabelService.DeleteLabelAsync(labelId);
                return Ok("Recipe Label : Deleted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
