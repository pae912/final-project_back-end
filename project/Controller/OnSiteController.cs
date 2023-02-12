using project.Dtos;
using project.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace project.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class OnSiteController : ControllerBase
    {
        private readonly ILogger<OnSiteController>  _logger;
        private readonly IOnSiteRepository _onsiteRepo;
        public OnSiteController(ILogger<OnSiteController> logger, IOnSiteRepository onsiteRepo)
        {
            _logger = logger;
            _onsiteRepo = onsiteRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetOnSite()
        {
            try
            {
                var onsite = await _onsiteRepo.GetOnSite();
                return Ok(new
                {
                    Success = true,
                    Message = "all onsite returned.",
                    onsite
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
        [HttpGet("{On_no}", Name = "OnSiteByNo")]
        public async Task<IActionResult> GetOnSite(int On_no)
        {
            try
            {
                var onsite = await _onsiteRepo.GetOnSite(On_no);
                if (onsite == null)
                    return NotFound();
                return Ok(new
                {
                    Success = true,
                    Message = "OnSite fetched.",
                    onsite
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany(OnSiteForCreationDto onsite)
        {
            try
            {
                var createdOnSite = await _onsiteRepo.CreateOnSite(onsite);
                return Ok(new
                {
                    Success = true,
                    Message = "OnSite created.",
                    createdOnSite
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPatch]
        [Route("{On_no}")]
        public async Task<IActionResult> UpdateOnSite(int On_no, OnSiteForUpdateDto onsite)
        {
            try
            {
                var dbOnSite = await _onsiteRepo.GetOnSite(On_no);
                if (dbOnSite == null)
                    return NotFound();
                await _onsiteRepo.UpdateOnSite(On_no, onsite);
                return Ok(new
                {
                    Success = true,
                    Message = "OnSite updated."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{On_no}")]
        public async Task<IActionResult> DeleteOnSite(int On_no)
        {
            try
            {
                var dbOnSite = await _onsiteRepo.GetOnSite(On_no);
                if (dbOnSite == null)
                    return NotFound();
                await _onsiteRepo.DeleteOnSite(On_no);
                return Ok(new
                {
                    Success = true,
                    Message = "OnSite deleted."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
