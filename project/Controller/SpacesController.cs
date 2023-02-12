using project.Dtos;
using project.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace project.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class SpacesController : ControllerBase
    {
        private readonly ILogger<SpacesController> _logger;
        private readonly ISpacesRepository _spacesRepo;
        public SpacesController(ILogger<SpacesController> logger, ISpacesRepository
        SpacesRepo)
        {
            _logger = logger;
            _spacesRepo = SpacesRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetSpaces()
        {
            try
            {
                var spaces = await _spacesRepo.GetSpaces();
                return Ok(new
                {
                    Success = true,
                    Message = "all Spaces returned.",
                    spaces
                });
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        // [HttpGet]
        // [Route("{id}")]
        [HttpGet("{S_id}", Name = "SpacesById")]
        public async Task<IActionResult> GetSpaces(string S_id)
        {
            try
            {
                var spaces = await _spacesRepo.GetSpaces(S_id);
                if (spaces == null)
                    return NotFound();
                return Ok(new
                {
                    Success = true,
                    Message = "Spaces fetched.",
                    spaces
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
         [HttpPost]
        public async Task<IActionResult> CreateSpaces(SpacesForCreationDto spaces)
        {
            try
            {
                var createdSpaces = await _spacesRepo.CreateSpaces(spaces);
                return Ok(new
                {
                    Success = true,
                    Message = "Spaces created.",
                    createdSpaces
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPatch]
        [Route("{S_id}")]
        public async Task<IActionResult> UpdateSpaces(string S_id, SpacesForUpdateDto spaces)
        {
            try
            {
                var dbSpaces = await _spacesRepo.GetSpaces(S_id);
                if (dbSpaces == null)
                    return NotFound();
                await _spacesRepo.UpdateSpaces(S_id, spaces);
                return Ok(new
                {
                    Success = true,
                    Message = "Spaces updated."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{S_id}")]
        public async Task<IActionResult> DeleteSpaces(string S_id)
        {
            try
            {
                var dbSpaces = await _spacesRepo.GetSpaces(S_id);
                if (dbSpaces == null)
                    return NotFound();
                await _spacesRepo.DeleteSpaces(S_id);
                return Ok(new
                {
                    Success = true,
                    Message = "Spaces deleted."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
