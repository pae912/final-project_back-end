using project.Dtos;
using project.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace project.Controller
{
    [EnableCors("AllowAny")]
    [ApiController]
    [Route("[controller]")]
    public class CategoryController: ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ILogger<CategoryController> logger, ICategoryRepository
        categoryRepo)
        {
            _logger = logger;
            _categoryRepo = categoryRepo;
        }
        [EnableCors("AllowAny")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var category = await _categoryRepo.GetCategories();
                return Ok(new
                {
                    Success = true,
                    Message = "all categories returned.",
                    category
                });
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]
        // [HttpGet]
        // [Route("{id}")]
        [HttpGet("{C_id}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategory(int C_id)
        {
            try
            {
                var category = await _categoryRepo.GetCategory(C_id);
                if (category == null)
                    return NotFound();
                return Ok(new
                {
                    Success = true,
                    Message = "Category fetched.",
                    category
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryForCreationDto category)
        {
            try
            {
                var createdCategory = await _categoryRepo.CreateCategory(category);
                return Ok(new
                {
                    Success = true,
                    Message = "DVD created.",
                    createdCategory
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]
        [HttpPatch]
        [Route("{C_id}")]
        public async Task<IActionResult> UpdateCategory(int C_id, CategoryForUpdateDto category)
        {
            try
            {
                var dbCategory = await _categoryRepo.GetCategory(C_id);
                if (dbCategory == null)
                    return NotFound();
                await _categoryRepo.UpdateCategory(C_id, category);
                return Ok(new
                {
                    Success = true,
                    Message = "Category updated."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [EnableCors("AllowAny")]
        [HttpDelete]
        [Route("{C_id}")]
        public async Task<IActionResult> DeleteCategory(int C_id)
        {
            try
            {
                var dbCategory = await _categoryRepo.GetCategory(C_id);
                if (dbCategory == null)
                    return NotFound();
                await _categoryRepo.DeleteCategory(C_id);
                return Ok(new
                {
                    Success = true,
                    Message = "Category deleted."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
    }
}
