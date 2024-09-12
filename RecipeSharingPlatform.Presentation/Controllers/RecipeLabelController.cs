using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeSharingPlatform.Application.DTOs;
using RecipeSharingPlatform.Application.Services.Interfaces;

namespace RecipeSharingPlatform.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeLabelController : ControllerBase
    {
        // inject IRecipeLabelDTOService
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

        [HttpGet("get-label-with-recipes")]
        public async Task<IActionResult> GetLabelWithRecipes(Guid labelId)
        {
            try
            {
                return Ok(await _recipeLabelService.GetLabelRecipesAsync(labelId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        [HttpPost("create-label")]
        public async Task<IActionResult> CreateLabel([FromBody] RecipeLabelDTO recipeLabelDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _recipeLabelService.CreateLabelAsync(recipeLabelDTO);
                return Ok($"Recipe Label - {recipeLabelDTO.Name} : Created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-label")]
        public async Task<IActionResult> UpdateLabel(Guid labelId, [FromBody] RecipeLabelDTO recipeLabelDTO)
        {
            if (!ModelState.IsValid || !labelId.Equals(recipeLabelDTO.Id))
                return BadRequest("Error with entered values!");

            try
            {
                await _recipeLabelService.UpdateLabelAsync(recipeLabelDTO);
                return Ok($"Recipe Label - {recipeLabelDTO.Name} : Updated successfully");
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
